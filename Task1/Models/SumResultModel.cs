using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Models
{
    public class SumResultModel
    {
        [Required(ErrorMessage = "Параметр должен быть определен")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Параметр должен быть положительным")]
        public int? A { get; set; }

        [Required(ErrorMessage = "Параметр должен быть определен")]
        [Range(Int32.MinValue, -1, ErrorMessage = "Параметр должен быть отрицательным")]
        public int? B { get; set; }

        public int Sum { get; set; }
    }
}

