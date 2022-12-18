using ASAsApiPersons.Models.ViewModels;

namespace ASAsApiPersons.Models.Services
{
    public interface IPeopleService
    {
        PersonViewModel Create(PersonCreateVM person);

        //R
        PersonViewModel FindById(int id);
        PersonViewModel FindByEmail(string email);
        IEnumerable<PersonViewModel> GetAll();

        //U
        bool Update(PersonViewModel person);

        //D
        bool Delete(int id);
    }
}
