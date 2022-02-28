using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;

namespace Rookie.Ecom.Admin.Validators
{
    public class ProductFeedBackDtoValidator : BaseValidator<ProductFeedBackDto>
    {
        public ProductFeedBackDtoValidator(IProductFeedBackService productFeedBackService)
        {
            RuleFor(m => m.Id)
                 .NotNull()
                 .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Id)));

            RuleFor(m => m.Comment)
                  .NotEmpty()
                  .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Comment)));

          //  RuleFor(x => x).MustAsync(
          //   async (dto, cancellation) =>
          //   {
          //       var exit = await productFeedBackService.GetByNameAsync(dto.Name);
          //       return exit == null || exit.Id != dto.Id;
          //   }
          //).WithMessage("Duplicate record");
        }
    }
}
