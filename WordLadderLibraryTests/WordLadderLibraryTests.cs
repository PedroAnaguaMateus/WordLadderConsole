using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordLadderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordLadderLibrary.Tests
{
    [TestClass()]
    public class WordLadderLibraryTests
    {
        [TestMethod()]
        public void FindLaddersTest()
        {
            IWordLadder wordLadder = new WordLadder();
            IList<IList<string>> result =  wordLadder.FindLadders("hide", "sort", File.ReadAllLines("c:\\Tests\\words.txt")).Reverse().ToList();
            Assert.AreEqual("hide", result[0][0].ToString());
            Assert.AreEqual("hire", result[0][1].ToString());
            Assert.AreEqual("sire", result[0][2].ToString());
            Assert.AreEqual("sore", result[0][3].ToString());
            Assert.AreEqual("sort", result[0][4].ToString());
        }

        [TestMethod()]
        public void EmptyWordsTest()
        {
            IWordLadder wordLadder = new WordLadder();
            IList<IList<string>> result = wordLadder.FindLadders("", "", File.ReadAllLines("c:\\Tests\\words.txt")).Reverse().ToList();
            Assert.AreEqual("", result[0][0].ToString());
        }

        [TestMethod()]
        public void EmptyFirtWordTest()
        {
            IWordLadder wordLadder = new WordLadder();
            IList<IList<string>> result = wordLadder.FindLadders("", "rest", File.ReadAllLines("c:\\Tests\\words.txt")).Reverse().ToList();
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod()]
        public void EmptyDictonaryTest()
        {
            IWordLadder wordLadder = new WordLadder();
            IList<IList<string>> result = wordLadder.FindLadders("hide", "sort", new List<string>()).Reverse().ToList();
            Assert.IsTrue(result.Count == 0);
        }
    }
}