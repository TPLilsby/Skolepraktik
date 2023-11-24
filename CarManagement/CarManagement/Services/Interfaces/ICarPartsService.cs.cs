using CarManagement.Enums.Oil;
using CarManagement.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Services.Interfaces
{
    internal interface ICarPartsService
    {
        List<Wheel> GetWheels();

        List<Oil> GetOil();
    }
}
