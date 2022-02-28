using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;

namespace Rookie.Ecom.Admin.Validators
{
    public class OrderItemDtoValidator : BaseValidator<OrderItemDto>
    {
        public OrderItemDtoValidator(IOrderItemService orderItemService)
        {
            RuleFor(m => m.Id)
                 .NotNull()
                 .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Id)));

            RuleFor(m => m.Quantity)
                  .NotEmpty()
                  .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Quantity))); 
            RuleFor(m => m.Price)
                   .NotEmpty()
                   .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Price)));            

          //  RuleFor(x => x).MustAsync(
          //   async (dto, cancellation) =>
          //   {
          //       var exit = await orderItemService.GetByNameAsync(dto.Name);
          //       return exit == null || exit.Id != dto.Id;
          //   }
          //).WithMessage("Duplicate record");
        }
    }
}
