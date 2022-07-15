using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekVsStarWars
{
    public class GameLogic
    {
        public bool isGameInProgress = true;
        private bool needToAskUserToPlay = true;
        private bool needToSelectStarTrekShip = true;
        private bool needToSelectStarWarsShip = true;

        public void TitleBar()
        {
            Console.WriteLine("Star Trek vs Star Wars!");
        }

        public void PlayGame()
        {
            if (needToAskUserToPlay)
            {
                Console.WriteLine($"Would you like to play a game? (Y)es or (N)o");
                var playerResponse = Console.ReadLine();

                while (playerResponse?.ToLower() != "y" && playerResponse?.ToLower() != "n")
                {
                    Console.WriteLine($"Please enter ONLY Y or N. Would you like to play a game?");
                    playerResponse = Console.ReadLine();
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
                Console.WriteLine($"Please enter a Star Trek Ship Name? (Y)es or (N)o");
                var playerResponse = Console.ReadLine();

                Console.WriteLine($"TODO - Write Get Star Trek Ships method");
                needToSelectStarTrekShip = false;
            }
        }

        public void CollectStarWarsShip()
        {
            if (needToSelectStarWarsShip && isGameInProgress)
            {
                Console.WriteLine($"Please enter a Star Wars Ship Name? (Y)es or (N)o");
                var playerResponse = Console.ReadLine();

                Console.WriteLine($"TODO - Write Get Star Wars Ships method");
                needToSelectStarWarsShip = false;
            }
        }

        public void ConfirmShipSelection()
        {
            var goToSwitchingShips = false;
            if (isGameInProgress)
            {
                {
                    Console.WriteLine($"Would you like change the selected Star Wars Ship? (Y)es or (N)o");
                    var playerResponse = Console.ReadLine();

                    while (playerResponse?.ToLower() != "y" && playerResponse?.ToLower() != "n")
                    {
                        Console.WriteLine($"Please enter ONLY Y or N.");
                        playerResponse = Console.ReadLine();
                    }

                    if (playerResponse?.ToLower() == "y")
                    {
                        needToSelectStarWarsShip = true;
                        goToSwitchingShips = true;
                    }

                    Console.WriteLine($"Would you like change the selected Star Trek Ship? (Y)es or (N)o");
                    playerResponse = Console.ReadLine();

                    while (playerResponse?.ToLower() != "y" && playerResponse?.ToLower() != "n")
                    {
                        Console.WriteLine($"Please enter ONLY Y or N.");
                        playerResponse = Console.ReadLine();
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
}
