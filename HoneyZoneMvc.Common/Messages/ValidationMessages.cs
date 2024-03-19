namespace HoneyZoneMvc.Common.Messages
{
    /// <summary>
    /// This static class contains constants which are used for informing of an error or a success
    /// </summary>
    public static class ValidationMessages
    {
        public const string ArgumentNull = "The argument {0} is null";

        //Product validation messages
        public const string ProductNameValueValidation = "Името трябва да е от {2} до {1} символа!";
        public const string ProductDescriptionValueValidation = "Описанието трябва да е от {2} до {1} символа!";
        public const string ProductPriceValueValidation = "Цената трябва да е от {1} до {2} лв!";
        public const string ProductInStockValueValidation = "Бройката в склад трябва да е от {1} до {2} броя!";
        public const string ProductAmountValueValidation = "Количеството трябва да започва с число и да завърши с (ml;l;g;mg;kg) Пример: 100g";
        public const string ProductDiscountValueValidation = "Отстъпката трябва да е от {1} до {2} процента!";
        public const string RequiredField = "Това поле е задължително!";


        //Category validatioin messages
        public const string CategoryValidation = "Категорията трябва да е от {2} до {1} символа!";


        //OrderDetail validation messages
        public const string OrderDetailNameValueValidation = "Името трябва да е от {2} до {1} символа!";
        public const string OrderDetailAddressValueValidation = "Адреса трябва да е от {2} до {1} символа!";
        public const string OrderDetailCityValueValidation = "Града трябва да е от {2} до {1} символа!";
        public const string OrderDetailPhoneNumberValueValidation = "Телефонният номер трябва да е от {2} до {1} символа!";
        public const string OrderDetailZipCodeValueValidation = "Пощенският код трябва да е {1} символа!";
        public const string OrderDetailEmailValueValidation = "Невалиден имейл адрес!";

        public const string NamesLength = "The {0} must be at least {2} and at max {1} characters long.";
        public const string EmailIsInvalid = "Invalid email address!";
        public const string PasswordLength = "The password must be at least {2} and at max {1} characters long.";
        public const string PasswordsMustMatch = "Password and Confirm Password must match!";
    }
}
