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
    public bool goToSwitchingShips = false;
    public bool displayShipSelection = true;
    public bool needToAskUserToPlay = true;
    public bool needToSelectStarTrekShip = true;
    public bool needToSelectStarWarsShip = true;
    public string? selectedStarWarsShipName;
    public string? selectedStarTrekShipName;
    public List<StarTrekShip> StarTrekShipList;
    public List<StarWarsShip> StarWarsShipList;

    public GameLogic(List<StarTrekShip> starTrekShipList, List<StarWarsShip> starWarsShipList)
    {
        StarTrekShipList = starTrekShipList;
        StarWarsShipList = starWarsShipList;
    }

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

    public string? CompareShipsAndDetermineWinner()
    {
       var starTrekShipToCompare = StarTrekShipList.Find(x => x.Name == selectedStarTrekShipName);
       var starWarsShipToCompare = StarWarsShipList.Find(x => x.Name == selectedStarWarsShipName);

       if (starTrekShipToCompare?.WarpStd == starWarsShipToCompare?.WarpStd)
        {
            return "tied";
        } 

       var winner = starTrekShipToCompare?.WarpStd > starWarsShipToCompare?.WarpStd ? selectedStarTrekShipName : selectedStarWarsShipName;
       return winner;
    }

    public int CollectStarTrekShip()
    {
        if (needToSelectStarTrekShip && isGameInProgress)
        {
            int shipCount = StarTrekShipList.Count;
            printStarTrekList();

            WriteLine("\nPlease select Star Trek Ship. Enter the number from the list above");
            var playerResponse = ReadLine();
            int responseNum;

            while (!Int32.TryParse(playerResponse, out responseNum))
            {
                Clear();
                printStarTrekList();
                WriteLine($"\n{playerResponse} is not a valid number.");
                WriteLine("Please enter a number.");
                playerResponse = ReadLine();
            }

            while (responseNum == 0 || responseNum > shipCount)
            {
                Clear();
                printStarTrekList();
                WriteLine($"\n{responseNum} is not an allowed number within the range.");
                WriteLine($"Please enter a number between 1 and {shipCount}");
                playerResponse = ReadLine();
                while (!Int32.TryParse(playerResponse, out responseNum))
                {
                    Clear();
                    printStarTrekList();
                    WriteLine($"\n{playerResponse} is not a valid number.");
                    WriteLine("Please enter a number.");
                    playerResponse = ReadLine();
                }
            }
            selectedStarTrekShipName = StarTrekShipList[responseNum - 1].Name;
            needToSelectStarTrekShip = false;
            Clear();
            return StarTrekShipList[responseNum - 1].Id;
        }
        return 0;
    }

    private void printStarTrekList()
    {
        int shipCount = 1;
        foreach (var ship in StarTrekShipList)
        {
            WriteLine($"{shipCount}) {ship.Name}");
            shipCount++;
        }
    }

    public int CollectStarWarsShip()
    {
        if (needToSelectStarWarsShip && isGameInProgress)
        {
            int shipCount = StarWarsShipList.Count;
            printStarWarsList();

            WriteLine("\nPlease select Star Wars Ship. Enter the number from the list above");
            var playerResponse = ReadLine();
            int responseNum;

            while (!Int32.TryParse(playerResponse, out responseNum))
            {
                Clear();
                printStarWarsList();
                WriteLine($"\n{playerResponse} is not a valid number.");
                WriteLine("Please enter a number.");
                playerResponse = ReadLine();
            }


            while (responseNum == 0 || responseNum > shipCount)
            {
                Clear();
                printStarWarsList();
                WriteLine($"\n{responseNum} is not an allowed number within the range.");
                WriteLine($"Please enter a number between 1 and {shipCount}");
                playerResponse = ReadLine();
                while (!Int32.TryParse(playerResponse, out responseNum))
                {
                    Clear();
                    printStarWarsList();
                    WriteLine($"\n{playerResponse} is not a valid number.");
                    WriteLine("Please enter a number.");
                    playerResponse = ReadLine();
                }
            }
            selectedStarWarsShipName = StarWarsShipList[responseNum - 1].Name;
            needToSelectStarWarsShip = false;
            Clear();
            return StarWarsShipList[responseNum - 1].Id;
        }
        return 0;
    }

    private void printStarWarsList()
    {
        int shipCount = 1;
        foreach (var ship in StarWarsShipList)
        {
            WriteLine($"{shipCount}) {ship.Name}");
            shipCount++;
        }
    }

    public void ConfirmShipSelection()
    {
        if (displayShipSelection && isGameInProgress)
        {
            {
                WriteLine($"You selected {selectedStarWarsShipName}.");
                WriteLine("Would you like to change your Star Wars ship? (Y)es or (N)o");
                var StarWarsPlayerResponse = ReadLine();

                while (StarWarsPlayerResponse?.ToLower() != "y" && StarWarsPlayerResponse?.ToLower() != "n")
                {
                    WriteLine($"Please enter ONLY Y or N.");
                    StarWarsPlayerResponse = ReadLine();
                    Clear();
                }

                if (StarWarsPlayerResponse?.ToLower() == "y")
                {
                    needToSelectStarWarsShip = true;
                    goToSwitchingShips = true;
                }

                WriteLine($"You selected {selectedStarTrekShipName}.");
                WriteLine("Would you like to change your Star Trek ship? (Y)es or (N)o");
                var StarTrekPlayerResponse = ReadLine();

                while (StarTrekPlayerResponse?.ToLower() != "y" && StarTrekPlayerResponse?.ToLower() != "n")
                {
                    WriteLine($"Please enter ONLY Y or N.");
                    StarTrekPlayerResponse = ReadLine();
                    Clear();
                }

                if (StarTrekPlayerResponse?.ToLower() == "y")
                {
                    needToSelectStarTrekShip = true;
                    goToSwitchingShips = true;
                }
                if (StarTrekPlayerResponse?.ToLower() == "n" && StarWarsPlayerResponse?.ToLower() == "n")
                {
                    displayShipSelection = false;
                    goToSwitchingShips = false;
                }
            }
            Clear();
        }
    }

    public void DisplayWinner()
    {
        if (!goToSwitchingShips && isGameInProgress)
        {
        var results = CompareShipsAndDetermineWinner();
        var starTrekShip = StarTrekShipList.Find(x => x.Name == selectedStarTrekShipName);
        var starWarsShip = StarWarsShipList.Find(x => x.Name == selectedStarWarsShipName);
        WriteLine($"\n{selectedStarTrekShipName} has a speed of {starTrekShip?.WarpStd}");
        WriteLine($"\n{selectedStarWarsShipName} has a speed of {starWarsShip?.WarpStd}");
            if (results == "tied")
            {
                WriteLine($"\nShips tied, please try again.");
            } else
            {
                WriteLine($"\n{(results == selectedStarTrekShipName ? selectedStarTrekShipName : selectedStarWarsShipName)} is the winner! Because they have more speed.");
            }
            isGameInProgress = false;
        }
    }

    public void QuitGame()
    {

    }
}
