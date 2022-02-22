using System;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class ProductPictureDto : BaseDto
    {
        public string PictureUrl { get; set; }

        public string Title { get; set; }

        public Guid? ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}
