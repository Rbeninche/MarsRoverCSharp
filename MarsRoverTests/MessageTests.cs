using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        Command[] commands = { new Command("foo", 0), new Command("bar", 20) };

        [TestMethod]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {
            try
            {
                new Message("New Rover", commands);

            }
            catch (ArgumentNullException ex)
            {

                Assert.AreEqual("Message name required", ex.Message);
            }
        }

        [TestMethod]
        public void ConstructorSetsName()
        {
            Message newMessage = new Message("Foo", commands);
            Assert.AreEqual("Foo", newMessage.Name);

        }


        [TestMethod]
        public void ConstructorSetsCommandsField()
        {
            Message newMessage = new Message("Bar", commands);
            Assert.AreEqual(commands, newMessage.Commands);

        }

    }
}
