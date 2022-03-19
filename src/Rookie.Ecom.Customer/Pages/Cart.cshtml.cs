using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IEnumerable<CartDto> carts { get; set; }
        public IEnumerable<ProductPictureDto> pictures { get; set; }
        public decimal subTotal { get; set; }

        public CartModel(IProductService productService, ICartService cartService, IProductPictureService productPictureService)
		{
            _productService = productService;
            _cartService = cartService;
            _productPictureService = productPictureService;
		}

        public void OnGet()
        {
            carts = _cartService.GetByUser(new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3")).Result.ToList();
            subTotal = 0;
            if(carts != null)
			{
                subTotal = carts.Sum(x => x.Price * x.Quantity);
            }
            pictures = _productPictureService.GetAllAsync().Result;
        }

        public IActionResult OnPost(int[] quantity)
        {
            carts = _cartService.GetByUser(new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3")).Result.ToList();
            for (int i = 0; i< quantity.Length; i++)
            {
                carts.ToList()[i].Quantity = quantity[i];
                _cartService.UpdateAsync(carts.ToList()[i]);
            }
            return RedirectToPage("Cart");
        }

            public IActionResult OnGetRemove(Guid id)
        {
            var obj = _cartService.IsExist(id, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3")).Result;
            if (obj != null)
            {
                _cartService.DeleteAsync(obj.Id);
            }
            return RedirectToPage("Cart");


        }

        public IActionResult OnGetCheckout()
        {
            String username = HttpContext.Session.GetString("username");
            if(username == null)
            {
                return RedirectToPage("Login");
            }
            else
            {
                return RedirectToPage("Thanks");

            }
        }


            public IActionResult OnGetBuyNow(Guid id)
        {
            ProductDto product = _productService.GetByIdAsync(id).Result;
            if (product != null)
            {
				try
				{                    
                    var obj = _cartService.IsExist(product.Id, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3")).Result;
                    CartDto cart = new CartDto();
                    cart.ProductId = product.Id;                    
                    cart.Price = product.Price;
                    cart.UserId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3");
                    if (obj != null)
                    {
                        cart.Id = obj.Id;
                        var quantity = 1 + obj.Quantity;
                        cart.Quantity = quantity;
                        _cartService.UpdateAsync(cart);
                    }
                    else
                    {
                        cart.Quantity = 1;
                        _cartService.AddAsync(cart);
                    }
                                        
                }
                catch(Exception e)
				{
                    Console.WriteLine(e.Message);
				}

            }
            return RedirectToPage("Cart");
        }
    }
}
