/* 
 * 2022-05-24 Guillermo Vignolo
 * 
 * Assumptions:
 * • Git branching was not used since features were developed in sequence without further changes.
 * • No major developing constraints were planned like emergency stop, obstacle collision, out of sync between
 * commands and real position (and its data recalibration) since this is the first approach.
 * • ROVER will move in constant increments (one grid unit) for the sake of simplicity.
 * 
 * Disclaimers:
 * • I personally use block-comments for documentation and line-comments for commenting out lines of code, since I
 * find it easier to tell the difference between them as I iterate through ideas.
 */

namespace NASA.Vehicles
{
    public class Rover
    {
        public Rover(int startingCoordinateX, int startingCoordinateY)
        {
            currentXCoordinate = startingCoordinateX;
            currentYCoordinate = startingCoordinateY;

            /* For simplicity. Also I do not think the initial facing direction is a big deal. Can be set as a constructor parameter */
            currentFacingDirection = direction.N;
        }

        /* Any logic will always be handled clockwise starting from North */
        public enum direction { N, E, S, W };
        public direction currentFacingDirection;
        public int currentXCoordinate;
        public int currentYCoordinate;

        /* 
         * This can be refactored later to a float variable such as degrees and later develop a conversion system
         * so the ROVER vehicle can have a more precise unit of measurement such as feet/meters/miles for movement.
         * Also because not every planet has the same size, with the assumption that ROVER can explore other planets, this should be
         * later refactored into a new mars class (possibly inherits a planet class inside NASA.Planets namespace) with information
         * regarding each planet
        */
        public int maxGridXValue = 359;
        public int maxGridYValue = 179;

        public void Move(char[] movementCommands)
        {
            /* Local functions (C#7) */
            void MoveBackward()
            {
                switch (currentFacingDirection)
                {
                    case direction.N:
                        /* Top to bottom */
                        DecrementYPosition();
                        break;
                    case direction.E:
                        /* Right to left */
                        DecrementXPosition();
                        break;
                    case direction.S:
                        /* Bottom to top */
                        IncrementYPosition();
                        break;
                    case direction.W:
                        /* Left to right */
                        IncrementXPosition();
                        break;
                }
            }

            void MoveForward()
            {
                switch (currentFacingDirection)
                {
                    case direction.N:
                        /* Bottom to top */
                        IncrementYPosition();
                        break;
                    case direction.E:
                        /* Left to right */
                        IncrementXPosition();
                        break;
                    case direction.S:
                        /* Top to bottom */
                        DecrementYPosition();
                        break;
                    case direction.W:
                        /* Right to left */
                        DecrementXPosition();
                        break;
                }
            }

            void TurnLeft()
            {
                /* Facing direction will change one unit counterclockwise */
                switch (currentFacingDirection)
                {
                    case direction.N:
                        currentFacingDirection = direction.W;
                        break;
                    case direction.E:
                        currentFacingDirection = direction.N;
                        break;
                    case direction.S:
                        currentFacingDirection = direction.E;
                        break;
                    case direction.W:
                        currentFacingDirection = direction.S;
                        break;
                }
            }

            void TurnRight()
            {
                /* Facing direction will change one unit clockwise */
                switch (currentFacingDirection)
                {
                    case direction.N:
                        currentFacingDirection = direction.E;
                        break;
                    case direction.E:
                        currentFacingDirection = direction.S;
                        break;
                    case direction.S:
                        currentFacingDirection = direction.W;
                        break;
                    case direction.W:
                        currentFacingDirection = direction.N;
                        break;
                }
            }

            if (movementCommands.Length == 0)
            {
                Console.WriteLine("No movement commands were entered. ROVER standing by...");
                return;
            }

            for (var i = 0; i < movementCommands.Length; i++)
            {
                switch (movementCommands[i])
                {
                    case 'b':
                        MoveBackward();
                        /* String interpolation (C#6) */
                        Console.WriteLine($"Vehicle moved backward. Current position is {currentXCoordinate} {currentYCoordinate}");
                        break;
                    case 'f':
                        MoveForward();
                        Console.WriteLine($"Vehicle moved forward. Current position is {currentXCoordinate} {currentYCoordinate}");
                        break;
                    case 'l':
                        TurnLeft();
                        Console.WriteLine($"Vehicle turned left. Now facing {currentFacingDirection}");
                        break;
                    case 'r':
                        TurnRight();
                        Console.WriteLine($"Vehicle turned right. Now facing {currentFacingDirection}");
                        break;
                    default:
                        Console.WriteLine($"Movement command at index {i} was not recognized. Proceeding with the next one.");
                        break;
                }
            }
        }

        private void IncrementXPosition()
        {
            currentXCoordinate += 1;
        }

        private void DecrementXPosition()
        {
            currentXCoordinate -= 1;
        }

        private void IncrementYPosition()
        {
            currentYCoordinate += 1;
        }

        private void DecrementYPosition()
        {
            currentYCoordinate -= 1;
        }

        public static void Main()
        {

        }
    }
}
