using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.ViewModels
{
    public class LanguageCreateViewModel
    {
        [Required]
        [RegularExpression("^[a-zA-ZÀ-ÿ ]*$", ErrorMessage = "Name cannot contain numbers")]
        [Display(Name = "Name")]
        [StringLength(80, MinimumLength = 1)]
        public string LanguageName { get; set; }

        public LanguageCreateViewModel() { }

        public LanguageCreateViewModel(string language)
        {
            LanguageName = language;
        }
    }
}
