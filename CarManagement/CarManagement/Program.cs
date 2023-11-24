// See https://aka.ms/new-console-template for more information

using CarManagement.Controllers;
using CarManagement.Services.Implementations;

ICarManagementController ctrl = new CarManagementController(new MoneyService(), new GuiService(), new CarPartsService());

ctrl.ShowAllWheels();
ctrl.ShowOilQuality();