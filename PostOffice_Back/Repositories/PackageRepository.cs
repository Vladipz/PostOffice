using System;
using lab3.Data;
using lab3.Interfaces;
using lab3.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace lab3.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly AppDbContext _appDbContext;

        public PackageRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddPackage(Package package)
        {
            _appDbContext.Packages.Add(package);

            _appDbContext.ChangeTracker.DetectChanges();

            _appDbContext.SaveChanges(); 
        }

        public void DeletePackage(Package package)
        {
            var packageToDelete = _appDbContext.Packages.FirstOrDefault(p => p.Id == package.Id);
            if (packageToDelete == null)
            {
                throw new ArgumentException("The package to delete cannot be found.");
            }
            _appDbContext.Packages.Remove(packageToDelete);
            _appDbContext.SaveChanges();
        }

        public void EditPackage(Package package)
        {
            var packageToUpdate = _appDbContext.Packages.FirstOrDefault(p => p.Id == package.Id);

            if (packageToUpdate == null)
            {
                throw new ArgumentException("The person to update cannot be found.");
            }

            _appDbContext.Entry(packageToUpdate).CurrentValues.SetValues(package);

            _appDbContext.SaveChanges();
        }

        public IEnumerable<Package> GetAllPackages()
        {
            var packageItems = _appDbContext.Packages
                .OrderBy(p => p.Id)
                .AsNoTracking()
                .AsEnumerable<Package>();

            return packageItems;

        }

        public Package? GetPackageById(string id)
        {
            return _appDbContext.Packages
                .Include(p => p.Receiver)
                .Include(p => p.Sender)
                .FirstOrDefault(p => p.Id.ToString() == id);
        }
    }
}
