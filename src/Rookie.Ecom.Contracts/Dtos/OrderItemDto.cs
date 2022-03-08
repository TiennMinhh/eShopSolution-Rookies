using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class OrderItemDto : BaseDto
    {
        public Guid OrderId { get; set; }
        public OrderDto Order { get; set; }
        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
