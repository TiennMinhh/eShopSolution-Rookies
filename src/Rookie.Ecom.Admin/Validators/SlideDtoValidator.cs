using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;

namespace Rookie.Ecom.Admin.Validators
{
    public class SlideDtoValidator : BaseValidator<SlideDto>
    {
        public SlideDtoValidator(ISlideService slideService)
        {
            RuleFor(m => m.Id)
                 .NotNull()
                 .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Id)));

            RuleFor(m => m.Name)
                  .NotEmpty()
                  .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Name)));

            RuleFor(m => m.Name)
               .MaximumLength(ValidationRules.SlideRules.MaxLenghCharactersForName)
               .WithMessage(string.Format(ErrorTypes.Common.MaxLengthError, ValidationRules.SlideRules.MaxLenghCharactersForName))
               .When(m => !string.IsNullOrWhiteSpace(m.Name));

            RuleFor(m => m.Url)
                  .NotEmpty()
                  .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Url)));

            RuleFor(x => x).MustAsync(
             async (dto, cancellation) =>
             {
                 var exit = await slideService.GetByNameAsync(dto.Name);
                 return exit == null || exit.Id != dto.Id;
             }
          ).WithMessage("Duplicate record");
        }
    }
}
