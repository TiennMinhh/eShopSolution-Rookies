using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor.Entities;
using Rookie.Ecom.DataAccessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IBaseRepository<UserRole> _baseRepository;
        private readonly IMapper _mapper;

        public UserRoleService(IBaseRepository<UserRole> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<UserRoleDto> AddAsync(UserRoleDto roleDto)
        {
            var role = _mapper.Map<UserRole>(roleDto);
            var item = await _baseRepository.AddAsync(role);
            return _mapper.Map<UserRoleDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(UserRoleDto roleDto)
        {
            var role = _mapper.Map<UserRole>(roleDto);
            await _baseRepository.UpdateAsync(role);
        }

        public async Task<IEnumerable<UserRoleDto>> GetAllAsync()
        {
            var categories = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<UserRoleDto>>(categories);
        }

        public async Task<UserRoleDto> GetByIdAsync(Guid id)
        {
            // map roles and users: collection (roleid, userid)
            // upsert: delete, update, insert
            // input vs db
            // input-y vs db-no => insert
            // input-n vs db-yes => delete
            // input-y vs db-y => update
            // unique, distinct, no-duplicate
            var role = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<UserRoleDto>(role);
        }

        public async Task<UserRoleDto> GetByNameAsync(string name)
        {
            var role = await _baseRepository.GetByAsync(x => x.Role.Name.Equals(name));
            return _mapper.Map<UserRoleDto>(role);
        }

        public async Task<PagedResponseModel<UserRoleDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.Role.Name.Contains(name));

            query = query.OrderBy(x => x.Role.Name);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<UserRoleDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<UserRoleDto>>(assets.Items)
            };
        }

    }
}
