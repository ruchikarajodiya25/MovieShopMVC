using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class Trailer : BaseEntity
    {
        public int MovieId { get; set; }

        [Required]
        [StringLength(2084)]
        public string TrailerUrl { get; set; }

        [StringLength(256)]
        public string? Name { get; set; }

        public Movie Movie { get; set; }
    }
}
