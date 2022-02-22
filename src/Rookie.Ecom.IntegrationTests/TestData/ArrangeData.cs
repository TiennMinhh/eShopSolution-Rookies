using Rookie.Ecom.DataAccessor.Entities;

namespace Rookie.Ecom.IntegrationTests.TestData
{
    public static class ArrangeData
    {
        public static Category Category() => new()
        {
            Name = "LA",
            Desc = "Laptop",
        };
    }
}