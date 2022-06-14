using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages.ViewComponents
{
    [ViewComponent(Name = "LatestProduct")]
    public class LatestProductViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index");
        }
    }
}
