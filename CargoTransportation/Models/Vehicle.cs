using System.Collections.Generic;

namespace CargoTransportation.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        public double CarryingCapacity { get; set; }
        public ICollection<DriverVehicle> VehicleDrivers { get; set; }

    }
}
