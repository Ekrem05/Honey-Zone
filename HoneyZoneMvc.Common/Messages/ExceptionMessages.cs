using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Common.Messages
{
    public static class ExceptionMessages
    {
        public static class ProductMessages
        {
            public const string ProductNotFound = "Product not found!";
            public const string ProductCannotBeDeleted = "Product cannot be deleted because it is used in an order that is not finished !";
            public const string NoProductsWithGivenCategory = "There are no products with category {0}";
            public const string NoProductsWithGivenId = "There is no product with id {0}";
            public const string DiscountCannotBeCancelled = "Discount cannot be cancelled because there isn't one!";
        }
       
        public const string ModelStateInvalid = "Invalid model state";
        public static class CategoryMessages
        {
            public const string CategoryCannotBeDeleted = "Category cannot be deleted because it is used in products!";
            public const string CategoryExists = "Category with this name is already in the database!";
            public const string InvalidCategory = "Invalid category!";
            public const string InvalidNull = "Category is null!";

        }
        public const string UserNotFound = "User not found!";
        public const string CartNotFound = "Cart not found!";
        public const string InvalidDiscountValue = "Invalid value while setting discount!";
        public const string ProductAlreadyExists = "Product already exists!";
        public const string CategoryAlreadyExists = "Category already exists!";
        public const string UserAlreadyExists = "User already exists!";
        public const string CartAlreadyExists = "Cart already exists!";
        public const string DiscountAlreadyExists = "Discount already exists!";
        public const string ProductNotAdded = "Product not added!";
        public const string ProductNotUpdated = "Product not updated!";
        public const string ProductNotDeleted = "Product not deleted!";
        public const string DiscountNotSet = "Discount not set!";
        public const string DiscountNotRemoved = "Discount not removed!";
        public const string QuantityNotDecreased = "Quantity not decreased!";
        public const string DiscountNotSetByCategory = "Discount not set by category!";



        public const string IdNull = "Id is null!";
        public const string GeneralException = "An error occurred while processing your request! Please contact an Administrator!";
    }
}
