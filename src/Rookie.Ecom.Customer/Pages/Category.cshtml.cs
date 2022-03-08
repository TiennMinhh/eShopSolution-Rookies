using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System.Collections.Generic;

namespace Rookie.Ecom.Customer.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly ILogger<CategoryModel> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryModel(ILogger<CategoryModel> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public IEnumerable<CategoryDto> listcategory => _categoryService.GetAllAsync().Result;

        public void OnGet()
        {
        }
    }
}
