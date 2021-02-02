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
    public class TestBag
    {
        private Bag _b1;
        private Bag _b2;
        private Item _gem;
        private Item _shovel;

        [SetUp]
        public void Setup()
        {
            _b1 = new Bag(new string[] { "lbag", "lpouch" }, "large pouch", "This is a large pouch.");
            _gem = new Item(new string[] { "gem", "jewel" }, "gem", "A small, shining gem.");
            _b1.Inventory.Put(_gem);
        }

        [Test]
        public void TestBagLocateItself()
        {
            Assert.AreEqual(_b1, _b1.Locate("lbag"));
            Assert.AreEqual(_b1, _b1.Locate("lpouch"));
        }

        [Test]
        public void TestBagLocateItems()
        {
            Assert.AreEqual(_gem, _b1.Locate("gem"));
        }

        [Test]
        public void TestBagLocateNothing()
        {
            Assert.AreEqual(null, _b1.Locate("self"));
        }

        [Test]
        public void TestBagFullDescription()
        {
            Assert.AreEqual("In the large pouch you can see:\na gem (gem)\n", _b1.FullDescription);
        }

        [Test]
        public void TestBagInBag()
        {
            _b2 = new Bag(new string[] { "spouch", "sbag" }, "small pouch", "This is a small pouch.");
            _shovel = new Item(new string[] { "shovel", "spade" }, "shovel", "This is a fine looking shovel.");
            _b2.Inventory.Put(_shovel);
            _b1.Inventory.Put(_b2);

            Assert.AreEqual(_gem, _b1.Locate("gem"));
            Assert.AreEqual(_b2, _b1.Locate("spouch"));
            Assert.AreEqual(null, _b1.Locate("shovel"));
        }
    }
}
