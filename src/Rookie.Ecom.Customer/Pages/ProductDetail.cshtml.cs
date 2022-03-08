using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Rookie.Ecom.Customer.Pages
{
    public class ProductDetailModel : PageModel
    {
        private readonly ILogger<ProductDetailModel> _logger;
        public ProductDetailModel(ILogger<ProductDetailModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
