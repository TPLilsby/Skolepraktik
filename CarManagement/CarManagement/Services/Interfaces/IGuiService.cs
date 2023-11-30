using CarManagement.Enums.Oil;
using CarManagement.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Services.Interfaces
{
    // Internal interface representing GUI services for managing car-related functionalities
    internal interface IGuiService
    {
        // Method declarations for showing different parts or functionalities related to cars
        void ShowAllParts(); // Method not currently in use

        void ShowAllWheels(List<Wheel> wheels); // Method to display information about car wheels

        void ShowOilQuality(List<Oil> oilQualities); // Method to display oil quality information


        // Methods for simulating actions related to oil change and refill
        string ChangeOil(string oilQuality); // Method to simulate changing the oil quality

        double RefillOil(double oilAmount); // Method to simulate refilling the oil


        // Method to allow user selection of a specific part of the program
        int ChooseProgram(); // Method to choose a specific part of the program to run
    }
}