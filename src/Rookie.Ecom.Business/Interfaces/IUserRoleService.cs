using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IUserRoleService
    {
        Task<IEnumerable<UserRoleDto>> GetAllAsync();

        Task<PagedResponseModel<UserRoleDto>> PagedQueryAsync(string name, int page, int limit);

        Task<UserRoleDto> GetByIdAsync(Guid id);

        Task<UserRoleDto> GetByNameAsync(string name);

        Task<UserRoleDto> AddAsync(UserRoleDto roleDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(UserRoleDto roleDto);
    }
}
