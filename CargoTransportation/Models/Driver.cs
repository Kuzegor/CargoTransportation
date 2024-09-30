using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CargoTransportation.Models
{
    public class Driver
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить это поле")]
        [MaxLength(30, ErrorMessage = "Введите не более 30 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить это поле")]
        [RegularExpression(@"^[0-9+]+$", ErrorMessage = "Вы можете ввести только цифры и '+'")]
        [MaxLength(12,ErrorMessage = "Введите не более 12 символов")]
        [MinLength(11, ErrorMessage = "Введите не менее 11 символов")]
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage = "Введите действительный email")]
        [Required(ErrorMessage = "Необходимо заполнить это поле")]
        [MaxLength(100, ErrorMessage = "Введите не более 100 символов")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить это поле")]
        [MaxLength(100, ErrorMessage = "Введите не более 100 символов")]
        public string Address { get; set; }
        public ICollection<DriverVehicle> DriverVehicles { get; set; }

    }
}
