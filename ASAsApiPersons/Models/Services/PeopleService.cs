using ASAsApiPersons.Models.Entity;
using ASAsApiPersons.Models.Repo;
using ASAsApiPersons.Models.ViewModels;

namespace ASAsApiPersons.Models.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepo _peopleRepo;

        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }

        public PersonViewModel Create(PersonCreateVM person)
        {
            Person newPerson = _peopleRepo.Create(new Person()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Title = person.Title
            });

            if (newPerson == null)
            {
                return null;
            }
            else
            {
                return new PersonViewModel(newPerson);
            }
        }

        public bool Delete(int id)
        {
            var person = _peopleRepo.FindById(id);

            if (person == null)
            {
                return false;
            }
            else
            {
                _peopleRepo.Delete(person);
                return true;
            }
        }

        public PersonViewModel FindByEmail(string email)
        {
            var person = _peopleRepo.FindByEmail(email);

            if (person == null)
            {
                return null;
            }
            else
            {
                return new PersonViewModel(person);
            }
        }

        public PersonViewModel FindById(int id)
        {
            var person = _peopleRepo.FindById(id);

            if (person == null)
            {
                return null;
            }
            else
            {
                return new PersonViewModel(person);
            }
        }

        public IEnumerable<PersonViewModel> GetAll()
        {
            List<PersonViewModel> people = new List<PersonViewModel>();

            foreach (Person person in _peopleRepo.GetAll())
            {
                people.Add(new PersonViewModel(person));
            }

            return people;
        }

        public bool Update(PersonViewModel person)
        {
            Person originalPerson = _peopleRepo.FindById(person.Id);

            originalPerson.FirstName = person.FirstName;
            originalPerson.LastName = person.LastName;
            originalPerson.Email = person.Email;
            originalPerson.Title = person.Title;

            _peopleRepo.Update(originalPerson);

            return true;
        }
    }
}
