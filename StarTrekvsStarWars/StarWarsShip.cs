using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekvsStarWars;

public class StarWarsShip : Ship
{
    public StarWarsShip(int id, string name, string model, string shipClass, string shields, int shipSpeed) : base(id, name, model, shipClass, shields, shipSpeed)
    {

    }
    public StarWarsShip(int id, string name, string model, string shipClass, double length, double width, double warpStd, double warpCrs, double warpMax, int speedAtmosMax, int maneuverability, string shields, int hull, int phasers, int torpedoes, int missiles, int tourInSpace) : base(id, name, model, shipClass, length, width, warpStd, warpCrs, warpMax, speedAtmosMax, maneuverability, shields, hull, phasers, torpedoes, missiles, tourInSpace)
    {
    }

    public StarWarsShip(string[] values) : base(values)
    {
    }
    public StarWarsShip(int id, string name, string model, string shipClass, string shields) : base(id, name, model, shipClass, shields)
    {
        
    }

    public void GetStarWarsShips()
    {
        Console.WriteLine("TODO - Returns list of Star Trek Ships ");
        Console.WriteLine("TODO - We need to be able to select choice");
        Console.WriteLine("TODO - Write Get Star Wars Ships.");
    }
}
