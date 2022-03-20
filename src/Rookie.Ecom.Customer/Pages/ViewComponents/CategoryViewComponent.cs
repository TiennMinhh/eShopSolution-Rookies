using Microsoft.AspNetCore.Mvc;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages.ViewComponents
{
    [ViewComponent(Name = "Category")]
    public class CategoryViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryViewComponent(ICategoryService categoryService)
		{
            _categoryService = categoryService;
		}
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var allCategories = _categoryService.GetAllAsync().Result.ToList();
            ViewBag.categories = CreateVM(null, allCategories);
            return View("Index");
        }

        public IEnumerable<CategoryDto> CreateVM(Guid? parentid, List<CategoryDto> source)
        {
            
            return from cate in source
                   where cate.ParentId == parentid
                   select new CategoryDto()
                   {
                       Id = cate.Id,
                       Name = cate.Name,
                       SortOrder = cate.SortOrder,
                       Desc = cate.Desc,
                       Status = cate.Status,
                      Children = CreateVM(cate.Id, source)
                   };
        }
    }
}
