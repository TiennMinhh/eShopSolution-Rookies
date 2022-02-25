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
    public class SlideController : Controller
    {
        private readonly ISlideService _slideService;
        public SlideController(ISlideService slideService)
        {
            _slideService = slideService;
        }

        [HttpPost]
        public async Task<ActionResult<SlideDto>> CreateAsync([FromBody] SlideDto slideDto)
        {
            Ensure.Any.IsNotNull(slideDto, nameof(slideDto));
            var asset = await _slideService.AddAsync(slideDto);
            return Created(Endpoints.Slide, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] SlideDto slideDto)
        {
            Ensure.Any.IsNotNull(slideDto, nameof(slideDto));
            await _slideService.UpdateAsync(slideDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var slideDto = await _slideService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(slideDto, nameof(slideDto));
            await _slideService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<SlideDto> GetByIdAsync(Guid id)
            => await _slideService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<SlideDto>> GetAsync()
            => await _slideService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<SlideDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _slideService.PagedQueryAsync(name, page, limit);
    }
}
