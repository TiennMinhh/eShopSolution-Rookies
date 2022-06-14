using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemDto>> GetAllAsync();

        Task<PagedResponseModel<OrderItemDto>> PagedQueryAsync(string name, int page, int limit);

        Task<OrderItemDto> GetByIdAsync(Guid id);

        Task<OrderItemDto> GetByNameAsync(Guid userId);

        Task<OrderItemDto> AddAsync(OrderItemDto orderItemDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(OrderItemDto orderItemDto);
        Task<IEnumerable<OrderItemDto>> GetByOrderUserAsync(Guid orderId);

        OrderItemDto Add(OrderItemDto orderItemDto);

    }
}
