using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarTrekvsStarWars;

namespace StarTrekvsStarWars;

class Program
{
    static void Main(string[] args)
    {

        var gl = new GameLogic();
        var reader = new StreamReader(File.OpenRead(@".\StarTrekShips.csv"));
        List<StarTrekShip> StShips = new List<StarTrekShip>();

        FileReader fr = new FileReader();
        List<string[]> totalFileValues = fr.createListFromFile(reader);
        foreach (var singleRowValues in totalFileValues)
        {
            StShips.Add(new StarTrekShip(singleRowValues));
        }

        foreach (var ship in StShips)
        {
            Console.WriteLine(ship.Name);
        }

        List<StarWarsShip> SwShips = new List<StarWarsShip>();

        SwShips.Add(new StarWarsShip(1, "X-Wing", "T-65", "Star Fighter", 12.5, 0, 3700, 16, 100, 1050, 75, "50", 20, 4, 6, 0, 7));
        SwShips.Add(new StarWarsShip(2, "Y-Wing", "BTL", "Assault Star Fighter", 23.4, 16, 2700, 11, 80, 1000, 59, "75", 40, 6, 8, 0, 7));
        SwShips.Add(new StarWarsShip(3, "A-Wing", "RZ-1", "Star Fighter", 9.6, 6.48, 5100, 21, 120, 1300, 96, "50", 14, 2, 0, 12, 7));
        SwShips.Add(new StarWarsShip(4, "B-Wing", "A/SF-01", "Heavy Assault Fighter", 4.7, 7.3, 2390, 16, 91, 950, 70, "100", 14, 5, 20, 0, 7));
        SwShips.Add(new StarWarsShip(5, "Head-Hunter", "Z-95", "Star Fighter", 11.8, 0, 2780, 16, 100, 1150, 86, "20", 14, 2, 6, 12, 1));
        SwShips.Add(new StarWarsShip(6, "Mon Calamari Cruiser", "MC80a", "Star Cruiser", 1300, 0, 0, 0, 60, 0, 0, "0", 0, 68, 0, 0, 730));
        SwShips.Add(new StarWarsShip(7, "Millienium Falcon", "YT-1300", "Light Freighter", 34.75, 0, 0, 0, 0, 800, 0, "120", 76, 3, 2, 0, 60));
        SwShips.Add(new StarWarsShip(8, "TIE Star Fighter", "Twin ION Engine/LN", "Star Fighter", 6.3, 6.4, 4100, 20, 100, 1200, 96, "0", 15, 2, 0, 0, 2));
        SwShips.Add(new StarWarsShip(9, "TIE Interceptor", "Twin ION Engine/Interceptor", "Star Fighter", 9.6, 0, 4240, 21, 110, 1250, 104, "0", 16, 6, 2, 0, 2));
        SwShips.Add(new StarWarsShip(10, "TIE Star Bomber", "Twin ION Engine/sa Bomber", "Space/Planetary Bomber", 7.8, 8.6, 2380, 13, 60, 850, 86, "0", 28, 2, 2, 2, 2));
        SwShips.Add(new StarWarsShip(11, "Star Wing", "Alpha-Class Xg-1 Star Wing", "Assault Star Fighter", 10, 15.1, 0, 20, 90, 1050, 78, "100", 28, 4, 2, 2, 3));
        SwShips.Add(new StarWarsShip(12, "TIE Avenger", "Twin ION Engine/ad Advanced", "Star Fighter", 9.8, 0, 0, 16, 133, 1300, 104, "40", 14, 4, 2, 2, 2));

        gl.TitleBar();
        do
        {
            gl.PlayGame();
            gl.CollectStarTrekShip();
            gl.CollectStarWarsShip();
            gl.ConfirmShipSelection();
        } while (gl.isGameInProgress);

        System.Console.WriteLine();
        System.Console.WriteLine("Thank you for playing the game");
        System.Console.WriteLine("Press any key to exit...");
        Console.ReadKey(true);


        //Console.WriteLine("Please Enter the name of the Star Trek ship.");
        //var StarTrekShipName = Console.ReadLine();
        //System.Console.WriteLine("Please Enter the name of the Star Wars ship.");
        //var StarWarsShipName = Console.ReadLine();
        //System.Console.WriteLine($"This Ship {StarTrekShipName} is better than {StarWarsShipName}");
        //System.Console.WriteLine("Press any key to exit...");
        //Console.ReadKey(true);
    }

}


