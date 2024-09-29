using CargoTransportation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoTransportation.Data.Interfaces
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> GetAllDriversAsync();
        Task<Driver> GetDriverByIdAsync(int id);
        Task<IEnumerable<Vehicle>> GetVehiclesByDriverIdAsync(int driverId);
        bool CreateDriver(Driver driver);
        bool UpdateDriver(Driver driver);
        bool DeleteDriver(Driver driver);
        bool Save();
        bool DriverExists(int driverId);

    }
}
