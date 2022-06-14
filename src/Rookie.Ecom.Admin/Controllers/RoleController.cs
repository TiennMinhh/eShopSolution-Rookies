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
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<ActionResult<RoleDto>> CreateAsync([FromBody] RoleDto roleDto)
        {
            Ensure.Any.IsNotNull(roleDto, nameof(roleDto));
            var asset = await _roleService.AddAsync(roleDto);
            return Created(Endpoints.Role, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] RoleDto roleDto)
        {
            Ensure.Any.IsNotNull(roleDto, nameof(roleDto));
            await _roleService.UpdateAsync(roleDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var roleDto = await _roleService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(roleDto, nameof(roleDto));
            await _roleService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<RoleDto> GetByIdAsync(Guid id)
            => await _roleService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<RoleDto>> GetAsync()
            => await _roleService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<RoleDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _roleService.PagedQueryAsync(name, page, limit);
    }
}
