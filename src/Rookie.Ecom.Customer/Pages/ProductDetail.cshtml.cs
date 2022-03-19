using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rookie.Ecom.Customer.Pages
{
    public class ProductDetailModel : PageModel
    {
        private readonly ILogger<ProductDetailModel> _logger;
        private readonly IProductService _productService;
        private readonly IProductPictureService _productPictureService;


        [BindProperty(Name = "id", SupportsGet = true)]
        public Guid Id { get; set; }
        public ProductDto product { get; set; }
        public IEnumerable<ProductPictureDto> pictures { get; set; }
        public IEnumerable<ProductDto> relatedProducts { get; set; }
        public string pictureName { get; set; }

        public ProductDetailModel(ILogger<ProductDetailModel> logger, IProductService productService,
            IProductPictureService productPictureService)
        {
            _logger = logger;
            _productService = productService;
            productPictureService = _productPictureService;
        }

        public void OnGet()
        {
            product = _productService.GetByIdAsync(Id).Result;
            //pictures = _productPictureService.GetByProductAsync(Id).Result;
            var picture = product.ProductPictures.SingleOrDefault(x => x.IsDefault);
            pictureName = picture == null ? "no-image.png" : picture.PictureUrl;
            relatedProducts = _productService.GetByCategory(product.CategoryId).Result;

        }
    }
}
