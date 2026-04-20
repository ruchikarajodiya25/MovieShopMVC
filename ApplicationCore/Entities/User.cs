using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128)]
        public string LastName { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        [Required]
        [StringLength(1024)]
        public string HashedPassword { get; set; }
    }
}