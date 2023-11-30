using CarManagement.Enums.Oil;
using CarManagement.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Services.Interfaces
{
    // Internal interface defining the contract for a service handling car parts
    internal interface ICarPartsService
    {
        // Method declaration to retrieve a list of wheels
        List<Wheel> GetWheels(); // This method returns a list of Wheel objects

        // Method declaration to retrieve a list of oil qualities
        List<Oil> GetOil(); // This method returns a list of Oil objects
    }
}
