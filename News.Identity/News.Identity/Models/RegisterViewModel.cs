using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace News.Identity.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords not equal")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Url)]
        [Editable(false)]
        [HiddenInput(DisplayValue =false)]
        public string ReturnURL { get; set; }
    }
}
