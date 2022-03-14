using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly ISlideService _slideService;
        private readonly IBrandService _brandService;

        public IndexModel(ILogger<IndexModel> logger, IProductService productService,
            ICategoryService categoryService, ISlideService slideService, IBrandService brandService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
            _slideService = slideService;
            _brandService = brandService;

        }
        public IEnumerable<CategoryDto> listCategory => _categoryService.GetAllAsync().Result;

        public IEnumerable<ProductDto> listProduct => _productService.GetAllAsync().Result;
        public IEnumerable<SlideDto> listSlide => _slideService.GetAllAsync().Result;
        public IEnumerable<ProductDto> listProductFeatured => _productService.GetByFeatured().Result;
        public IEnumerable<BrandDto> listBrand => _brandService.GetAllAsync().Result;


        public void OnGet()
        {

        }
    }
}
