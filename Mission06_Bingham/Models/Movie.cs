using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Bingham.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; } // No need to require an ID (auto-generated)


        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }


        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, 2100, ErrorMessage = "Please enter a valid year.")]
        public int Year { get; set; }

        public string Director { get; set; }

        public string Rating { get; set; }

        [Required(ErrorMessage = "Edited is required.")]
        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Copied To Plex is required.")]
        public bool? CopiedToPlex { get; set; }

        [StringLength(25, ErrorMessage = "Notes cannot be more than 25 characters.")]
        public string? Notes { get; set; }

    }
}
