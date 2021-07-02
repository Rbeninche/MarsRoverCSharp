using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {
            Rover newRover = new Rover(200);
            Assert.AreEqual(200, newRover.Position);

        }

        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Rover newRover = new Rover(200);
            Assert.AreEqual("NORMAL", newRover.Mode);

        }

        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts()
        {
            Rover newRover = new Rover(200);
            Assert.AreEqual(110, newRover.GeneratorWatts);

        }

        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {
            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER") };
            Message newMessage = new Message("FOO", commands);
            Rover newRover = new Rover(300);

            newRover.ReceiveMessage(newMessage);

            string expectedRoverMode = "LOW_POWER";
            string actualRoverMode = newRover.Mode;


            Assert.AreEqual(expectedRoverMode, actualRoverMode);


        }

        [TestMethod]
        public void DoesNotMoveInLowPower()
        {
            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 10) };
            Message newMessage = new Message("FOO", commands);
            Rover newRover = new Rover(300);

            newRover.ReceiveMessage(newMessage);

            string expectedRoverMode = "LOW_POWER";
            string actualRoverMode = newRover.Mode;


            Assert.AreEqual(expectedRoverMode, actualRoverMode);


            int expectedRoverPosition = 300;
            int actualRoverPosition = newRover.Position;

            Assert.AreEqual(expectedRoverPosition, actualRoverPosition);

        }

        [TestMethod]
        public void PositionChangesFromMoveCommand()
        {
            Command[] commands = { new Command("MOVE", 10) };
            Message newMessage = new Message("FOO", commands);
            Rover newRover = new Rover(300);

            int expectedRoverPosition = 300;
            int actualRoverPosition = newRover.Position;

            Assert.AreEqual(expectedRoverPosition, actualRoverPosition);

            newRover.ReceiveMessage(newMessage);

            expectedRoverPosition = 10;
            actualRoverPosition = newRover.Position;

            Assert.AreEqual(expectedRoverPosition, actualRoverPosition);

        }

        [TestMethod]
        public void RoverReturnsAMessageForAnUnknownCommand()
        {
            try
            {
                Command[] commands = { new Command("STOP", 0) };
                Message newMessage = new Message("FOO", commands);
                Rover newRover = new Rover(300);



                newRover.ReceiveMessage(newMessage);

            }
            catch (ArgumentException ex)
            {

                Assert.AreEqual("This commantype is denied", ex.Message);
            }
            
           


        }



    }
}
