using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission04_JoelsMovies.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        //These fields are all required
        [Required]
        public string Category { get; set; } 
        [Required]
        public string Title { get; set; }
        [Required]
        public string Year { get; set; } 
        [Required]
        public string Director { get; set; } 
        [Required]
        public string Rating { get; set; } //dropdown G, PG, PG-13, R

        // These fields are optional
        public bool Edited { get; set; } //yes/no option (true/false)
        public string Lent_to { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; } //limit to 25 characters


    }
}
