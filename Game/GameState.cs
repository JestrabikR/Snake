namespace Snake.Game;

using Enums;
using Models;

public class GameState
{
    private readonly Snake _snake;
    private readonly Berry _berry;

    public int BoardWidth { get; }
    public int BoardHeight { get; }
    public int Score { get; private set; }
    public bool IsGameOver { get; private set; }

    public Position SnakeHead => _snake.Head;
    public IReadOnlyList<Position> SnakeBody => _snake.Segments;
    public Position BerryPosition => _berry.Position;

    public GameState(int initialScore, int boardWidth, int boardHeight)
    {
        BoardWidth = boardWidth;
        BoardHeight = boardHeight;
        Score = initialScore;

        var center = new Position(boardWidth / 2, boardHeight / 2);
        _snake = new Snake(center, GameConfig.InitialSnakeLength);
        _berry = new Berry(boardWidth, boardHeight);
    }

    public void Tick(Direction direction)
    {
        _snake.Move(direction);

        if (HitsWall() || _snake.CollidesWithSelf())
        {
            IsGameOver = true;
            return;
        }

        if (SnakeHead != BerryPosition)
        {
            return;
        }

        Score++;
        _snake.Grow();
        _berry.Relocate(BoardWidth, BoardHeight);
    }

    private bool HitsWall()
    {
        return SnakeHead.X == 0 || SnakeHead.X == BoardWidth - 1
                || SnakeHead.Y == 0 || SnakeHead.Y == BoardHeight - 1;
    }
}