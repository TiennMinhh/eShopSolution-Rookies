using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Admin.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateAsync([FromBody] OrderDto orderDto)
        {
            Ensure.Any.IsNotNull(orderDto, nameof(orderDto));
            var asset = await _orderService.AddAsync(orderDto);
            return Created(Endpoints.Order, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] OrderDto orderDto)
        {
            Ensure.Any.IsNotNull(orderDto, nameof(orderDto));
            await _orderService.UpdateAsync(orderDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var orderDto = await _orderService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(orderDto, nameof(orderDto));
            await _orderService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> GetByIdAsync(Guid id)
            => await _orderService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<OrderDto>> GetAsync()
            => await _orderService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<OrderDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _orderService.PagedQueryAsync(name, page, limit);
    }
}
