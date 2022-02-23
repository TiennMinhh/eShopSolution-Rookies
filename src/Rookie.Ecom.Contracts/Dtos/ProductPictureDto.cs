using System;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class ProductPictureDto : BaseDto
    {
        public string PictureUrl { get; set; }
        public string Title { get; set; }
        public Boolean IsDefault { get; set; }
        public int SortOrder { get; set; }
        public Guid? ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}
