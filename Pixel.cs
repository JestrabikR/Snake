namespace Snake;

public class Pixel(int x, int y, ConsoleColor color)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    public ConsoleColor Color { get; set; } = color;
}