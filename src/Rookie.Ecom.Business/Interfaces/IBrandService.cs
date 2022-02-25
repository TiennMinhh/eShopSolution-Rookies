using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDto>> GetAllAsync();

        Task<PagedResponseModel<BrandDto>> PagedQueryAsync(string name, int page, int limit);

        Task<BrandDto> GetByIdAsync(Guid id);

        Task<BrandDto> GetByNameAsync(string name);

        Task<BrandDto> AddAsync(BrandDto brandDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(BrandDto brandDto);
    }
}
