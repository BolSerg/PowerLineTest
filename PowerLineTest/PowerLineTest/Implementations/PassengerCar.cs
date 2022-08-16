using PowerLineTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerLineTest.Implementations
{
    /// <summary>
    /// Класс легкового автомобиля
    /// </summary>
    public class PassengerCar : Car, IPassengerCar
    {
        public override CarType CarType => CarType.PassengerCar;
        /// <summary>
        /// Максимально допустимое число пассажиров
        /// </summary>
        public int PassengersMaximum { get; set; }
        public PassengerCar(double medianFuelConsumption, double fuelTankVolume,
            double currentFuelVolume, double speed, int passengers,
            double fuelConsumptionMeasure = 100) :
            base(medianFuelConsumption, fuelTankVolume, currentFuelVolume, speed, fuelConsumptionMeasure)
        {
            PassengersMaximum = passengers;
        }

        public override double GetTravelDistanceByCargoAndPassengers(int passengers, double cargo)
        {
            if (passengers > PassengersMaximum || passengers < 0)
                throw new InvalidOperationException("Некорректное число пассажиров");
            var baseDistance = base.GetTravelDistanceByCargoAndPassengers(passengers, cargo);
            return baseDistance - 0.06d * passengers * baseDistance;
        }
    }
}
