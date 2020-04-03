using MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Test
{
    public class DirectionTest
    {
        [Theory]
        [InlineData('N', DirectionType.N)]
        [InlineData('S', DirectionType.S)]
        [InlineData('W', DirectionType.W)]
        [InlineData('E', DirectionType.E)]
        [InlineData('R', DirectionType.N)]
        public void Convert_DirectionInput_ReturnsCorrectDirectionType(char directionInput,DirectionType? expectedDirectionType)
        {
            DirectionType? directionType = Direction.ParseInputToDirectionType(directionInput);
            Assert.Equal(expectedDirectionType, directionType);
        }
    }
}
