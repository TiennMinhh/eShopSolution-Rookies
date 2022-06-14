namespace Rookie.Ecom.Contracts.Constants
{
    public static class ValidationRules
    {
        public static class CommonRules
        {
            public const int MinLenghCharactersForText = 0;
            public const int MaxLenghCharactersForText = 255;
        }

        public static class CategoryRules
        {
            public const int MinLenghCharactersForName = 0;
            public const int MaxLenghCharactersForName = 50;

            public const int MinLenghCharactersForDesc = 0;
            public const int MaxLenghCharactersForDesc = 100;
        }

        public static class CityRules
        {
            public const int MinLenghCharactersForName = 0;
            public const int MaxLenghCharactersForName = 50;
        }
        public static class BrandRules
        {
            public const int MinLenghCharactersForName = 0;
            public const int MaxLenghCharactersForName = 50;
        }
        public static class CartRules
        {
            public const int MinLenghCharactersForName = 0;
            public const int MaxLenghCharactersForName = 50;
        }
        public static class OrderItemRules
        {
            public const int MinLenghCharactersForName = 0;
            public const int MaxLenghCharactersForName = 50;
        }
        public static class OrderRules
        {
            public const int MinLenghCharactersForAddressLine = 0;

            public const int MinLenghCharactersForPhone = 10;
            public const int MaxLenghCharactersForPhone = 11;
        }
        public static class ProductRules
        {
            public const int MinLenghCharactersForName = 0;
            public const int MaxLenghCharactersForName = 50;

            public const int MinLenghCharactersForDesc = 0;
            public const int MaxLenghCharactersForDesc = 100;


        }
        public static class ProductFeedbackRules
        {
            public const int MinLenghCharactersForName = 0;
            public const int MaxLenghCharactersForName = 50;
        }
        public static class ProductPictureRules
        {
            public const int MaxLenghCharactersForTitle = 50;
        }
        public static class RoleRules
        {
            public const int MinLenghCharactersForName = 0;
            public const int MaxLenghCharactersForName = 50;
        }
        public static class SlideRules
        {
            public const int MinLenghCharactersForName = 0;
            public const int MaxLenghCharactersForName = 50;
        }
        public static class UserRules
        {
            public const int MinLenghCharactersForName = 0;
            public const int MaxLenghCharactersForName = 50;

            public const int MinLenghCharactersForPassword = 3;

        }
        public static class AddressRules
        {
            public const int MinLenghCharactersForAddressLine = 0;
            public const int MinLenghCharactersForPhone = 10;
            public const int MaxLenghCharactersForPhone = 11;
        }
    }
}
