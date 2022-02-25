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
    public class OrderItemController : Controller
    {
        private readonly IOrderItemService _orderItemService;
        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderItemDto>> CreateAsync([FromBody] OrderItemDto orderItemDto)
        {
            Ensure.Any.IsNotNull(orderItemDto, nameof(orderItemDto));
            var asset = await _orderItemService.AddAsync(orderItemDto);
            return Created(Endpoints.OrderItem, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] OrderItemDto orderItemDto)
        {
            Ensure.Any.IsNotNull(orderItemDto, nameof(orderItemDto));
            await _orderItemService.UpdateAsync(orderItemDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var orderItemDto = await _orderItemService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(orderItemDto, nameof(orderItemDto));
            await _orderItemService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<OrderItemDto> GetByIdAsync(Guid id)
            => await _orderItemService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<OrderItemDto>> GetAsync()
            => await _orderItemService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<OrderItemDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _orderItemService.PagedQueryAsync(name, page, limit);
    }
}
