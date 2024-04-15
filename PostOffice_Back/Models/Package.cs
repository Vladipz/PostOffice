using System;
using System.ComponentModel.DataAnnotations;
using lab3.Data.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;

namespace lab3.Models
{
    [Collection("packages")]
    public class Package
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("sender")]
        public Person Sender { get; set; }
        [BsonElement("receiver")]
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
