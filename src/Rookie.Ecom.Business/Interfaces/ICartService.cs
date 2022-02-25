using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<CartDto>> GetAllAsync();

        Task<PagedResponseModel<CartDto>> PagedQueryAsync(string name, int page, int limit);

        Task<CartDto> GetByIdAsync(Guid id);

        Task<CartDto> GetByNameAsync(string name);

        Task<CartDto> AddAsync(CartDto cartDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(CartDto cartDto);
    }
}
