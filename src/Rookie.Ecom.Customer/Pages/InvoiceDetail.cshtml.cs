using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;

namespace Rookie.Ecom.Customer.Pages
{
    public class InvoiceDetailModel : PageModel
    {

        private IOrderService _orderService;
        private IOrderItemService _orderItemService;
        private IUserService _userService;
        private IAddressService _addressService;

        public OrderDto order { get; set; }
        public IEnumerable<OrderItemDto> orderItems { get; set; }
        public IEnumerable<AddressDto> addresses { get; set; }
        [BindProperty(Name = "id", SupportsGet = true)]
        public Guid Id { get; set; }
        public InvoiceDetailModel(IOrderService orderService, IUserService userService, IOrderItemService orderItemService, IAddressService addressService)
        {
            _orderService = orderService;
            _userService = userService;
            _orderItemService = orderItemService;
            _addressService = addressService;
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
                order = _orderService.GetByIdAsync(Id).Result;
                orderItems = _orderItemService.GetByOrderUserAsync(order.Id).Result;
                return Page();
            }
        }
    }
}

