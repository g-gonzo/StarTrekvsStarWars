using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarTrekvsStarWars;
using System.IO;
using System;
using System.Text;
using System.Collections.Generic;

namespace StarTrekvsStarWarsTest;

[TestClass]
public class StarWarsShipTest
{

    [TestMethod]
    public void StarWarsShip_Check_ShipConstuctor1()
    {
        List<StarWarsShip> StarWarsShipList1 = new List<StarWarsShip>
    {
        new StarWarsShip(1, "nameOne", "thisModel", "thisShipClass", "55"),
        new StarWarsShip(2, "nameTwo", "thatModel", "thatShipClass","15")
    };

        var switem = StarWarsShipList1.Find(switem => switem.Id == 1);
        Assert.AreEqual(switem.Id, 1);
        Assert.AreEqual(switem.Name, "nameOne");
        Assert.AreEqual(switem.Model, "thisModel");
        Assert.AreEqual(switem.ShipClass, "thisShipClass");
        Assert.AreEqual(switem.Shields, "55");
    }

    [TestMethod]
    public void StarWarsShip_Check_ShipConstructor2()
    {
        List<StarWarsShip> StarWarsShipList2 = new List<StarWarsShip>
    {
        new StarWarsShip(1, "nameOne", "thisModel", "thisShipClass", 65.5, 34, 3700, 15, 55, 800, 50, "55", 20, 12, 24, 6, 365),
        new StarWarsShip(2, "nameTwo", "thatModel", "thatShipClass", 20.5, 15.5, 4000, 20, 75, 875, 30, "15", 10, 2, 4, 6, 5)
    };
        var switem = StarWarsShipList2.Find(switem => switem.Id == 1);

        Assert.AreEqual(switem.Id, 1);
        Assert.AreEqual(switem.Name, "nameOne");
        Assert.AreEqual(switem.Model, "thisModel");
        Assert.AreEqual(switem.ShipClass, "thisShipClass");
        Assert.AreEqual(switem.Length, 65.5);
        Assert.AreEqual(switem.Width, 34);
        Assert.AreEqual(switem.WarpStd, 3700);
        Assert.AreEqual(switem.WarpCrs, 15);
        Assert.AreEqual(switem.WarpMax, 55);
        Assert.AreEqual(switem.SpeedAtmosMax, 800);
        Assert.AreEqual(switem.Maneuverability, 50);
        Assert.AreEqual(switem.Shields, "55");
        Assert.AreEqual(switem.Hull, 20);
        Assert.AreEqual(switem.Phasers, 12);
        Assert.AreEqual(switem.Torpedoes, 24);
        Assert.AreEqual(switem.Missiles, 6);
        Assert.AreEqual(switem.TourInSpace, 365);
        Assert.AreEqual(StarWarsShipList2.Count, 2);
    }


    [TestMethod]
    public void StarWarsShip_Check_ShipConstructor3()
    {
        string[] StarWarsShipArry3 = { "1", "nameOne", "thisModel", "thisShipClass", "65.5", "34", "3700", "15", "55", "800", "50", "55", "20", "12", "24", "6", "365" };

        List<StarWarsShip> StarWarShipList3 = new List<StarWarsShip> { new StarWarsShip(StarWarsShipArry3) };

        var switem = StarWarShipList3.Find(switem => switem.Id == 1);
        Assert.AreEqual(switem.Id, 1);
        Assert.AreEqual(switem.Name, "nameOne");
        Assert.AreEqual(switem.Model, "thisModel");
        Assert.AreEqual(switem.ShipClass, "thisShipClass");
        Assert.AreEqual(switem.Length, 65.5);
        Assert.AreEqual(switem.Width, 34);
        Assert.AreEqual(switem.WarpStd, 3700);
        Assert.AreEqual(switem.WarpCrs, 15);
        Assert.AreEqual(switem.WarpMax, 55);
        Assert.AreEqual(switem.SpeedAtmosMax, 800);
        Assert.AreEqual(switem.Maneuverability, 50);
        Assert.AreEqual(switem.Shields, "55");
        Assert.AreEqual(switem.Hull, 20);
        Assert.AreEqual(switem.Phasers, 12);
        Assert.AreEqual(switem.Torpedoes, 24);
        Assert.AreEqual(switem.Missiles, 6);
        Assert.AreEqual(switem.TourInSpace, 365);
    }

}
