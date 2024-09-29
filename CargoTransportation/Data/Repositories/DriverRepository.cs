using CargoTransportation.Data.Interfaces;
using CargoTransportation.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoTransportation.Data.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly CargoDbContext _context;
        public DriverRepository(CargoDbContext context)
        {
            _context = context;
        }

        public bool CreateDriver(Driver driver)
        {
            _context.Add(driver);
            return Save();
        }

        public bool DeleteDriver(Driver driver)
        {
            _context.Remove(driver);
            return Save();
        }

        public bool DriverExists(int driverId)
        {
            return _context.Drivers.Any(d => d.Id == driverId);
        }

        public async Task<IEnumerable<Driver>> GetAllDriversAsync()
        {
            return await _context.Drivers.ToListAsync();
        }

        public async Task<Driver> GetDriverByIdAsync(int id)
        {
            return await _context.Drivers.Where(d => d.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByDriverIdAsync(int driverId)
        {
            return await _context.DriverVehicles.Where(dv => dv.DriverId == driverId).Select(v => v.Vehicle).ToListAsync();
        }

        public bool Save()
        {
            int savedChanges = _context.SaveChanges();
            return savedChanges > 0 ? true : false;
        }

        public bool UpdateDriver(Driver driver)
        {
            _context.Update(driver);
            return Save();
        }
    }
}
