using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarTrekvsStarWars;
using System.IO;
using System;
using System.Text;

namespace StarTrekvsStarWarsTest;

[TestClass]
public class GameLogicTest
{
    [TestMethod]
    public void PlayGame_TypeLowerN_ShouldEndTheGame()
    {
        GameLogic gl = new GameLogic();
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
        GameLogic gl = new GameLogic();
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
        GameLogic gl = new GameLogic();
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
        GameLogic gl = new GameLogic();
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
        GameLogic gl = new GameLogic();
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
    public void CollectStarTrekShip_IsGameInProgressIsTrue_NeedToSelectStarTrekShipIsTrue_ShouldPopQuestion()
    {
        GameLogic gl = new GameLogic();
        gl.needToSelectStarTrekShip = true;
        gl.isGameInProgress = true;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringReader = new StringReader("");
        Console.SetIn(stringReader);

        gl.CollectStarTrekShip();

        var output = stringWriter.ToString();
        Assert.AreEqual("Please enter a Star Trek Ship Name? (Y)es or (N)o\r\n" +
            "TODO - Write Get Star Trek Ships method\r\n", output);
        Assert.IsFalse(gl.needToSelectStarTrekShip);
    }

    [TestMethod]
    public void CollectStarTrekShip_isGameInProgressIsFalse_needToSelectStarTrekShipIsTrue_ShouldDoNothing()
    {
        GameLogic gl = new GameLogic();
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
        GameLogic gl = new GameLogic();
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
        GameLogic gl = new GameLogic();
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
        GameLogic gl = new GameLogic();
        gl.needToSelectStarWarsShip = true;
        gl.isGameInProgress = true;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringReader = new StringReader("");
        Console.SetIn(stringReader);

        gl.CollectStarWarsShip();

        var output = stringWriter.ToString();
        Assert.AreEqual("Please enter a Star Wars Ship Name? (Y)es or (N)o\r\n" +
            "TODO - Write Get Star Wars Ships method\r\n", output);
        Assert.IsFalse(gl.needToSelectStarWarsShip);
    }

    [TestMethod]
    public void CollectStarWarsShip_isGameInProgressIsFalse_needToSelectStarWarsShipIsTrue_ShouldDoNothing()
    {
        GameLogic gl = new GameLogic();
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
        GameLogic gl = new GameLogic();
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
        GameLogic gl = new GameLogic();
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
        GameLogic gl = new GameLogic();
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
        GameLogic gl = new GameLogic();
        gl.isGameInProgress = true;
        gl.needToSelectStarWarsShip = false;
        gl.needToSelectStarTrekShip = false;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("n");
        stringBuilder.AppendLine("n");
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);

        gl.ConfirmShipSelection();

        var output = stringWriter.ToString();
        Assert.AreEqual("Would you like to change the selected Star Wars Ship? (Y)es or (N)o\r\n" +
            "Would you like to change the selected Star Trek Ship? (Y)es or (N)o\r\n", output);
        Assert.IsFalse(gl.isGameInProgress);
    }

    [TestMethod]
    public void ConfirmShipSelection_ChangingStarWarsShip_ShouldEnableNeedToSelectStarWarsShip()
    {
        GameLogic gl = new GameLogic();
        gl.isGameInProgress = true;
        gl.needToSelectStarWarsShip = false;
        gl.needToSelectStarTrekShip = false;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("y");
        stringBuilder.AppendLine("n");
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);

        gl.ConfirmShipSelection();

        var output = stringWriter.ToString();
        Assert.AreEqual("Would you like to change the selected Star Wars Ship? (Y)es or (N)o\r\n" +
            "Would you like to change the selected Star Trek Ship? (Y)es or (N)o\r\n", output);
        Assert.IsTrue(gl.needToSelectStarWarsShip);
        Assert.IsTrue(gl.isGameInProgress);
    }

    [TestMethod]
    public void ConfirmShipSelection_ChangingBothShips_ShouldSetRespecitveBoolValuesToTrue()
    {
        GameLogic gl = new GameLogic();
        gl.isGameInProgress = true;
        gl.needToSelectStarWarsShip = false;
        gl.needToSelectStarTrekShip = false;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("y");
        stringBuilder.AppendLine("y");
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);

        gl.ConfirmShipSelection();

        var output = stringWriter.ToString();
        Assert.AreEqual("Would you like to change the selected Star Wars Ship? (Y)es or (N)o\r\n" +
            "Would you like to change the selected Star Trek Ship? (Y)es or (N)o\r\n", output);
        Assert.IsTrue(gl.needToSelectStarWarsShip);
        Assert.IsTrue(gl.needToSelectStarTrekShip);
        Assert.IsTrue(gl.isGameInProgress);
    }

    [TestMethod]
    public void ConfirmShipSelection_BothQuestionsLoopWhenIncorrectAnswerIsGiven()
    {
        GameLogic gl = new GameLogic();
        gl.isGameInProgress = true;
        gl.needToSelectStarWarsShip = false;
        gl.needToSelectStarTrekShip = false;
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
        Assert.AreEqual("Would you like to change the selected Star Wars Ship? (Y)es or (N)o\r\n" +
            "Please enter ONLY Y or N.\r\n" +
            "Would you like to change the selected Star Trek Ship? (Y)es or (N)o\r\n" +
            "Please enter ONLY Y or N.\r\n", output);
        Assert.IsFalse(gl.needToSelectStarWarsShip);
        Assert.IsFalse(gl.needToSelectStarTrekShip);
        Assert.IsFalse(gl.isGameInProgress);
    }
}
