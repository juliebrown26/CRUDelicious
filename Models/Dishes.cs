using System.ComponentModel.DataAnnotations;
using System;

namespace crudelicious.Models
{
    public class Dishes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Chef { get; set; }

        [Required]
        [Range(1, 11)]
        public int Tastiness { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}