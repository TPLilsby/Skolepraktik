using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ØVelses_opgaver
{
    public class Employee
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public int CPRNumber { get; set; }

        Employee ( string firstName, string lastName, int cprNumber ) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            CPRNumber = cprNumber;
        }
    }

    public class Manager : Employee
    {
        public int PhonewNumber { get; set; }

        Manager (int phonewNumber, string firstName) : this(firstName, la)
        {
            PhonewNumber = phonewNumber;
        }
    }

    public class Projectmanager : Manager
    {
        string Email { get; set; } = string.Empty;
    }

    public class Sweeper : Employee
    {

    }
}
