using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace News.Identity.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Url)]
        [Editable(false)]
        [HiddenInput(DisplayValue = false)]
        public string ReturnURL { get; set; }

        public bool IsRememberMe { get; set; }
    }
}
