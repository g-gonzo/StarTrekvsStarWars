using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekvsStarWars;

public abstract class Ship
{
    public int Id { get; internal set; }
    public string Name { get; internal set; }
    public string Model { get; internal set; }
    public string ShipClass { get; internal set; }
    public double Length { get; internal set; }
    public double Width { get; internal set; }
    public double WarpStd { get; internal set; }
    public double WarpCrs { get; internal set; }
    public double WarpMax { get; internal set; }
    public int SpeedAtmosMax { get; internal set; }
    public int Maneuverability { get; internal set; }
    public string Shields { get; internal set; }
    public int Hull { get; internal set; }
    public int Phasers { get; internal set; }
    public int Torpedoes { get; internal set; }
    public int Missiles { get; internal set; }
    public int TourInSpace { get; internal set; }

    public Ship(int id, string name, string model, string shipClass, string shields, int shipSpeed)
    {
        this.Id = id;
        this.Name = name;
        this.Model = model;
        this.ShipClass = shipClass;
        this.Shields = shields;
        this.WarpStd = shipSpeed;
    }
    public Ship(int id, string name, string model, string shipClass, double length, double width, double warpStd, double warpCrs, double warpMax, int speedAtmosMax,
      int maneuverability, string shields, int hull, int phasers, int torpedoes, int missiles, int tourInSpace)
    {
        this.Id = id;
        this.Name = name;
        this.Model = model;
        this.ShipClass = shipClass;
        this.Length = length;
        this.Width = width;
        this.WarpStd = warpStd;
        this.WarpCrs = warpCrs;
        this.WarpMax = warpMax;
        this.SpeedAtmosMax = speedAtmosMax;
        this.Maneuverability = maneuverability;
        this.Shields = shields;
        this.Hull = hull;
        this.Phasers = phasers;
        this.Torpedoes = torpedoes;
        this.Missiles = missiles;
        this.TourInSpace = tourInSpace;
    }

    public Ship(string[] values)
    {
        this.Id = Int32.Parse(values[0]);
        this.Name = values[1];
        this.Model = values[2];
        this.ShipClass = values[3];
        this.Length = Double.Parse(values[4]);
        this.Width = Double.Parse(values[5]);
        this.WarpStd = Double.Parse(values[6]);
        this.WarpCrs = Double.Parse(values[7]);
        this.WarpMax = Double.Parse(values[8]);
        this.SpeedAtmosMax = Int32.Parse(values[9]);
        this.Maneuverability = Int32.Parse(values[10]);
        this.Shields = values[11];
        this.Hull = Int32.Parse(values[12]);
        this.Phasers = Int32.Parse(values[13]);
        this.Torpedoes = Int32.Parse(values[14]);
        this.Missiles = Int32.Parse(values[15]);
        this.TourInSpace = Int32.Parse(values[16]);
    }
}
