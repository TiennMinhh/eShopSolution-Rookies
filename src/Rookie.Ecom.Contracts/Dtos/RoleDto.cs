using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class RoleDto : BaseDto
    {
        public string Name { get; set; }

        public int Status { get; set; }

        public ICollection<UserDto> Users { get; set; }
    }
}
