using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Frontend.Models
{
    public class CreateArticleModel
    {
        [DataType(DataType.Text)]
        [StringLength(32)]
        [Required]
        public string Title { get; set; }
    }
}