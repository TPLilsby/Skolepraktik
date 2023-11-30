using CarManagement.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Services.Interfaces
{
    // Interface defining the contract for a Car Manual Service
    internal interface ICarManualService
    {
        // Method declaration to get a list of cars
        List<Car> GetCars();  // This method returns a list of Car objects
    }
}