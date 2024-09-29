using CargoTransportation.Models;
using Microsoft.EntityFrameworkCore;

namespace CargoTransportation.Data
{
    public class CargoDbContext : DbContext
    {
        public CargoDbContext(DbContextOptions<CargoDbContext> options) : base(options)
        {

        }

        public DbSet<Driver> Drivers { get; set;}
        public DbSet<Vehicle> Vehicles { get; set;}
        public DbSet<DriverVehicle> DriverVehicles { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DriverVehicle>()
                .HasKey(driverVehicle => new { driverVehicle.DriverId, driverVehicle.VehicleId });
            modelBuilder.Entity<DriverVehicle>()
                .HasOne(driverVehicle => driverVehicle.Driver)
                .WithMany(driver => driver.DriverVehicles)
                .HasForeignKey(driverVehicle => driverVehicle.DriverId);
            modelBuilder.Entity<DriverVehicle>()
                .HasOne(driverVehicle => driverVehicle.Vehicle)
                .WithMany(vehicle => vehicle.VehicleDrivers)
                .HasForeignKey(driverVehicle => driverVehicle.VehicleId);
        }
    }
}
