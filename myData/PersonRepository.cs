using myData.DTOs;
using myData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myData
{
    public class PersonRepository : IPersonRepository
    {
        public PersonDTO GetPerson(int id)
        {
            PersonsData persons = new PersonsData();

            var data = persons.GetPersonsData();

            PersonDTO P = (from x in data
                          where x.Id == id
                          select x).FirstOrDefault();

            return P;
        }

        public List<PersonDTO> GetPersons()
        {
            List<PersonDTO> persons = new List<PersonDTO>();
            PersonsData data = new PersonsData();
            
            persons = data.GetPersonsData().ToList();
            return persons;
        }

        public void SavePerson(PersonDTO person)
        {
            List<PersonDTO> persons = new List<PersonDTO>();

            // please add a breakpoint here to see the data being added
            persons.Add(person); 
        }
    }
}
