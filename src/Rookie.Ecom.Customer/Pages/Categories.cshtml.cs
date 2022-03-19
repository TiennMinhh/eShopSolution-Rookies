using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;

namespace Rookie.Ecom.Customer.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly ILogger<CategoryModel> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        [BindProperty(Name = "id", SupportsGet = true)]
        public Guid Id { get; set; }
        public CategoryDto category { get; set; }
        public IEnumerable<ProductDto> products { get; set; }

        public CategoryModel(ILogger<CategoryModel> logger, ICategoryService categoryService,
            IProductService productService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _productService = productService;
        }

        public void OnGet()
        {
            category = _categoryService.GetByIdAsync(Id).Result;
            products = _productService.GetByCategory(Id).Result;
        }
    }
}
