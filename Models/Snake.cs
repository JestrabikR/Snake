using Snake.Enums;

namespace Snake.Models;

public class Snake(Position startPosition, int initialLength)
{
    private readonly List<Position> _segments = [];
    private int _pendingGrowth = initialLength - 1;

    public Position Head { get; private set; } = startPosition;
    public IReadOnlyList<Position> Segments => _segments;

    public void Move(Direction direction)
    {
        _segments.Add(Head);
        Head = ComputeNextPosition(direction);

        if (_pendingGrowth > 0)
        {
            _pendingGrowth--;
        }
        else
        {
            _segments.RemoveAt(0);
        }
    }

    public void Grow() => _pendingGrowth++;

    public bool CollidesWithSelf()
    {
        return _segments.Any(segment => segment == Head);
    }

    private Position ComputeNextPosition(Direction direction)
    {
        return direction switch
        {
            Direction.Up => Head with { Y = Head.Y - 1 },
            Direction.Down => Head with { Y = Head.Y + 1 },
            Direction.Left => Head with { X = Head.X - 1 },
            Direction.Right => Head with { X = Head.X + 1 },
            _ => Head
        };
    }
}
