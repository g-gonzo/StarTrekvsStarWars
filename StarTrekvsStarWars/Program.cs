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
        List<StarTrekShip> StShips = new List<StarTrekShip>();
        List<StarWarsShip> SwShips = new List<StarWarsShip>();
        var player = new Player();

        StShips = buildStarTrekList();
        SwShips = buildStarWarsList();

        gl.TitleBar();
        do
        {
            gl.PlayGame();
            var selectedId = gl.CollectStarTrekShip(StShips);
            if (selectedId != 0)
            {
                player.selectedStarTrekId = selectedId;
            }
            var enemyId = gl.CollectStarWarsShip(SwShips);
            if (enemyId != 0)
            {
                player.selectedStarWarsId = enemyId;
            }
            gl.ConfirmShipSelection();
        } while (gl.isGameInProgress);

        System.Console.WriteLine();
        System.Console.WriteLine("Thank you for playing the game");
        System.Console.WriteLine("Press any key to exit...");
        Console.ReadKey(true);

    }

    private static List<StarTrekShip> buildStarTrekList()
    {
        List<StarTrekShip> shipList = new List<StarTrekShip>();
        var reader = new StreamReader(File.OpenRead(@".\StarTrekShips.csv"));

        FileReader fr = new FileReader();
        List<string[]> totalFileValues = fr.createListFromFile(reader);
        foreach (var singleRowValues in totalFileValues)
        {
            shipList.Add(new StarTrekShip(singleRowValues));
        }
        return shipList;
    }

    private static List<StarWarsShip> buildStarWarsList()
    {
        List<StarWarsShip> shipList2 = new List<StarWarsShip>();
        var reader = new StreamReader(File.OpenRead(@".\StarWarsShips.csv")); 

        FileReader fr = new FileReader();
        List<string[]> totalFileValues = fr.createListFromFile(reader);
        foreach (var singleRowValues in totalFileValues)
        {
            shipList2.Add(new StarWarsShip(singleRowValues));
        }
        return shipList2;
    }

}


