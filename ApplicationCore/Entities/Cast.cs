using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class Cast : BaseEntity
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(16)]
        public string? Gender { get; set; }

        [StringLength(1024)]
        public string? TmdbUrl { get; set; }

        [StringLength(2084)]
        public string? ProfilePath { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();
    }
}
