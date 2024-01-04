using CarManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Services.Implementations
{
    // Internal class representing a MoneyService implementation
    internal class MoneyService : IMoneyService
    {
        public MoneyService() { }

        public double CaculatePayment()
        {
            var payments = File.ReadLines(@"C:\\Users\\zbctoli\\Documents\\GitHub\\Skolepraktik\\CarManagement\\CarManagement\\TextDocuments\\Payments.txt");

            double totalPayment = 0;

            foreach (var payment in payments)
            {
                totalPayment += double.Parse(payment);
            }

            return totalPayment;
        }
    }
}