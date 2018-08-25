using System;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata02_KarateChop;

namespace Kata02_KarateChop.Test
{
    [TestClass]
    public class ChopTester
    {
        private Chop chop;
        [TestInitialize]
        public void ChopTesterInit()
        {
            chop = new Chop();
        }
        [TestMethod]
        [ExpectedException(typeof(EmptyArrayException))]
        public void EmptyArray_ThrowsError()
        {            
            Assert.AreEqual(1, chop.Chopper(1, new int[] {}));
        }

        [TestMethod]
        public void SortedArrayTests_ReturnValidResponse()
        {   
            Assert.AreEqual(0, chop.Chopper(1, new[] { 1 }));
            Assert.AreEqual(1, chop.Chopper(2, new[] { 1, 2 }));
            Assert.AreEqual(2, chop.Chopper(3, new[] { 1, 2, 3, 4, 5 }));
            Assert.AreEqual(3, chop.Chopper(3, new[] { -10, -1, 2, 3, 4, 5 }));
            Assert.AreEqual(1, chop.Chopper(3, new []{ 1, 3, 6, 7, 8, 9, 10, 22, 33, 44}));
            Assert.AreEqual(8, chop.Chopper(33, new[] { 1, 3, 6, 7, 8, 9, 10, 22, 33, 44 }));
        }
        /*
        [TestMethod]
        public void UnsortedArraytests_ReturnValidResponse()
        {
            //TODO: Unsorted Array support
            //Assert.AreEqual(6, chop.Chopper(-7, new[] { 1, 2, 3, 4, 5, -7 }));
        }*/
        [TestMethod]
        public void ValidArrayWithNoTarget_ThrowsNotFoundError()
        {
            Assert.ThrowsException<TargetNumberNotFoundException>(() => chop.Chopper(2, new[] { 1 }));
            Assert.ThrowsException<TargetNumberNotFoundException>(() => chop.Chopper(0, new[] { 1, 2, 3, 4, 8, 10 }));
            Assert.ThrowsException<TargetNumberNotFoundException>(() => chop.Chopper(-1, new[] { 3, 4, 8, 10 }));
        }
    }
}
