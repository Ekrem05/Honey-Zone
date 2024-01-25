namespace HoneyZoneMvc.Constraints
{
    public static class ValidationValues
    {
        public const int ProductNameMinValue = 3;
        public const int ProductNameMaxValue = 50;
        public const double ProductPriceMinValue = 1.00;
        public const double ProductPriceMaxValue = 10000;
        public const int ProductDescriptionMinValue = 30;
        public const int ProductDescriptionMaxValue = 500;
        public const int ProductInStockMinValue = 0; 
        public const int ProductInStockMaxValue = 10000;
        public const string ProductQuantityRegx = "^\\d+\\s?(ml|l|g|mg|kg)$";
    }
}
