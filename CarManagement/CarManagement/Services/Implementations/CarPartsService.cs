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

        Random rndTirePressure = new Random(); // Random instance to generate tire pressures

        // Lists to store wheels categorized by seasons
        List<Wheel> summerWheels = new List<Wheel>(); // List to store summer wheels
        List<Wheel> winterWheels = new List<Wheel>(); // List to store winter wheels
        List<Wheel> wholeYearWheels = new List<Wheel>(); // List to store wheels suitable for the whole year

        // Constructor for CarPartsService class
        public CarPartsService()
        {
            // Creating Wheel objects and adding them to the 'wheels' list
            wheels.Add(new Wheel(1, WheelTypeEnum.WholeYear, TireBrandEnum.Goodyear, TirePlacementEnum.FrontLeft, TireSizeEnum.Sixteen, rndTirePressure.Next(35, 70)));
            wheels.Add(new Wheel(2, WheelTypeEnum.WholeYear, TireBrandEnum.Goodyear, TirePlacementEnum.FrontRight, TireSizeEnum.Sixteen, rndTirePressure.Next(35, 70)));
            wheels.Add(new Wheel(3, WheelTypeEnum.WholeYear, TireBrandEnum.Goodyear, TirePlacementEnum.RearLeft, TireSizeEnum.Sixteen, rndTirePressure.Next(35, 60)));
            wheels.Add(new Wheel(4, WheelTypeEnum.WholeYear, TireBrandEnum.Goodyear, TirePlacementEnum.RearRight, TireSizeEnum.Sixteen, rndTirePressure.Next(35, 60)));

            // Creating Oil objects and adding them to the 'oilQualities' list
            oilQualities.Add(new Oil(1, Enums.Oil.OilQualityEnum.Bad));
            oilQualities.Add(new Oil(2, Enums.Oil.OilQualityEnum.Okay));
            oilQualities.Add(new Oil(3, Enums.Oil.OilQualityEnum.Good));

            #region Adding wheels to specific wheel type
            // Adding Wheel objects for summer wheels
            summerWheels.Add(new Wheel(1, WheelTypeEnum.Summer, TireBrandEnum.Michelin, TirePlacementEnum.FrontLeft, TireSizeEnum.Sixteen, rndTirePressure.Next(35, 70)));
            summerWheels.Add(new Wheel(2, WheelTypeEnum.Summer, TireBrandEnum.Michelin, TirePlacementEnum.FrontRight, TireSizeEnum.Sixteen, rndTirePressure.Next(35, 70)));
            summerWheels.Add(new Wheel(3, WheelTypeEnum.Summer, TireBrandEnum.Michelin, TirePlacementEnum.RearLeft, TireSizeEnum.Sixteen, rndTirePressure.Next(35, 70)));
            summerWheels.Add(new Wheel(4, WheelTypeEnum.Summer, TireBrandEnum.Michelin, TirePlacementEnum.RearRight, TireSizeEnum.Sixteen, rndTirePressure.Next(35, 70)));

            // Adding Wheel objects for winter wheels
            winterWheels.Add(new Wheel(1, WheelTypeEnum.Winter, TireBrandEnum.Bridgestone, TirePlacementEnum.FrontLeft, TireSizeEnum.Eighteen, rndTirePressure.Next(35, 70)));
            winterWheels.Add(new Wheel(2, WheelTypeEnum.Winter, TireBrandEnum.Bridgestone, TirePlacementEnum.FrontRight, TireSizeEnum.Eighteen, rndTirePressure.Next(35, 70)));
            winterWheels.Add(new Wheel(3, WheelTypeEnum.Winter, TireBrandEnum.Bridgestone, TirePlacementEnum.RearLeft, TireSizeEnum.Eighteen, rndTirePressure.Next(35, 70)));
            winterWheels.Add(new Wheel(4, WheelTypeEnum.Winter, TireBrandEnum.Bridgestone, TirePlacementEnum.RearRight, TireSizeEnum.Eighteen, rndTirePressure.Next(35, 70)));

            // Adding Wheel objects for whole-year wheels
            wholeYearWheels.Add(new Wheel(1, WheelTypeEnum.WholeYear, TireBrandEnum.Continental, TirePlacementEnum.FrontLeft, TireSizeEnum.Seventeen, rndTirePressure.Next(35, 70)));
            wholeYearWheels.Add(new Wheel(2, WheelTypeEnum.WholeYear, TireBrandEnum.Continental, TirePlacementEnum.FrontRight, TireSizeEnum.Seventeen, rndTirePressure.Next(35, 70)));
            wholeYearWheels.Add(new Wheel(3, WheelTypeEnum.WholeYear, TireBrandEnum.Continental, TirePlacementEnum.RearLeft, TireSizeEnum.Seventeen, rndTirePressure.Next(35, 70)));
            wholeYearWheels.Add(new Wheel(4, WheelTypeEnum.WholeYear, TireBrandEnum.Continental, TirePlacementEnum.RearRight, TireSizeEnum.Seventeen, rndTirePressure.Next(35, 70)));
            #endregion
        }

        #region GetWheels Methods
        // Method to retrieve the list of all Wheel objects
        public List<Wheel> GetWheels()
        {
            return wheels; // Returns the list of wheels
        }

        // Method to retrieve the list of summer Wheel objects
        public List<Wheel> GetSummerWheels()
        {
            return summerWheels; // Returns the list of summer wheels
        }

        // Method to retrieve the list of winter Wheel objects
        public List<Wheel> GetWinterWheels()
        {
            return winterWheels; // Returns the list of winter wheels
        }

        // Method to retrieve the list of whole-year Wheel objects
        public List<Wheel> GetWholeYearWheels()
        {
            return wholeYearWheels; // Returns the list of whole-year wheels
        }
        #endregion


        // Method to retrieve the list of Oil objects
        public List<Oil> GetOil()
        {
            return oilQualities; // Returns the list of oil qualities
        }


    }
}

