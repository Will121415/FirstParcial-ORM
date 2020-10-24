using BLL;
using Entity;
using Microsoft.AspNetCore.Mvc;
using presentacion.Models;
using System.Collections.Generic;
using System.Linq;
using DAL;
namespace presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController: ControllerBase
    {
        private readonly PersonService personService;
        public PersonController(FirstParcialContext context)
        {
            personService = new PersonService(context);
        }

        //POST: api/Person
        [HttpPost]
        public ActionResult<PersonViewModel> Post(PersonInputModel personInput)
        {
            Person person  = Map(personInput);
            var response = personService.Save(person);
            if(response.Error)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Person);
        }

        private Person Map(PersonInputModel personInput)
        {
            var person = new Person();

            person.Identification = personInput.Identification;
            person.Name = personInput.Name;
            person.Surnames = personInput.Surnames;
            person.Sex = personInput.Sex;
            person.Age = personInput.Age;
            person.Department = personInput.Department;
            person.City = personInput.City;

            person.Support = new Support();
            person.Support.IdSupport = personInput.Support.IdSupport;
            person.Support.Value = personInput.Support.Value;
            person.Support.Modality = personInput.Support.Modality;
            person.Support.Date = personInput.Support.Date;

            return person;
        }

        // GET: api/Person
        [HttpGet]

        public ActionResult<IEnumerable<PersonViewModel>> Get()
        {
            ConsultResponse response = personService.GetConsult();
            if(response.Persons == null) {
                BadRequest(response.Message);
            }
            var persons = response.Persons.Select(p => new PersonViewModel(p));
            return Ok(response.Persons);
        }
    

        [HttpGet("{identification}")]
        public ActionResult<PersonViewModel> GetPerson(string identification)
        {
            ServiceResponse response =  personService.GetPerson(identification);
            if(response.Person == null) return NotFound("Persona no encontrada!");
            var p =  new PersonViewModel(response.Person);

            return Ok(p);
        }

        
    }
}