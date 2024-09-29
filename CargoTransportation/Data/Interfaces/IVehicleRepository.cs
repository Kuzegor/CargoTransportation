using CargoTransportation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoTransportation.Data.Interfaces
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task<IEnumerable<Driver>> GetDriversByVehicleIdAsync(int vehicleId);
        bool CreateVehicle(Vehicle vehicle);
        bool UpdateVehicle(Vehicle vehicle);
        bool DeleteVehicle(Vehicle vehicle);
        bool Save();
        bool VehicleExists(int vehicleId);
    }
}
