using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class Genre : BaseEntity
    {
        [Required]
        [StringLength(24)]
        public string Name { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}