using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;

namespace Rookie.Ecom.Customer.Pages
{
    public class ProfileModel : PageModel
    {
        private IUserService _userService;

        [BindProperty]
        public UserDto user { get; set; }

        public ProfileModel(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            string username = HttpContext.Session.GetString("username");
            if(username != null)
            {
                user = _userService.GetByUserNameAsync(username).Result;
                return Page();
            }
            else
            {
                return RedirectToPage("login");
            }
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(user.Password))
            {
                user.Password = _userService.GetByIdAsync(user.Id).Result.Password;
            }
            else
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            }
            user.Status = 1;
            var newUser = user;
            _userService.UpdateAsync(newUser);

            return RedirectToPage("Profile");

        }
    }
}
