using Microsoft.AspNetCore.Http;
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
    public class ProductDetailModel : PageModel
    {
        private readonly ILogger<ProductDetailModel> _logger;
        private readonly IProductService _productService;
        private readonly IProductFeedBackService _productFeedbackService;
        private readonly IProductPictureService _productPictureService;
        private readonly IUserService _userService;


        [BindProperty(Name = "id", SupportsGet = true)]
        public Guid Id { get; set; }
        public ProductDto product { get; set; }
        public IEnumerable<ProductPictureDto> pictures { get; set; }
        public IEnumerable<ProductDto> relatedProducts { get; set; }
        public IEnumerable<ProductFeedBackDto> feedBacks { get; set; }
        public string pictureName { get; set; }


        public float ratingStar;
        public string usernameSession { get; set; }

        public ProductDetailModel(ILogger<ProductDetailModel> logger, IProductService productService,
            IProductPictureService productPictureService, IProductFeedBackService productFeedbackService, IUserService userService)
        {
            _logger = logger;
            _productService = productService;
            _productPictureService = productPictureService;
            _productFeedbackService = productFeedbackService;
            _userService = userService;
        }

        public void OnGet()
        {
            product = _productService.GetByIdAsync(Id).Result;
            //pictures = _productPictureService.GetByProductAsync(Id).Result;
            var picture = _productPictureService.GetAllAsync().Result.SingleOrDefault(x => x.IsDefault && x.ProductId == product.Id);
            pictureName = picture == null ? "no-image.png" : picture.PictureUrl;
            relatedProducts = _productService.GetByCategory(product.CategoryId).Result;
            usernameSession = usernameSession = HttpContext.Session.GetString("username");
            feedBacks = _productFeedbackService.GetByProductAsync(Id).Result;
            if (feedBacks.Count() != 0)
            {
                ratingStar = (float)feedBacks.Average(x => x.Rating);
            }

        }

        public async Task<IActionResult> OnPostRating(string comment, int rating, Guid ProductId)
        {

            var userId = _userService.GetByUserNameAsync(HttpContext.Session.GetString("username")).Result.Id;

            var feedBack = new ProductFeedBackDto
            {
                UserId = userId,
                ProductId = ProductId,
                Comment = comment,
                Rating = rating,
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatorId = userId,
                Pubished = true,
            };
            await _productFeedbackService.AddAsync(feedBack);

            return Redirect("ProductDetail?id=" +ProductId);
        }
    }
}
