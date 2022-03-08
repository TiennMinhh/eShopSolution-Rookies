using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IProductPictureService
    {
        Task<IEnumerable<ProductPictureDto>> GetAllAsync();

        Task<PagedResponseModel<ProductPictureDto>> PagedQueryAsync(string name, int page, int limit);

        Task<ProductPictureDto> GetByIdAsync(Guid id);

        Task<ProductPictureDto> GetByNameAsync(string name);

        Task<ProductPictureDto> AddAsync(ProductPictureDto productPictureDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(ProductPictureDto productPictureDto);
    }
}
