using System;
using AutoMapper;
using lab3.Data;
using lab3.Dtos;
using lab3.Interfaces;
using lab3.Models;
using lab3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Tree;
using MongoDB.Bson;

namespace lab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPackageService _packageService;

        public PackageController(IMapper mapper, IPackageService packageService)
        {
            _mapper = mapper;
            _packageService = packageService;
        }


        [HttpPut("{id}")]
        public ActionResult<Package> ReturnPackage(string id)
        {


            var packageItem = _packageService.ReturnPackage(id);
            if (packageItem == null)
            {
                return NotFound();
            }

            return Ok(packageItem);

        }

        // POST api/package
        [HttpPost]
        public ActionResult<Package> CreatePackage([FromBody] PackageCreateDto packageCreateDto)
        {
            var packageModel = _mapper.Map<Package>(packageCreateDto);


            packageModel = _packageService.SendPackage(packageModel);
            var packageReadDto = _mapper.Map<PackageReadDto>(packageModel);
            return CreatedAtRoute(nameof(GetPackageById), new { Id = packageReadDto.Id }, packageReadDto);
        }

        // GET api/package/{id}
        [HttpGet("{id}", Name = "GetPackageById")]
        public ActionResult<Package> GetPackageById(string id)
        {
            var packageItem = _packageService.GetPackageById(id);

            if (packageItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PackageReadDto>(packageItem));

        }
        [HttpPut("{id}/Deliver")]
        public ActionResult<Package> DeliverPackage(string id)
        {
            PackageReadDto package = null;
            try
            {
                package = _packageService.ReceivePackage(id);
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
            if (package == null)
            {
                return NotFound();
            }


            return Ok(package);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PackageReadDto>> GetPackages()
        {
            var packageItems = _packageService.GetPackages();

            return Ok(packageItems.Select(p => _mapper.Map<PackageReadDto>(p)));
        }

    }
}
