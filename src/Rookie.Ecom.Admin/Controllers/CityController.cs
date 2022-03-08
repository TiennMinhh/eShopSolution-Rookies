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
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost]
        public async Task<ActionResult<CityDto>> CreateAsync([FromBody] CityDto cityDto)
        {
            Ensure.Any.IsNotNull(cityDto, nameof(cityDto));
            var asset = await _cityService.AddAsync(cityDto);
            return Created(Endpoints.City, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] CityDto cityDto)
        {
            Ensure.Any.IsNotNull(cityDto, nameof(cityDto));
            await _cityService.UpdateAsync(cityDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var cityDto = await _cityService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(cityDto, nameof(cityDto));
            await _cityService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<CityDto> GetByIdAsync(Guid id)
            => await _cityService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<CityDto>> GetAsync()
            => await _cityService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<CityDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _cityService.PagedQueryAsync(name, page, limit);
    }
}
