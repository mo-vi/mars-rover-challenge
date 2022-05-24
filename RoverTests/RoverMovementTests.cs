using Microsoft.VisualStudio.TestTools.UnitTesting;
using NASA.Vehicles;

namespace RoverTests
{
    [TestClass]
    public class RoverMovementTests
    {      
        [TestMethod]
        public void CheckFacingOrientation()
        {
            Rover rover = new Rover(0, 0);

            /* Check console to see exception about an unrecognized character */
            rover.Move(new char[] { 'r', 'l', 'g', 'r' });

            Assert.AreEqual("E", rover.currentFacingDirection.ToString());

            rover.Move(new char[] { });

            /* Check console to see exception about movement action without parameters */
            Assert.AreEqual("E", rover.currentFacingDirection.ToString());
        }

        [TestMethod]
        public void CheckGridResetOnX()
        {
            Rover rover = new Rover(359, 22);

            rover.Move(new char[] {'r', 'f'});

            Assert.AreEqual(0, rover.currentXCoordinate);
        }

        [TestMethod]
        public void CheckGridResetOnXBackwards()
        {
            Rover rover = new Rover(0, 22);

            rover.Move(new char[] { 'r', 'b' });

            Assert.AreEqual(359, rover.currentXCoordinate);
        }

        [TestMethod]
        public void CheckGridResetOnY()
        {
            Rover rover = new Rover(7, 359);

            rover.Move(new char[] {'f'});

            Assert.AreEqual(0, rover.currentYCoordinate);
        }

        [TestMethod]
        public void CheckGridResetOnYBackwards()
        {
            Rover rover = new Rover(15, 0);

            rover.Move(new char[] { 'b' });

            Assert.AreEqual(179, rover.currentYCoordinate);
        }

        [TestMethod]
        public void CheckXCoordinate()
        {
            Rover rover = new Rover(0, 0);

            rover.Move(new char[] {'r', 'f', 'f'});

            Assert.AreEqual(2, rover.currentXCoordinate);
        }

        [TestMethod]
        public void CheckYCoordinate()
        {
            Rover rover = new Rover(11, 4);

            rover.Move(new char[] {'l', 'f', 'f', 'b', 'r', 'f'});

            Assert.AreEqual(5, rover.currentYCoordinate);
        }
    }
}
