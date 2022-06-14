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
    public class ProductPictureController : Controller
    {
        private readonly IProductPictureService _productPictureService;
        public ProductPictureController(IProductPictureService productPictureService)
        {
            _productPictureService = productPictureService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductPictureDto>> CreateAsync([FromBody] ProductPictureDto productPictureDto)
        {
            Ensure.Any.IsNotNull(productPictureDto, nameof(productPictureDto));
            var asset = await _productPictureService.AddAsync(productPictureDto);
            return Created(Endpoints.ProductPicture, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProductPictureDto productPictureDto)
        {
            Ensure.Any.IsNotNull(productPictureDto, nameof(productPictureDto));
            await _productPictureService.UpdateAsync(productPictureDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var productPictureDto = await _productPictureService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(productPictureDto, nameof(productPictureDto));
            await _productPictureService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ProductPictureDto> GetByIdAsync(Guid id)
            => await _productPictureService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<ProductPictureDto>> GetAsync()
            => await _productPictureService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<ProductPictureDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _productPictureService.PagedQueryAsync(name, page, limit);
    }
}
