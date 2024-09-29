using CargoTransportation.Models;

namespace CargoTransportation.Data.Interfaces
{
    public interface IDriverVehicleRepository
    {
        bool Create(DriverVehicle driverVehicle);
        bool Delete(DriverVehicle driverVehicle);
        bool Save();
        bool Exists(DriverVehicle driverVehicle);

    }
}
