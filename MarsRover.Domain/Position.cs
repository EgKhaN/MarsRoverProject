namespace MarsRover.Domain
{
    public class Position
    {
        public Position()
        {
            X = 0;
            Y = 0;
        }
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}