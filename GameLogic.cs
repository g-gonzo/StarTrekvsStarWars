using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekVsStarWars
{
    public class GameLogic
    {

        public void TitleBar()
        {
            Console.WriteLine("Star Trek vs Star Wars!");
        }

        public void PlayGame()
        {

            Console.WriteLine($"Would you like to play a game? (Y)es or (N)o");
            //Console.ReadLine();

            var playerResponse = Console.ReadLine();
            Console.ReadLine();

            if (playerResponse == "y")
            {
                StartGame();
                //Console.WriteLine($"TODO - Write Start Game method");
            }
            else if (playerResponse == "n")
            {
                Console.WriteLine($"TODO - Write Quit/Reset Method");
            }

        }

        public void StartGame()
        {
            Console.WriteLine($"Would you like to comapare Star Trek Ships? (Y)es or (N)o");
            //Console.ReadLine();

            var playerResponse = Console.ReadLine();
            Console.ReadLine();

            if (playerResponse == "y")
            {
                //StarTrekShip.GetStarTrekShips();
                Console.WriteLine($"TODO - Write Get Star Trek Ships method");
            }
            else if (playerResponse == "n")
            {
                Console.WriteLine($"TODO - Write Quit/Reset Method");
            }
        }

        public void QuitGame()
        {

        }
    }
}
