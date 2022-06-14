using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class UserRoleDto : BaseDto
    {
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
        public Guid RoleId { get; set; }
        public RoleDto Role { get; set; }
        public bool Status { get; set; }
    }
}
