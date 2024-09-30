using CargoTransportation.Data.Interfaces;
using CargoTransportation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CargoTransportation.Controllers
{
    public class DriverVehicleController : Controller
    {
        private readonly IDriverVehicleRepository _driverVehicleRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly IVehicleRepository _vehicleRepository;
        public DriverVehicleController(IDriverVehicleRepository driverVehicleRepository, IDriverRepository driverRepository, IVehicleRepository vehicleRepository)
        {
            _driverVehicleRepository = driverVehicleRepository;
            _driverRepository = driverRepository;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IActionResult> Create()
        {
            var drivers = await _driverRepository.GetAllDriversAsync();
            var vehicles = await _vehicleRepository.GetAllVehiclesAsync();
            ViewBag.Drivers = new SelectList(drivers, "Id", "Name");
            ViewBag.Vehicles = new SelectList(vehicles, "Id", "ModelAndNumber");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int driverId, int vehicleId)
        {
            var driverVehicle = new DriverVehicle
            {
                DriverId = driverId,
                VehicleId = vehicleId
            };

            if (_driverVehicleRepository.Exists(driverVehicle) == false) 
            {
                _driverVehicleRepository.Create(driverVehicle);
                return RedirectToAction("DriverVehicles","Driver", new {id = driverId});
            }
            else
            {
                return RedirectToAction("DriverVehicles", "Driver", new { id = driverId });
            }
        }

        public IActionResult Delete(int driverId, int vehicleId)
        {
            var driverVehicle = new DriverVehicle
            {
                DriverId = driverId,
                VehicleId = vehicleId
            };
            return View(driverVehicle);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteDriverVehicle(DriverVehicle driverVehicle)
        {

            if (_driverVehicleRepository.Exists(driverVehicle) == true)
            {
                _driverVehicleRepository.Delete(driverVehicle);
                return RedirectToAction("DriverVehicles", "Driver", new { id = driverVehicle.DriverId });
            }
            else
            {
                return RedirectToAction("DriverVehicles", "Driver", new { id = driverVehicle.DriverId });
            }
        }
    }
}
