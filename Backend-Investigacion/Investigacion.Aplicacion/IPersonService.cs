using Investigacion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigacion.Aplicacion
{
    public interface IPersonService
    {
        Task<List<Person>> GetAllPersons();
        Task<Person> GetPersonById(int id);
        Task CreatePerson(Person person);
        Task UpdatePerson(Person person);
        Task DeletePerson(Person person);
    }
}
