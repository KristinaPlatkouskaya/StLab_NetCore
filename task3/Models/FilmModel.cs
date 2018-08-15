using System.ComponentModel.DataAnnotations;

namespace task3.Models
{
    public class FilmModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name filed is requered")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Country filed is requered")]
        public string Country { get; set; }

        [Required(ErrorMessage = "The Year filed is requered")]
        public int Year { get; set; }

        [Required(ErrorMessage = "The Producer filed is requered")]
        public string Producer { get; set; }
    }
}
