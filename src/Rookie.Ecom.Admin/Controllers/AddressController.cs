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
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<ActionResult<AddressDto>> CreateAsync([FromBody] AddressDto addressDto)
        {
            Ensure.Any.IsNotNull(addressDto, nameof(addressDto));
            var asset = await _addressService.AddAsync(addressDto);
            return Created(Endpoints.Address, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] AddressDto addressDto)
        {
            Ensure.Any.IsNotNull(addressDto, nameof(addressDto));
            await _addressService.UpdateAsync(addressDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var addressDto = await _addressService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(addressDto, nameof(addressDto));
            await _addressService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<AddressDto> GetByIdAsync(Guid id)
            => await _addressService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<AddressDto>> GetAsync()
            => await _addressService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<AddressDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _addressService.PagedQueryAsync(name, page, limit);
    }
}
