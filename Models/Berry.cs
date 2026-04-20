namespace Snake.Models;

public class Berry(int boardWidth, int boardHeight)
{
    public Position Position { get; private set; } = GeneratePosition(boardWidth, boardHeight);

    public void Relocate(int boardWidth, int boardHeight)
        => Position = GeneratePosition(boardWidth, boardHeight);

    private static Position GeneratePosition(int boardWidth, int boardHeight)
    {
        return new Position(
            Random.Shared.Next(1, boardWidth - 1),
            Random.Shared.Next(1, boardHeight - 1)
        );
    }
}
