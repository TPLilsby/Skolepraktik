using CarManagement.Objects;
using CarManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Services.Implementations
{
    // Internal class for managing car manual-related services
    internal class CarManualService : ICarManualService // Implements the ICarManualService interface
    {
        // List to store cars
        List<Car> cars = new List<Car>(); // Initialization of the list to store Car objects

        // Constructor for CarManualService class
        public CarManualService()
        {
            // Creating a specific car instance - Ford Transit Custom
            Car fordTransitCustom = new Car(1, "Ford", "Transit Custom", Enums.Wheel.TyreSizeEnum.Sixteen, 40, 60, 9.80, 8);

            // Adds the newly created car to the list
            cars.Add(fordTransitCustom); // Adding Ford Transit Custom to the list of cars
        }

        // Method to retrieve the list of cars
        public List<Car> GetCars()
        {
            return cars; // Returns the list of cars
        }
    }
}
