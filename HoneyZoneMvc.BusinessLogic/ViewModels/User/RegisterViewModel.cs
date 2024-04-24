using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static HoneyZoneMvc.Common.Messages.ValidationMessages;
using static HoneyZoneMvc.Constraints.DataConstants;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.User
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = RequiredField)]
        [StringLength(UserValidation.NameMaxValue, MinimumLength = UserValidation.NameMinValue, ErrorMessage = NamesLength)]
        [DisplayName("Име")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(UserValidation.NameMaxValue, MinimumLength = UserValidation.NameMinValue, ErrorMessage = NamesLength)]
        [DisplayName("Фамилия")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [EmailAddress(ErrorMessage = EmailIsInvalid)]
        [DisplayName("Е-поща")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(UserValidation.PasswordMaxValue, MinimumLength = UserValidation.PasswordMinValue, ErrorMessage = PasswordLength)]
        [RegularExpression(UserValidation.PasswordContainsDigit, ErrorMessage = PasswordDigit)]
        [DataType(DataType.Password)]
        [DisplayName("Парола")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = PasswordsMustMatch)]
        [DisplayName("Потвърдете паролата")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
