using CarManagement.Enums.Oil;
using CarManagement.Objects;
using CarManagement.Services.Interfaces;
using CarManagement.Services.Implementations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarManagement.Services.Implementations
{
    // Internal class for GuiService that implements the IGuiService interface
    internal class GuiService : IGuiService
    {
        // GuiService constructor
        public GuiService() { }

        #region Method for choosing which Part of the Program
        // Method to choose a specific part of the program to run
        public int ChooseProgram()
        {
            // Boolean variable for the while loop
            bool loop = true;

            // Loop until the user provides a valid choice
            while (loop)
            {
                // Prompt the user to choose between two options: check(1) or manual(2)
                Console.WriteLine("Choose between the check(1) or Manual(2)");
                int choice = int.Parse(Console.ReadLine());

                // Check if the user input is either 1 or 2
                if (choice == 1 || choice == 2)
                {
                    // Set the variable to false to exit the loop
                    loop = false;

                    //Return the user's choice
                    return choice;

                    //Else if the input is correct it will jump out of the while loop
                }
                else
                {

                    // Inform the user that something went wrong with their input
                    Console.WriteLine("Something went wrong");
                }
            }

            // Return a default value (2 in this case) if there's an issue with the input
            return 2;
            // End of Method
        }
        #endregion

        #region Service Page (Methods for displaying information to the user)

        // Not in use currently
        public void ShowAllParts() { }

        // Method to show all the wheels to the user
        public void ShowAllWheels(List<Wheel> wheels)
        {
            // Display a message indicating the wheels belong to a car
            Console.WriteLine("Car Wheels:");

            // Iterate through the list of wheels and print details for each wheel
            foreach (Wheel wheel in wheels)
            {
                // Print the ID and placement of each wheel
                Console.WriteLine($"{wheel.Id} | {wheel.TyrePlacement}");
            }
            // End of method
        }

        // Method to display oil quality and amount to the user
        public void ShowOilQuality(List<Oil> oilQualities)
        {
            // Display the header for the oil quality and amount test
            Console.WriteLine("\nTest Of Oil Quality & Amount");

            // Save values from OilQualityEnum to string variables for later use
            string bad = OilQualityEnum.Bad.ToString();
            string okay = OilQualityEnum.Okay.ToString();
            string good = OilQualityEnum.Good.ToString();


            // Generate a random number between 1-4 to determine the oil quality
            Random rndOilQuality = new Random();
            int randomOilQuality = rndOilQuality.Next(1, 4);

            // Generate a random number between 0-12 to simulate the amount of oil left in the car
            Random rndOilCapacity = new Random();
            double randomOilCapacity = rndOilCapacity.Next(0, 12);

            // Check different oil qualities
            // Oil quality: bad
            if (randomOilQuality == 1)
            {
                // Display the oil quality and the remaining oil. As it's "Bad," the oil needs to be changed.
                Console.WriteLine($"Oil Quality: {bad} | Oil remaining: {randomOilCapacity}L");
                Console.WriteLine("Needs to be changed!!!!!");

                // Boolean variable for the quality while loop
                bool qualityLoop = true;

                // Loop until the user decides whether to change the oil or not
                while (qualityLoop)
                {
                    // Prompt the user to input '1' to change the oil
                    Console.Write("\nPress 1 to change oil: ");
                    int oilInputBad = int.Parse(Console.ReadLine());

                    // If the user inputs '1,' call the ChangeOil method and display the result
                    if (oilInputBad == 1)
                    {
                        // Calls a method named ChangeOil, that takes the oil quality value from the Enum with it,
                        // and prints the returning value to the console.
                        Console.WriteLine(ChangeOil(bad));

                        // Set the variable to false to exit the loop
                        qualityLoop = false;

                    }
                    else
                    {
                        // Continue the loop if the input is something else
                        qualityLoop = true;
                    }
                }

                // Boolean variable for the refill while loop
                bool refillLoop = true;

                // Loop until the user decides whether to refill the oil or not
                while (refillLoop)
                {
                    // Prompt the user to input 'R' to refill oil
                    Console.WriteLine("\nPress R to refill oil");
                    char userInput = char.Parse(Console.ReadLine());

                    // If the user inputs 'R,' call the RefillOil method and display the result
                    if (userInput == 'r')
                    {
                        //Calls a method named RefillOil, that takes the amount of the remaining oil from a vasrible with it,
                        //ánd prints the returning value to the console.
                        Console.WriteLine(RefillOil(randomOilCapacity));

                        // Set the variable to false to exit the loop
                        refillLoop = false;

                    }
                    else
                    {
                        // Continue the loop if the input is something else
                        refillLoop = true;
                    }
                }

                // Oil quality: okay
            }
            else if (randomOilQuality == 2)
            {
                // Display the oil quality and the remaining oil. As it's "Okay," the user can decide to change it now or wait for the next check.
                Console.WriteLine($"Oil Quality: {okay} | Oil remaining: {randomOilCapacity}L");
                Console.WriteLine("change it now or else it needs to be changed at next check.");

            }
            // Oil quality: good
            else if (randomOilQuality == 3)
            {

                // Display the oil quality and the remaining oil. As it's "Good," there's no need to change the oil.
                Console.WriteLine($"Oil Quality: {good} | Oil remaining: {randomOilCapacity}L");
                Console.WriteLine("No worries quality is good :)");
            }
            // End of Method
        }
        #endregion

        #region Service Page (Methods for functional usage)
        // Method to simulate changing oil
        public string ChangeOil(string oilQuality)
        {
            // Clear the console to provide a clean interface
            Console.Clear();

            // Display the current oil quality to inform the user
            Console.WriteLine("Here you can change oil...");
            Console.WriteLine($"Current oil quality: {oilQuality}");


            // Boolean variable for the while loop
            bool loop = true;

            // Loop until the user confirms the oil change
            while (loop)
            {
                // Prompt the user to input '1' to change the oil
                Console.Write("\nPress 1 to change the oil: ");
                int userInput = int.Parse(Console.ReadLine());

                // If the user input isn't '1', indicate that something went wrong
                if (userInput != 1)
                {
                    // Notify the user that something went wrong
                    Console.WriteLine("Something went wrong");

                }
                else
                {

                    // Set the variable to false to exit the loop as the user confirms the oil change
                    loop = false;
                }
            }

            // Return a message indicating the oil quality changed to "good"
            return $"Oil is now changed from {oilQuality} to {OilQualityEnum.Good.ToString()}";
            //End of Method
        }

        // Method to simulate refilling oil
        public double RefillOil(double oilAmount)
        {
            // The total amount of oil in a tank
            double totalAmount = 15;

            // Calculate how much oil is refilled by subtracting the current amount from the total
            double refilledOil = totalAmount - oilAmount;

            // Return the amount of oil refilled
            return refilledOil;
            // End of Method
        }
        #endregion

        #region Manual Page (Methods for displaying information to the user)
        // Method to display all cars with their IDs and brands
        public void ShowAllCars(List<Car> cars)
        {
            // Foreach loop
            foreach (Car car in cars)
            {
                // Display id and brand of the cars
                Console.WriteLine($"{car.Id}: {car.Brand}");
            }

            Console.WriteLine(); // Empty line for separation
        }

        // Method to display detailed information of a specific car by its ID
        public void ShowCarById(List<Car> cars)
        {
            // Foreach loop
            foreach (Car car in cars)
            {
                // Display brand and model of the car
                Console.WriteLine($"{car.Brand}: {car.Model}");

                // Display tyre size of the car
                Console.WriteLine($"Tyre Size: {car.TyreSize}");
            }

            // Prompt the user to press ESC to return to the start menu
            Console.WriteLine("\nPress ESC to get to the start menu:");
            var info = Console.ReadKey();

            // If the user presses ESC, clear the console and return to the start menu
            if (info.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                ChooseProgram(); // Assuming ChooseProgram() is a method that leads to the start menu
            }
        }
        #endregion

    }
}