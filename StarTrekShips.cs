using System;
using System.Collections.Generic;

public class StarTrekShips
{
	private int id;
	private string name;
	private string model;
	private string shipClass;
	private float length;		
	private float width;
	private float warpStd;     
	private float warpCrs;
	private float warpMax;
	private int speedAtmosMax;
	private int maneuverability;
	private string shields;
	private int hull;
	private int phasers;
	private int torpedoes;
	private int missiles;
	private int tourInSpace;

	List<StarTrekShips> StShips = new List<StarTrekShips>();

	public StarTrekShips()
	{
		this.id = id;
		this.name = name;
		this.model = model;
		this.shipClass = shipClass;
		this.length = length;
		this.width = width;
		this.warpStd = warpStd;
		this.warpCrs = warpCrs;
		this.warpMax = warpMax;
		this.speedAtmosMax = speedAtmosMax;
		this.maneuverability = maneuverability;
		this.shields = shields;
		this.hull = hull;
		this.phasers = phasers;
		this.torpedoes = torpedoes;
		this.missiles = missiles;
		this.tourInSpace = tourInSpace;

		StShips.Add(new StarTrekShips(101, "Valkyrie", "Constellation", "Exploratory Cruiser", 315, 175, 6, 7, 8, 0, 0, "Merlin", 325000, 18, 3, 0, 3650));
		StShips.Add(new StarTrekShips(102, "Intrepid", "Excelsior", "Heavy Cruiser", 467, 186, 8, 9, 9.3, 0, 0, "Merlin", 1534610, 24, 4, 0, 1825));
		StShips.Add(new StarTrekShips(103, "Excalibur", "Ambassador", "Heavy Cruiser", 526, 320, 6, 8.5, 9, 0, 0, "FSP/1", 3740000, 12, 2, 0, 1825));
		StShips.Add(new StarTrekShips(104, "Fartagut", "Nebula", "Light Cruiser", 442.23, 463.73, 6, 9.2, 9.6, 0, 0, "FSQ/1", 3309000, 8, 2, 0, 1825));
		StShips.Add(new StarTrekShips(105, "Princeton", "Niagara", "Fast Cruiser", 565, 505, 7, 9, 9.4, 0, 0, "FSP/1", 41850000, 12, 2, 0, 1825));
		StShips.Add(new StarTrekShips(106, "Enterprise", "Galaxy", "Large Exploratory Cruiser", 642.51, 463.73, 6, 9.2, 9.6, 0, 0, "FSQ/1", 4500000, 12, 2, 0, 1825));
		StShips.Add(new StarTrekShips(107, "Dominion", "Akira", "Battle Cruiser", 455, 292, 7, 9, 9.8, 0, 0, "FSQ/1", 1600000, 6, 8, 0, 1825));
		StShips.Add(new StarTrekShips(108, "Magellan", "Galaxy II", "Large Exploratory Cruiser", 642.51, 463.73, 7, 9.5, 9.9, 0, 0, "FSS/1", 4780000, 12, 2, 0, 1825));
		StShips.Add(new StarTrekShips(109, "Vengeance", "Entente", "Dreadnought", 643, 464, 7, 9.5, 9.9, 0, 0, "FSQ/2", 5520000, 15, 4, 0, 1825));
		StShips.Add(new StarTrekShips(110, "Tsunami", "Sullivans", "Tactical Frigate", 320, 256, 6, 9, 9.6, 0, 0, "FSQ/1", 14850000, 12, 8, 0, 1825));
		StShips.Add(new StarTrekShips(111, "Concorde", "Freedom", "Destroyer", 430, 260, 0, 7.5, 9, 0, 0, "FSP/1", 1075000, 3, 2, 0, 1825));
		StShips.Add(new StarTrekShips(112, "Everst", "Steam Runner", "Heavy Destroyer", 292, 217, 7, 9, 9.6, 0, 0, "FSP/1", 275000, 6, 2, 0, 1825));

	}

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Model { get; private set; }
    public string ShipClass { get; private set; }
    public float Length { get; private set; }
    public float Width { get; private set; }
    public float WarpStd { get; private set; }
    public float WarpCrs { get; private set; }
    public float WarpMax { get; private set; }
    public int SpeedAtmosMax { get; private set; }
    public int Maneuverability { get; private set; }
    public string Shields { get; private set; }
    public int Hull { get; private set; }
    public int Phasers { get; set; }
    public int Torpedoes { get; private set; }
    public int Missiles { get; private set; }
    public int TourInSpace { get; private set; }
}
