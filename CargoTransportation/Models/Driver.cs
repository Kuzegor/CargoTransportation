using System;
using System.Collections.Generic;

namespace CargoTransportation.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<DriverVehicle> DriverVehicles { get; set; }

    }
}
