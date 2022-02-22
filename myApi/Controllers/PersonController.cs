using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myApi.Models;
using myData.DTOs;
using myData.Interfaces;
using System;
using System.Collections.Generic;

namespace myApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public PersonController(IPersonRepository repo, IMapper mapper, ILogger<PersonModel> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]   
        public IActionResult Get()
        {
            try
            {
                var people = _repo.GetPersons();
                var persons = _mapper.Map<List<PersonModel>>(people);
                _logger.LogInformation("Retrieved all Persons and mapped the DTOs to Models");

                return Ok(persons);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ran into an error " + ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPerson(int id)
        {
            try
            {
                var person = _repo.GetPerson(id);
                var mappedPerson = _mapper.Map<PersonModel>(person);
                _logger.LogInformation("Retrieved Person by ID and mapped the DTO to a Model");

                return Ok(mappedPerson);
            }
            catch(Exception ex)
            {
                _logger.LogError("Ran into an error " + ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody]PersonModel person)
        {
            try
            {
                if (person == null) return BadRequest("Not a valid person.");

                if (!ModelState.IsValid) return BadRequest("Not a valid person.");

                var mappedPerson = _mapper.Map<PersonDTO>(person);
                _logger.LogInformation("Passed in a person model, converted it to a DTO and saved.");

                _repo.SavePerson(mappedPerson);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError("Ran into an error " + ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}
