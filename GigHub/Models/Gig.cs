using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public ApplicationUser Artista { get; set; }

        [Required]
        public string ArtistaID { get; set; }

        public DateTime Data { get; set; }

        [Required]
        [StringLength(255)]
        public string Local { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public byte GenreID { get; set; }
    }


}