using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface ISlideService
    {
        Task<IEnumerable<SlideDto>> GetAllAsync();

        Task<PagedResponseModel<SlideDto>> PagedQueryAsync(string name, int page, int limit);

        Task<SlideDto> GetByIdAsync(Guid id);

        Task<SlideDto> GetByNameAsync(string name);

        Task<SlideDto> AddAsync(SlideDto slideDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(SlideDto slideDto);
    }
}
