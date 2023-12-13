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
        public int HorsePower { get; set; }            // Horse power on the car

        // Parts on the car
        public TireSizeEnum TireSize { get; set; }     // Size of the car's tires
        public int TirePressureMin { get; set; }       // Minimum tire pressure
        public int TirePressureMax { get; set; }       // Maximum tire pressure
        public double TotalOilCapacity { get; set; }   // Total oil capacity of the car
        public int NumberOfLights { get; set; }        // Number of lights in the car

        // Constructor to initialize the Car object with specified details
        public Car(int id, string brand, string  model, int horsePower, TireSizeEnum tireSize, int tirePressureMin, int tirePressureMax, double totalOilCapacity, int numberOfLights)
        {
            Id = id;                                // Initializing the ID property
            Brand = brand;                          // Initializing the Brand property
            Model = model;                          // Initializing the Model property
            HorsePower = horsePower;                // Initializing the HorsePower property
            TireSize = tireSize;                    // Initializing the TireSize property
            TirePressureMin = tirePressureMin;      // Initializing the TirePressureMin property
            TirePressureMax = tirePressureMax;      // Initializing the TirePressureMax property
            TotalOilCapacity = totalOilCapacity;    // Initializing the TotalOilCapacity property
            NumberOfLights = numberOfLights;        // Initializing the  NumberOfLight property
        }
    }
}

