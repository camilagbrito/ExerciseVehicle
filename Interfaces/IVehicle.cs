using E07_Vehicle.Enums;
using E07_Vehicle.Models;
using System;

namespace E07_Vehicle
{
    internal interface IVehicle
    {
        Brand Brand { get; }
        Model Model { get; }
        Color Color { get; }
        string LicencePlate { get; }
        int Displacement { get; }
        int Speed { get; }
        DateTime RegistrationDate { get; }

        void Create();
        void Stop(Vehicle vehicle);
        void SpeedUp(Vehicle vehicle, int value);
        void SpeedDown(Vehicle vehicle, int value);

    }
}
