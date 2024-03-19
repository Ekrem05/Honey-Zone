using System.ComponentModel.DataAnnotations;
using static HoneyZoneMvc.Common.Messages.ValidationMessages;
using static HoneyZoneMvc.Constraints.DataConstants;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.User
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = RequiredField)]
        [StringLength(UserValidation.NameMaxValue, MinimumLength = UserValidation.NameMinValue, ErrorMessage = NamesLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(UserValidation.NameMaxValue, MinimumLength = UserValidation.NameMinValue, ErrorMessage = NamesLength)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [EmailAddress(ErrorMessage = EmailIsInvalid)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(UserValidation.PasswordMaxValue, MinimumLength = UserValidation.PasswordMinValue, ErrorMessage = PasswordLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = PasswordsMustMatch)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
