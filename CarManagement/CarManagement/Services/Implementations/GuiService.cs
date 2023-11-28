using CarManagement.Enums.Oil;
using CarManagement.Objects;
using CarManagement.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarManagement.Services.Implementations
{
    // Internal class for GuiService that extends from an Interface named IGuiService
    internal class GuiService : IGuiService
    {
        // GuiService constructor
        public GuiService() { }

        #region Methods for show things to user
        //Not in use (Think to use to show all parts to check on the car)
        public void ShowAllParts() { }

        //Method for show all the wheels (gets a list of wheels)
        public void ShowAllWheels(List<Wheel> wheels)
        {
            Console.WriteLine("Car Wheels:");

            //Runs through a list and print the wheels to the console
            foreach (Wheel wheel in wheels)
            {
                //Print wheels id & placement
                Console.WriteLine($"{wheel.Id} | {wheel.TyrePlacement}");
            }
        }

        //Method to show oil quality & amount
        public void ShowOilQuality(List<Oil> oilQualities)
        {
            Console.WriteLine("\nTest Of Oil Quality & Amount");

            //Save values from OilQualityEnum to sring varible to later use
            string bad = OilQualityEnum.Bad.ToString();
            string okay = OilQualityEnum.Okay.ToString();
            string good = OilQualityEnum.Good.ToString();

            //Generate random number bbetween 1-4, to choose between the 3 string varibles above,
            //to get the quality of the oil
            Random rndOilQuality = new Random();
            int randomOilQuality = rndOilQuality.Next(1, 4);

            ////Generate random number bbetween 0-12, to get the amount of oil left in the car
            Random rndOilCapacity = new Random();
            int randomOilCapacity = rndOilCapacity.Next(0, 12);

            //If-tatement for the diffrent oil qualities
            //Oil quality bad
            if (randomOilQuality == 1)
            {
                //Print the oil quality and the remaining oil. And because its "Bad" The oil it needs to be changed.
                Console.WriteLine($"Oil Quality: {bad} | Oil remaining: {randomOilCapacity}L");
                Console.WriteLine("Needs to be changed!!!!!");
                
                //Bool varible for the quality while loop
                bool qualityLoop = true;

                //While loop
                while (qualityLoop)
                {
                    //Read the user input and save it to a int varible
                    Console.Write("\nPress 1 to change oil: ");
                    int oilInputBad = int.Parse(Console.ReadLine());

                    //If the user input 1 it will run a method
                    if (oilInputBad == 1)
                    {
                        //Calls a method named ChangeOil, that takes the oil quality value from the Enum with it,
                        //ánd prints the returning value to the console.
                        Console.WriteLine(ChangeOil(bad));

                        //Set the varible to false & and stops the while loop
                        qualityLoop = false;

                    //If the input is something else it will run the while loop again
                    } else
                    {
                        //varible set to true
                        qualityLoop = true;
                    }
                }

                //Bool varible for the refill while loop
                bool refillLoop = true;

                //While loop
                while (refillLoop)
                {
                    //Read the user input and save it to a char varible
                    Console.WriteLine("\nPress R to refill oil");
                    char userInput = char.Parse(Console.ReadLine());

                    //If the user input is 'r' it will run a method
                    if (userInput == 'r')
                    {
                        //Calls a method named RefillOil, that takes the amount of the remaining oil from a vasrible with it,
                        //ánd prints the returning value to the console.
                        Console.WriteLine(RefillOil(randomOilCapacity));

                        //Set the varible to false & and stops the while loop
                        refillLoop = false;

                    //If the input is something else it will run the while loop again
                    } else
                    {
                        //varible set to true
                        refillLoop = true;
                    }
                }

            //Oil quality okay
            } else if (randomOilQuality == 2)
            {
                //Print the oil quality and the remaining oil. And because its "Okay" give the user to change it or wait.
                Console.WriteLine($"Oil Quality: {okay} | Oil remaining: {randomOilCapacity}L");
                Console.WriteLine("chance it now or else it needs to be changed at next check.");


            //Oil quality good
            } else if (randomOilQuality == 3) 
            {

                //Print the oil quality and the remaining oil. And because its "Good" The oil don't needs to be changed.
                Console.WriteLine($"Oil Quality: {good} | Oil remaining: {randomOilCapacity}L");
                Console.WriteLine("No worries quality is good :)");
            }
        }
        #endregion

        #region Methods for functional usage
        //Method to Chanhing oil
        public string ChangeOil(string oilQuality)
        {
            //Clear the console
            Console.Clear();

            //Show the current oil quality
            Console.WriteLine("Here you can change oil...");
            Console.WriteLine($"Current oil quality: {oilQuality}");


            //Bool varible for the while loop
            bool loop = true;

            //While loop
            while (loop)
            {

                //Read the user input and save it to a int varible
                Console.Write("\nPress 1 to change the oil: ");
                int userInput = int.Parse(Console.ReadLine());

                //If the user input isn't 1 it will run the while loop again
                if (userInput != 1)
                {
                    //printed to the console
                    Console.WriteLine("Something went wrong");

                //Else if the input is correct it will jump out of the while loop
                } else {

                    //Set the varible to false & and stops the while loop
                    loop = false;
                }
            }

            //Returns a vulue with the oil quality changed to "good".
            return $"Oil is now changed from {oilQuality} to {OilQualityEnum.Good.ToString()}";
        }

        //Method to refill oil
        public int RefillOil(int oilAmount)
        {
            //The total amount of oil in a tank.
            int totalAmount = 15;

            //Calculate how much oiled that is refilled.
            int refilledOil = totalAmount - oilAmount;

            //Returns a int with how much is refilled
            return refilledOil;

        }

        //Method to choose wich part of the program you will run
        public int ChooseProgram()
        {
            //Bool varible for the while loop
            bool loop = true;

            //While loop
            while (loop)
            {

                //Read the user input and save it to a string varible
                Console.WriteLine("Choose between the check(1) or Manual(2)");
                int choice = int.Parse(Console.ReadLine());

                //If the user input isn't 1 it will run the while loop again
                if (choice == 1 || choice == 2)
                {
                    //Set the varible to false & and stops the while loop
                    loop = false;

                    //Returns the user choice
                    return choice;

                    //Else if the input is correct it will jump out of the while loop
                }
                else
                {
                    //printed to the console
                    Console.WriteLine("Something went wrong");
                }
            }

            //Returns a vulue
            return 2;
        }
        #endregion

    }
}