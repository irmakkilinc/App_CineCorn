﻿using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        public DateTime? RealaseDate { get; set; }

        public decimal? TotalRevenue { get; set; }

        [Required(ErrorMessage = "Director is required!")]
        public int? DirectorId { get; set; }

        public Director Director { get; set; }

        public List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}
