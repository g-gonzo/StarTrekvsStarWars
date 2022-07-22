using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekvsStarWars;

public class GameLogic : ConsoleWrapper
{
    public bool isGameInProgress = true;
    public bool needToAskUserToPlay = true;
    public bool needToSelectStarTrekShip = true;
    public bool needToSelectStarWarsShip = true;

    public void TitleBar()
    {
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
        }
    }

    public void CollectStarTrekShip()
    {
        if (needToSelectStarTrekShip && isGameInProgress)
        {
            WriteLine($"Please enter a Star Trek Ship Name? (Y)es or (N)o");
            var playerResponse = ReadLine();

            WriteLine($"TODO - Write Get Star Trek Ships method");
            needToSelectStarTrekShip = false;
        }
    }

    public void CollectStarWarsShip()
    {
        if (needToSelectStarWarsShip && isGameInProgress)
        {
            WriteLine($"Please enter a Star Wars Ship Name? (Y)es or (N)o");
            var playerResponse = ReadLine();

            WriteLine($"TODO - Write Get Star Wars Ships method");
            needToSelectStarWarsShip = false;
        }
    }

    public void ConfirmShipSelection()
    {
        var goToSwitchingShips = false;
        if (isGameInProgress)
        {
            {
                WriteLine($"Would you like to change the selected Star Wars Ship? (Y)es or (N)o");
                var playerResponse = ReadLine();

                while (playerResponse?.ToLower() != "y" && playerResponse?.ToLower() != "n")
                {
                    WriteLine($"Please enter ONLY Y or N.");
                    playerResponse = ReadLine();
                }

                if (playerResponse?.ToLower() == "y")
                {
                    needToSelectStarWarsShip = true;
                    goToSwitchingShips = true;
                }

                WriteLine($"Would you like to change the selected Star Trek Ship? (Y)es or (N)o");
                playerResponse = ReadLine();

                while (playerResponse?.ToLower() != "y" && playerResponse?.ToLower() != "n")
                {
                    WriteLine($"Please enter ONLY Y or N.");
                    playerResponse = ReadLine();
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
        }
    }

    public void QuitGame()
    {

    }
}
