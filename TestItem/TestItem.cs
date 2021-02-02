/*
 * File: TestItem.cs
 * Author: Lawrence Zhou
 * Unit: COS20007 Object Oriented Programming
 * Institution: Swinburne University of Technology
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Don't forget this.
using SwinAdventure;

namespace SwinAdventure
{
    [TestFixture]
    public class TestItem
    {
        private Item shovel;

        [SetUp]
        public void Setup()
        {
            shovel = new Item(new string[] { "shovel", "spade" },
                "shovel", "This might be a fine...");
        }

        [Test]
        public void TestAreYou()
        {
            Assert.IsTrue(shovel.AreYou("shovel"));
        }

        [Test]
        public void TestShortDesc()
        {
            Assert.AreEqual(shovel.ShortDescription, "a shovel (shovel)");
        }

        [Test]
        public void TestFullDesc()
        {
            Assert.AreEqual(shovel.FullDescription, "This might be a fine...");
        }
    }
}
