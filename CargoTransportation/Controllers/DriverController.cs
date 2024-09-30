using CargoTransportation.Data.Interfaces;
using CargoTransportation.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CargoTransportation.Controllers
{
    public class DriverController : Controller
    {
        private readonly IDriverRepository _driverRepository;
        public DriverController(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        // DRIVER VEHICLES
        public async Task<IActionResult> DriverVehicles(int id, string name)
        {
            ViewBag.Name = name;
            TempData["currentDriverOrVehicleId"] = id;
            var vehicles = await _driverRepository.GetVehiclesByDriverIdAsync(id);
            if (vehicles != null)
            {
                return View(vehicles);
            }
            else
            {
                return NotFound();
            }
        }

        // INDEX
        public async Task<IActionResult> Index()
        {
            IEnumerable<Driver> drivers = await _driverRepository.GetAllDriversAsync();
            if (drivers != null)
            {
                return View(drivers);
            }
            else
            {
                return NotFound();
            }
        }

        // DETAILS
        public async Task<IActionResult> Details(int id)
        {          
            Driver driver = await _driverRepository.GetDriverByIdAsync(id);
            if (driver != null)
            {
                return View(driver);
            }
            else
            {
                return NotFound();
            }
        }

        // CREATE
        public IActionResult Create()
        {
            Driver driver = new Driver();
            return View(driver);
        }
        [HttpPost]
        public IActionResult Create(Driver driver)
        {
            if (ModelState.IsValid == false)
            {
                return View(driver);
            }        

            _driverRepository.CreateDriver(driver);
            return RedirectToAction("Details", new { id = driver.Id });
        }

        // EDIT
        public async Task<IActionResult> Edit(int id)
        {
            Driver driver = await _driverRepository.GetDriverByIdAsync(id);
            if (driver != null)
            {
                return View(driver);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(Driver driver)
        {
            if (ModelState.IsValid == false)
            {
                return View(driver);
            }

            if (_driverRepository.DriverExists(driver.Id))
            {
                _driverRepository.UpdateDriver(driver);
                return RedirectToAction("Details", new { id = driver.Id });
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            Driver driver = await _driverRepository.GetDriverByIdAsync(id);
            if (driver != null)
            {
                return View(driver);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Delete(Driver driver)
        {
            if (_driverRepository.DriverExists(driver.Id))
            {                
                _driverRepository.DeleteDriver(driver);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
