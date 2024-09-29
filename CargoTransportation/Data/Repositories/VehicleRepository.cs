using CargoTransportation.Data.Interfaces;
using CargoTransportation.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoTransportation.Data.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly CargoDbContext _context;
        public VehicleRepository(CargoDbContext context)
        {
            _context = context;
        }
        public bool CreateVehicle(Vehicle vehicle)
        {
            _context.Add(vehicle);
            return Save();
        }

        public bool DeleteVehicle(Vehicle vehicle)
        {
            _context.Remove(vehicle);
            return Save();
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<IEnumerable<Driver>> GetDriversByVehicleIdAsync(int vehicleId)
        {
            return await _context.DriverVehicles.Where(dv => dv.VehicleId == vehicleId).Select(dv => dv.Driver).ToListAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            return await _context.Vehicles.Where(v => v.Id == id).FirstOrDefaultAsync();
        }

        public bool Save()
        {
            int savedChanges = _context.SaveChanges();
            return savedChanges > 0 ? true : false;
        }

        public bool UpdateVehicle(Vehicle vehicle)
        {
            _context.Update(vehicle);
            return Save();
        }

        public bool VehicleExists(int vehicleId)
        {
            return _context.Vehicles.Any(v => v.Id == vehicleId);
        }
    }
}
