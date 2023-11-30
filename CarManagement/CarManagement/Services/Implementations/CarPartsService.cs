using CarManagement.Enums.Wheel;
using CarManagement.Objects;
using CarManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Services.Implementations
{
    // Internal class representing a service for handling car parts
    internal class CarPartsService : ICarPartsService // Implements the ICarPartsService interface
    {
        // Lists to store Wheel and Oil objects
        List<Wheel> wheels = new List<Wheel>(); // Initialization of the list to store Wheel objects
        List<Oil> oilQualities = new List<Oil>(); // Initialization of the list to store Oil objects

        // Constructor for CarPartsService class
        public CarPartsService()
        {
            // Making Wheel objects and adding them to the 'wheels' list
            wheels.Add(new Wheel(1, WheelTypeEnum.WholeYear, TyreBrandEnum.Goodyear, TyrePlacementEnum.FrontLeft, TyreSizeEnum.Sixteen));
            wheels.Add(new Wheel(2, WheelTypeEnum.WholeYear, TyreBrandEnum.Goodyear, TyrePlacementEnum.FrontRight, TyreSizeEnum.Sixteen));
            wheels.Add(new Wheel(3, WheelTypeEnum.WholeYear, TyreBrandEnum.Goodyear, TyrePlacementEnum.RearLeft, TyreSizeEnum.Sixteen));
            wheels.Add(new Wheel(4, WheelTypeEnum.WholeYear, TyreBrandEnum.Goodyear, TyrePlacementEnum.RearRight, TyreSizeEnum.Sixteen));

            // Making Oil objects and adding them to the 'oilQualities' list
            oilQualities.Add(new Oil(1, Enums.Oil.OilQualityEnum.Bad));
            oilQualities.Add(new Oil(2, Enums.Oil.OilQualityEnum.Okay));
            oilQualities.Add(new Oil(3, Enums.Oil.OilQualityEnum.Good));
        }

        // Method to retrieve the list of Wheel objects
        public List<Wheel> GetWheels()
        {
            return wheels; // Returns the list of wheels
        }

        // Method to retrieve the list of Oil objects
        public List<Oil> GetOil()
        {
            return oilQualities; // Returns the list of oil qualities
        }
    }
}
