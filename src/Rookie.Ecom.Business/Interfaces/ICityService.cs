using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetAllAsync();

        Task<PagedResponseModel<CityDto>> PagedQueryAsync(string name, int page, int limit);

        Task<CityDto> GetByIdAsync(Guid id);

        Task<CityDto> GetByNameAsync(string name);

        Task<CityDto> AddAsync(CityDto cityDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(CityDto cityDto);
    }
}
