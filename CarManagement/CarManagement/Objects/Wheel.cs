using CarManagement.Enums.Wheel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Objects
{
    internal class Wheel
    {
        public int Id { get; }
        public WheelTypeEnum WheelType { get; }
        public TyreBrandEnum TyreBrand { get; }
        public TyrePlacementEnum TyrePlacement { get; }
        public TyreSizeEnum TyreSize { get; }

        public Wheel (int id, WheelTypeEnum wheelType, TyreBrandEnum tyreBrand, TyrePlacementEnum tyrePlacement, TyreSizeEnum tyreSize)
        {
            Id = id;
            WheelType = wheelType;
            TyreBrand = tyreBrand;
            TyrePlacement = tyrePlacement;
            TyreSize = tyreSize;
        }
    }
}
