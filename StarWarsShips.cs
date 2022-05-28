using System;

/// <summary>
/// List of objects
/// </summary>
public class StarWarsShips
{
    private int id;
    private string name;
    private string model;
    private string shipClass;
    private double length;
    private double width;
    private int accelSpeedG;
    private int accelSpeedMglt;
    private int mglt;
    private int speedAtmosMax;
    private int maneuverability;
    private int shieldsSbd;
    private int hull;
    private int cannons;
    private int torpedoes;
    private int missiles;
    private int tourInSpace;

    List<StarWarsShips> SwShips = new List<StarWarsShips>();

    public StarWarsShips(int id, string name, string model, string shipClass, double length, double width, int accelSpeedG, int accelSpeedMglt, int mglt, int speedAtmosMax, 
                            int maneuverability, int shieldsSbd, int hull, int cannons, int torpedoes, int missiles, int tourInSpace)
	{
        this.id = id;
        this.name = name;
        this.model = model;
        this.shipClass = shipClass;
        this.length = length;
        this.width = width;
        this.accelSpeedG = accelSpeedG;
        this.accelSpeedMglt = accelSpeedMglt;
        this.mglt = mglt;
        this.speedAtmosMax = speedAtmosMax;
        this.maneuverability = maneuverability;
        this.shieldsSbd = shieldsSbd;
        this.hull = hull;
        this.cannons = cannons;
        this.torpedoes = torpedoes;
        this.missiles = missiles;
        this.tourInSpace = tourInSpace;

        SwShips.Add(new StarWarsShips(1, "X-Wing", "T-65", "Star Fighter", 12.5, 0, 3700, 16, 100, 1050, 75, 50, 20, 4, 6, 0, 7));
        SwShips.Add(new StarWarsShips(2, "Y-Wing", "BTL", "Assault Star Fighter", 23.4, 16, 2700, 11, 80, 1000, 59, 75, 40, 6, 8, 0, 7));
        SwShips.Add(new StarWarsShips(3, "A-Wing", "RZ-1", "Star Fighter", 9.6, 6.48, 5100, 21, 120, 1300, 96, 50, 14, 2, 0, 12, 7));
        SwShips.Add(new StarWarsShips(4, "B-Wing", "A/SF-01", "Heavy Assault Fighter", 4.7, 7.3, 2390, 16, 91, 950, 70, 100, 14, 5, 20, 0, 7));
        SwShips.Add(new StarWarsShips(5, "Head-Hunter", "Z-95", "Star Fighter", 11.8, 0, 2780, 16, 100, 1150, 86, 20, 14, 2, 6, 12, 1));
        SwShips.Add(new StarWarsShips(6, "Mon Calamari Cruiser", "MC80a", "Star Cruiser", 1300, 0, 0, 0, 60, 0, 0, 0, 0, 68, 0, 0, 730));
        SwShips.Add(new StarWarsShips(7, "Millienium Falcon", "YT-1300", "Light Freighter", 34.75, 0, 0, 0, 0, 800, 0, 120, 76, 3, 2, 0, 60));
        SwShips.Add(new StarWarsShips(8, "TIE Star Fighter", "Twin ION Engine/LN", "Star Fighter", 6.3, 6.4, 4100, 20, 100, 1200, 96, 0, 15, 2, 0, 0, 2));
        SwShips.Add(new StarWarsShips(9, "TIE Interceptor", "Twin ION Engine/Interceptor", "Star Fighter", 9.6, 0, 4240, 21, 110, 1250, 104, 0, 16, 6, 2, 0, 2));
        SwShips.Add(new StarWarsShips(10, "TIE Star Bomber", "Twin ION Engine/sa Bomber", "Space/Planetary Bomber", 7.8, 8.6, 2380, 13, 60, 850, 86, 0, 28, 2, 2, 2, 2));
        SwShips.Add(new StarWarsShips(11, "Star Wing", "Alpha-Class Xg-1 Star Wing", "Assault Star Fighter", 10, 15.1, 0, 20, 90, 1050, 78, 100, 28 4, 2, 2, 3));
        SwShips.Add(new StarWarsShips(12, "TIE Avenger", "Twin ION Engine/ad Advanced", "Star Fighter", 9.8, 0, 0, 16 133, 1300, 104, 40, 14, 4, 2, 2, 2));
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Model { get; private set; }
    public string ShipClass { get; private set; }
    public double Length { get; private set; }
    public double Width { get; private set; }
    public int AccelSpeedG { get; private set; }
    public int AccelSpeedMglt { get; private set; }
    public int Mglt { get; private set; }
    public int SpeedAtmosMax { get; private set; }
    public int Maneuverability { get; private set; }
    public int ShieldsSbd { get; private set; }
    public int Hull { get; private set; }
    public int Cannons { get; private set; }
    public int Torpedoes { get; private set; }
    public int Missiles { get; private set; }
    public int TourInSpace { get; private set; }
}
