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
    internal class CarPartsService : ICarPartsService
    {
        List<Wheel> wheels = new List<Wheel>();
        List<Oil> oilQualities = new List<Oil>();

        public CarPartsService() { 
            
            //Making wheel opbjects & adds to a list named wheels
            wheels.Add(new Wheel(1, WheelTypeEnum.WholeYear, TyreBrandEnum.Goodyear, TyrePlacementEnum.FrontLeft, TyreSizeEnum.Sixteen));
            wheels.Add(new Wheel(2, WheelTypeEnum.WholeYear, TyreBrandEnum.Goodyear, TyrePlacementEnum.FrontRight, TyreSizeEnum.Sixteen));
            wheels.Add(new Wheel(3, WheelTypeEnum.WholeYear, TyreBrandEnum.Goodyear, TyrePlacementEnum.RearLeft, TyreSizeEnum.Sixteen));
            wheels.Add(new Wheel(4, WheelTypeEnum.WholeYear, TyreBrandEnum.Goodyear, TyrePlacementEnum.RearRight, TyreSizeEnum.Sixteen));

            //Making oil objects and adds to a list named oilQualities
            oilQualities.Add(new Oil(1, Enums.Oil.OilQualityEnum.Bad));
            oilQualities.Add(new Oil(2, Enums.Oil.OilQualityEnum.Okay));
            oilQualities.Add(new Oil(3, Enums.Oil.OilQualityEnum.Good));
        }

        public List<Wheel> GetWheels() {  return wheels; }

        public List<Oil> GetOil() { return oilQualities; }
    }
}
