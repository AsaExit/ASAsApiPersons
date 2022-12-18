using ASAsApiPersons.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace ASAsApiPersons.Models.ViewModels
{
    public class PersonViewModel
    {

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

        public PersonViewModel() { }

        public PersonViewModel(Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
            Email = person.Email;
            Title = person.Title;
        }
    }
}
