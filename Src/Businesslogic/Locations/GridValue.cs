namespace Businesslogic.Locations
{
    public class GridValue<T>(T value)
    {
        public T Value { get; set; } = value;
        public ConsoleColor Color { get; set; } = ConsoleColor.White;
    }
}
