using MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Test
{
    public class RoverTest
    {
        [Theory]
        [InlineData(CommandType.L, DirectionType.N, DirectionType.W)]
        [InlineData(CommandType.L, DirectionType.W, DirectionType.S)]
        [InlineData(CommandType.R, DirectionType.E, DirectionType.S)]
        [InlineData(CommandType.R, DirectionType.N, DirectionType.E)]

        public void Turn_Command_ReturnsRightDirection(CommandType commandType, DirectionType currentDirection, DirectionType expectedDirection)
        {
            Rover rover = new Rover(currentDirection);
            rover.Turn(commandType);
            Assert.Equal(expectedDirection, rover.DirectionType);
        }


        [Theory]
        [InlineData(DirectionType.W, 1, 2, 0, 2)]
        [InlineData(DirectionType.S, 0, 2, 0, 1)]
        [InlineData(DirectionType.E, 0, 1, 1, 1)]
        [InlineData(DirectionType.N, 1, 1, 1, 2)]
        public void Move_Forward_ReturnsRightPosition(DirectionType currentDirection, int currentPositionX, int currentPositionY, int expectedPositionX, int expectedPositionY)
        {
            Rover rover = new Rover(currentDirection);
            rover.Position = new Position(currentPositionX, currentPositionY);
            rover.Move();
            Assert.Equal(expectedPositionX, rover.Position.X);
            Assert.Equal(expectedPositionY, rover.Position.Y);
        }

        [Theory]
        [InlineData("LMLMLMLMM" , "1 3 N", 1, 2, 'N')]
        [InlineData("MMRMMRMRRM", "5 1 E", 3, 3, 'E')]
        public void ExecuteCommand_Command_ReturnsCorrectPositionAndDirection(string input, string output , int positionX,int positionY, char direction)
        {
            Rover rover = new Rover(positionX, positionY, direction);
            rover.ExecuteCommands(input);

            Assert.Equal(output, rover.Output());
        }

        [Theory]
        [InlineData("1 2 N",1,2,DirectionType.N)]
        [InlineData("3 3 E",3,3,DirectionType.E)]
        [InlineData("sadasasd 5676789/3 7734*/*5",0,0,DirectionType.N)]
        public void Parse_Input_ReturnsRoverInstance(string input, int expectedPositionX,int expectedPositionY, DirectionType expectedDirectionType)
        {
            Rover rover = Rover.Parse(input);

            Assert.Equal(expectedPositionX, rover.Position.X);
            Assert.Equal(expectedPositionY, rover.Position.Y);
            Assert.Equal(expectedDirectionType, rover.DirectionType);
        }
        
        [Fact]
        public void Parse_Input_ReturnsNullForShortInput()
        {
            string input = "sadasasd 5676789/3";
            Rover rover = Rover.Parse(input);
            Assert.Null(rover);
        }
    }
}
