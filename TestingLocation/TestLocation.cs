using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Don't forget this.
using SwinAdventure;

namespace SwinAdventure
{
    [TestFixture]
    public class TestLocation
    {
        private Location _testLocation;
        private Player _testPlayer;
        private Item _testGem;
        private Look_Command _testLook;

        [SetUp]
        public void Setup()
        {
            _testLocation = new Location(new string[] { "woods" }, "The woods", "A dark, scary place..");
            _testPlayer = new Player("Lawrence", "This is a fine character.", _testLocation);
            _testGem = new Item(new string[] { "gem", "jewel" }, "gem", "A small, shining gem.");
            _testLook = new Look_Command(new string[] { "test" });

            _testLocation.Inventory.Put(_testGem);
        }

        [Test]
        public void TestLocationFullDescription()
        {
            Assert.AreEqual("You are located in The woods.\nThis is A dark, scary place...\n In The woods, you can see: \na gem (gem)\n", _testLocation.FullDescription);
        }

        [Test]
        public void TestLocationLocateSelf()
        {
            Assert.AreEqual(_testLocation.Locate("woods"), _testLocation);
        }

        [Test]
        public void TestLocationLocateItems()
        {
            Assert.AreEqual(_testGem, _testLocation.Locate("gem"));
        }

        [Test]
        public void TestPlayerLocateItemsLocation()
        {
            Assert.AreEqual(_testGem, _testPlayer.Locate("gem"));
        }

        // Test for "look at gem"

        [Test]
        public void TestLookCommandLocateGem()
        {
            Assert.AreEqual("A small, shining gem.", _testLook.Execute(_testPlayer, new string[] { "look", "at", "gem" }));
        }
    }
}
