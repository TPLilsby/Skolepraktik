using CarManagement.Enums.Car;
using CarManagement.Enums.Wheel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarManagement.Objects
{
    /// <summary>
    /// This class represents different cars and their specifications for the manual.
    /// </summary>
    internal class Car
    {
        // Main properties representing car details for the manual
        public int Id { get; set; }                    // Unique identifier for the car
        public string Brand { get; set; }              // Brand of the car
        public string Model { get; set; }              // Model of the car

        // Parts on the car
        public TyreSizeEnum TyreSize { get; set; }     // Size of the car's tires
        public int TyrePressureMin { get; set; }       // Minimum tire pressure
        public int TyrePressureMax { get; set; }       // Maximum tire pressure
        public double TotalOilCapacity { get; set; }   // Total oil capacity of the car
        public int NumberOfLights { get; set; }        // Number of lights in the car

        // Constructor to initialize the Car object with specified details
        public Car(int id, string brand, string model, TyreSizeEnum tyreSize, int tyrePressureMin, int tyrePressureMax, double totalOilCapacity, int numberOfLights)
        {
            // Initializing the properties of the Car object
            Id = id;
            Brand = brand;
            Model = model;
            TyreSize = tyreSize;
            TyrePressureMin = tyrePressureMin;
            TyrePressureMax = tyrePressureMax;
            TotalOilCapacity = totalOilCapacity;
            NumberOfLights = numberOfLights;
        }
    }
}

