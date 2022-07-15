using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarTrekVsStarWars;

namespace StarTrekvsStarWars
{

    class Program
    {
        static void Main(string[] args)
        {

            var gl = new GameLogic();

            List<StarTrekShip> StShips = new List<StarTrekShip>();

            StShips.Add(new StarTrekShip(101, "Valkyrie", "Constellation", "Exploratory Cruiser", 315, 175, 6, 7, 8, 0, 0, "Merlin", 325000, 18, 3, 0, 3650));
            StShips.Add(new StarTrekShip(102, "Intrepid", "Excelsior", "Heavy Cruiser", 467, 186, 8, 9, 9.3, 0, 0, "Merlin", 1534610, 24, 4, 0, 1825));
            StShips.Add(new StarTrekShip(103, "Excalibur", "Ambassador", "Heavy Cruiser", 526, 320, 6, 8.5, 9, 0, 0, "FSP/1", 3740000, 12, 2, 0, 1825));
            StShips.Add(new StarTrekShip(104, "Fartagut", "Nebula", "Light Cruiser", 442.23, 463.73, 6, 9.2, 9.6, 0, 0, "FSQ/1", 3309000, 8, 2, 0, 1825));
            StShips.Add(new StarTrekShip(105, "Princeton", "Niagara", "Fast Cruiser", 565, 505, 7, 9, 9.4, 0, 0, "FSP/1", 41850000, 12, 2, 0, 1825));
            StShips.Add(new StarTrekShip(106, "Enterprise", "Galaxy", "Large Exploratory Cruiser", 642.51, 463.73, 6, 9.2, 9.6, 0, 0, "FSQ/1", 4500000, 12, 2, 0, 1825));
            StShips.Add(new StarTrekShip(107, "Dominion", "Akira", "Battle Cruiser", 455, 292, 7, 9, 9.8, 0, 0, "FSQ/1", 1600000, 6, 8, 0, 1825));
            StShips.Add(new StarTrekShip(108, "Magellan", "Galaxy II", "Large Exploratory Cruiser", 642.51, 463.73, 7, 9.5, 9.9, 0, 0, "FSS/1", 4780000, 12, 2, 0, 1825));
            StShips.Add(new StarTrekShip(109, "Vengeance", "Entente", "Dreadnought", 643, 464, 7, 9.5, 9.9, 0, 0, "FSQ/2", 5520000, 15, 4, 0, 1825));
            StShips.Add(new StarTrekShip(110, "Tsunami", "Sullivans", "Tactical Frigate", 320, 256, 6, 9, 9.6, 0, 0, "FSQ/1", 14850000, 12, 8, 0, 1825));
            StShips.Add(new StarTrekShip(111, "Concorde", "Freedom", "Destroyer", 430, 260, 0, 7.5, 9, 0, 0, "FSP/1", 1075000, 3, 2, 0, 1825));
            StShips.Add(new StarTrekShip(112, "Everst", "Steam Runner", "Heavy Destroyer", 292, 217, 7, 9, 9.6, 0, 0, "FSP/1", 275000, 6, 2, 0, 1825));

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

}

