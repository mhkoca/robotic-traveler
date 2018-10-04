using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traveler;

namespace TravelerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMove()
        {
            Robot robot = new Robot( new string[]{ "1", "2" , "E"});

            robot.Move();
            Assert.AreEqual(2, robot.CurrentLocation.X);
            Assert.AreEqual(2, robot.CurrentLocation.Y);
            Assert.AreEqual(Direction.E, robot.CurrentDirection);
        }

        [TestMethod]
        public void TestMove2()
        {
            Robot robot = new Robot(new string[] { "1", "2", "N" });
            Area.EndLocation = new Location(5, 5);
            string route = "LMLMLMLMM";

            Program.Move(robot, route);
            Assert.AreEqual(1, robot.CurrentLocation.X);
            Assert.AreEqual(3, robot.CurrentLocation.Y);
            Assert.AreEqual(Direction.N, robot.CurrentDirection);
        }

        [TestMethod]
        public void TestMove3()
        {
            Robot robot = new Robot(new string[] { "3", "3", "E" });
            Area.EndLocation = new Location(5, 5);
            string route = "MMRMMRMRRM";

            Program.Move(robot, route);
            Assert.AreEqual(5, robot.CurrentLocation.X);
            Assert.AreEqual(1, robot.CurrentLocation.Y);
            Assert.AreEqual(Direction.E, robot.CurrentDirection);
        }

        [TestMethod]
        public void TestTurnRight()
        {
            Robot robot = new Robot(new string[] { "1", "2", "E" });

            robot.Turn(TurningDirection.R);
            Assert.AreEqual(1, robot.CurrentLocation.X);
            Assert.AreEqual(2, robot.CurrentLocation.Y);
            Assert.AreEqual(Direction.S, robot.CurrentDirection);
        }

        [TestMethod]
        public void TestTurnLeft()
        {
            Robot robot = new Robot(new string[] { "5", "2", "N" });

            robot.Turn(TurningDirection.L);
            Assert.AreEqual(5, robot.CurrentLocation.X);
            Assert.AreEqual(2, robot.CurrentLocation.Y);
            Assert.AreEqual(Direction.W, robot.CurrentDirection);
        }

        [TestMethod]
        public void TestCornerValidation1()
        {
            CornerCommand cornerCommand = new CornerCommand("5 5");

            Assert.AreEqual(true, cornerCommand.Validate());
        }

        [TestMethod]
        public void TestCornerValidation2()
        {
            CornerCommand cornerCommand = new CornerCommand("55");

            Assert.AreEqual(false, cornerCommand.Validate());
        }

        [TestMethod]
        public void TestCornerValidation3()
        {
            CornerCommand cornerCommand = new CornerCommand("5 5 5");

            Assert.AreEqual(false, cornerCommand.Validate());
        }

        [TestMethod]
        public void TestCornerValidation4()
        {
            CornerCommand cornerCommand = new CornerCommand("A 5");

            Assert.AreEqual(false, cornerCommand.Validate());
        }

        [TestMethod]
        public void TestLocationValidation1()
        {
            LocationCommand locationCommand = new LocationCommand("A 5");
            Area.EndLocation = new Location(6, 5);

            Assert.AreEqual(false, locationCommand.Validate());
        }

        [TestMethod]
        public void TestLocationValidation2()
        {
            LocationCommand locationCommand = new LocationCommand("5 5");
            Area.EndLocation = new Location(6, 5);

            Assert.AreEqual(false, locationCommand.Validate());
        }

        [TestMethod]
        public void TestLocationValidation3()
        {
            LocationCommand locationCommand = new LocationCommand("55N");
            Area.EndLocation = new Location(6, 5);

            Assert.AreEqual(false, locationCommand.Validate());
        }

        [TestMethod]
        public void TestLocationValidation4()
        {
            LocationCommand locationCommand = new LocationCommand("5 5 N");
            Area.EndLocation = new Location(4, 5);
            Assert.AreEqual(false, locationCommand.Validate());
        }

        [TestMethod]
        public void TestLocationValidation5()
        {
            LocationCommand locationCommand = new LocationCommand("5 5 N");
            Area.EndLocation = new Location(6, 5);
            Assert.AreEqual(true, locationCommand.Validate());
        }

        [TestMethod]
        public void TestRouteValidation1()
        {
            RouteCommand routeCommand = new RouteCommand("N");

            Assert.AreEqual(false, routeCommand.Validate());
        }

        [TestMethod]
        public void TestRouteValidation2()
        {
            RouteCommand routeCommand = new RouteCommand("L");

            Assert.AreEqual(true, routeCommand.Validate());
        }
    }
}
