using System;
using AutoMapper;
using lab3.Dtos;
using lab3.Interfaces;
using lab3.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace lab3.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;
        private readonly DistanceCalculator _distanceCalculator;
        private readonly DateCalculator _dateCalculator;
        private readonly CostCalculator _costCalculator;
        private readonly IMapper _mapper;

        public PackageService(
            IPackageRepository packageRepository,
            DistanceCalculator distanceCalculator,
            DateCalculator dateCalculator,
            CostCalculator costCalculator,
            IMapper mapper)
        {
            _packageRepository = packageRepository;
            _distanceCalculator = distanceCalculator;
            _dateCalculator = dateCalculator;
            _costCalculator = costCalculator;
            _mapper = mapper;
        }

        public Package GetPackageById(string id)
        {
            var packageItem = _packageRepository.GetPackageById(id);

            if (packageItem == null)
            {
                return packageItem;
            }
            return packageItem;
        }

        public IEnumerable<Package> GetPackages()
        {
            var packageItems = _packageRepository.GetAllPackages();


            return packageItems;
        }

        public PackageReadDto ReceivePackage(string id)
        {
            var packageItem = _packageRepository.GetPackageById(id);

            if (packageItem == null)
            {
                return null;
            }

            // Check if the package is already delivered
            if (packageItem.DeliveryStatus == Data.Enums.Status.Received)
            {
                throw new ArgumentException("The package has already been delivered.");
            }

            // Update package status to Delivered
            packageItem.DeliveryStatus = Data.Enums.Status.Received;
            _packageRepository.EditPackage(packageItem);

            return _mapper.Map<PackageReadDto>(packageItem);
        }

        public PackageReadDto ReturnPackage(string id)
        {
            var packageItem = _packageRepository.GetPackageById(id);
            if (packageItem == null)
            {
                return null;
            }


            (packageItem.Sender, packageItem.Receiver) = (packageItem.Receiver, packageItem.Sender);


            packageItem.SentDate = DateTime.Now;
            packageItem.DeliveryDate = _dateCalculator.CalculateDeliveryDate(packageItem.SentDate, packageItem.Distance, 100);
            _packageRepository.EditPackage(packageItem);
            var response = _mapper.Map<PackageReadDto>(packageItem);
            return response;
        }

        public Package SendPackage(Package package)
        {
            package.Id = ObjectId.GenerateNewId();
            package.SentDate = DateTime.Now;
            package.Distance = _distanceCalculator.CalculateDistance(); // сервіс який може калькулювати відстань
            package.DeliveryDate = _dateCalculator.CalculateDeliveryDate(package.SentDate, package.Distance, 100);
            package.DeliveryStatus = Data.Enums.Status.Sent;
            double weight = 0;
            foreach (var item in package.Items)
            {
                weight += item.Weight;
            }
            package.DeliveryCost = _costCalculator.CalculateDeliveryCost(package.Distance, weight, 5);
            _packageRepository.AddPackage(package);
            return package;
        }
    }
}
