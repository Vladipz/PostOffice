using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;

namespace lab3.Models
{
    // [Collection("persons")]
    public class Person
    {

        // [BsonId]
        // [BsonRepresentation(BsonType.ObjectId)]
        // public ObjectId Id { get; set; }
        [Required(ErrorMessage = "You must enter the name.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You must enter an address.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "You must enter a phone number.")]
        public string PhoneNumber { get; set; }
        // public Person()
        // {
        //     Id = ObjectId.GenerateNewId().ToString();
        // }
        // public List<Package> Packages { get; set; }
    }
}
