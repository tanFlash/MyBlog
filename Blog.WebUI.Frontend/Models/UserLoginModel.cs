using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Frontend.Models
{
    public class UserLoginModel
    {
        [Required()]
        public string Login { get; set; }

        [Required()]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}