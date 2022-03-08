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
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateAsync([FromBody] UserDto userDto)
        {
            Ensure.Any.IsNotNull(userDto, nameof(userDto));
            var asset = await _userService.AddAsync(userDto);
            return Created(Endpoints.User, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UserDto userDto)
        {
            Ensure.Any.IsNotNull(userDto, nameof(userDto));
            await _userService.UpdateAsync(userDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var userDto = await _userService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(userDto, nameof(userDto));
            await _userService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<UserDto> GetByIdAsync(Guid id)
            => await _userService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAsync()
            => await _userService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<UserDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _userService.PagedQueryAsync(name, page, limit);
    }
}
