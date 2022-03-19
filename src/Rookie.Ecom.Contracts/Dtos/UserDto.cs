using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime Birthday { get; set; }
        public string Email { get; set; }

        public int Status { get; set; }
        public ICollection<AddressDto> Addresses { get; set; }
        public ICollection<OrderDto> Orders { get; set; }
        public ICollection<ProductFeedBackDto> ProductFeedBacks { get; set; }
        public ICollection<UserRoleDto> UserRoles { get; set; }


    }
}
