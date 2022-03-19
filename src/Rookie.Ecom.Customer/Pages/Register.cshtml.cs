using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System;

namespace Rookie.Ecom.Customer.Pages
{
    public class RegisterModel : PageModel
    {

        private IUserService _userService;
        private IUserRoleService _userRoleService;
        private const string CUSTOMER_ROLE_ID = "593887de-f117-44b5-a2f0-f2048d056bb9";

        [BindProperty]
        public UserDto user { get; set; }

        public RegisterModel(IUserService userService, IUserRoleService userRoleService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
        }
        public void OnGet()
        {
            user = new UserDto();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Status = 1;
            _userService.AddAsync(user);
            UserRoleDto userRole = new UserRoleDto
            {
                UserId = user.Id,
                RoleId = Guid.Parse("593887de-f117-44b5-a2f0-f2048d056bb9"),
                Status = true

            };
            _userRoleService.AddAsync(userRole);

            return RedirectToPage("Login");
        }
    }
}
