using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarTrekvsStarWars;
using System.IO;
using System;
using System.Text;

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
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("RandomText");
            stringBuilder.AppendLine("n");
            var stringReader = new StringReader(stringBuilder.ToString());
            Console.SetIn(stringReader);

            gl.PlayGame();

            var output = stringWriter.ToString();
            Assert.AreEqual("Would you like to play a game? (Y)es or (N)o\r\nPlease enter ONLY Y or N. Would you like to play a game?\r\n", output);
            Assert.IsFalse(gl.isGameInProgress);
            Assert.IsFalse(gl.needToAskUserToPlay);
        }
    }
}
