using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;

namespace Rookie.Ecom.Customer.Pages
{
    public class LoginModel : PageModel
    {
        private IUserService _userService;
        private IUserRoleService _userRoleService;
        private const string CUSTOMER_ROLE_ID = "593887de-f117-44b5-a2f0-f2048d056bb9";

        [BindProperty]
        public string Msg { get; set; }

        public LoginModel(IUserService userService, IUserRoleService userRoleService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
        }
        public void OnGet()
        {
            Msg = "";
        }

        public IActionResult OnGetlogout()
        {
            HttpContext.Session.Remove("username");
            return Page();
        }

        public IActionResult OnPost(string username, string password)
        {
            if (!ModelState.IsValid)
                return Page();
            if(Check(username, password) != null)
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToPage("Welcome");
            }
            else
            {
                Msg = "Invalid";
                return Page();
            }
            
        }
        private UserDto Check(string username, string password)
        {
            var account = _userService.GetByUserNameAsync(username).Result;
            if (account != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, account.Password))
                    return account;
            }
            return null;
        }
    }
}
