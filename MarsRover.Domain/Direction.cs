using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain
{
    public class Direction
    {
        public static DirectionType ParseInputToDirectionType(char input)
        {
            switch (input)
            {
                case 'N':
                    return DirectionType.N;
                case 'E':
                    return DirectionType.E;
                case 'S':
                    return DirectionType.S;
                case 'W':
                    return DirectionType.W;
                default:
                    return DirectionType.N;
            }
        }
    }
    public enum DirectionType
    {
        /// <summary> North, 0 </summary>
        N,
        /// <summary> East, 1</summary>
        E,
        /// <summary> South, 2 </summary>
        S,
        /// <summary> West, 3 </summary>
        W
    }
}
