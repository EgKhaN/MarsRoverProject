using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain
{
    public class Rover
    {
        #region Constructor
        public Rover() { }
        public Rover(DirectionType direction)
        {
            this.Position = new Position();
            this.DirectionType = direction;
        }

        public Rover(int positionX, int positionY, char direction)
        {
            this.Position = new Position(positionX, positionY);
            this.DirectionType = Direction.ParseInputToDirectionType(direction);
        }
        #endregion

        #region Properties
        public Position Position { get; set; }

        public DirectionType DirectionType { get; set; }
        #endregion


        #region Methods
        public static Rover Parse(string inputLine)
        {
            int positionX = 0, positionY = 0;
            char heading = ' ';
            Rover rover = null;

            var splittedInput = inputLine.Split(' ');

            if (splittedInput.Length >= 3)
            {
                rover = new Rover();
                Int32.TryParse(splittedInput[0], out positionX);
                Int32.TryParse(splittedInput[1], out positionY);
                Char.TryParse(splittedInput[2], out heading);
                rover.Position = new Position(positionX, positionY);
                rover.DirectionType = Direction.ParseInputToDirectionType(heading);
            }

            return rover;
        }

        public string Output()
        {
            return Position.X + " " + Position.Y + " " + DirectionType;
        }

        public void ExecuteCommands(string commandInput)
        {
            List<Command> commandList = Command.ConvertInputsToCommandList(commandInput);
            foreach (var command in commandList)
            {
                if (command.Type == CommandType.M)
                    Move();
                else
                    Turn(command.Type);
            }
        }

        public void Turn(CommandType commandType)
        {
            var calcuatedDirection = ((int)DirectionType + (int)commandType);
            int definedDirectionsCount = Enum.GetNames(typeof(DirectionType)).Length;

            if (calcuatedDirection < 0)
                calcuatedDirection += definedDirectionsCount;
            else if (calcuatedDirection > definedDirectionsCount - 1)
                calcuatedDirection -= definedDirectionsCount;

            DirectionType = (DirectionType)calcuatedDirection;
        }

        public void Move(Plateau plateau = null)
        {
            switch (DirectionType)
            {
                case DirectionType.N:
                    if (plateau == null || (plateau != null && plateau.EndingCoordinates.Y > Position.Y))
                        Position.Y += 1;
                    break;
                case DirectionType.E:
                    if (plateau == null || (plateau != null && plateau.EndingCoordinates.X > Position.X))
                        Position.X += 1;
                    break;
                case DirectionType.S:
                    if (plateau == null || (plateau != null && plateau.StartingCoordinates.Y < Position.Y))
                        Position.Y -= 1;
                    break;
                case DirectionType.W:
                    if (plateau == null || (plateau != null && plateau.StartingCoordinates.X < Position.X))
                        Position.X -= 1;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }





}
