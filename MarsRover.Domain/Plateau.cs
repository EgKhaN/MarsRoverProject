using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain
{
    public class Plateau
    {
        #region Fields
        public int Height { get; set; }
        public int Width { get; set; }
        public Position StartingCoordinates { get; set; }
        public Position EndingCoordinates { get; set; }

        #endregion

        #region Constuctors
        public Plateau()
        {
            Height = 0;
            Width = 0;
            StartingCoordinates = new Position(0, 0);
            EndingCoordinates = new Position(0, 0);
        }
        public Plateau(int height, int width, Position startingCoordinates)
        {
            this.Height = height;
            this.Width = width;
            this.StartingCoordinates = startingCoordinates;
            this.EndingCoordinates = new Position(startingCoordinates.X + width, startingCoordinates.Y + height);
        }
        #endregion

        #region Methods

        public static Plateau Parse(string input)
        {
            int height, width;
            var splittedString = input.Split(' ');
            Plateau plateau = null;
            if (splittedString.Length >=2)
            {
                Int32.TryParse(splittedString[0], out height);
                Int32.TryParse(splittedString[1], out width);
                plateau = new Plateau(height,width, new Position(0,0));
            }

            return plateau;
        }
        #endregion



    }
}
