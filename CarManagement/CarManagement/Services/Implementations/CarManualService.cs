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

        // List to store specific instances of a Ford Transit Custom
        List<Car> fordTransitCustomList = new List<Car>();

        // Constructor for CarManualService class
        public CarManualService()
        {
            // Creating a specific car instance - Ford Transit Custom
            Car fordTransitCustom = new Car(1, "Ford", "Transit Custom", Enums.Wheel.TyreSizeEnum.Sixteen, 40, 60, 9.80, 8);

            // Adds the newly created car to the general list
            cars.Add(fordTransitCustom); // Adding Ford Transit Custom to the list of cars

            // Adds the Ford Transit Custom instance to its specific list
            fordTransitCustomList.Add(fordTransitCustom);
        }

        // Method to retrieve the general list of cars
        public List<Car> GetCars()
        {
            return cars; // Returns the list of all cars
        }

        // Method to get specific car details by ID
        public List<Car> GetCarById()
        {
            // Prompt the user to choose a car ID
            Console.Write("Choose Id on the car: ");
            int carIdInput = int.Parse(Console.ReadLine());

            Console.Clear(); // Clear the console screen

            // Check the car ID entered by the user
            switch (carIdInput)
            {
                case 1:
                    // If the ID is 1, return details of a specific car (e.g., Ford Transit Custom)
                    return fordTransitCustomList; // Returns specific car details if the ID matches
            }

            // If the entered ID doesn't match, return the general list of cars
            return cars; // Returns the general list of cars if ID doesn't match
        }

    }
}