namespace HoneyZoneMvc.Common.Messages
{
    public static class ExceptionMessages
    {
        public static class ProductMessages
        {
            public const string ProductNotFound = "Продуктът не е намерен!";
            public const string ProductCannotBeDeleted = "Продуктът не може да бъде изтрит, защото се използва в незавършена поръчка!";
            public const string NoProductsWithGivenCategory = "Няма продукти с категория {0}";
            public const string NoProductWithGivenId = "Няма продукт с идентификатор {0}";
            public const string ProductAlreadyExists = "Продуктът вече съществува!";
            public const string DiscountCannotBeCancelled = "Отстъпката не може да бъде анулирана, защото не съществува!";

        }

        public const string ModelStateInvalid = "Невалидни данни";
        public static class CategoryMessages
        {
            public const string CategoryCannotBeDeleted = "Категорията не може да бъде изтрита, защото е асоциирана с продукти!";
            public const string CategoryExists = "Категория с това име вече съществува в базата данни!";
            public const string InvalidCategory = "Невалидна категория!";
            public const string InvalidNull = "Категорията е нулева!";

        }
        public static class OrderMessages
        {
            public const string OrderNotFound = "Поръчката не е намерена!";

        }
        public const string UserNotFound = "Потребителят не е намерен!";
        public const string CartNotFound = "Количката не е намерена!";
        public const string InvalidDiscountValue = "Невалидна стойност при задаване на отстъпка!";

        public const string CategoryAlreadyExists = "Категорията вече съществува!";
        public const string UserAlreadyExists = "Потребителят вече съществува!";
        public const string CartAlreadyExists = "Количката вече съществува!";
        public const string CartIsEmpty = "Количката е празна!";
        public const string DiscountNotSetByCategory = "Отстъпката не е зададена от категория!";



        public const string IdNull = "Идентификаторът е нулев!";
        public const string GeneralException = "Възникна грешка при обработката на вашето искане! Моля, свържете се с администратор!";
    }
}
