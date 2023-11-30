using CarManagement.Enums.Oil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Objects
{
    // Internal class representing an oil entity
    internal class Oil
    {
        // Properties of the Oil class
        public int Id { get; }                    // Property for the ID of the oil
        public OilQualityEnum Quality { get; }    // Property for the quality of the oil using OilQualityEnum

        // Constructor for initializing the Oil object with an ID and quality
        public Oil(int id, OilQualityEnum quality)
        {
            Id = id;             // Initializing the ID property
            Quality = quality;   // Initializing the Quality property
        }
    }
}