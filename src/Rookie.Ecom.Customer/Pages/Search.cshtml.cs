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
    public class SearchModel : PageModel
    {
        private readonly ILogger<SearchModel> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IProductPictureService _productPictureService;

        [BindProperty(Name = "categoryId", SupportsGet = true)]
        public string categoryId { get; set; }

        [BindProperty(Name = "keyword", SupportsGet = true)]
        public string keyword { get; set; }
        public IEnumerable<ProductDto> products { get; set; }

        public SearchModel(ILogger<SearchModel> logger, IProductService productService,
            ICategoryService categoryService, IProductPictureService productPictureService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
            _productPictureService = productPictureService;

        }
        public IEnumerable<CategoryDto> listCategory => _categoryService.GetAllAsync().Result;
        public IEnumerable<ProductPictureDto> pictures => _productPictureService.GetAllAsync().Result;


        public void OnGet()
        {
			if (categoryId.Equals("-1"))
			{
                products = _productService.SearchByNameAsync(keyword).Result;
			}
			else
			{
                products = _productService.GetByCategory(new Guid(categoryId)).Result.Where(x => x.Name.Contains(keyword));
			}
        }
    }
}
