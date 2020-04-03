using MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Test
{
    public class CommandTest
    {
        [Fact]
        public void Convert_Commands_ReturnsRightCommandTypeAndValidity()
        {
            var command = Command.CreateCommandTypeFromInput('L');

            Assert.NotNull(command);
            Assert.Equal(CommandType.L, command.Type);
        } 
        
        [Theory]
        [InlineData('S')]
        [InlineData('D')]
        [InlineData(' ')]
        public void Convert_Commands_ReturnsNullWhenInvalidCommand(char commandInput)
        {
            var command = Command.CreateCommandTypeFromInput(commandInput);

            Assert.Null(command);
        }

        [Fact]
        public void Convert_Commands_ReturnsCorrectCommandListFromCommandInput()
        {
            var commandList = Command.ConvertInputsToCommandList("LMSTR*");

            Assert.Equal(3, commandList.Count);
            Assert.Equal(CommandType.L, commandList[0].Type);
            Assert.Equal(CommandType.M, commandList[1].Type);
            Assert.Equal(CommandType.R, commandList[2].Type);

            var commandList2 = Command.ConvertInputsToCommandList("   sda7643*/");
            Assert.Empty(commandList2);

        }


    }
}
