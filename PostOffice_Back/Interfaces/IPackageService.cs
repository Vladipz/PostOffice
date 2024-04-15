using System;
using lab3.Dtos;
using lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3.Interfaces
{
    public interface IPackageService
    {
        Package SendPackage(Package package);
        PackageReadDto ReceivePackage(string id);

        PackageReadDto ReturnPackage(string id);
        Package GetPackageById(string id);
        IEnumerable<Package> GetPackages();
    }
}
