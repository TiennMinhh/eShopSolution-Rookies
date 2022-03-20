using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System.Collections.Generic;

namespace Rookie.Ecom.Customer.Pages
{
    public class InvoiceManagementModel : PageModel
    {

        private IOrderService _orderService;
        private IUserService _userService;

        public List<OrderDto> orders { get; set; }
        public InvoiceManagementModel(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }
        public IActionResult OnGet()
        {
            string username = HttpContext.Session.GetString("username");
            if (username == null)
            {
                return RedirectToPage("Login");
            }
            else
            {
                var account = _userService.GetByUserNameAsync(username).Result;
                orders = (List<OrderDto>)_orderService.GetByUserAsync(account.Id).Result;
                return Page();
            }
        }
    }
}

