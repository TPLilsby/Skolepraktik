﻿using CarManagement.Enums.Oil;
using CarManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Controllers
{
    class CarManagementController : ICarManagementController
    {
        private readonly IMoneyService _moneyService;
        private readonly IGuiService _guiService;
        private readonly ICarPartsService _carPartsService;

        public CarManagementController (IMoneyService moneyService, IGuiService guiService, ICarPartsService carPartsService)
        {
            _moneyService = moneyService;
            _guiService = guiService;
            _carPartsService = carPartsService;
        }

        public void ProgramRunner() {

            int input = this._guiService.ChooseProgram();

            if (input == 1) {
                Console.Clear();
                this._guiService.ShowAllWheels(this._carPartsService.GetWheels());

                this._guiService.ShowOilQuality(this._carPartsService.GetOil());
            } else if (input == 2) {
                Console.Clear();
            }
        }
        /*
        public void ShowAllWheels()
        {

            this._guiService.ShowAllWheels(this._carPartsService.GetWheels());
        }

        public void ShowOilQuality()
        {
            this._guiService.ShowOilQuality(this._carPartsService.GetOil());
        }
        */

    }
}
