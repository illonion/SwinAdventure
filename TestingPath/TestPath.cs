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
    public class TestPath
    {
        private Location _north;
        private Location _south;

        private Player _player;

        private Path _northsouthpath;


        [SetUp]
        public void Setup()
        {
            _north = new Location(new string[] { "north", "upper" }, "North", "up the north");
            _south = new Location(new string[] { "south", "lower" }, "South", "down the south");
            _player = new Player("Lawrence", "This is a fine character.", _north);
            _northsouthpath = new Path(new string[] { "northsouthP" }, "NSPath", "the path from the north to the south", _north, _south);
        }

        [Test]
        public void TestPlayerMoveNorthSouth()
        {
            Assert.AreEqual(_north, _player.Location);
            _northsouthpath.Go(_player);
            Assert.AreEqual(_south, _player.Location);
        } 
    }
}
