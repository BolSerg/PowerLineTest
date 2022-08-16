using PowerLineTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerLineTest.Implementations
{
    /// <summary>
    /// Класс грузового автомобиля
    /// </summary>
    public class CargoCar : Car, ICargoCar
    {
        public override CarType CarType => CarType.CargoCar;
        /// <summary>
        /// Максимальная грузоподъёмность
        /// </summary>
        public double MaxCargoWeight { get; set; }
        public CargoCar(double medianFuelConsumption, double fuelTankVolume, 
            double currentFuelVolume, double speed, double cargoWeight,
            double fuelConsumptionMeasure = 100) 
            : base(medianFuelConsumption, fuelTankVolume, currentFuelVolume,
                  speed, fuelConsumptionMeasure)
        {
            MaxCargoWeight = cargoWeight;
        }

        public override double GetTravelDistanceByCargoAndPassengers(int passengers, double cargo)
        {
            if (cargo > MaxCargoWeight || cargo < 0)
                throw new InvalidOperationException("Некорректный вес груза");
            var baseDistance = base.GetTravelDistanceByCargoAndPassengers(passengers, cargo);
            return baseDistance - (cargo % 200) * 0.04 * baseDistance;
        }
    }
}
