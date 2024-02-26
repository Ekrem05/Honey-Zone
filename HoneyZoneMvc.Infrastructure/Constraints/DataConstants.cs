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
            public const string AmountRegx = "^\\d+\\s?(ml|l|g|mg|kg)$";
        }


        public static class Category
        {
            public const int NameMaxValue = 20;
            public const int NameMinValue = 3;
        }



    }
}
