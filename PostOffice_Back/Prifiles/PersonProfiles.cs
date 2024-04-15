using System;
using AutoMapper;
using lab3.Models;
using MongoDB.Bson;

namespace lab3.Prifiles
{
    public class PersonProfiles : Profile
    {
        public PersonProfiles()
        {
            //Sourse -> Target
            CreateMap<Person, PersonResponse>();
            CreateMap<ObjectId, string>().ConvertUsing(ObjectId => ObjectId.ToString());

        }
    }
}
