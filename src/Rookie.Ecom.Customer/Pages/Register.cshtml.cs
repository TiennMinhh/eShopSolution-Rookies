using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages
{
    public class RegisterModel : PageModel
    {

        private IUserService _userService;
        private IUserRoleService _userRoleService;
        private IAddressService _addressService;
        private const string CUSTOMER_ROLE_ID = "593887de-f117-44b5-a2f0-f2048d056bb9";

        [BindProperty]
        public UserDto user { get; set; }

        public RegisterModel(IUserService userService, IUserRoleService userRoleService, IAddressService addressService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _addressService = addressService;
        }
        public void OnGet()
        {
            user = new UserDto();
        }

        public IActionResult OnPost(string address, string phone)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Status = 1;
            user  = _userService.AddAsync(user).Result;
            UserRoleDto userRole = new UserRoleDto
            {
                UserId = user.Id,
                RoleId = Guid.Parse("593887de-f117-44b5-a2f0-f2048d056bb9"),
                Status = true

            };
            _userRoleService.AddAsync(userRole);
            AddressDto addressDto = new AddressDto
            {
                AddressLine = address,
                CreatorId = user.Id,
                Phone = phone,
                UserId = user.Id,
                Pubished = true,
                Status = 1,
                CreatedDate = DateTime.Now
            };
            _addressService.AddAsync(addressDto);

            return RedirectToPage("Login");
        }
    }
}
