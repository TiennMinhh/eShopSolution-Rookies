using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllAsync();

        Task<PagedResponseModel<RoleDto>> PagedQueryAsync(string name, int page, int limit);

        Task<RoleDto> GetByIdAsync(Guid id);

        Task<RoleDto> GetByNameAsync(string name);

        Task<RoleDto> AddAsync(RoleDto roleDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(RoleDto roleDto);
    }
}
