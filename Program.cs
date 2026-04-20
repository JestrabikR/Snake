///█ ■
////https://www.youtube.com/watch?v=SGZgvMwjq2U

using Snake.Enums;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 16;
            Console.WindowWidth = 32;

            var screenWidth = Console.WindowWidth;
            var screenHeight = Console.WindowHeight;

            var randomNumber = new Random();
            var score = 5;
            var isGameOver = false;

            var head = new Pixel(screenWidth / 2, screenHeight / 2, ConsoleColor.Red);
            
            var movementDirection = Direction.Right;
            var bodyXPositions = new List<int>();
            var bodyYPositions = new List<int>();

            var berryX = randomNumber.Next(1, screenWidth - 1);
            var berryY = randomNumber.Next(1, screenHeight - 1);

            while (true)
            {
                Console.Clear();
                
                if (head.X == screenWidth - 1 || head.X == 0 || head.Y == screenHeight - 1 || head.Y == 0)
                {
                    isGameOver = true;
                }
                
                for (var i = 0; i < screenWidth; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("■");
                }
                
                for (var i = 0; i < screenWidth; i++)
                {
                    Console.SetCursorPosition(i, screenHeight - 1);
                    Console.Write("■");
                }
                
                for (var i = 0; i < screenHeight; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("■");
                }
                
                for (var i = 0; i < screenHeight; i++)
                {
                    Console.SetCursorPosition(screenWidth - 1, i);
                    Console.Write("■");
                }
                
                Console.ForegroundColor = ConsoleColor.Green;

                if (berryX == head.X && berryY == head.Y)
                {
                    score++;
                    berryX = randomNumber.Next(1, screenWidth - 2);
                    berryY = randomNumber.Next(1, screenHeight - 2);
                }

                for (var i = 0; i < bodyXPositions.Count; i++)
                {
                    Console.SetCursorPosition(bodyXPositions[i], bodyYPositions[i]);
                    Console.Write("■");
                    if (bodyXPositions[i] == head.X && bodyYPositions[i] == head.Y)
                    {
                        isGameOver = true;
                    }
                }

                if (isGameOver)
                {
                    break;
                }

                Console.SetCursorPosition(head.X, head.Y);
                Console.ForegroundColor = head.Color;
                Console.Write("■");
                Console.SetCursorPosition(berryX, berryY);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("■");

                var tickStartTime = DateTime.Now;
                var hasMovedThisTick = false;

                while (true)
                {
                    var currentTime = DateTime.Now;
                    if (currentTime.Subtract(tickStartTime).TotalMilliseconds > 500) { break; }

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                        //Console.WriteLine(keyPressed.Key.ToString());
                        if (keyPressed.Key.Equals(ConsoleKey.UpArrow) && movementDirection != Direction.Down && !hasMovedThisTick)
                        {
                            movementDirection = Direction.Up;
                            hasMovedThisTick = true;
                        }
                        if (keyPressed.Key.Equals(ConsoleKey.DownArrow) && movementDirection != Direction.Up && !hasMovedThisTick)
                        {
                            movementDirection = Direction.Down;
                            hasMovedThisTick = true;
                        }
                        if (keyPressed.Key.Equals(ConsoleKey.LeftArrow) && movementDirection != Direction.Right && !hasMovedThisTick)
                        {
                            movementDirection = Direction.Left;
                            hasMovedThisTick = true;
                        }
                        if (keyPressed.Key.Equals(ConsoleKey.RightArrow) && movementDirection != Direction.Left && !hasMovedThisTick)
                        {
                            movementDirection = Direction.Right;
                            hasMovedThisTick = true;
                        }
                    }
                }
                
                bodyXPositions.Add(head.X);
                bodyYPositions.Add(head.Y);
                
                switch (movementDirection)
                {
                    case Direction.Up:
                        head.Y--;
                        break;
                    case Direction.Down:
                        head.Y++;
                        break;
                    case Direction.Left:
                        head.X--;
                        break;
                    case Direction.Right:
                        head.X++;
                        break;
                }

                if (bodyXPositions.Count > score)
                {
                    bodyXPositions.RemoveAt(0);
                    bodyYPositions.RemoveAt(0);
                }
            }
            Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
            Console.WriteLine("Game over, Score: " + score);
            Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
        }
    }
}
//¦