using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekvsStarWars;

public class StarTrekShip : Ship
{
    public StarTrekShip(int id, string name, string model, string shipClass, string shields) : base(id, name, model, shipClass, shields)
    {

    }
    public StarTrekShip(int id, string name, string model, string shipClass, double length, double width, double warpStd, double warpCrs, double warpMax, int speedAtmosMax, int maneuverability, string shields, int hull, int phasers, int torpedoes, int missiles, int tourInSpace) : base(id, name, model, shipClass, length, width, warpStd, warpCrs, warpMax, speedAtmosMax, maneuverability, shields, hull, phasers, torpedoes, missiles, tourInSpace)
    {
    }

    public StarTrekShip(string[] values) : base(values)
    {
    }

    public void GetStarTrekShips()
    {
        Console.WriteLine("TODO - Returns list of Star Trek Ships ");
        Console.WriteLine("TODO - We need to be able to select choice");
        Console.WriteLine("TODO - Write Get Star Wars Ships.");
    }
}


