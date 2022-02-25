using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();

        Task<PagedResponseModel<OrderDto>> PagedQueryAsync(string name, int page, int limit);

        Task<OrderDto> GetByIdAsync(Guid id);

        Task<OrderDto> GetByNameAsync(string name);

        Task<OrderDto> AddAsync(OrderDto orderDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(OrderDto orderDto);
    }
}
