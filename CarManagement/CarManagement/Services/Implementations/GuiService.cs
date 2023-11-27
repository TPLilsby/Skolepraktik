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
        // GuiService constructor
        public GuiService() { }

        #region Methods for show things to user
        //Not in use (Think to use to show all parts to chck on the car)
        public void ShowAllParts() { }

        //Method for show all the wheels (gets a list of wheels)
        public void ShowAllWheels(List<Wheel> wheels)
        {
            Console.WriteLine("Car Wheels:");

            foreach (Wheel wheel in wheels)
            {
                Console.WriteLine($"{wheel.Id} | {wheel.TyrePlacement}");
            }
        }

        //Method to show oil quality & amount
        public void ShowOilQuality(List<Oil> oilQualities)
        {
            Console.WriteLine("\nTest Of Oil Quality & Amount");

            string bad = OilQualityEnum.Bad.ToString();
            string okay = OilQualityEnum.Okay.ToString();
            string good = OilQualityEnum.Good.ToString();

            Random rndOilQuality = new Random();
            int randomOilQuality = rndOilQuality.Next(1, 4);

            Random rndOilCapacity = new Random();
            int randomOilCapacity = rndOilCapacity.Next(0, 12);

            if (randomOilQuality == 1)
            {
                Console.WriteLine($"Oil Quality: {bad} | Oil remaining: {randomOilCapacity}L");
                Console.WriteLine("Needs to be changed!!!!!");

                bool qualityLoop = true;

                while (qualityLoop)
                {
                    Console.WriteLine("Press 1 to change oil");
                    int oilInputBad = int.Parse(Console.ReadLine());
                    if (oilInputBad == 1)
                    {
                        ChangeOil(bad);
                        qualityLoop = false;
                    }
                    else
                    {
                        qualityLoop = true;
                    }
                }

                bool refillLoop = true;

                while (refillLoop)
                {
                    Console.WriteLine("Press R to refill oil");
                    char userInput = char.Parse(Console.ReadLine());

                    if (userInput == 'r')
                    {
                        RefillOil(randomOilCapacity);
                        refillLoop = false;
                    } else
                    {
                        refillLoop = true;
                    }
                }


            } else if (randomOilQuality == 2) 
            {
                Console.WriteLine($"Oil Quality: {okay} | Oil remaining: {randomOilCapacity}L");
                Console.WriteLine("Needs to be changed at next check.");
            } else if (randomOilQuality == 3) 
            {
                Console.WriteLine($"Oil Quality: {good} | Oil remaining: {randomOilCapacity}L");
                Console.WriteLine("No worries quality is good :)");
            }
        }
        #endregion

        #region Methods for functional usage
        //Method to Chanhing oil
        public void ChangeOil(string oilQuality)
        {
            Console.WriteLine("Here you can change oil...");
            Console.WriteLine($"Current oil quality: {oilQuality}");

            bool loop = true;

            while (loop)
            {
                Console.WriteLine("Press 1 to change the oil");
                int userInput = int.Parse(Console.ReadLine());
                if (userInput != 1)
                {
                    Console.WriteLine("Something went wrong");
                } else {
                    Console.WriteLine($"Oil is now changed from {oilQuality} to {OilQualityEnum.Good.ToString()}");
                    loop = false;
                }
            }
        }

        //Method to refill oil
        public void RefillOil(int oilAmount)
        {
            int totalAmount = 15;


        }
        #endregion

    }
}