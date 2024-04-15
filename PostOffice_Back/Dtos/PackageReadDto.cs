using System;
using lab3.Data.Enums;
using lab3.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace lab3.Dtos
{
    public class PackageReadDto
    {

        public string Id { get; set; }
        public Person Sender { get; set; }
        public Person Receiver { get; set; }
        public int Distance { get; set; }
        public DateTime SentDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        [BsonElement("items")]
        public List<Item> Items { get; set; }
        public double DeliveryCost { get; set; }
        public Status DeliveryStatus { get; set; }

    }
}
