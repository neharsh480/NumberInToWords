using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NameNumber.WebAPI.Models
{
    public class InputModel: IValidatableObject
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Number { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Number > 999999999.99m)
            {
                yield return new ValidationResult("Number should be less than 1 Billion");
            }
        }
    }
}