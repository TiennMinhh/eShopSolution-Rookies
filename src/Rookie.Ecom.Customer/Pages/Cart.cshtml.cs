using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rookie.Ecom.Customer.Pages
{
    public class CartModel : PageModel
    {

        private IProductService _productService;
        private ICartService _cartService;
        private IProductPictureService _productPictureService;
        private IUserService _userService;
        private IOrderService _orderService;
        private IOrderItemService _orderItemService;
        private IAddressService _addressService;

        public IEnumerable<CartDto> carts { get; set; }
        public IEnumerable<ProductPictureDto> pictures { get; set; }
        public decimal subTotal { get; set; }
        public CartModel(IProductService productService, ICartService cartService, IProductPictureService productPictureService, 
            IUserService userService, IOrderService orderService, IOrderItemService orderItemService, IAddressService addressService)
        {
            _productService = productService;
            _cartService = cartService;
            _productPictureService = productPictureService;
            _userService = userService;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _addressService = addressService;
        }

        public void OnGet()
        {
            string sessionCart = HttpContext.Session.GetString("cart");
            subTotal = 0;
            if (sessionCart != null)
            {
                carts = JsonConvert.DeserializeObject<List<CartDto>>(sessionCart);
                subTotal = carts.Sum(x => x.Price * x.Quantity);
            }
        }

        public IActionResult OnPost(int[] quantity)
        {
            List<CartDto> items = JsonConvert.DeserializeObject<List<CartDto>>
                (HttpContext.Session.GetString("cart"));
            for (int i = 0; i < quantity.Length; i++)
            {
                items[i].Quantity = quantity[i];
            }
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(items));
            return RedirectToPage("Cart");
        }

        public IActionResult OnGetRemove(Guid id)
        {
            List<CartDto> items = JsonConvert.DeserializeObject<List<CartDto>>
                (HttpContext.Session.GetString("cart"));
            int index = exists(id, items);
            items.RemoveAt(index);
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(items));
            return RedirectToPage("Cart");
        }

        public IActionResult OnGetCheckout()
        {
            string username = HttpContext.Session.GetString("username");
            if (username == null)
            {
                return RedirectToPage("Login");
            }
            else
            {
                var account = _userService.GetByUserNameAsync(username).Result;
                var address = _addressService.GetByUserAsync(account.Id).Result;

                //add order
                var order = new OrderDto
                {
                    CreatedDate = DateTime.Now,
                    CreatorId = account.Id,
                    Pubished = true,
                    Status = 1,
                    UserId = account.Id,

                };
                if(address != null)
                {
                    order.Phone = address.Phone;
                    order.AddressLine = address.AddressLine;
                }
                order = _orderService.AddAsync(order).Result;

                //add order items
                List<CartDto> items = JsonConvert.DeserializeObject<List<CartDto>>
                (HttpContext.Session.GetString("cart"));
                if(items != null)
                {
                    foreach(var item in items)
                    {                        
                        _orderItemService.Add(new OrderItemDto
                        {
                            OrderId = order.Id,
                            ProductId = item.ProductId,
                            Price = item.Product.Price,
                            Quantity = item.Quantity,
                            CreatedDate = DateTime.Now,
                            Pubished = true
                        });
                    }
                }
                HttpContext.Session.Remove("cart");
                return RedirectToPage("Thanks");

            }
        }


        public IActionResult OnGetBuyNow(Guid id)
        {
            ProductDto product = _productService.GetByIdAsync(id).Result;
            ProductPictureDto photo = _productPictureService.GetByProductAsync(id).Result.FirstOrDefault(x => x.IsDefault);
            string photoname = photo == null ? "no-image.png" : photo.PictureUrl;
            if (product != null)
            {
                try
                {
                    string sessionCart = HttpContext.Session.GetString("cart");
                    var obj = _cartService.IsExist(product.Id, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3")).Result;
                    if (sessionCart == null)
                    {
                        List<CartDto> items = new List<CartDto>();
                        items.Add(new CartDto
                        {
                            Product = new ProductDto
                            {
                                Name = product.Name,
                                Price = product.Price,
                            },
                            ProductId = product.Id,
                            Price = product.Price,
                            Quantity = 1,
                            Photo = photoname

                        });
                        HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(items));
                    }
                    else
                    {
                        List<CartDto> items = JsonConvert.DeserializeObject<List<CartDto>>(sessionCart);
                        int index = exists(id, items);
                        if(index == -1)
                        {
                            items.Add(new CartDto
                            {
                                Product = new ProductDto
                                {
                                    Name = product.Name,
                                    Price = product.Price,
                                },
                                ProductId = product.Id,
                                Price = product.Price,
                                Quantity = 1,
                                Photo = photoname

                            });
                        }
                        else
                        {
                            items[index].Quantity++;
                        }
                        HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(items));
                    }                    

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return RedirectToPage("Cart");
        }

        private int exists(Guid id, List<CartDto> items)
        {
            for (var i = 0; i < items.Count; i++)
            {
                if(items[i].ProductId == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
