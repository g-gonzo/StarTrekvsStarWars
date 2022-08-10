using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace StarTrekvsStarWars;

public class GameLogic : ConsoleWrapper
{
    public bool isGameInProgress = true;
    public bool needToAskUserToPlay = true;
    public bool needToSelectStarTrekShip = true;
    public bool needToSelectStarWarsShip = true;
    public string? selectedStarWarsShipName;
    public string? selectedStarTrekShipName;

    public void TitleBar()
    {
        Clear();
        WriteLine("Star Trek vs Star Wars!");
    }

    public void PlayGame()
    {
        if (needToAskUserToPlay)
        {
            WriteLine("Would you like to play a game? (Y)es or (N)o");
            var playerResponse = ReadLine();

            while (playerResponse?.ToLower() != "y" && playerResponse?.ToLower() != "n")
            {
                WriteLine($"Please enter ONLY Y or N. Would you like to play a game?");
                playerResponse = ReadLine();
            }

            if (playerResponse?.ToLower() == "n")
            {
                isGameInProgress = false;
            }
            needToAskUserToPlay = false;
            Clear();
        }
    }

    public void CollectStarTrekShip(List<StarTrekShip> shipList)
    {
        if (needToSelectStarTrekShip && isGameInProgress)
        {
            int shipCount = shipList.Count;
            printStarTrekList(shipList);

            WriteLine("\nPlease select Star Trek Ship. Enter the number from the list above");
            var playerResponse = ReadLine();
            int responseNum;

            while (!Int32.TryParse(playerResponse, out responseNum))
            {
                Clear();
                printStarTrekList(shipList);
                WriteLine($"\n{playerResponse} is not a valid number.");
                WriteLine("Please enter a number.");
                playerResponse = ReadLine();
            }

            while (responseNum == 0 || responseNum > shipCount)
            {
                Clear();
                printStarTrekList(shipList);
                WriteLine($"\n{responseNum} is not an allowed number within the range.");
                WriteLine($"Please enter a number between 1 and {shipCount}");
                playerResponse = ReadLine();
                while (!Int32.TryParse(playerResponse, out responseNum))
                {
                    Clear();
                    printStarTrekList(shipList);
                    WriteLine($"\n{playerResponse} is not a valid number.");
                    WriteLine("Please enter a number.");
                    playerResponse = ReadLine();
                }
            }
            selectedStarTrekShipName = shipList[responseNum - 1].Name;
            needToSelectStarTrekShip = false;
            Clear();
        }
    }

    private void printStarTrekList(List<StarTrekShip> shipList)
    {
        int shipCount = 1;
        foreach (var ship in shipList)
        {
            WriteLine($"{shipCount}) {ship.Name}");
            shipCount++;
        }
    }

    public void CollectStarWarsShip(List<StarWarsShip> shipList)
    {
        if (needToSelectStarWarsShip && isGameInProgress)
        {
            int shipCount = shipList.Count;
            printStarWarsList(shipList);

            WriteLine("\nPlease select Star Wars Ship. Enter the number from the list above");
            var playerResponse = ReadLine();
            int responseNum;

            while (!Int32.TryParse(playerResponse, out responseNum))
            {
                Clear();
                printStarWarsList(shipList);
                WriteLine($"\n{playerResponse} is not a valid number.");
                WriteLine("Please enter a number.");
                playerResponse = ReadLine();
            }


            while (responseNum == 0 || responseNum > shipCount)
            {
                Clear();
                printStarWarsList(shipList);
                WriteLine($"\n{responseNum} is not an allowed number within the range.");
                WriteLine($"Please enter a number between 1 and {shipCount}");
                playerResponse = ReadLine();
                while (!Int32.TryParse(playerResponse, out responseNum))
                {
                    Clear();
                    printStarWarsList(shipList);
                    WriteLine($"\n{playerResponse} is not a valid number.");
                    WriteLine("Please enter a number.");
                    playerResponse = ReadLine();
                }
            }
            selectedStarWarsShipName = shipList[responseNum - 1].Name;
            needToSelectStarWarsShip = false;
            Clear();
        }
    }

    private void printStarWarsList(List<StarWarsShip> shipList)
    {
        int shipCount = 1;
        foreach (var ship in shipList)
        {
            WriteLine($"{shipCount}) {ship.Name}");
            shipCount++;
        }
    }

    public void ConfirmShipSelection()
    {
        var goToSwitchingShips = false;
        if (isGameInProgress)
        {
            {
                WriteLine($"You selected {selectedStarWarsShipName}.");
                WriteLine("Would you like to change your Star Wars ship? (Y)es or (N)o");
                var playerResponse = ReadLine();

                while (playerResponse?.ToLower() != "y" && playerResponse?.ToLower() != "n")
                {
                    WriteLine($"Please enter ONLY Y or N.");
                    playerResponse = ReadLine();
                    Clear();
                }

                if (playerResponse?.ToLower() == "y")
                {
                    needToSelectStarWarsShip = true;
                    goToSwitchingShips = true;
                }

                WriteLine($"You selected {selectedStarTrekShipName}.");
                WriteLine("Would you like to change your Star Trek ship? (Y)es or (N)o");
                playerResponse = ReadLine();

                while (playerResponse?.ToLower() != "y" && playerResponse?.ToLower() != "n")
                {
                    WriteLine($"Please enter ONLY Y or N.");
                    playerResponse = ReadLine();
                    Clear();
                }

                if (playerResponse?.ToLower() == "y")
                {
                    needToSelectStarTrekShip = true;
                    goToSwitchingShips = true;
                }

                if (!goToSwitchingShips)
                {
                    isGameInProgress = false;
                }

            }
            Clear();
        }
    }

    public void QuitGame()
    {

    }
}
