using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekVsStarWars
{
    public class StarWarsShip : Ship
    {
        public StarWarsShip(int id, string name, string model, string shipClass, double length, double width, double warpStd, double warpCrs, double warpMax, int speedAtmosMax, int maneuverability, string shields, int hull, int phasers, int torpedoes, int missiles, int tourInSpace) : base(id, name, model, shipClass, length, width, warpStd, warpCrs, warpMax, speedAtmosMax, maneuverability, shields, hull, phasers, torpedoes, missiles, tourInSpace)
        {

        }
    }
}