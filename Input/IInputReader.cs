using Snake.Enums;

namespace Snake.Input;

public interface IInputReader
{
    Direction ReadDirectionDuringTick(Direction currentDirection, TimeSpan tickDuration);
}
