using CargoTransportation.Data.Interfaces;
using CargoTransportation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CargoTransportation.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
         
        // VEHICLE DRIVERS
        public async Task<IActionResult> VehicleDrivers(int id, string modelAndNumber)
        {
            ViewBag.ModelAndNumber = modelAndNumber;
            TempData["currentDriverOrVehicleId"] = id;
            var vehicles = await _vehicleRepository.GetDriversByVehicleIdAsync(id);
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
            var vehicles = await _vehicleRepository.GetAllVehiclesAsync();
            if (vehicles != null)
            {
                return View(vehicles);
            }
            else
            {
                return NotFound();
            }
        }

        // DETAILS
        public async Task<IActionResult> Details(int id)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
            if (vehicle != null)
            {
                return View(vehicle);
            }
            else
            {
                return NotFound();
            }
        }

        // CREATE
        public IActionResult Create()
        {
            Vehicle vehicle = new Vehicle();
            return View(vehicle);
        }
        [HttpPost]
        public IActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid == false)
            {
                return View(vehicle);
            }
            _vehicleRepository.CreateVehicle(vehicle);
            return RedirectToAction("Details", new { id = vehicle.Id });
        }

        // EDIT
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
            if (vehicle != null)
            {
                return View(vehicle);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid == false)
            {
                return View(vehicle);
            }

            if (_vehicleRepository.VehicleExists(vehicle.Id))
            {
                _vehicleRepository.UpdateVehicle(vehicle);
                return RedirectToAction("Details", new { id = vehicle.Id });
            }
            else
            {
                return NotFound();
            }
        }

        //DELETE 
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
            if (vehicle != null)
            {
                return View(vehicle);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Delete(Vehicle vehicle)
        {
            if (_vehicleRepository.VehicleExists(vehicle.Id))
            {
                _vehicleRepository.DeleteVehicle(vehicle);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

    }
}
