using System;
using lab3.Models;
using MongoDB.Bson;

namespace lab3.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllPersons();
        Person? GetPersonById(string id);

        void AddPerson(Person person);

        void EditPerson(Person person);

        void DeletePerson(Person person);
    }
}
