using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Address : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public string AddressLine { get; set; }
        public int Phone { get; set; }
        public int Status { get; set; }
    }
}
