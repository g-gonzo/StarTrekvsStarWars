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

    public int CompareShipsAndDetermineWinner(int StarTrekId, int StarWarsId)
    {
       var StarTrekShipToCompare = StarTrekShipList.Find(x => x.Id == StarTrekId);
       var StarWarsShipToCompare = StarWarsShipList.Find(x => x.Id == StarWarsId);

       var winner = StarTrekShipToCompare?.SpeedAtmosMax > StarWarsShipToCompare?.SpeedAtmosMax ? StarTrekId : StarWarsId;
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

    public void DisplayWinner(int StarTrekId, int StarWarsId, bool StarTrekShipWon)
    {
        var starTrekShip = StarTrekShipList.Find(x => x.Id == StarTrekId);
        var starWarsShip = StarWarsShipList.Find(x => x.Id == StarWarsId);

        WriteLine($"\n{selectedStarTrekShipName} has a speed of {starTrekShip?.SpeedAtmosMax}");
        WriteLine($"\n{selectedStarWarsShipName} has a speed of {starWarsShip?.SpeedAtmosMax}");
        WriteLine($"\n{(StarTrekShipWon ? selectedStarTrekShipName : selectedStarWarsShipName)} is the winner! Because they have more speed.");
    }

    public void QuitGame()
    {

    }
}
