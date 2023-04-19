using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PracticeFinalExam.Models
{
    public class Movie
    { 
        [Key]
        [Required]
        public int MovieID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string Lent_To { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }

        // Foreign Key
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
