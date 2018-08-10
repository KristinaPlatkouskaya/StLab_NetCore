using System;
using System.ComponentModel.DataAnnotations;

namespace Task1.Models
{
    public class ValueModel
    {
        [Required(ErrorMessage = "The parameter must be defined")]
        [Range(1, Int32.MaxValue, ErrorMessage = "The parameter must be positive")]
        public int? A { get; set; }

        [Required(ErrorMessage = "The parameter must be defined")]
        [Range(Int32.MinValue, -1, ErrorMessage = "The parameter must be negative")]
        public int? B { get; set; }
    }
}
