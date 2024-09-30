using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CargoTransportation.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [MaxLength(30, ErrorMessage = "Введите не более 30 символов")]
        [Required(ErrorMessage = "Необходимо заполнить это поле")]
        public string Make { get; set; }
        [MaxLength(30, ErrorMessage = "Введите не более 30 символов")]
        [Required(ErrorMessage = "Необходимо заполнить это поле")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить это поле")]
        [MaxLength(20, ErrorMessage = "Введите не более 20 символов")]
        public string RegistrationNumber { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить это поле")]
        public double CarryingCapacity { get; set; }
        public ICollection<DriverVehicle> VehicleDrivers { get; set; }
        public string ModelAndNumber {
            get
            {
                return Model + " (" + RegistrationNumber + ")";
            } 
        }

    }
}
