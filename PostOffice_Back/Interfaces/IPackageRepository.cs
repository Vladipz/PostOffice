using System;
using lab3.Models;
using MongoDB.Bson;

namespace lab3.Interfaces
{
    public interface IPackageRepository
    {
        IEnumerable<Package> GetAllPackages();
        Package? GetPackageById(string id);

        void AddPackage(Package package);

        void EditPackage(Package package);

        void DeletePackage(Package package);
    }
}
