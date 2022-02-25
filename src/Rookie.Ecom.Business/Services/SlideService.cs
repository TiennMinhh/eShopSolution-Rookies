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
    public class SlideService : ISlideService
    {
        private readonly IBaseRepository<Slide> _baseRepository;
        private readonly IMapper _mapper;

        public SlideService(IBaseRepository<Slide> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<SlideDto> AddAsync(SlideDto slideDto)
        {
            var slide = _mapper.Map<Slide>(slideDto);
            var item = await _baseRepository.AddAsync(slide);
            return _mapper.Map<SlideDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(SlideDto slideDto)
        {
            var slide = _mapper.Map<Slide>(slideDto);
            await _baseRepository.UpdateAsync(slide);
        }

        public async Task<IEnumerable<SlideDto>> GetAllAsync()
        {
            var categories = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<SlideDto>>(categories);
        }

        public async Task<SlideDto> GetByIdAsync(Guid id)
        {
            // map roles and users: collection (roleid, userid)
            // upsert: delete, update, insert
            // input vs db
            // input-y vs db-no => insert
            // input-n vs db-yes => delete
            // input-y vs db-y => update
            // unique, distinct, no-duplicate
            var slide = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<SlideDto>(slide);
        }

        public async Task<SlideDto> GetByNameAsync(string name)
        {
            var slide = await _baseRepository.GetByAsync(x => x.Name == name);
            return _mapper.Map<SlideDto>(slide);
        }

        public async Task<PagedResponseModel<SlideDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.Name.Contains(name));

            query = query.OrderBy(x => x.Name);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<SlideDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<SlideDto>>(assets.Items)
            };
        }

    }
}
