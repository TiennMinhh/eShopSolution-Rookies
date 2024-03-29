﻿using System;
using System.Collections.Generic;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Detail { get; set; }

        public decimal Price { get; set; }

        public decimal? Cost { get; set; }

        public bool IsFeatured { get; set; }
        public bool IsHome { get; set; }

        public int Quantity { get; set; }
        public Guid BrandId { get; set; }
        public BrandDto Brand { get; set; }

        public Guid CategoryId { get; set; }

        public CategoryDto Category { get; set; }

        public ICollection<ProductPictureDto> ProductPictures { get; set; }
    }
}
