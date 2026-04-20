using Snake.Game;

namespace Snake.Rendering;

public interface IGameRenderer
{
    void Initialize(int boardWidth, int boardHeight);
    void Render(GameState state);
    void DrawGameOver(GameState state);
}
