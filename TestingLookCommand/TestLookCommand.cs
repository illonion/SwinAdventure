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
    public class TestLookCommand
    {
        private Location _testLocation;
        private Look_Command _testLook;
        private Player _testPlayer;
        private Item _testGem;
        private Bag _testBag;

        [SetUp]
        public void Setup()
        {
            _testLocation = new Location(new string[] { "woods" }, "The woods", "A dark, scary place..");
            _testLook = new Look_Command(new string[] { "look", "command" });
            _testPlayer = new Player("me", "inventory", _testLocation);
            _testGem = new Item(new string[] { "gem", "jewel" }, "gem", "This is a shiny gem.");
            _testBag = new Bag(new string[] { "bag", "lbag" }, "large pouch", "This is a large pouch.");

            _testBag.Inventory.Put(_testGem);
            _testPlayer.Inventory.Put(_testBag);
        }

        [Test]
        public void TestLook()
        {
            Assert.AreEqual("You are located in The woods.\nThis is A dark, scary place...\n In The woods, you can see: \n", _testLook.Execute(_testPlayer, new string[] { "look" }));
        }

        [Test]
        public void TestLookAtMe()
        {
            Assert.AreEqual("inventory\nYou are carrying a large pouch (bag)\n", _testLook.Execute(_testPlayer, new string[] { "look", "at", "me" }));
        }

        [Test]
        public void TestLookAtItemInContainer()
        {
            Assert.AreEqual("This is a shiny gem.", _testLook.Execute(_testPlayer, new string[] { "look", "at", "gem", "in", "lbag" }));
        }

        [Test]
        public void TestLookAtItemNotInContainer()
        {
            Assert.AreEqual("I can not find the pc.", _testLook.Execute(_testPlayer, new string[] { "look", "at", "pc", "in", "lbag" }));
        }

        [Test]
        public void TestLookHello()
        {
            Assert.AreEqual("I don't know how to look like that.", _testLook.Execute(_testPlayer, new string[] { "hello" }));
        }
    }
}
