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
    public class ProductFeedBackService : IProductFeedBackService
    {
        private readonly IBaseRepository<ProductFeedBack> _baseRepository;
        private readonly IMapper _mapper;

        public ProductFeedBackService(IBaseRepository<ProductFeedBack> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ProductFeedBackDto> AddAsync(ProductFeedBackDto productFeedBackDto)
        {
            var productFeedBack = _mapper.Map<ProductFeedBack>(productFeedBackDto);
            var item = await _baseRepository.AddAsync(productFeedBack);
            return _mapper.Map<ProductFeedBackDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(ProductFeedBackDto productFeedBackDto)
        {
            var productFeedBack = _mapper.Map<ProductFeedBack>(productFeedBackDto);
            await _baseRepository.UpdateAsync(productFeedBack);
        }

        public async Task<IEnumerable<ProductFeedBackDto>> GetAllAsync()
        {
            var categories = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<ProductFeedBackDto>>(categories);
        }

        public async Task<ProductFeedBackDto> GetByIdAsync(Guid id)
        {
            // map roles and users: collection (roleid, userid)
            // upsert: delete, update, insert
            // input vs db
            // input-y vs db-no => insert
            // input-n vs db-yes => delete
            // input-y vs db-y => update
            // unique, distinct, no-duplicate
            var productFeedBack = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<ProductFeedBackDto>(productFeedBack);
        }

        public async Task<ProductFeedBackDto> GetByNameAsync(string name)
        {
            var productFeedBack = await _baseRepository.GetByAsync(x => x.User.Name == name);
            return _mapper.Map<ProductFeedBackDto>(productFeedBack);
        }

        public async Task<PagedResponseModel<ProductFeedBackDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.User.Name.Contains(name));

            query = query.OrderBy(x => x.CreatedDate);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<ProductFeedBackDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<ProductFeedBackDto>>(assets.Items)
            };
        }

        public async Task<IEnumerable<ProductFeedBackDto>> GetByProductAsync(Guid productId)
        {
            var productFeedBacks = await _baseRepository.Entities.Include(x => x.User).Where(x => x.ProductId == productId).OrderByDescending(x => x.CreatedDate).ToListAsync();
            return _mapper.Map<IEnumerable<ProductFeedBackDto>>(productFeedBacks);
        }
    }
}
