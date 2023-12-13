using CarManagement.Enums.Wheel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Objects
{
    // Internal class representing a wheel entity
    internal class Wheel
    {
        // Properties of the Wheel class
        public int Id { get; }                     // Property for the ID of the wheel
        public WheelTypeEnum WheelType { get; }    // Property for the type of the wheel using WheelTypeEnum
        public TireBrandEnum TireBrand { get; }    // Property for the brand of the Tire using TireBrandEnum
        public TirePlacementEnum TirePlacement { get; } // Property for the placement of the Tire using TirePlacementEnum
        public TireSizeEnum TireSize { get; }      // Property for the size of the Tire using TireSizeEnum
        public double TirePressure { get; }        // Property for the Tire Pressure of the wheel

        // Constructor for initializing the Wheel object with various properties
        public Wheel(int id, WheelTypeEnum wheelType, TireBrandEnum tireBrand, TirePlacementEnum tirePlacement, TireSizeEnum tireSize, double tirePressure)
        {
            Id = id;                                // Initializing the ID property
            WheelType = wheelType;                  // Initializing the WheelType property
            TireBrand = tireBrand;                  // Initializing the TireBrand property
            TirePlacement = tirePlacement;          // Initializing the TirePlacement property
            TireSize = tireSize;                    // Initializing the TireSize property
            TirePressure = tirePressure;            // Initializing the TirePressure property
        }
    }
}

