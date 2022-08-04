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
   

    List<StarWarsShip> StarWarsShipList = new List<StarWarsShip>
    {
        new StarWarsShip(1, "nameOne", "thisModel", "thisShipClass", 65.5, 34, 3700, 15, 55, 800, 50, "55", 20, 12, 24, 6, 365),
        new StarWarsShip(2, "nameTwo", "thatModel", "thatShipClass", 20.5, 15.5, 4000, 20, 75, 875, 30, "15", 10, 2, 4, 6, 5)
    };

    [TestMethod]
    public void StarWarsShip_Check_ListExists()
    {
        //Arrange
       var swcount = StarWarsShipList.Count;
        var shipcount = 2;
        var result = false;
        //Act
        if (swcount == shipcount)
        {
            result = true;
        }
        else { result = false; }   
        //Assert
        Assert.IsTrue(result);  
    }

    [TestMethod]
    public void StarWarsShip_Check_SomeThing()
    {
 
     
    }

}
