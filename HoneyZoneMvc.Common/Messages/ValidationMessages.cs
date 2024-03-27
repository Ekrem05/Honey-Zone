namespace HoneyZoneMvc.Common.Messages
{
    /// <summary>
    /// This static class contains constants which are used for informing of an error or a success
    /// </summary>
    public static class ValidationMessages
    {
        public const string ArgumentNull = "The argument {0} is null";

        // Product validation messages
        public const string ProductNameValueValidation = "The name must be between {2} and {1} characters!";
        public const string ProductDescriptionValueValidation = "The description must be between {2} and {1} characters!";
        public const string ProductPriceValueValidation = "The price must be between {1} and {2} BGN!";
        public const string ProductInStockValueValidation = "The stock quantity must be between {1} and {2} units!";
        public const string ProductAmountValueValidation = "The quantity must start with a number and end with (ml; l; g; mg; kg). Example: 100g";
        public const string ProductDiscountValueValidation = "The discount must be between {1} and {2} percent!";
        public const string RequiredField = "This field is required!";

        // Category validation messages
        public const string CategoryValidation = "The category must be between {2} and {1} characters!";

        // OrderDetail validation messages
        public const string OrderDetailNameValueValidation = "The name must be between {2} and {1} characters!";
        public const string OrderDetailAddressValueValidation = "The address must be between {2} and {1} characters!";
        public const string OrderDetailCityValueValidation = "The city must be between {2} and {1} characters!";
        public const string OrderDetailPhoneNumberValueValidation = "The phone number must be between {2} and {1} characters!";
        public const string OrderDetailZipCodeValueValidation = "The ZIP code must be {1} characters!";
        public const string OrderDetailEmailValueValidation = "Invalid email address!";

        public const string NamesLength = "The {0} must be at least {2} and at max {1} characters long.";
        public const string EmailIsInvalid = "Invalid email address!";
        public const string PasswordLength = "The password must be at least {2} and at max {1} characters long.";
        public const string PasswordsMustMatch = "Password and Confirm Password must match!";
    }
}
