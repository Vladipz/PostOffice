using System;
using System.Runtime.InteropServices;
using AutoMapper;
using lab3.Interfaces;
using lab3.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace lab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;


        public PersonController(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PersonResponse>> GetPersons()
        {
            Console.WriteLine("Getting persons....");
            var personItems = _personRepository.GetAllPersons();

            var response = personItems.Select(p => new PersonResponse
            {
                // Id = p.Id.ToString(),
                Name = p.Name,
                Address = p.Address,
                PhoneNumber = p.PhoneNumber
            });

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetPersonById")]
        public ActionResult<Person> GetPersonById(string id)
        {

            var personItem = _personRepository.GetPersonById(id);

            if (personItem != null)
            {
                return Ok(_mapper.Map<Person>(personItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<Person> CreatePerson(
            Person person)
        {
            // person.Id = ObjectId.GenerateNewId();
            var personModel = _mapper.Map<Person>(person);
            _personRepository.AddPerson(personModel);

            var personResponse = _mapper.Map<PersonResponse>(personModel);

            return CreatedAtRoute(nameof(GetPersonById), new { Id = personResponse.Id }, personResponse);
        }


    }
}
