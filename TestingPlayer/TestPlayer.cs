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
    public class TestPlayer
    {
        private Location _location;
        private Player _player1;
        private Item _sword;
        private Item _shovel;
        private Item _pc;

        [SetUp]
        public void Setup()
        {
            _location = new Location(new string[] { "woods" }, "The woods.", "A dark, scary place..");
            _player1 = new Player("Lawrence", "This is a fine character.", _location);
            _shovel = new Item(new string[] { "shovel", "spade" },
                "shovel", "This might be a fine...");
            _sword = new Item(new string[] { "sword" },
                "sword", "This is a fine looking sword.");
            _pc = new Item(new string[] { "pc" },
                "computer", "This computer can do a lot of things!");
            _player1.Inventory.Put(_shovel);
            _player1.Inventory.Put(_sword);
            _player1.Inventory.Put(_pc);
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.AreEqual("This is a fine character.\nYou are carrying a shovel (shovel)\na sword (sword)\na computer (pc)\n", _player1.FullDescription);
        }

        [Test]
        public void TestPlayerLocateNothing()
        {
            Assert.AreEqual(_player1.Locate("service"), null);
        }

        [Test]
        public void TestPlayerLocateItems()
        {
            Assert.AreEqual(_player1.Locate("shovel"), _shovel);
        }

        [Test]
        public void TestPlayerLocateItself()
        {
            Assert.AreEqual(_player1.Locate("me"), _player1);
        }

        [Test]
        public void TestPlayerIdentifiable()
        {
            Assert.IsTrue(_player1.AreYou("me"));
            Assert.IsTrue(_player1.AreYou("inventory"));
        }
    }
}
