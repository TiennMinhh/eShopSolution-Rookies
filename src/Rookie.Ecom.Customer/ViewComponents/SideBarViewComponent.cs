using Microsoft.AspNetCore.Mvc;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.ViewComponents
{
    public class SideBarViewComponent:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public SideBarViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listCategory =  (List<CategoryDto>)_categoryService.GetAllAsync().Result;
            return View(listCategory);
        }
    }
}
