// using System;
// using lab3.Data;
// using lab3.Interfaces;
// using lab3.Models;
// using Microsoft.AspNetCore.Http.HttpResults;
// using Microsoft.EntityFrameworkCore;
// using MongoDB.Bson;

// namespace lab3.Repositories
// {
//     public class PersonRepository : IPersonRepository
//     {
//         private readonly AppDbContext _appDbContext;

//         public PersonRepository(AppDbContext appDbContext)
//         {
//             _appDbContext = appDbContext;   
//         }

//         public void AddPerson(Person person)
//         {

//             _appDbContext.Persons.Add(person);

//             _appDbContext.ChangeTracker.DetectChanges();

//             _appDbContext.SaveChanges();

//         }

//         public void DeletePerson(Person person)
//         {
//             var personToDelete = _appDbContext.Persons.FirstOrDefault(p => p.Id == person.Id);
//             if (personToDelete == null)
//             {
//                 throw new ArgumentException("The person to delete cannot be found.");
//             }
//             _appDbContext.Persons.Remove(personToDelete);
//             _appDbContext.SaveChanges();
//         }

//         public void EditPerson(Person person)
//         {

//             var personToUpdate = _appDbContext.Persons.FirstOrDefault(p => p.Id == person.Id);

//             if (personToUpdate == null)
//             {
//                 throw new ArgumentException("The person to update cannot be found.");
//             }

//             _appDbContext.Entry(personToUpdate).CurrentValues.SetValues(person);

//             _appDbContext.SaveChanges();

//         }

//         public IEnumerable<Person> GetAllPersons()
//         {
//             return _appDbContext.Persons.OrderBy(p => p.Id).AsNoTracking().AsEnumerable<Person>();
//         }

//         public Person? GetPersonById(string id)
//         {


//             return _appDbContext.Persons.FirstOrDefault(p => p.Id.ToString() == id);


//         }
//     }
// }
