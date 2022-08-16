using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarTrekvsStarWars;

namespace StarTrekvsStarWarsTest;

[TestClass]
public class GameLogicTest
{
    List<StarTrekShip> starTrekShipList = new List<StarTrekShip>
    {
        new StarTrekShip( 1, "StarTrekNameOne", "thisModel", "thisShipClass", "thisShield", 6),
        new StarTrekShip( 2, "StarTrekNameTwo", "thatModel", "thatShipClass", "thatShield", 11)
    };

    string starTrekDisplayedList = "1) StarTrekNameOne\r\n2) StarTrekNameTwo\r\n";

    List<StarWarsShip> starWarsShipList = new List<StarWarsShip>
    {
        new StarWarsShip( 1, "StarWarsNameOne", "thisModel", "thisShipClass", "thisShield", 6),
        new StarWarsShip( 2, "StarWarsNameTwo", "thatModel", "thatShipClass", "thatShield", 7)
    };

    string StarWarsDisplayedList = "1) StarWarsNameOne\r\n2) StarWarsNameTwo\r\n";

    [TestMethod]
    public void PlayGame_TypeLowerN_ShouldEndTheGame()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringReader = new StringReader("n");
        Console.SetIn(stringReader);

        gl.PlayGame();

        var output = stringWriter.ToString();
        Assert.AreEqual("Would you like to play a game? (Y)es or (N)o\r\n", output);
        Assert.IsFalse(gl.isGameInProgress);
        Assert.IsFalse(gl.needToAskUserToPlay);
    }

    [TestMethod]
    public void PlayGame_TypeUpperN_ShouldEndTheGame()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringReader = new StringReader("N");
        Console.SetIn(stringReader);

        gl.PlayGame();

        var output = stringWriter.ToString();
        Assert.AreEqual("Would you like to play a game? (Y)es or (N)o\r\n", output);
        Assert.IsFalse(gl.isGameInProgress);
        Assert.IsFalse(gl.needToAskUserToPlay);
    }

    [TestMethod]
    public void PlayGame_TypeUpperY_ShouldLetTheGameProgress()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringReader = new StringReader("Y");
        Console.SetIn(stringReader);

        gl.PlayGame();

        var output = stringWriter.ToString();
        Assert.AreEqual("Would you like to play a game? (Y)es or (N)o\r\n", output);
        Assert.IsTrue(gl.isGameInProgress);
        Assert.IsFalse(gl.needToAskUserToPlay);
    }

    [TestMethod]
    public void PlayGame_TypeLowerY_ShouldLetTheGameProgress()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringReader = new StringReader("y");
        Console.SetIn(stringReader);

        gl.PlayGame();

        var output = stringWriter.ToString();
        Assert.AreEqual("Would you like to play a game? (Y)es or (N)o\r\n", output);
        Assert.IsTrue(gl.isGameInProgress);
        Assert.IsFalse(gl.needToAskUserToPlay);
    }

    [TestMethod]
    public void PlayGame_TypingRandomText_ShouldKeepAskingUntilAProperResponseIsGiven()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("RandomText");
        stringBuilder.AppendLine("n");
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);

        gl.PlayGame();

        var output = stringWriter.ToString();
        Assert.AreEqual("Would you like to play a game? (Y)es or (N)o\r\n" +
            "Please enter ONLY Y or N. Would you like to play a game?\r\n", output);
        Assert.IsFalse(gl.isGameInProgress);
        Assert.IsFalse(gl.needToAskUserToPlay);
    }

    [TestMethod]
    public void CollectStarTrekShip_AnsweringQuestionWithExpectedNumAnswer()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.needToSelectStarTrekShip = true;
        gl.isGameInProgress = true;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringReader = new StringReader("1");
        Console.SetIn(stringReader);

        gl.CollectStarTrekShip();

        var output = stringWriter.ToString();
        Assert.AreEqual(
            starTrekDisplayedList +
            "\n" +
            "Please select Star Trek Ship. Enter the number from the list above\r\n", output);
        Assert.IsFalse(gl.needToSelectStarTrekShip);
    }

    [TestMethod]
    public void CollectStarTrekShip_AnsweringQuestionWithLetters()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.needToSelectStarTrekShip = true;
        gl.isGameInProgress = true;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("RandomText");
        stringBuilder.AppendLine("1");
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);

        gl.CollectStarTrekShip();

        var output = stringWriter.ToString();
        Assert.AreEqual(
            starTrekDisplayedList +
            "\n" +
            "Please select Star Trek Ship. Enter the number from the list above\r\n" +
            starTrekDisplayedList +
            "\n" +
            "RandomText is not a valid number.\r\n" +
            "Please enter a number.\r\n", output);
        Assert.IsFalse(gl.needToSelectStarTrekShip);
    }

    [TestMethod]
    public void CollectStarTrekShip_AnsweringQuestionWithIncorrectNumbersAndLetters()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.needToSelectStarTrekShip = true;
        gl.isGameInProgress = true;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("3");
        stringBuilder.AppendLine("RandomText");
        stringBuilder.AppendLine("1");
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);

        gl.CollectStarTrekShip();

        var output = stringWriter.ToString();
        Assert.AreEqual(
            starTrekDisplayedList +
            "\n" +
            "Please select Star Trek Ship. Enter the number from the list above\r\n" +
            starTrekDisplayedList +
            "\n" +
            "3 is not an allowed number within the range.\r\n" +
            "Please enter a number between 1 and 2\r\n" +
            starTrekDisplayedList +
            "\n" +
            "RandomText is not a valid number.\r\n" +
            "Please enter a number.\r\n", output);
        Assert.IsFalse(gl.needToSelectStarTrekShip);
    }

    [TestMethod]
    public void CollectStarTrekShip_AnsweringQuestionWithSecondNumberInList()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.needToSelectStarTrekShip = true;
        gl.isGameInProgress = true;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("2");
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);

        gl.CollectStarTrekShip();

        var output = stringWriter.ToString();
        Assert.AreEqual(
            starTrekDisplayedList +
            "\n" +
            "Please select Star Trek Ship. Enter the number from the list above\r\n", output);
        Assert.IsFalse(gl.needToSelectStarTrekShip);
        Assert.AreEqual(gl.selectedStarTrekShipName, "StarTrekNameTwo");
    }

    [TestMethod]
    public void CollectStarTrekShip_isGameInProgressIsFalse_needToSelectStarTrekShipIsTrue_ShouldDoNothing()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.needToSelectStarTrekShip = true;
        gl.isGameInProgress = false;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        gl.CollectStarTrekShip();

        var output = stringWriter.ToString();
        Assert.AreEqual("", output);
        Assert.IsTrue(gl.needToSelectStarTrekShip);
    }

    [TestMethod]
    public void CollectStarTrekShip_isGameInProgressIsTrue_needToSelectStarTrekShipIsFalse_ShouldDoNothing()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.needToSelectStarTrekShip = false;
        gl.isGameInProgress = true;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        gl.CollectStarTrekShip();

        var output = stringWriter.ToString();
        Assert.AreEqual("", output);
        Assert.IsFalse(gl.needToSelectStarTrekShip);
    }

    [TestMethod]
    public void CollectStarTrekShip_isGameInProgressIsFalse_needToSelectStarTrekShipIsFalse_ShouldDoNothing()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.needToSelectStarTrekShip = false;
        gl.isGameInProgress = false;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        gl.CollectStarTrekShip();

        var output = stringWriter.ToString();
        Assert.AreEqual("", output);
        Assert.IsFalse(gl.needToSelectStarTrekShip);
    }

    [TestMethod]
    public void CollectStarWarsShip_isGameInProgressIsTrue_needToSelectStarWarsShipIsTrue_ShouldPopQuestion()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.needToSelectStarWarsShip = true;
        gl.isGameInProgress = true;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringReader = new StringReader("1");
        Console.SetIn(stringReader);

        gl.CollectStarWarsShip();

        var output = stringWriter.ToString();
        Assert.AreEqual(StarWarsDisplayedList +
            "\n" +
            "Please select Star Wars Ship. Enter the number from the list above\r\n", output);
        Assert.IsFalse(gl.needToSelectStarWarsShip);
        Assert.AreEqual(gl.selectedStarWarsShipName, "StarWarsNameOne");
    }

    [TestMethod]
    public void CollectStarWarsShip_FirstWhileLoop_LetterSubmitFail()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.needToSelectStarWarsShip = true;
        gl.isGameInProgress = true;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("p");
        stringBuilder.AppendLine("1");
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);

        gl.CollectStarWarsShip();

        var output = stringWriter.ToString();
        Assert.AreEqual(StarWarsDisplayedList +
            "\n" +
            "Please select Star Wars Ship. Enter the number from the list above\r\n" +
            StarWarsDisplayedList +
            "\n" +
            "p is not a valid number.\r\n" +
            "Please enter a number.\r\n", output);
        Assert.IsFalse(gl.needToSelectStarWarsShip);
    }

    [TestMethod]
    public void CollectStarWarsShip_SecondWhileLoop_LargerNumberThanShipCountFail()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.needToSelectStarWarsShip = true;
        gl.isGameInProgress = true;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("3");
        stringBuilder.AppendLine("1");
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);

        gl.CollectStarWarsShip();

        var output = stringWriter.ToString();
        Assert.AreEqual(StarWarsDisplayedList +
            "\n" +
            "Please select Star Wars Ship. Enter the number from the list above\r\n" +
            StarWarsDisplayedList +
            "\n" +
            "3 is not an allowed number within the range.\r\n" +
            "Please enter a number between 1 and 2\r\n", output);
        Assert.IsFalse(gl.needToSelectStarWarsShip);
    }

    [TestMethod]
    public void CollectStarWarsShip_SecondWhileLoop_SmallerNumberThanShipCountFail()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.needToSelectStarWarsShip = true;
        gl.isGameInProgress = true;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("0");
        stringBuilder.AppendLine("1");
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);

        gl.CollectStarWarsShip();

        var output = stringWriter.ToString();
        Assert.AreEqual(StarWarsDisplayedList +
            "\n" +
            "Please select Star Wars Ship. Enter the number from the list above\r\n" +
            StarWarsDisplayedList +
            "\n" +
            "0 is not an allowed number within the range.\r\n" +
            "Please enter a number between 1 and 2\r\n", output);
        Assert.IsFalse(gl.needToSelectStarWarsShip);
    }

    [TestMethod]
    public void CollectStarWarsShip_ThirdWhileLoop_CheckingForNumberFail()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.needToSelectStarWarsShip = true;
        gl.isGameInProgress = true;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("3");
        stringBuilder.AppendLine("p");
        stringBuilder.AppendLine("1");
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);

        gl.CollectStarWarsShip();

        var output = stringWriter.ToString();
        Assert.AreEqual(StarWarsDisplayedList +
            "\n" +
            "Please select Star Wars Ship. Enter the number from the list above\r\n" +
            StarWarsDisplayedList +
            "\n" +
            "3 is not an allowed number within the range.\r\n" +
            "Please enter a number between 1 and 2\r\n" +
            StarWarsDisplayedList +
            "\n" +
            "p is not a valid number.\r\n" +
            "Please enter a number.\r\n", output);
        Assert.IsFalse(gl.needToSelectStarWarsShip);
    }

    [TestMethod]
    public void CollectStarWarsShip_isGameInProgressIsFalse_needToSelectStarWarsShipIsTrue_ShouldDoNothing()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.needToSelectStarWarsShip = true;
        gl.isGameInProgress = false;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        gl.CollectStarWarsShip();

        var output = stringWriter.ToString();
        Assert.AreEqual("", output);
        Assert.IsTrue(gl.needToSelectStarWarsShip);
    }

    [TestMethod]
    public void CollectStarWarsShip_isGameInProgressIsTrue_needToSelectStarWarsShipIsFalse()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.needToSelectStarWarsShip = false;
        gl.isGameInProgress = true;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        gl.CollectStarWarsShip();

        var output = stringWriter.ToString();
        Assert.AreEqual("", output);
        Assert.IsFalse(gl.needToSelectStarWarsShip);
    }

    [TestMethod]
    public void CollectStarWarsShip_isGameInProgressIsFalse_needToSelectStarWarsShipIsFalse_ShouldDoNothing()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.needToSelectStarWarsShip = false;
        gl.isGameInProgress = false;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        gl.CollectStarWarsShip();

        var output = stringWriter.ToString();
        Assert.AreEqual("", output);
        Assert.IsFalse(gl.needToSelectStarWarsShip);
    }

    [TestMethod]
    public void ConfirmShipSelection_isGameInProgressIsFalse_ShouldDoNothing()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.isGameInProgress = false;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        gl.ConfirmShipSelection();

        var output = stringWriter.ToString();
        Assert.AreEqual("", output);
    }

    [TestMethod]
    public void ConfirmShipSelection_AnsweringEachQuestionWithNo_ShouldEndTheGame()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.isGameInProgress = true;
        gl.needToSelectStarWarsShip = false;
        gl.needToSelectStarTrekShip = false;
        gl.selectedStarWarsShipName = "nameOne";
        gl.selectedStarTrekShipName = "nameTwo";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("n");
        stringBuilder.AppendLine("n");
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);

        gl.ConfirmShipSelection();

        var output = stringWriter.ToString();
        Assert.AreEqual("You selected nameOne.\r\n" + "Would you like to change your Star Wars ship? (Y)es or (N)o\r\n" +
            "You selected nameTwo.\r\n" + "Would you like to change your Star Trek ship? (Y)es or (N)o\r\n", output);
        Assert.IsTrue(gl.isGameInProgress);
    }

    [TestMethod]
    public void ConfirmShipSelection_ChangingStarWarsShip_ShouldEnableNeedToSelectStarWarsShip()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.isGameInProgress = true;
        gl.needToSelectStarWarsShip = false;
        gl.needToSelectStarTrekShip = false;
        gl.selectedStarWarsShipName = "nameOne";
        gl.selectedStarTrekShipName = "nameTwo";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("y");
        stringBuilder.AppendLine("n");
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);

        gl.ConfirmShipSelection();

        var output = stringWriter.ToString();
        Assert.AreEqual("You selected nameOne.\r\n" + "Would you like to change your Star Wars ship? (Y)es or (N)o\r\n" +
            "You selected nameTwo.\r\n" + "Would you like to change your Star Trek ship? (Y)es or (N)o\r\n", output);
        Assert.IsTrue(gl.needToSelectStarWarsShip);
        Assert.IsTrue(gl.isGameInProgress);
    }

    [TestMethod]
    public void ConfirmShipSelection_ChangingBothShips_ShouldSetRespecitveBoolValuesToTrue()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.isGameInProgress = true;
        gl.needToSelectStarWarsShip = false;
        gl.needToSelectStarTrekShip = false;
        gl.selectedStarWarsShipName = "nameOne";
        gl.selectedStarTrekShipName = "nameTwo";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("y");
        stringBuilder.AppendLine("y");
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);

        gl.ConfirmShipSelection();

        var output = stringWriter.ToString();
        Assert.AreEqual("You selected nameOne.\r\n" + "Would you like to change your Star Wars ship? (Y)es or (N)o\r\n" +
            "You selected nameTwo.\r\n" + "Would you like to change your Star Trek ship? (Y)es or (N)o\r\n", output);
        Assert.IsTrue(gl.needToSelectStarWarsShip);
        Assert.IsTrue(gl.needToSelectStarTrekShip);
        Assert.IsTrue(gl.isGameInProgress);
    }

    [TestMethod]
    public void ConfirmShipSelection_BothQuestionsLoopWhenIncorrectAnswerIsGiven()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.isGameInProgress = true;
        gl.needToSelectStarWarsShip = false;
        gl.needToSelectStarTrekShip = false;
        gl.selectedStarTrekShipName = "Excalibur";
        gl.selectedStarWarsShipName = "Princeton";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("RandomStarWarsBlah");
        stringBuilder.AppendLine("n");
        stringBuilder.AppendLine("RandomStarTrekBlah");
        stringBuilder.AppendLine("n");
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);

        gl.ConfirmShipSelection();

        var output = stringWriter.ToString();
        Assert.AreEqual("You selected Princeton.\r\n" + "Would you like to change your Star Wars ship? (Y)es or (N)o\r\n" +
            "Please enter ONLY Y or N.\r\n" +
            "You selected Excalibur.\r\n" + "Would you like to change your Star Trek ship? (Y)es or (N)o\r\n" +
            "Please enter ONLY Y or N.\r\n", output);
        Assert.IsFalse(gl.needToSelectStarWarsShip);
        Assert.IsFalse(gl.needToSelectStarTrekShip);
        Assert.IsTrue(gl.isGameInProgress);
    }

    [TestMethod]
    public void CompareShipsAndDetermineWinner_WhenShipsCompared_returnsTied()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.isGameInProgress = true;
        gl.needToSelectStarWarsShip = false;
        gl.needToSelectStarTrekShip = false;
        var starTrekShip = gl.selectedStarTrekShipName = "StarTrekNameOne";
        var starWarsShip = gl.selectedStarWarsShipName = "StarWarsNameOne";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("n");
        stringBuilder.AppendLine("n");
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);

        gl.ConfirmShipSelection();
        var results = gl.CompareShipsAndDetermineWinner(starTrekShip, starWarsShip);

        var output = stringWriter.ToString();
        Assert.AreEqual("You selected StarWarsNameOne.\r\n" + "Would you like to change your Star Wars ship? (Y)es or (N)o\r\n" +
            "You selected StarTrekNameOne.\r\n" + "Would you like to change your Star Trek ship? (Y)es or (N)o\r\n", output);
        Assert.AreEqual("tied", results);
    }

    [TestMethod]
    public void CompareShipsAndDetermineWinner_WhenShipsCompared_returnsWinner()
    {
        GameLogic gl = new GameLogic(starTrekShipList, starWarsShipList);
        gl.isGameInProgress = true;
        gl.needToSelectStarWarsShip = false;
        gl.needToSelectStarTrekShip = false;
        var starTrekShip = gl.selectedStarTrekShipName = "StarTrekNameOne";
        var starWarsShip = gl.selectedStarWarsShipName = "StarWarsNameTwo";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("n");
        stringBuilder.AppendLine("n");
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);

        //var winner = gl.CompareShipsAndDetermineWinner(starTrekShip, starWarsShip);
        gl.DisplayWinner();

        var output = stringWriter.ToString();
        //Assert.AreEqual("StarWarsNameTwo", winner);
    }
}
