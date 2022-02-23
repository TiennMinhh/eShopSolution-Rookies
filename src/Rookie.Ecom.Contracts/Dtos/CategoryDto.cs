using System;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public string Desc { get; set; }
        public Guid? ParentId { get; set; }
        public int Status { get; set; }
    }
}
