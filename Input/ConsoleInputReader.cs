namespace Snake.Input;

using Enums;

public class ConsoleInputReader : IInputReader
{
    public Direction ReadDirectionDuringTick(Direction currentDirection, TimeSpan tickDuration)
    {
        var newDirection = currentDirection;
        var tickEnd = DateTime.Now + tickDuration;
        var alreadyChangedDirection = false;

        while (DateTime.Now < tickEnd)
        {
            if (!Console.KeyAvailable)
            {
                Thread.Sleep(10);
                continue;
            }

            var key = Console.ReadKey(intercept: true);
            var attempted = MapKeyToDirection(key.Key);

            if (!attempted.HasValue || alreadyChangedDirection || IsOpposite(attempted.Value, currentDirection))
            {
                continue;
            }

            newDirection = attempted.Value;
            alreadyChangedDirection = true;
        }

        return newDirection;
    }

    private static Direction? MapKeyToDirection(ConsoleKey key)
    {
        return key switch
        {
            ConsoleKey.UpArrow => Direction.Up,
            ConsoleKey.DownArrow => Direction.Down,
            ConsoleKey.LeftArrow => Direction.Left,
            ConsoleKey.RightArrow => Direction.Right,
            _ => null
        };
    }

    private static bool IsOpposite(Direction a, Direction b)
    {
        return (a == Direction.Up && b == Direction.Down)
               || (a == Direction.Down && b == Direction.Up)
               || (a == Direction.Left && b == Direction.Right)
               || (a == Direction.Right && b == Direction.Left);
    }
}

