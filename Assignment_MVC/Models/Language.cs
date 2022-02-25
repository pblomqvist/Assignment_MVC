using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class Language
    {
        [Key]
        [Display(Name = "Id")]
        public int LanguageId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string LanguageName { get; set; }

        //Navigation property
        public ICollection<PersonLanguage> PersonLanguages { get; set; }
    }
}
