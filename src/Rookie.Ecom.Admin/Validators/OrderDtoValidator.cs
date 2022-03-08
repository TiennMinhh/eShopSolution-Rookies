using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;

namespace Rookie.Ecom.Admin.Validators
{
    public class OrderDtoValidator : BaseValidator<OrderDto>
    {
        public OrderDtoValidator(IOrderService orderService)
        {
            RuleFor(m => m.Id)
                 .NotNull()
                 .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Id)));

            RuleFor(m => m.AddressLine)
                  .NotEmpty()
                  .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.AddressLine)));

            RuleFor(m => m.AddressLine)
               .MinimumLength(ValidationRules.OrderRules.MinLenghCharactersForAddressLine)
               .WithMessage(string.Format(ErrorTypes.Common.MaxLengthError, ValidationRules.OrderRules.MinLenghCharactersForAddressLine))
               .When(m => !string.IsNullOrWhiteSpace(m.AddressLine));

            RuleFor(m => m.Phone)
                  .NotEmpty()
                  .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Phone)));

            RuleFor(m => m.Phone)
               .MaximumLength(ValidationRules.OrderRules.MaxLenghCharactersForPhone)
               .WithMessage(string.Format(ErrorTypes.Common.MaxLengthError, ValidationRules.OrderRules.MaxLenghCharactersForPhone))
               .When(m => !string.IsNullOrWhiteSpace(m.Phone));

          //  RuleFor(x => x).MustAsync(
          //   async (dto, cancellation) =>
          //   {
          //       var exit = await orderService.GetByNameAsync(dto.Name);
          //       return exit == null || exit.Id != dto.Id;
          //   }
          //).WithMessage("Duplicate record");
        }
    }
}
