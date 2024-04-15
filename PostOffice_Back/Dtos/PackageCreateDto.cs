using System;
using lab3.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace lab3.Dtos
{
    public class PackageCreateDto
    {

        public Person Sender { get; set; }
        public Person Receiver { get; set; }

        [BsonElement("items")]
        public List<Item> Items { get; set; }
    }
}
