using Microsoft.AspNetCore.Mvc;
using Rookie.Ecom.Business.Interfaces;
using System;
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
            var carts = _cartService.GetByUser(new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3")).Result.ToList();
            ViewBag.subTotal = 0;
            if (carts != null)
            {
                ViewBag.countItem = carts.Count();
                ViewBag.subTotal = carts.Sum(x => x.Price * x.Quantity);
            }
            return View("Index");
        }
    }
}
