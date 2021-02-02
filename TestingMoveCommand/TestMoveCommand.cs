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
    public class TestMoveCommand
    {
        private Path north;
        private Path south;

        Location NorthHotel = new Location(new string[] { "hotel" }, "Hotel", "a nice hotel");
        Location SouthMotel = new Location(new string[] { "motel" }, "Motel", "a cozy motel");

        Player _player;

        MoveCommand _move;

        [SetUp]
        public void Setup()
        {
            north = new Path(new string[] { "north" }, "north", "northway", NorthHotel, SouthMotel);
            south = new Path(new string[] { "south" }, "south", "southway", SouthMotel, NorthHotel);

            _player = new Player("Lawrence", "the best programmer", NorthHotel);

            _move = new MoveCommand(new string[] { "move", "go", "leave", "head" });
        }

        [Test]
        public void TestMovingCommand()
        {
            NorthHotel.AddPath(north);
            Assert.AreEqual("You head north.\nYou travel through northway.\nYou arrive at Motel", _move.Execute(_player, new string[] { "move", "north" }));
        }

        [Test]
        public void TestMoveBackCommand()
        {
            NorthHotel.AddPath(south);
            Assert.AreEqual("You head south.\nYou travel through southway.\nYou arrive at Hotel", _move.Execute(_player, new string[] { "move", "south" }));

        }

        [Test]
        public void TestMoveInvalidPath()
        {
            Assert.AreEqual("The path was not found.", _move.Execute(_player, new string[] { "leave", "down" }));
        }
    }
}
