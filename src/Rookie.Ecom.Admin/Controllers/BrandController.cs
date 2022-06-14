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
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        public async Task<ActionResult<BrandDto>> CreateAsync([FromBody] BrandDto brandDto)
        {
            Ensure.Any.IsNotNull(brandDto, nameof(brandDto));
            var asset = await _brandService.AddAsync(brandDto);
            return Created(Endpoints.Brand, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] BrandDto brandDto)
        {
            Ensure.Any.IsNotNull(brandDto, nameof(brandDto));
            await _brandService.UpdateAsync(brandDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var brandDto = await _brandService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(brandDto, nameof(brandDto));
            await _brandService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<BrandDto> GetByIdAsync(Guid id)
            => await _brandService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<BrandDto>> GetAsync()
            => await _brandService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<BrandDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _brandService.PagedQueryAsync(name, page, limit);
    }
}
