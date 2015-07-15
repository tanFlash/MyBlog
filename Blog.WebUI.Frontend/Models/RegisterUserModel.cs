using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Frontend.Models
{
    public class RegisterUserModel
    {
        [DataType(DataType.Text)]
        [StringLength(32, MinimumLength = 3)]
        [Required()]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [StringLength(32, MinimumLength = 3)]
        [Required()]
        public string LastName { get; set; }

        [DataType(DataType.Text)]
        [StringLength(32, MinimumLength = 3)]
        [Required()]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [StringLength(32, MinimumLength = 6)]
        [Required()]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}