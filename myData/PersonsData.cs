using myData.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myData
{
    public class PersonsData
    {
        public List<PersonDTO> GetPersonsData()
        {
            List<PersonDTO> list = new List<PersonDTO>();

            list.Add(new PersonDTO() { Id = 1, Name = "John Doe", Email = "doej@test.com" });
            list.Add(new PersonDTO() { Id = 2, Name = "Jane Doe", Email = "doeja@test.com" });
            list.Add(new PersonDTO() { Id = 3, Name = "Tom Smith", Email = "tom.smith@test.com" });

            return list;
        }
    }
}
