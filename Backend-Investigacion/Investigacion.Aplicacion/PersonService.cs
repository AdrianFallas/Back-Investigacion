using Investigacion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigacion.Aplicacion
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository<Person> _personRepository;

        public PersonService(IPersonRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Person>> GetAllPersons()
        {
            return await _personRepository.GetAll();
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await _personRepository.GetById(id);
        }

        public async Task CreatePerson(Person person)
        {
            await _personRepository.Add(person);
        }

        public async Task UpdatePerson(Person person)
        {
            await _personRepository.Update(person);
        }

        public async Task DeletePerson(Person person)
        {
            await _personRepository.Delete(person);
        }
    }
}
