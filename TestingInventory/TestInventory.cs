/*
 * File: TestInventory.cs
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

namespace SwinAdventure //Rename this to the namespace of your project.
{
    [TestFixture]
    public class TestInventory //Rename this appropriately.
    {
        private Inventory _inventory;
        private Item _shovel;
        private Item _jewel;

        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory();
            _shovel = new Item(new string[] { "shovel", "spade" },
                "shovel", "This might be a fine...");
            _inventory.Put(_shovel);
        }

        [Test]
        public void TestFindItem()
        {
            Assert.IsTrue(_inventory.HasItem("shovel"));
        }

        [Test]
        public void TestNoItemFind()
        {
            Assert.AreEqual(_inventory.Fetch("card"), null);
        }

        [Test]
        public void TestFetchItem()
        {
            Assert.AreEqual(_inventory.Fetch("spade"), _shovel);
            Assert.IsTrue(_inventory.HasItem("shovel"));
        }

        [Test]
        public void TestTakeItem()
        {
            Assert.AreEqual(_inventory.Take("shovel"), _shovel);
            Assert.IsFalse(_inventory.HasItem("shovel"));
        }

        [Test]
        public void TestItemList()
        {
            _jewel = new Item(new string[] { "jewel", "gem" },
                "jewel", "This might be a fine jewel...");
            _inventory.Put(_jewel);
            Assert.AreEqual(_inventory.ItemList, "a shovel (shovel)\na jewel (jewel)\n");
        }
    }
}
