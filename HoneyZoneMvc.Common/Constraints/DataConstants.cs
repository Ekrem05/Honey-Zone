namespace HoneyZoneMvc.Constraints
{
    public static class DataConstants
    {
        public static class Product
        {
            public const int NameMinValue = 3;
            public const int NameMaxValue = 50;
            public const double PriceMinValue = 1.00;
            public const double PriceMaxValue = 10000;
            public const int DescriptionMinValue = 30;
            public const int DescriptionMaxValue = 500;
            public const int InStockMinValue = 0;
            public const int InStockMaxValue = 10000;
            public const int DiscountMaxValue = 100;
            public const int DiscountMinValue = 1;
            public const string AmountRegx = "^\\d+\\s?(ml|l|g|mg|kg)$";
        }
        public const string DateFormat = "dd/MM/yyyy";

        public static class Category
        {
            public const int NameMaxValue = 20;
            public const int NameMinValue = 3;
        }
        public static class OrderDetails
        {
            public const int NameMaxValue = 30;
            public const int NameMinValue = 2;

            public const int AddressMaxValue = 100;
            public const int AddressMinValue = 2;

            public const int CityMaxValue = 30;
            public const int CityMinValue = 2;

            public const int PhoneNumberMaxValue = 13;
            public const int PhoneNumberMinValue = 10;

            public const int ZipCodeLength= 4;
        }

        public static class Satus
        {
            public const int NameMaxValue = 20;
            public const int NameMinValue = 3;
            public const string InitialStatus = "Pending";
        }
        public static class ImageUrl
        {
            public const int NameMaxValue = 120;
            public const int NameMinValue = 2;
        }
        public static class DeliveryMethod
        {
            public const int NameMaxValue = 12;
            public const int NameMinValue = 2;
        }
    }
}
