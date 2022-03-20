using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Rookie.Ecom.Customer.Pages
{
    public class WelcomeModel : PageModel
    {
        public string Username { get; set; }
        public IActionResult OnGet()
        {
            string username = HttpContext.Session.GetString("username");
            if(username == null)
            {
                return RedirectToPage("login");
            }
            else
            {
                Username = username;
                return Page();
            }
        }
    }
}
