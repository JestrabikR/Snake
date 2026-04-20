using Snake.Enums;

namespace Snake.Game;

public static class GameConfig
{
    public const int BoardWidth = 32;
    public const int BoardHeight = 16;
    public const int InitialSnakeLength = 5;
    public const Direction InitialSnakeDirection = Direction.Right;
    public const int TickDurationMs = 500;
}
