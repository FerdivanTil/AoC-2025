using System.Diagnostics;

namespace Businesslogic.Locations
{
    [DebuggerDisplay("Coordinate = {Coord}")]
    public class Coordinate : IEquatable<Coordinate>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Coord => $"{X},{Y}";
        public Coordinate()
        { }
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static Coordinate Parse(string input)
        {
            var xY = input
                .Split(",")
                .Select(i => Convert.ToInt32(i))
                .ToList();
            return new Coordinate(xY[0], xY[1]);
        }

        public bool Equals(Coordinate other)
        {
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}
