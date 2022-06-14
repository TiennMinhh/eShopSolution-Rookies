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
    public class ProductFeedBackController : Controller
    {
        private readonly IProductFeedBackService _productFeedBackService;
        public ProductFeedBackController(IProductFeedBackService productFeedBackService)
        {
            _productFeedBackService = productFeedBackService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductFeedBackDto>> CreateAsync([FromBody] ProductFeedBackDto productFeedBackDto)
        {
            Ensure.Any.IsNotNull(productFeedBackDto, nameof(productFeedBackDto));
            var asset = await _productFeedBackService.AddAsync(productFeedBackDto);
            return Created(Endpoints.ProductFeedBack, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProductFeedBackDto productFeedBackDto)
        {
            Ensure.Any.IsNotNull(productFeedBackDto, nameof(productFeedBackDto));
            await _productFeedBackService.UpdateAsync(productFeedBackDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var productFeedBackDto = await _productFeedBackService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(productFeedBackDto, nameof(productFeedBackDto));
            await _productFeedBackService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ProductFeedBackDto> GetByIdAsync(Guid id)
            => await _productFeedBackService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<ProductFeedBackDto>> GetAsync()
            => await _productFeedBackService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<ProductFeedBackDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _productFeedBackService.PagedQueryAsync(name, page, limit);
    }
}
