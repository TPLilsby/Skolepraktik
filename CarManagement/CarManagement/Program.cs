// See https://aka.ms/new-console-template for more information

using CarManagement.Controllers;
using CarManagement.Services.Implementations;

// Creating an instance of CarManagementController and initializing it with instances of required services

// Instantiate a variable 'ctrl' of type ICarManagementController, which represents the car management controller interface
ICarManagementController ctrl = new CarManagementController(new MoneyService(), new GuiService(), new CarPartsService(), new CarManualService());

// Invoking the ProgramRunner method of the ctrl object to start the program

// Calling the ProgramRunner method of the ctrl object to execute the program logic and manage car functionalities
ctrl.ProgramRunner();