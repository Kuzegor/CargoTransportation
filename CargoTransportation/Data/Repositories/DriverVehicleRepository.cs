using CargoTransportation.Data.Interfaces;
using CargoTransportation.Models;
using System.Linq;

namespace CargoTransportation.Data.Repositories
{
    public class DriverVehicleRepository : IDriverVehicleRepository
    {
        private readonly CargoDbContext _context;
        public DriverVehicleRepository(CargoDbContext context)
        {
            _context = context;
        }
        public bool Create(DriverVehicle driverVehicle)
        {
            _context.Add(driverVehicle);
            return Save();
        }

        public bool Delete(DriverVehicle driverVehicle)
        {
            _context.Remove(driverVehicle);
            return Save();
        }

        public bool Exists(DriverVehicle driverVehicle)
        {
            return _context.DriverVehicles.Any(dv => (dv.VehicleId == driverVehicle.VehicleId)&&(dv.DriverId == driverVehicle.DriverId));
        }

        public bool Save()
        {
            int savedChanges = _context.SaveChanges();
            return savedChanges > 0 ? true : false;
        }
    }
}
