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

        // Method to display information about all the wheels of a car to the user
        public void ShowAllWheels(List<Wheel> wheels)
        {

            File.WriteAllText(@"C:\Users\zbctoli\Documents\GitHub\Skolepraktik\CarManagement\CarManagement\TextDocuments\Payments.txt", string.Empty);
            File.WriteAllText(@"C:\Users\zbctoli\Documents\GitHub\Skolepraktik\CarManagement\CarManagement\TextDocuments\ServiceReview.txt", string.Empty);


            double totalPressure = 0; // Variable to store the total pressure of all wheels

            // Display a message indicating the displayed wheels belong to a car
            Console.WriteLine("Car Wheels:");

            // Iterate through the list of wheels and print details for each wheel
            foreach (Wheel wheel in wheels)
            {
                // Print the ID and placement of each wheel along with its tire pressure
                Console.WriteLine("________________________________________");
                Console.WriteLine($"{wheel.Id}: {wheel.TirePlacement} | {wheel.WheelType} | {wheel.TireBrand} - {wheel.TirePressure} ¤|");

                // Calculate the total pressure of all wheels
                totalPressure += wheel.TirePressure;
            }


            bool changeLoop = true; // Loop control variable for tire change prompt

            // Continuously prompt the user for tire change preference until valid input is received
            while (changeLoop)
            {
                Console.Write("Choose 1 (To Change) | Choose 2 (to not change): ");
                int input = int.Parse(Console.ReadLine()); // Read user input for preference

                if (input == 1)
                {
                    changeLoop = false; // Exit loop if the user chooses to change tires
                }
                else if (input == 2)
                {
                    // If the user opts not to change, adjust the tire pressure and display the result
                    Console.WriteLine(FixTirePressure(totalPressure));
                    changeLoop = false; // Exit loop
                }
                else
                {
                    Console.WriteLine("Wrong input try again...."); // Display error for invalid input
                    changeLoop = true; // Restart loop for incorrect input
                }
            }

            // End of method
        }

        // Method to display information about the summer wheels
        public void ShowSummerWheels(List<Wheel> summerWheels)
        {
            Console.Clear();

            // Variable to store the total pressure of summer wheels
            double totalPressure = 0;
            double payment = 149.95;

            // Display header indicating a change to summer wheels
            Console.WriteLine($"The wheels are changed to Summer | Costs {payment}:");

            // Writing the payment amount to the file
            string paymentsFilePath = @"C:\Users\zbctoli\Documents\GitHub\Skolepraktik\CarManagement\CarManagement\TextDocuments\Payments.txt";
            using (StreamWriter psw = File.AppendText(paymentsFilePath))
            {
                psw.WriteLine(payment);
                psw.Close();
            }

            // Displaying summer wheels' details and writing them to a file
            string summerWheelsFilePath = @"C:\Users\zbctoli\Documents\GitHub\Skolepraktik\CarManagement\CarManagement\TextDocuments\ServiceReview.txt";
            using (StreamWriter summerWheelsWriter = File.AppendText(summerWheelsFilePath))
            {
                summerWheelsWriter.WriteLine("\nSummer Wheels:");

                // Iterate through each wheel in the list of summer wheels
                foreach (Wheel wheel in summerWheels)
                {
                    // Display separator line for each wheel
                    Console.WriteLine("________________________________________");

                    // Display details of each summer wheel: ID, placement, type, brand, and pressure
                    Console.WriteLine($"{wheel.Id}: {wheel.TirePlacement} | {wheel.WheelType} | {wheel.TireBrand} - {wheel.TirePressure} ¤|");

                    // Write details to the file
                    summerWheelsWriter.WriteLine("________________________________________");
                    summerWheelsWriter.WriteLine($"{wheel.Id}: {wheel.TirePlacement} | {wheel.WheelType} | {wheel.TireBrand} - {wheel.TirePressure} ¤|");

                    // Calculate the total pressure by adding each wheel's pressure to the total
                    totalPressure += wheel.TirePressure;
                }
                summerWheelsWriter.Close();
            }

            Console.WriteLine(FixTirePressure(totalPressure)); // The FixTirePressure method's logic should be implemented separately
            // End of method
        }

        // Method to display information about the winter wheels
        public void ShowWinterWheels(List<Wheel> winterWheels)
        {
            Console.Clear();

            // Variable to store the total pressure of winter wheels
            double totalPressure = 0;
            double payment = 149.95;

            // Display header indicating a change to winter wheels
            Console.WriteLine($"The wheels are changed to Winter | Costs {payment}:");

            // Writing the payment amount to the file
            string paymentsFilePath = @"C:\Users\zbctoli\Documents\GitHub\Skolepraktik\CarManagement\CarManagement\TextDocuments\Payments.txt";
            using (StreamWriter psw = File.AppendText(paymentsFilePath))
            {
                psw.WriteLine(payment);
            }

            // Displaying winter wheels' details and writing them to a file
            string winterWheelsFilePath = @"C:\Users\zbctoli\Documents\GitHub\Skolepraktik\CarManagement\CarManagement\TextDocuments\ServiceReview.txt";
            using (StreamWriter winterWheelsWriter = File.AppendText(winterWheelsFilePath))
            {
                winterWheelsWriter.WriteLine("\nWiner Wheels:");

                // Iterate through each wheel in the list of winter wheels
                foreach (Wheel wheel in winterWheels)
                {
                    // Display separator line for each wheel
                    Console.WriteLine("________________________________________");

                    // Display details of each winter wheel: ID, placement, type, brand, and pressure
                    Console.WriteLine($"{wheel.Id}: {wheel.TirePlacement} | {wheel.WheelType} | {wheel.TireBrand} - {wheel.TirePressure} ¤|");

                    // Write details to the file
                    winterWheelsWriter.WriteLine("________________________________________");
                    winterWheelsWriter.WriteLine($"{wheel.Id}: {wheel.TirePlacement} | {wheel.WheelType} | {wheel.TireBrand} - {wheel.TirePressure} ¤|");

                    // Calculate the total pressure by adding each wheel's pressure to the total
                    totalPressure += wheel.TirePressure;
                }
            }

            Console.WriteLine(FixTirePressure(totalPressure)); // The FixTirePressure method's logic should be implemented separately
            // End of method
        }

        // Method to display information about the whole-year wheels
        public void ShowWholeYearWheels(List<Wheel> wholeYearWheels)
        {
            // Clear the console screen
            Console.Clear();

            // Variable to store the total pressure of winter wheels
            double totalPressure = 0;
            double payment = 149.95;

            // Display header indicating a change to whole-year wheels
            Console.WriteLine($"The wheels are changed to Whole Year | Costs {payment}:");

            // File path for storing payment information
            string paymentsFilePath = @"C:\Users\zbctoli\Documents\GitHub\Skolepraktik\CarManagement\CarManagement\TextDocuments\Payments.txt";

            // Writing the payment amount to the file
            using (StreamWriter psw = File.AppendText(paymentsFilePath))
            {
                psw.WriteLine(payment);
            }

            // File path for storing whole-year wheels' details
            string wholeYearWheelsFilePath = @"C:\Users\zbctoli\Documents\GitHub\Skolepraktik\CarManagement\CarManagement\TextDocuments\ServiceReview.txt";

            // Displaying whole-year wheels' details and writing them to a file
            using (StreamWriter wholeYearWheelsWriter = File.AppendText(wholeYearWheelsFilePath))
            {
                wholeYearWheelsWriter.WriteLine("\nWhole-Year Wheels:");

                // Iterate through each wheel in the list of whole-year wheels
                foreach (Wheel wheel in wholeYearWheels)
                {
                    // Display separator line for each wheel
                    Console.WriteLine("________________________________________");

                    // Display details of each whole-year wheel: ID, placement, type, brand, and pressure
                    Console.WriteLine($"{wheel.Id}: {wheel.TirePlacement} | {wheel.WheelType} | {wheel.TireBrand} - {wheel.TirePressure} ¤|");

                    // Write details to the file
                    wholeYearWheelsWriter.WriteLine("________________________________________");
                    wholeYearWheelsWriter.WriteLine($"{wheel.Id}: {wheel.TirePlacement} | {wheel.WheelType} | {wheel.TireBrand} - {wheel.TirePressure} ¤|");

                    // Calculate the total pressure by adding each wheel's pressure to the total
                    totalPressure += wheel.TirePressure;
                }
            }


            Console.WriteLine(FixTirePressure(totalPressure)); // The FixTirePressure method's logic should be implemented separately
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
            {// Display the oil quality and remaining oil. Since it's "Bad," the oil needs to be changed.
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

                        Console.WriteLine(ChangeOil(bad)); // Simulate changing the oil quality
                        qualityLoop = false; // Exit the loop after changing the oil
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong..."); // Display an error message for invalid input
                        qualityLoop = true; // Restart the loop due to invalid input
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


                    // If the user inputs 'r' to refill the oil
                    if (userInput == 'r')
                    {
                        Console.WriteLine($"{RefillOil(randomOilCapacity)}"); // Simulate refilling the oil
                        refillLoop = false; // Exit the loop after refilling
                    }
                    // If the user input is not 'r'
                    else
                    {
                        Console.WriteLine("Something went wrong..."); // Display an error message for invalid input
                        refillLoop = true; // Restart the loop if the input is something else
                    }

                }
            }
            // Oil quality: okay
            else if (randomOilQuality == 2)
            {
                // Display the oil quality and remaining oil. If it's "Okay," the user can decide to change it now or wait for the next check.
                Console.WriteLine($"Oil Quality: {okay} | Oil remaining: {randomOilCapacity}L");
                Console.WriteLine("Change it now or else it needs to be changed at the next check.");

                // Boolean variable for the quality while loop
                bool qualityLoop = true;

                // Loop until the user decides whether to change the oil or not
                while (qualityLoop)
                {
                    // Prompt the user to choose whether to change the oil now or wait
                    Console.WriteLine("\nDo you want to change it now(1) or wait(2)");
                    int oilInputOkay = int.Parse(Console.ReadLine());

                    // If the user chooses to change the oil immediately by inputting '1'
                    if (oilInputOkay == 1)
                    {
                        Console.WriteLine(ChangeOil(okay)); // Simulate changing the oil quality
                        qualityLoop = false; // Exit the loop after changing the oil
                    }
                    // If the user chooses to wait until later by inputting '2'
                    else if (oilInputOkay == 2)
                    {
                        qualityLoop = false; // User chooses to wait, exit the loop
                    }
                    // If the input is neither '1' nor '2'
                    else
                    {
                        Console.WriteLine("Something went wrong..."); // Display an error message for invalid input
                        qualityLoop = true; // Restart the loop due to invalid input
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


                    // If the user inputs 'r' to refill the oil
                    if (userInput == 'r')
                    {
                        Console.WriteLine($"{RefillOil(randomOilCapacity)}"); // Simulate refilling the oil
                        refillLoop = false; // Exit the loop after refilling
                    }
                    // If the user input is not 'r'
                    else
                    {
                        Console.WriteLine("Something went wrong..."); // Display an error message for invalid input
                        refillLoop = true; // Restart the loop if the input is something else
                    }

                }
            }
            // Oil quality: good
            else if (randomOilQuality == 3)
            {

                // Display the oil quality and the remaining oil. As it's "Good," there's no need to change the oil.
                Console.WriteLine($"Oil Quality: {good} | Oil remaining: {randomOilCapacity}L");
                Console.WriteLine("No worries quality is good :)");

                // Boolean variable for the refill while loop
                bool refillLoop = true;

                // Loop until the user decides whether to refill the oil or not
                while (refillLoop)
                {
                    // Prompt the user to input 'R' to refill oil
                    Console.WriteLine("\nPress R to refill oil");
                    char userInput = char.Parse(Console.ReadLine());


                    // If the user inputs 'r' to refill the oil
                    if (userInput == 'r')
                    {
                        Console.WriteLine($"{RefillOil(randomOilCapacity)}"); // Simulate refilling the oil
                        refillLoop = false; // Exit the loop after refilling
                    }
                    // If the user input is not 'r'
                    else
                    {
                        Console.WriteLine("Something went wrong..."); // Display an error message for invalid input
                        refillLoop = true; // Restart the loop if the input is something else
                    }

                }
            }
            // End of Method
        }
        
        public void ShowTotalPayment(double totalPayment)
        {

            // Displaying total payment details and writing them to a file
            string ServiceOverviewFilePath = @"C:\Users\zbctoli\Documents\GitHub\Skolepraktik\CarManagement\CarManagement\TextDocuments\ServiceReview.txt";
            using (StreamWriter totalPaymentWriter = File.AppendText(ServiceOverviewFilePath))
            {

                Console.WriteLine($"\nTotal payment: {totalPayment}");

                totalPaymentWriter.WriteLine($"\nTotal payment: {totalPayment}");


            }
        }
        #endregion

        #region Service Page (Methods for functional usage)

        // Method to adjust the tire pressure
        public string FixTirePressure(double totalPressure)
        {
            bool loop = true; // Boolean variable for the while loop

            while (loop)
            {
                Console.Write("\nPress C to change the tire pressure: "); // Prompting the user for input
                string input = Console.ReadLine().ToUpper(); // Reading user input and converting it to uppercase

                double pressure; // Variable to store the calculated pressure
                double payment;

                if (input == "C") // Check if the user input is 'C' for changing tire pressure
                {
                    payment = 15;

                    // Calculate the new tire pressure (totalPressure divided by 4)
                    pressure = totalPressure / 4;


                    // Writing the payment amount to the file
                    string paymentsFilePath = @"C:\Users\zbctoli\Documents\GitHub\Skolepraktik\CarManagement\CarManagement\TextDocuments\Payments.txt";
                    using (StreamWriter psw = File.AppendText(paymentsFilePath))
                    {
                        psw.WriteLine(payment);
                    }

                    // Displaying tire pressure details and writing them to a file
                    string ServiceOverviewFilePath = @"C:\Users\zbctoli\Documents\GitHub\Skolepraktik\CarManagement\CarManagement\TextDocuments\ServiceReview.txt";
                    using (StreamWriter pressureWriter = File.AppendText(ServiceOverviewFilePath))
                    {
                        pressureWriter.WriteLine("\nChanged Pressure: ");
                        pressureWriter.WriteLine($"Tire pressure is changed to: {pressure} | Costs {payment}");
                    }

                    // Return the new tire pressure as a string message
                    return $"Tire pressure is changed to: {pressure} | Costs {payment}";
                }
                else
                {
                    Console.WriteLine("Wrong input!!..."); // Display error message for incorrect input
                    loop = true; // Restart the loop due to incorrect input
                }
            }
            return ""; // Default return value

            // End of method
        }

        // Method to prompt the user for a choice to change tires
        public string ChooseToChange()
        {
            // Prompting the user to choose whether they want to change tires or not
            Console.Write("\nDo you want to change tires? (Y/Yes - N/No): ");

            // Reading user input and converting it to uppercase for consistency
            string input = Console.ReadLine().ToUpper();

            // Validating the user's input
            if (input == "Y" || input == "N")
            {
                return input; // Returning the user's choice
            }

            // If the input is not Y or N, defaulting to 'Y'
            return "Y";
        }

        // Method to simulate changing wheels
        public int ChangeWheels()
        {

            // Convert wheel types to strings for display
            string summer = Enums.Wheel.WheelTypeEnum.Summer.ToString();
            string winter = Enums.Wheel.WheelTypeEnum.Winter.ToString();
            string wholeYear = Enums.Wheel.WheelTypeEnum.WholeYear.ToString();

            string[] wheelTypes = { summer, winter, wholeYear }; // Array containing different wheel types
            int id = 1; // ID for each wheel type

            Console.WriteLine();

            // Display available wheel types with their corresponding IDs
            foreach (string wheelType in wheelTypes)
            {
                Console.WriteLine($"{id}: {wheelType}"); // Displaying each wheel type with an ID
                id++;
            }

            bool loop = true; // Boolean variable for the while loop

            // Loop until the user provides a valid choice
            while (loop)
            {
                Console.Write("\nChoose the specific ID of the wheel set you want to change to: ");
                int input = int.Parse(Console.ReadLine()); // Read user input

                // Check if the input corresponds to a valid wheel set ID
                if (input == 1 || input == 2 || input == 3)
                {
                    return input; // Return the chosen wheel set ID
                }
                else
                {
                    Console.WriteLine("Something went wrong... Try again"); // Display error message for invalid input
                    loop = true; // Restart the loop due to invalid input
                }
            }
            return 1; // Default return value

            // End of method
        }


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

            double payment = 49.95;

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

            // Writing the payment amount to the file
            string paymentsFilePath = @"C:\Users\zbctoli\Documents\GitHub\Skolepraktik\CarManagement\CarManagement\TextDocuments\Payments.txt";
            using (StreamWriter psw = File.AppendText(paymentsFilePath))
            {
                psw.WriteLine(payment);
            }

            // Displaying oil quality details and writing them to a file
            string ServiceOverviewFilePath = @"C:\Users\zbctoli\Documents\GitHub\Skolepraktik\CarManagement\CarManagement\TextDocuments\ServiceReview.txt";
            using (StreamWriter qualityWriter = File.AppendText(ServiceOverviewFilePath))
            {
                qualityWriter.WriteLine("\nOil Quality:");
                qualityWriter.WriteLine($"Oil is now changed from {oilQuality} to {OilQualityEnum.Good.ToString()} | Costs: {payment}");
            }

            // Return a message indicating the oil quality changed to "good"
            return $"Oil is now changed from {oilQuality} to {OilQualityEnum.Good.ToString()} | Costs: {payment}";

            //End of Method
        }

        // Method to simulate refilling oil
        public string RefillOil(double oilAmount)
        {
            Console.WriteLine("What is the total capacity on the car? - Min 12 L");
            double totalAmount = double.Parse(Console.ReadLine());


            // Calculate how much oil is refilled by subtracting the current amount from the total
            double refilledOil = totalAmount - oilAmount;

            double payment = refilledOil * 4.3;

            // Writing the payment amount to the file
            string paymentsFilePath = @"C:\Users\zbctoli\Documents\GitHub\Skolepraktik\CarManagement\CarManagement\TextDocuments\Payments.txt";
            using (StreamWriter psw = File.AppendText(paymentsFilePath))
            {
                psw.WriteLine(payment);
            }

            // Displaying refilled oil details and writing them to a file
            string ServiceOverviewFilePath = @"C:\Users\zbctoli\Documents\GitHub\Skolepraktik\CarManagement\CarManagement\TextDocuments\ServiceReview.txt";
            using (StreamWriter refillWriter = File.AppendText(ServiceOverviewFilePath))
            {
                refillWriter.WriteLine("\nRefilled Oil:");
                refillWriter.WriteLine($"Refilled oil: {refilledOil}L | Costs: {payment}");
            }

            // Return the amount of oil refilled
            return $"Refilled oil: {refilledOil}L | Costs: {payment}";
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
        public void ShowCarById(List<Car> returnedCar)
        {
            // Loop through each car in the 'returnedCar' list and display it's specifications
            foreach (Car car in returnedCar)
            {
                // Display different specifications of the car
                Console.WriteLine($"{car.Brand}: {car.Model}"); // Display brand and model of the car
                Console.WriteLine($"Horse Power: {car.HorsePower} HK"); // Display the car's horsepower
                Console.WriteLine($"Tire Size: {car.TireSize}"); // Display Tire size of the car
                Console.WriteLine($"Tire pressure between: {car.TirePressureMin} - {car.TirePressureMax}"); // Display Tire pressure range
                Console.WriteLine($"Oil capacity: {car.TotalOilCapacity} L"); // Display oil capacity of the car
                Console.WriteLine($"Number Of Lights: {car.NumberOfLights}"); // Display number of lights on the car
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