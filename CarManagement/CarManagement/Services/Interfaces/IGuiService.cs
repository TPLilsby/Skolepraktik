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
        #region Program Runner
        // Method to allow user selection of a specific part of the program
        int ChooseProgram(); // Method to choose a specific part of the program to run
        #endregion

        #region Car Service Page
        // Method declarations for showing different parts or functionalities related to cars
        void ShowAllParts(); // Method not currently in use

        #region Wheels
        void ShowAllWheels(List<Wheel> wheels); // Method to display information about car wheels

        // Methods to display specific types of wheels
        void ShowSummerWheels(List<Wheel> summerWheels); // Method to show summer wheels
        void ShowWinterWheels(List<Wheel> winterWheels); // Method to show winter wheels
        void ShowWholeYearWheels(List<Wheel> wholeYearWheels); // Method to show whole year wheels
        #endregion

        void ShowOilQuality(List<Oil> oilQualities); // Method to display oil quality information

        void ShowTotalPayment(double totalPayment); // Method to display the total payment

        // Methods for simulating actions related to car maintenance
        string FixTirePressure(double totalPressure); // Method to fix tire pressure
        string ChooseToChange(); // Method to prompt the user for tire change preference
        int ChangeWheels(); // Method to initiate the process of changing wheels
        string ChangeOil(string oilQuality); // Method to simulate changing the oil quality
        string RefillOil(double oilAmount); // Method to simulate refilling the oil
        #endregion

        #region Manual Page
        // Method declarations for displaying information about available cars
        void ShowAllCars(List<Car> cars); // Method to display all available cars
        void ShowCarById(List<Car> returnedCar); // Method to display detailed information of a specific car by its ID
        #endregion
    }
}