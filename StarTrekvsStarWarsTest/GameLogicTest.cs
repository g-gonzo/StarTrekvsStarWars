using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarTrekvsStarWars;
using System.IO;
using System;

namespace StarTrekvsStarWarsTest
{
    [TestClass]
    public class GameLogicTest
    {
        [TestMethod]
        public void PlayGame_TypeLowerN()
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
        public void PlayGame_TypeUpperN()
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
        public void PlayGame_TypeNo()
        {
            GameLogic gl = new GameLogic();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var stringFirstReader = new StringReader("No");
            Console.SetIn(stringFirstReader);
            var stringSecondReader = new StringReader("y");
            Console.SetIn(stringSecondReader);
            


            gl.PlayGame();

            var playOutput = stringWriter.ToString();
           // var correctionOutput = stringWriterCorrectionQuestion.ToString();
            //Assert.AreEqual("Would you like to play a game? (Y)es or (N)o\r\n", playOutput);
            Assert.AreEqual("Please enter ONLY Y or N. Would you like to play a game?\r\n", playOutput);
            Assert.IsFalse(gl.isGameInProgress);
            Assert.IsFalse(gl.needToAskUserToPlay);
        }
    }
}