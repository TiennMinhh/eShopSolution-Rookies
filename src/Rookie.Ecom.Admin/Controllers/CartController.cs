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
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<ActionResult<CartDto>> CreateAsync([FromBody] CartDto cartDto)
        {
            Ensure.Any.IsNotNull(cartDto, nameof(cartDto));
            var asset = await _cartService.AddAsync(cartDto);
            return Created(Endpoints.Cart, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] CartDto cartDto)
        {
            Ensure.Any.IsNotNull(cartDto, nameof(cartDto));
            await _cartService.UpdateAsync(cartDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var cartDto = await _cartService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(cartDto, nameof(cartDto));
            await _cartService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<CartDto> GetByIdAsync(Guid id)
            => await _cartService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<CartDto>> GetAsync()
            => await _cartService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<CartDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _cartService.PagedQueryAsync(name, page, limit);
    }
}
