using System;
using System.Collections.Generic;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public string Desc { get; set; }
        public Guid? ParentId { get; set; }
        public CategoryDto ParentCategory { get; set; }
        public int Status { get; set; }

        public ICollection<ProductDto> products { get; set; }

        public IEnumerable<CategoryDto> Children { get; set; }
    }
}
