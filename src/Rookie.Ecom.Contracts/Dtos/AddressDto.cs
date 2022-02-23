using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class AddressDto : BaseDto
    {
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
        public Guid CityId { get; set; }
        public CityDto City { get; set; }
        public string AddressLine { get; set; }
        public int Phone { get; set; }
        public int Status { get; set; }
    }
}
