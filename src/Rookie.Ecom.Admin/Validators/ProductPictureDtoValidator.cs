using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;

namespace Rookie.Ecom.Admin.Validators
{
    public class ProductPictureDtoValidator : BaseValidator<ProductPictureDto>
    {
        public ProductPictureDtoValidator(IProductPictureService productPictureService)
        {
            RuleFor(m => m.Id)
                 .NotNull()
                 .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Id)));

            RuleFor(m => m.PictureUrl)
                  .NotEmpty()
                  .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.PictureUrl)));

            RuleFor(m => m.Title)
                 .NotEmpty()
                 .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Title)));

            RuleFor(m => m.Title)
               .MaximumLength(ValidationRules.ProductPictureRules.MaxLenghCharactersForTitle)
               .WithMessage(string.Format(ErrorTypes.Common.MaxLengthError, ValidationRules.ProductPictureRules.MaxLenghCharactersForTitle))
               .When(m => !string.IsNullOrWhiteSpace(m.Title));

            RuleFor(x => x).MustAsync(
             async (dto, cancellation) =>
             {
                 var exit = await productPictureService.GetByNameAsync(dto.Title);
                 return exit == null || exit.Id != dto.Id;
             }
          ).WithMessage("Duplicate record");
        }
    }
}
