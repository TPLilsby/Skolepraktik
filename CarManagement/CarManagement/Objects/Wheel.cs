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
        public TyreBrandEnum TyreBrand { get; }    // Property for the brand of the tyre using TyreBrandEnum
        public TyrePlacementEnum TyrePlacement { get; } // Property for the placement of the tyre using TyrePlacementEnum
        public TyreSizeEnum TyreSize { get; }      // Property for the size of the tyre using TyreSizeEnum

        // Constructor for initializing the Wheel object with various properties
        public Wheel(int id, WheelTypeEnum wheelType, TyreBrandEnum tyreBrand, TyrePlacementEnum tyrePlacement, TyreSizeEnum tyreSize)
        {
            Id = id;                               // Initializing the ID property
            WheelType = wheelType;                  // Initializing the WheelType property
            TyreBrand = tyreBrand;                  // Initializing the TyreBrand property
            TyrePlacement = tyrePlacement;          // Initializing the TyrePlacement property
            TyreSize = tyreSize;                    // Initializing the TyreSize property
        }
    }
}

