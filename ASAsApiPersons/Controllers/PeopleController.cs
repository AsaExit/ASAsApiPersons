using ASAsApiPersons.Models.Entity;
using ASAsApiPersons.Models.Services;
using ASAsApiPersons.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASAsApiPersons.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        #region Get

        [HttpGet("all")]
        [ProducesResponseType(200)]
      
        public IEnumerable<PersonViewModel> Get()
        {

             return _peopleService.GetAll();
            
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<PersonViewModel> Get([FromQuery] string email = null)
        {
            IEnumerable<PersonViewModel> model;

            if (email != null)
            {
                model = new List<PersonViewModel>();

                var person = _peopleService.FindByEmail(email);
                if (person != null)
                {
                    (model as List<PersonViewModel>).Add(person);
                }
            }
            else
            {
                model = _peopleService.GetAll();
            }

            return model;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public PersonViewModel GetById([FromRoute] int id)
        {
            return _peopleService.FindById(id);
        }

        #endregion Get


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public PersonViewModel Create(PersonCreateVM person)
        {
            PersonViewModel personViewModel = _peopleService.Create(person);
            if (personViewModel == null)
            {
                Response.StatusCode = 400;
            }
            else
            {
                Response.StatusCode = 201;
            }
            return personViewModel;
        }


        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(409)]
        public void Edit(PersonViewModel person)
        {
            if (_peopleService.Update(person))
            {
                Response.StatusCode = 204;
            }
            else
            {
                Response.StatusCode = 409;
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        public void Delete(int id)
        {
            if (_peopleService.Delete(id))
            {
                Response.StatusCode = 202;
            }
            else
            {
                Response.StatusCode = 400;
            }
        }
    }
}
