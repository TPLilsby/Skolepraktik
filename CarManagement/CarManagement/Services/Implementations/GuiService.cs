using CarManagement.Enums.Oil;
using CarManagement.Objects;
using CarManagement.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Services.Implementations
{
    internal class GuiService : IGuiService
    {
        public GuiService() { }

        public void ShowAllParts() { }

        public void ShowAllWheels(List<Wheel> wheels)
        {
            Console.WriteLine("Car Wheels:");

            foreach (Wheel wheel in wheels)
            {
                Console.WriteLine($"{wheel.Id} | {wheel.TyrePlacement}");
            }
        }

        public void ShowOilQuality(List<Oil> oilQualities)
        {
            Console.WriteLine("\nTest Of Oil Quality & Amount");

            string bad = OilQualityEnum.Bad.ToString();
            string okay = OilQualityEnum.Okay.ToString();
            string good = OilQualityEnum.Good.ToString();

            Random rnd = new Random();
           int randomNumber = rnd.Next(0, 4);

            if (randomNumber == 1)
            {
                Console.WriteLine($"Oil Quality: {bad}");
                Console.WriteLine("Needs to be shift!!!!!");
            } else if (randomNumber == 2) 
            {
                Console.WriteLine($"Oil Quality: {okay}");
                Console.WriteLine("Needs to be shift at next check.");
            } else if (randomNumber == 3) 
            {
                Console.WriteLine($"Oil Quality: {good}");
                Console.WriteLine("No worries quality is good :)");
            }
        }
    }
}