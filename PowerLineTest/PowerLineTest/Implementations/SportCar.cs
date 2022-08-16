using PowerLineTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerLineTest.Implementations
{
    /// <summary>
    /// Класс для спортивного автомобиля
    /// </summary>
    public class SportCar : Car, ISportCar
    {
        public override CarType CarType => CarType.SportCar;
        public SportCar(double medianFuelConsumption, double fuelTankVolume, 
            double currentFuelVolume, double speed, double fuelConsumptionMeasure = 100) 
            : base(medianFuelConsumption, fuelTankVolume, currentFuelVolume, speed, fuelConsumptionMeasure)
        {
        }
    }
}
