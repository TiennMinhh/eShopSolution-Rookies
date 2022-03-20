using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IProductFeedBackService
    {
        Task<IEnumerable<ProductFeedBackDto>> GetAllAsync();

        Task<PagedResponseModel<ProductFeedBackDto>> PagedQueryAsync(string name, int page, int limit);

        Task<ProductFeedBackDto> GetByIdAsync(Guid id);

        Task<ProductFeedBackDto> GetByNameAsync(string name);

        Task<ProductFeedBackDto> AddAsync(ProductFeedBackDto productFeedBackDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(ProductFeedBackDto productFeedBackDto);
        Task<IEnumerable<ProductFeedBackDto>> GetByProductAsync(Guid productId);

    }
}
