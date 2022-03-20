using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages.ViewComponents
{
    [ViewComponent(Name = "MenuTop")]
    public class MenuTopViewComponent : ViewComponent
    {

        //public string usernameSession { get; set; }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.usernameSession = HttpContext.Session.GetString("username");
            return View("Index");
        }
    }
}
