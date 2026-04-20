namespace Snake;

public class Pixel(Position position, ConsoleColor color)
{
    public int X { get; set; } = position.X;
    public int Y { get; set; } = position.Y;
    public ConsoleColor Color { get; set; } = color;
}