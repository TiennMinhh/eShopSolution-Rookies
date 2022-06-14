using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressDto>> GetAllAsync();

        Task<PagedResponseModel<AddressDto>> PagedQueryAsync(string name, int page, int limit);

        Task<AddressDto> GetByIdAsync(Guid id);
        Task<AddressDto> GetByUserAsync(Guid id);

        Task<AddressDto> GetByNameAsync(string name);

        Task<AddressDto> AddAsync(AddressDto addressDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(AddressDto addressDto);
    }
}
