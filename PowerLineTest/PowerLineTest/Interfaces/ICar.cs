using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerLineTest.Interfaces
{
    /// <summary>
    /// Базовый интерфейс для автомобилей
    /// </summary>
    public interface ICar
    {
        /// <summary>
        /// Получение дистанции перемещения с полным баком
        /// </summary>
        /// <returns></returns>
        public double GetTravelDistanceWithFullFuel();

        /// <summary>
        /// Получение дистанции перемещения с текущим запасом топлива
        /// </summary>
        /// <returns>
        public double GetTravelDistanceWithCurrentFuel();

        /// <summary>
        /// Получение времени, затрачиваемого на указанный путь с указанным количеством топлива
        /// </summary>
        /// <returns>
        public double GetTravelTimeByRangeAndFuel(double range, double fuel);

        /// <summary>
        /// Получение дистанции перемещения с текущим запасом топлива с учётом пассажиров и груза
        /// </summary>
        /// <returns>
        public double GetTravelDistanceByCargoAndPassengers(int passengers, double cargo);
    }
}
