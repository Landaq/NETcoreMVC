using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RemoteValidationDemo.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Please Enter a Valid Email")]
        [Remote(action: "IsEmailAvailable", controller:"RemoteValidation", ErrorMessage ="Email is already in use. Please use a diffrent email address.")]
        [UniqueEmail]
        public string Email { get; set; }

        [Required(ErrorMessage = "User Name is Required")]
        [MinLength(8, ErrorMessage = "Minimum 8 characters Required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$])[A-Za-z\d@#$]{8,}$", ErrorMessage = @"Username must be at least 8 characters
                                                                                                            long and include lower case, upper case, a digit
                                                                                                            , and a special character.")]
        [Remote(action:"IsUsernameAvailable", controller:"RemoteValidation", ErrorMessage = "Username is already taken. Please use a different username.")]
        [UniqueUsername]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

    }
}
