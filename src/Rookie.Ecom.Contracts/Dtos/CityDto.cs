using System;
using System.Collections.Generic;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class CityDto : BaseDto
    {
        public string Name { get; set; }
        public int Status { get; set; }
        public ICollection<AddressDto> Addresses { get; set; }
    }
}
