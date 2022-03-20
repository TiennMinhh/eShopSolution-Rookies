using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor.Data;
using Rookie.Ecom.DataAccessor.Entities;
using Rookie.Ecom.DataAccessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IBaseRepository<OrderItem> _baseRepository;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderItemService(IBaseRepository<OrderItem> baseRepository, IMapper mapper, ApplicationDbContext dbContext)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<OrderItemDto> AddAsync(OrderItemDto orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);
            var item = await _baseRepository.AddAsync(orderItem);
            return _mapper.Map<OrderItemDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(OrderItemDto orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);
            await _baseRepository.UpdateAsync(orderItem);
        }

        public async Task<IEnumerable<OrderItemDto>> GetAllAsync()
        {
            var categories = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<OrderItemDto>>(categories);
        }

        public async Task<OrderItemDto> GetByIdAsync(Guid id)
        {
            // map roles and users: collection (roleid, userid)
            // upsert: delete, update, insert
            // input vs db
            // input-y vs db-no => insert
            // input-n vs db-yes => delete
            // input-y vs db-y => update
            // unique, distinct, no-duplicate
            var orderItem = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<OrderItemDto>(orderItem);
        }

        public async Task<OrderItemDto> GetByNameAsync(Guid orderId)
        {
            var orderItem = await _baseRepository.GetByAsync(x => x.OrderId == orderId);
            return _mapper.Map<OrderItemDto>(orderItem);
        }

        public async Task<PagedResponseModel<OrderItemDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.Product.Name.Contains(name));

            query = query.OrderBy(x => x.Product.Name);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<OrderItemDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<OrderItemDto>>(assets.Items)
            };
        }

        public async Task<IEnumerable<OrderItemDto>> GetByOrderUserAsync(Guid orderId)
        {
            var items = await _baseRepository.Entities
                .Include(x => x.Product)
                .Include(x => x.Product.ProductPictures)
                .Where(x => x.OrderId == orderId).ToListAsync();
            return _mapper.Map<List<OrderItemDto>>(items);
        }

        public OrderItemDto Add(OrderItemDto orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);
            var item = _dbContext.OrderItems.Add(orderItem).Entity;
            _dbContext.SaveChanges();
            return _mapper.Map<OrderItemDto>(item);
        }
    }
}
