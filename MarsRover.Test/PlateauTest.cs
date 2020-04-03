using MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Test
{
    public class PlateauTest
    {
        [Theory]
        [InlineData("5 5", 5, 5)]
        public void Parse_Input_ReturnsPlateauInstance(string input, int expectedHeight, int expectedWidth)
        {
            Plateau plateau = Plateau.Parse(input);

            Assert.Equal(expectedHeight, plateau.Height);
            Assert.Equal(expectedWidth, plateau.Width);
        }

        [Fact]
        public void Parse_Input_ReturnsNullForShortInput()
        {
            string input = "sadasasd";
            Plateau plateau = Plateau.Parse(input);
            Assert.Null(plateau);
        }
    }
}
