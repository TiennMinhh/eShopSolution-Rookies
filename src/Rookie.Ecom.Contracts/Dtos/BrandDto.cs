using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class BrandDto : BaseDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int Status { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}
