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
        List<Wheel> GetWheels(); // Retrieves a list of all available wheels.

        // Method to retrieve a list of summer wheels
        List<Wheel> GetSummerWheels(); // Retrieves a list of summer wheels.

        // Method to retrieve a list of winter wheels
        List<Wheel> GetWinterWheels(); // Retrieves a list of winter wheels.

        // Method to retrieve a list of whole-year wheels
        List<Wheel> GetWholeYearWheels(); // Retrieves a list of wheels suitable for the whole-year.



        // Method declaration to retrieve a list of oil qualities
        List<Oil> GetOil(); // Retrieves a list of available oil qualities.
    }
}
