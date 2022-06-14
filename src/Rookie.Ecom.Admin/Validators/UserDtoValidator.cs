using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;

namespace Rookie.Ecom.Admin.Validators
{
    public class UserDtoValidator : BaseValidator<UserDto>
    {
        public UserDtoValidator(IUserService userService)
        {
            RuleFor(m => m.Id)
                 .NotNull()
                 .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Id)));

            RuleFor(m => m.Name)
                  .NotEmpty()
                  .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Name)));

            RuleFor(m => m.Name)
               .MaximumLength(ValidationRules.UserRules.MaxLenghCharactersForName)
               .WithMessage(string.Format(ErrorTypes.Common.MaxLengthError, ValidationRules.UserRules.MaxLenghCharactersForName))
               .When(m => !string.IsNullOrWhiteSpace(m.Name));

            RuleFor(m => m.UserName)
                  .NotEmpty()
                  .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.UserName)));

            RuleFor(m => m.Password)
                  .NotEmpty()
                  .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Password)));

            RuleFor(m => m.Password)
               .MinimumLength(ValidationRules.UserRules.MinLenghCharactersForPassword)
               .WithMessage(string.Format(ErrorTypes.Common.MinLengthError, ValidationRules.UserRules.MinLenghCharactersForPassword))
               .When(m => !string.IsNullOrWhiteSpace(m.Password));

            RuleFor(m => m.Birthday)
                  .NotEmpty()
                  .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Birthday)));

            RuleFor(m => m.Email)
                .EmailAddress()
                .WithMessage(x => string.Format(ErrorTypes.Common.InvalidEmailError));


            RuleFor(x => x).MustAsync(
             async (dto, cancellation) =>
             {
                 var exit = await userService.GetByNameAsync(dto.UserName);
                 return exit == null || exit.Id != dto.Id;
             }
          ).WithMessage("Duplicate record");
        }
    }
}
