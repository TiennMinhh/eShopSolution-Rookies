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
    public class CartService : ICartService
    {
        private readonly IBaseRepository<Cart> _baseRepository;
        private readonly IMapper _mapper;

        public CartService(IBaseRepository<Cart> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<CartDto> AddAsync(CartDto cartDto)
        {
            var cart = _mapper.Map<Cart>(cartDto);
            var item = await _baseRepository.AddAsync(cart);
            return _mapper.Map<CartDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(CartDto cartDto)
        {
            var cart = _mapper.Map<Cart>(cartDto);
            await _baseRepository.UpdateAsync(cart);
        }

        public async Task<IEnumerable<CartDto>> GetAllAsync()
        {
            var categories = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<CartDto>>(categories);
        }

        public async Task<CartDto> GetByIdAsync(Guid id)
        {
            // map roles and users: collection (roleid, userid)
            // upsert: delete, update, insert
            // input vs db
            // input-y vs db-no => insert
            // input-n vs db-yes => delete
            // input-y vs db-y => update
            // unique, distinct, no-duplicate
            var cart = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> GetByNameAsync(string name)
        {
            //var cart = await _baseRepository.GetByAsync(x => x.Name == name);
            var cart = await _baseRepository.GetAllAsync();
            return _mapper.Map<CartDto>(cart);
        }

        public async Task<PagedResponseModel<CartDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.Product.Name.Contains(name));

            query = query.OrderBy(x => x.Price);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<CartDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<CartDto>>(assets.Items)
            };
        }

		public async Task<CartDto> IsExist(Guid productId, Guid userId)
        {
            var carts = await _baseRepository.Entities
                .FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId);
            return _mapper.Map<CartDto>(carts);
        }

        public async Task<IEnumerable<CartDto>> GetByUser(Guid userId)
        {
            var carts = await _baseRepository.Entities
                .Include(x => x.Product)
                .Where(x => x.UserId == userId).ToListAsync();
            return _mapper.Map<IEnumerable<CartDto>>(carts);
        }
    }
}
