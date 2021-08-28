using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project2KevinArnoldWobble;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project2KevinArnoldWobble.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void BuildpossibleTestN()
        {
            var tprog = new Program();
            string[] lines = new string[] { ">sequence 1 ","ATCN" };

            Assert.ThrowsException<KeyNotFoundException>(() => tprog.Buildpossible(lines) );
            
        }

        [TestMethod()]
        public void BuildpossibleTestEmpty()
        {
            var tprog = new Program();
            string[] lines = new string[] { };
            var dict = tprog.Buildpossible(lines);
            var checkdict = new  Dictionary<string, string[]> () { };
            Assert.AreEqual(dict.Keys.Count, checkdict.Keys.Count);
        }
    }
}