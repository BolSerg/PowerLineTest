using PowerLineTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerLineTest.Implementations
{
    /// <summary>
    /// Основной класс автомобиля
    /// </summary>
    public class Car : ICar
    {
        /// <summary>
        /// Тип ТС
        /// </summary>
        public virtual CarType CarType => CarType.BaseCar;
        
        /// <summary>
        /// Средний расход топлива
        /// </summary>
        public double MedianFuelConsumption { get; set; }

        /// <summary>
        /// Объём топливного бака
        /// </summary>
        public double FuelTankVolume { get; set; }

        /// <summary>
        /// Текущий запас топлива
        /// </summary>
        public double CurrentFuelVolume { get; set; }

        /// <summary>
        /// Скорость
        /// </summary>
        public double Speed    { get; set; }

        /// <summary>
        /// Дистанция измерения среднего расхода топлива
        /// </summary>
        public double FuelConsumptionMeasure { get; set; }

        public Car(double medianFuelConsumption, double fuelTankVolume, double currentFuelVolume,
            double speed, double fuelConsumptionMeasure = 100)
        {
            MedianFuelConsumption = medianFuelConsumption;
            FuelTankVolume = fuelTankVolume;
            CurrentFuelVolume = currentFuelVolume;
            Speed = speed;
            FuelConsumptionMeasure = fuelConsumptionMeasure;
            CheckSpeedAndConsumption();
        }

        public double GetTravelDistanceWithFullFuel()
        {
            return GetTravelDistanceByFuel(FuelTankVolume);
        }

        public double GetTravelDistanceWithCurrentFuel()
        {
            return GetTravelDistanceByFuel(CurrentFuelVolume);
        }

        public double GetTravelTimeByRangeAndFuel(double range, double fuel)
        {
            if (range > GetTravelDistanceWithFullFuel() || range > GetTravelDistanceByFuel(fuel))
                throw new InvalidOperationException("Автомобиль не может проехать такую дистанцию с указанным количеством топлива");
            CheckSpeedAndConsumption();
            return range / Speed;
        }

        public virtual double GetTravelDistanceByCargoAndPassengers(int passengers, double cargo)
        {
            return (CurrentFuelVolume / MedianFuelConsumption) * FuelConsumptionMeasure;
        }

        private double GetTravelDistanceByFuel(double fuel)
        {
            
            return (fuel / MedianFuelConsumption) * FuelConsumptionMeasure;
        }

        private void CheckSpeedAndConsumption()
        {
            if (MedianFuelConsumption <= 0)
                throw new InvalidOperationException("Некорректный расход топлива");
            if (Speed <= 0)
                throw new InvalidOperationException("Некорректная скорость");
        }
    }
}
