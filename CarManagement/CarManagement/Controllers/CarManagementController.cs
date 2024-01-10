using CarManagement.Enums.Oil;
using CarManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Controllers
{
    // Class implementing the ICarManagementController interface to manage car-related functionalities
    class CarManagementController : ICarManagementController
    {
        private readonly IMoneyService _moneyService; // Service for money-related operations
        private readonly IGuiService _guiService; // Service for GUI-related operations
        private readonly ICarPartsService _carPartsService; // Service for car parts-related operations
        private readonly ICarManualService _carManualService; // Service for managing car manual-related operations

        // Constructor for CarManagementController initializing necessary services via dependency injection
        public CarManagementController (IMoneyService moneyService, IGuiService guiService, ICarPartsService carPartsService, ICarManualService carManualService)
        {
            _moneyService = moneyService;
            _guiService = guiService;
            _carPartsService = carPartsService;
            _carManualService = carManualService;
        }
        // Method implementing the program flow for managing car functionalities
        public void ProgramRunner()
        {
            // Getting user input to choose a program part
            int input = this._guiService.ChooseProgram();

            // Check user input for different program actions
            if (input == 1)
            {
                // Case when user input is 1:
                // Clearing the console and displaying information about wheels and oil quality

                // Clear the console screen to provide a clean display
                Console.Clear();

                // Display information about available wheels using the GUI service and CarPartsService
                this._guiService.ShowAllWheels(this._carPartsService.GetWheels());

                // Prompt the user to choose whether they want to change tires or view oil quality
                string choice = this._guiService.ChooseToChange();

                // Based on the user's choice, display the appropriate information
                if (choice == "Y")
                {
                    // Get user input to change wheels (e.g., summer, winter, or whole year)
                    int wheelInput = this._guiService.ChangeWheels();

                    // Display information about different types of wheels based on user selection
                    if (wheelInput == 1)
                    {
                        // Show information about summer wheels using the CarPartsService and GuiService
                        this._guiService.ShowSummerWheels(this._carPartsService.GetSummerWheels());
                    }
                    else if (wheelInput == 2)
                    {
                        // Show information about winter wheels using the CarPartsService and GuiService
                        this._guiService.ShowWinterWheels(this._carPartsService.GetWinterWheels());
                    }
                    else if (wheelInput == 3)
                    {
                        // Show information about whole-year wheels using the CarPartsService and GuiService
                        this._guiService.ShowWholeYearWheels(this._carPartsService.GetWholeYearWheels());
                    }
                }
                else if (choice == "N")
                {
                    // Show information about oil quality using the CarPartsService and GuiService
                    this._guiService.ShowOilQuality(this._carPartsService.GetOil());
                }

                // Shows the total payment using the MoneyService
                this._guiService.ShowTotalPayment(this._moneyService.CaculatePayment());
            }
            else if (input == 2)
            {
                // Case when user input is 2:
                // Clearing the console (Placeholder for potential future functionalities for the manual)

                // Clear the console screen as a placeholder for future functionalities
                Console.Clear();

                // Display all available cars using GUI service based on the car manual service data
                this._guiService.ShowAllCars(this._carManualService.GetCars());

                // Display detailed information of a specific car using GUI service based on the car manual service data
                this._guiService.ShowCarById(this._carManualService.GetCarById());
            }

            // Placeholder for handling additional user input conditions
            // Additional conditions for other possible user inputs can be added here
        }


    }
}
