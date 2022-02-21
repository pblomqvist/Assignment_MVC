using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class PersonLanguage
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public string LanguageName { get; set; }
        public Language Language { get; set; }
    }
}
