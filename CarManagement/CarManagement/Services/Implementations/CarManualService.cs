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

        // List to store specific instances of a Toyota Yaris
        List<Car> toyotaYarisList = new List<Car>();

        // Constructor for CarManualService class
        public CarManualService()
        {
            // Creating specific instances of cars
            Car fordTransitCustom = new Car(1, "Ford", "Transit Custom", 130,
                Enums.Wheel.TyreSizeEnum.Sixteen, 40, 60, 9.80, 8); // Ford Transit Custom

            Car toyotaYaris = new Car(2, "Toyota", "Yaris", 72,
                Enums.Wheel.TyreSizeEnum.Fiveteen, 30, 50, 2.80, 8); // and Toyota Yaris

            // Adds the newly created cars to the general list of cars
            cars.Add(fordTransitCustom); // Adding Ford Transit Custom to the list of cars
            cars.Add(toyotaYaris); // Adding Toyota Yaris to the list of cars

            // Adds the Ford Transit Custom instance to its specific list
            fordTransitCustomList.Add(fordTransitCustom); // Adding Ford Transit Custom to its specific list

            // Adds the Toyota Yaris instance to its specific list
            toyotaYarisList.Add(toyotaYaris); // Adding Toyota Yaris to its specific list
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

                case 2:
                    // If the ID is 2, return details of another specific car (e.g., Toyota Yaris)
                    return toyotaYarisList; // Returns specific car details if the ID matches

                case 3:
                    return cars;

                // Default case when the entered ID doesn't match any predefined cases
                default:
                    // Return a default list or handle the case accordingly
                    return cars; // Returns the general list of cars if ID doesn't match any specific case
            }

            // If the entered ID doesn't match, return the general list of cars
            return cars; // Returns the general list of cars if ID doesn't match
        }

    }
}