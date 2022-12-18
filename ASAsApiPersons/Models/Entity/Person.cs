using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASAsApiPersons.Models.Entity
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(120, MinimumLength = 5)]
        public string? Email { get; set; }

        public string? Title { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public List<Person>? people { get; set; }
    }
}
