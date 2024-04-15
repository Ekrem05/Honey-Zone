namespace HoneyZoneMvc.Common.Messages
{
    public static class ExceptionMessages
    {
        public static class ProductMessages
        {
            public const string ProductNotFound = "Product not found!";
            public const string ProductCannotBeDeleted = "Product cannot be deleted because it is used in an order that is not finished !";
            public const string NoProductsWithGivenCategory = "There are no products with category {0}";
            public const string NoProductWithGivenId = "There is no product with id {0}";
            public const string ProductAlreadyExists = "Product already exists!";
            public const string DiscountCannotBeCancelled = "Discount cannot be cancelled because there isn't one!";
        }

        public const string ModelStateInvalid = "Invalid model state";
        public static class CategoryMessages
        {
            public const string CategoryCannotBeDeleted = "Category cannot be deleted because it is associated with products!";
            public const string CategoryExists = "Category with this name is already in the database!";
            public const string InvalidCategory = "Invalid category!";
            public const string InvalidNull = "Category is null!";

        }
        public static class OrderMessages
        {
            public const string OrderNotFound = "Order not found!";

        }
        public const string UserNotFound = "User not found!";
        public const string CartNotFound = "Cart not found!";
        public const string InvalidDiscountValue = "Invalid value while setting discount!";

        public const string CategoryAlreadyExists = "Category already exists!";
        public const string UserAlreadyExists = "User already exists!";
        public const string CartAlreadyExists = "Cart already exists!";
        public const string CartIsEmpty = "Cart is empty!";
        public const string DiscountNotSetByCategory = "Discount not set by category!";



        public const string IdNull = "Id is null!";
        public const string GeneralException = "An error occurred while processing your request! Please contact an Administrator!";
    }
}
