using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordLadderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordLadderConsole.Tests
{
    [TestClass()]
    public class WordLadderConsoleTests
    {
        [TestMethod()]
        public void FindLaddersTest()
        {
            ConsoleController consoleController = new("hide", "sort", File.ReadAllLines("c:\\Tests\\words.txt").ToList());
            IList<IList<string>> result = consoleController.GetLadders();
            Assert.AreEqual("hide", result[0][0].ToString());
            Assert.AreEqual("hire", result[0][1].ToString());
            Assert.AreEqual("sire", result[0][2].ToString());
            Assert.AreEqual("sore", result[0][3].ToString());
            Assert.AreEqual("sort", result[0][4].ToString());
        }

        [TestMethod()]
        public void FindLaddersSpinSpotTest()
        {
            ConsoleController consoleController = new("spin", "spot", File.ReadAllLines("c:\\Tests\\words.txt").ToList());
            IList<IList<string>> result = consoleController.GetLadders();
            Assert.AreEqual("spin", result[0][0].ToString());
            Assert.AreEqual("spit", result[0][1].ToString());
            Assert.AreEqual("spot", result[0][2].ToString());

        }


        [TestMethod()]
        public void FindLaddersSameCostTest()
        {
            ConsoleController consoleController = new("same", "cost", File.ReadAllLines("c:\\Tests\\words.txt").ToList());
            IList<IList<string>> result = consoleController.GetLadders();
            Assert.AreEqual("same", result[0][0].ToString());
            Assert.AreEqual("came", result[0][1].ToString());
            Assert.AreEqual("case", result[0][2].ToString());
            Assert.AreEqual("cast", result[0][3].ToString());
            Assert.AreEqual("cost", result[0][4].ToString());
        }

        [TestMethod()]
        public void EmptyWordsTest()
        {
            ConsoleController consoleController = new("", "", File.ReadAllLines("c:\\Tests\\words.txt").ToList());
            IList<IList<string>> result = consoleController.GetLadders();
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod()]
        public void EmptyFirtWordTest()
        {
            ConsoleController consoleController = new("", "sort", File.ReadAllLines("c:\\Tests\\words.txt").ToList());
            IList<IList<string>> result = consoleController.GetLadders();
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod()]
        public void EmptyDictonary()
        {
            ConsoleController consoleController = new("", "sort", new List<string>());
            IList<IList<string>> result = consoleController.GetLadders();
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod()]
        public void DifferentLengthsWordTest()
        {
            ConsoleController consoleController = new("radiod", "sort", File.ReadAllLines("c:\\Tests\\words.txt").ToList());
            IList<IList<string>> result = consoleController.GetLadders();
            Assert.IsTrue(result.Count == 0);
        }
    }
}