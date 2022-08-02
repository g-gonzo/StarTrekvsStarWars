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
    public void Check_ShipListExists()
    {
        //Arrange

        
        //Act


        //Assert


    }

    [TestMethod]
    public void Write_DisplaysThePassedInString()
    {
        ConsoleWrapper cw = new ConsoleWrapper();
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        cw.Write("Some Text");

        var output = stringWriter.ToString();
        Assert.AreEqual("Some Text", output);
    }

    [TestMethod]
    public void WriteLine_DisplaysThePassedInString()
    {
        ConsoleWrapper cw = new ConsoleWrapper();
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        cw.WriteLine("Some Text");

        var output = stringWriter.ToString();
        Assert.AreEqual("Some Text\r\n", output);
    }
}
