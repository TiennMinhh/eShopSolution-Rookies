using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;

namespace Rookie.Ecom.Admin.Validators
{
    public class UserRoleDtoValidator : BaseValidator<UserRoleDto>
    {
        public UserRoleDtoValidator(IUserRoleService roleService)
        {
            

            RuleFor(x => x).MustAsync(
             async (dto, cancellation) =>
             {
                 var exit = await roleService.GetByNameAsync(dto.Role.Name);
                 return exit == null || exit.Id != dto.Id;
             }
          ).WithMessage("Duplicate record");
        }
    }
}
