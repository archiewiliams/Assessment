using myData.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myData.Interfaces
{
    public interface IPersonRepository
    {
        List<PersonDTO> GetPersons();
        PersonDTO GetPerson(int id);
        void SavePerson(PersonDTO person);
    }
}
