using System;

namespace StarTrekvsStarWars
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter the name of the Star Trek ship.");
            var StarTrekShipName = Console.ReadLine();
            System.Console.WriteLine("Please Enter the name of the Star Wars ship.");
            var StarWarsShipName = Console.ReadLine();
            System.Console.WriteLine($"This Ship {StarTrekShipName} is better than {StarWarsShipName}");
            System.Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

    }

}

