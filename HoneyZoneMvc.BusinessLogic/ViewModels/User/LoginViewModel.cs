using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HoneyZoneMvc.Common.Messages.ValidationMessages;
using static HoneyZoneMvc.Constraints.DataConstants;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = RequiredField)]
        [EmailAddress(ErrorMessage = EmailIsInvalid)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(UserValidation.PasswordMaxValue, MinimumLength = UserValidation.PasswordMinValue, ErrorMessage = PasswordLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}
