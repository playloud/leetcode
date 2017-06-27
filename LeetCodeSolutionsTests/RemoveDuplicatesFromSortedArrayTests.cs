using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCodeSolutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutions.Tests
{
    [TestClass()]
    public class RemoveDuplicatesFromSortedArrayTests
    {
        [TestMethod()]
        public void RemoveDuplicatesTest()
        {

            int[] test = { 1, 1, 2};
            RemoveDuplicatesFromSortedArray ss = new RemoveDuplicatesFromSortedArray();
            Assert.AreEqual(ss.RemoveDuplicates(test), 3);
        }

        [TestMethod()]
        public void removeDuplicates2Test()
        {
            int[] test = { 1, 1, 2};
            RemoveDuplicatesFromSortedArray ss = new RemoveDuplicatesFromSortedArray();
            Assert.AreEqual(ss.removeDuplicates2(test), 2);
        }
    }
}