using ASAsApiPersons.Models.Entity;

namespace ASAsApiPersons.Models.Repo
{
    public interface IPeopleRepo
    {
        //C
        Person Create(Person person);

        //R
        Person FindById(int id);
        Person FindByEmail(string email);
        List<Person> GetAll();

        //U
        void Update(Person person);

        //D
        void Delete(Person person);
    }
}
