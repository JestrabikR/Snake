///█ ■
////https://www.youtube.com/watch?v=SGZgvMwjq2U

using Snake.Game;
using Snake.Input;
using Snake.Rendering;

IGameRenderer renderer = new ConsoleGameRenderer();
IInputReader inputReader = new ConsoleInputReader();
var gameState = new GameState(GameConfig.InitialSnakeLength, GameConfig.BoardWidth, GameConfig.BoardHeight);

var direction = GameConfig.InitialSnakeDirection;

renderer.Initialize(GameConfig.BoardWidth, GameConfig.BoardHeight);

while (!gameState.IsGameOver)
{
    renderer.Render(gameState);
    direction = inputReader.ReadDirectionDuringTick(direction, TimeSpan.FromMilliseconds(GameConfig.TickDurationMs));
    gameState.Tick(direction);
}

renderer.DrawGameOver(gameState);
