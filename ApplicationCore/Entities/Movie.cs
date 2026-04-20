using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Movie : BaseEntity
    {
        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        [StringLength(4000)]
        public string? Overview { get; set; }

        [StringLength(2084)]
        public string? PosterUrl { get; set; }

        [StringLength(2084)]
        public string? BackdropUrl { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Budget { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Revenue { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Price { get; set; }

        [Column(TypeName = "decimal(3,1)")]
        public decimal? Rating { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }

        public ICollection<Trailer> Trailers { get; set; } = new List<Trailer>();
        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();
    }
}
