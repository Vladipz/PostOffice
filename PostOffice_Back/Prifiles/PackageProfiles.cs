using System;
using AutoMapper;
using lab3.Dtos;
using lab3.Models;

namespace lab3.Prifiles
{
    public class PackageProfiles : Profile
    {
        public PackageProfiles()
        {
            CreateMap<Package, PackageReadDto>();

            CreateMap<PackageCreateDto, Package>();



        }
    }
}
