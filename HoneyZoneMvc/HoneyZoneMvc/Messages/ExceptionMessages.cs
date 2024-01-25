namespace HoneyZoneMvc.Messages
{
    /// <summary>
    /// This static class contains constants which are used for informing of an error or a success
    /// </summary>
    public static class ExceptionMessages
    {
        //Errors in product service
        public const string NoProductsWithGivenCategory = "There are no products with category {0}";
        public const string NoProductsWithGivenId = "There is no product with id {0}";
        public const string ArgumentNull = "The argument {0} is null";







        //Product validation messages
        public const string ProductNameValueValidation = "Името трябва да е от {2} до {1} символа!";
        public const string ProductDescriptionValueValidation = "Описанието трябва да е от {2} до {1} символа!";
        public const string ProductPriceValueValidation = "Цената трябва да е от {1} до {2} лв!";
        public const string ProductInStockValueValidation = "Бройката в склад трябва да е от {1} до {2} броя!";
        public const string ProductQuantityValueValidation = "Количеството трябва да започва с число и да завърши с (ml;l;g;mg;kg) Пример: 100g";
        public const string RequiredField = "Това поле е задължително!";

    }
}
