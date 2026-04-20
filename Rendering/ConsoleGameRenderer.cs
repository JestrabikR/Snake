using Snake.Game;

namespace Snake.Rendering;

public class ConsoleGameRenderer : IGameRenderer
{
    private const char TileChar = '■';

    public void Initialize(int boardWidth, int boardHeight)
    {
        Console.WindowWidth = boardWidth;
        Console.WindowHeight = boardHeight;
        Console.CursorVisible = false;
    }

    public void Render(GameState state)
    {
        Console.Clear();
        DrawWalls(state.BoardWidth, state.BoardHeight);
        DrawBody(state.SnakeBody);
        DrawHead(state.SnakeHead);
        DrawBerry(state.BerryPosition);
    }

    public void DrawGameOver(GameState state)
    {
        Console.SetCursorPosition(state.BoardWidth / 5, state.BoardHeight / 2);
        Console.WriteLine("Game over, Score: " + state.Score);
        Console.SetCursorPosition(state.BoardWidth / 5, state.BoardHeight / 2 + 1);
    }

    private static void DrawTile(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(TileChar);
    }

    private static void DrawWalls(int width, int height)
    {
        Console.ForegroundColor = ConsoleColor.White;
        DrawHorizontalLine(y: 0, width);
        DrawHorizontalLine(y: height - 1, width);
        DrawVerticalLine(x: 0, height);
        DrawVerticalLine(x: width - 1, height);
    }

    private static void DrawBody(IReadOnlyList<Position> segments)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var segment in segments)
        {
            DrawTile(segment.X, segment.Y);
        }
    }

    private static void DrawHead(Position head)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        DrawTile(head.X, head.Y);
    }

    private static void DrawBerry(Position berry)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        DrawTile(berry.X, berry.Y);
    }

    private static void DrawHorizontalLine(int y, int width)
    {
        for (var x = 0; x < width; x++)
        {
            DrawTile(x, y);
        }
    }

    private static void DrawVerticalLine(int x, int height)
    {
        for (var y = 0; y < height; y++)
        {
            DrawTile(x, y);
        }
    }
}
