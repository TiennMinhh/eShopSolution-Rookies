using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages.ViewComponents
{
    [ViewComponent(Name = "CartLeft")]
    public class CartLeftViewComponent : ViewComponent
    {

        private ICartService _cartService;

        public CartLeftViewComponent(ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessionCart = HttpContext.Session.GetString("cart");
            ViewBag.subTotal = 0;
            ViewBag.countItem = 0;
            if (sessionCart != null)
            {
                List<CartDto> carts = JsonConvert.DeserializeObject<List<CartDto>>(sessionCart);
                ViewBag.countItem = carts.Count();
                ViewBag.subTotal = carts.Sum(x => x.Price * x.Quantity);
            }
            return View("Index");
        }
    }
}
