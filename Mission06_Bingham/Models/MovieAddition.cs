using System.ComponentModel.DataAnnotations;

namespace Mission06_Bingham.Models
{
    public class MovieAddition
    {
        public int MovieID { get; set; } // No need to require an ID (auto-generated)

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, 2100, ErrorMessage = "Please enter a valid year.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Director is required.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        public string Rating { get; set; }

        public bool? Edited { get; set; }

        public string? Lent { get; set; }

        [StringLength(25, ErrorMessage = "Notes cannot be more than 25 characters.")]
        public string? Notes { get; set; }

    }
}
