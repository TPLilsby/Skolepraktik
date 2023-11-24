using ØVelses_opgaver;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");


        Employee employee = new Employee();
        Employee manager = new Manager();
        Employee projectManger = new Projectmanager();
        Employee sweeper = new Sweeper();

        ((Sweeper)sweeper).FirstName = "fhjnbvcls";
        ((Sweeper)sweeper).LastName = "lils";

        Console.WriteLine(((Manager)manager).PhonewNumber = 12345678);

        Manager m = new Manager();

        manager.FirstName = employee.FirstName;





    }

}