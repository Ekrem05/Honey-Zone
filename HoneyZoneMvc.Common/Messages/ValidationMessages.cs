namespace HoneyZoneMvc.Common.Messages
{
    /// <summary>
    /// This static class contains constants which are used for informing of an error or a success
    /// </summary>
    public static class ValidationMessages
    {
        public const string ArgumentNull = "Аргументът {0} е нулев";

        // Съобщения за валидация на продукта
        public const string ProductNameValueValidation = "Името трябва да бъде между {2} и {1} символа!";
        public const string ProductDescriptionValueValidation = "Описанието трябва да бъде между {2} и {1} символа!";
        public const string ProductPriceValueValidation = "Цената трябва да бъде между {1} и {2} BGN!";
        public const string ProductInStockValueValidation = "Количеството в наличност трябва да бъде между {1} и {2} броя!";
        public const string ProductAmountValueValidation = "Количеството трябва да започва с число и да завършва с (ml; l; g; mg; kg). Пример: 100g";
        public const string ProductDiscountValueValidation = "Отстъпката трябва да бъде между {1} и {2} процента!";
        public const string RequiredField = "Това поле е задължително!";

        // Съобщения за валидация на категорията
        public const string CategoryValidation = "Категорията трябва да бъде между {2} и {1} символа!";

        // Съобщения за валидация на детайлите на поръчката
        public const string OrderDetailNameValueValidation = "Името трябва да бъде между {2} и {1} символа!";
        public const string OrderDetailAddressValueValidation = "Адресът трябва да бъде между {2} и {1} символа!";
        public const string OrderDetailCityValueValidation = "Градът трябва да бъде между {2} и {1} символа!";
        public const string OrderDetailPhoneNumberValueValidation = "Телефонният номер трябва да бъде между {2} и {1} символа!";
        public const string OrderDetailZipCodeValueValidation = "Пощенският код трябва да бъде {1} символа!";
        public const string OrderDetailEmailValueValidation = "Невалиден имейл адрес!";

        public const string NamesLength = "{0} трябва да е поне {2} и максимум {1} символа дълга.";
        public const string EmailIsInvalid = "Невалиден имейл адрес!";
        public const string PasswordLength = "Паролата трябва да е поне {2} и максимум {1} символа дълга.";
        public const string PasswordsMustMatch = "Паролата и Потвърди паролата трябва да съвпадат!";
        public const string PasswordDigit = "Паролата трябва да съдържа поне една цифра!";
    }

}
