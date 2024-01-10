using CarManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Services.Implementations
{
    // Internal class representing a MoneyService implementation
    internal class MoneyService : IMoneyService
    {
        // MoneyService constructor
        public MoneyService() { }

        // Method to calculate payments
        public double CaculatePayment()
        {
            // Take all payments from a text file 
            var payments = File.ReadLines(@"C:\\Users\\zbctoli\\Documents\\GitHub\\Skolepraktik\\CarManagement\\CarManagement\\TextDocuments\\Payments.txt");

            // Variable for total payment
            double totalPayment = 0;

            // Runs through every payment
            foreach (var payment in payments)
            {
                // Adding them together
                totalPayment += double.Parse(payment);
            }

            // Returns the result
            return totalPayment;
        }
    }
}