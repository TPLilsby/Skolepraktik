using CarManagement.Enums.Oil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Objects
{
    internal class Oil
    {
        public int Id { get; }
        public OilQualityEnum Quality { get; }

       
        public Oil (int id, OilQualityEnum quality)
        {
            Id = id;
            Quality = quality;
        }
    }
}
