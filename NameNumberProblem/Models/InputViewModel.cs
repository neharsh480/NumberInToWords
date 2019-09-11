using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NameNumber.Models
{
    public class InputViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Number can't have more than 2 decimal places")]
        public decimal Number { get; set; }
    }
}