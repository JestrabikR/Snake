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

            var head = new Pixel();
            head.XPos = screenWidth / 2;
            head.YPos = screenHeight / 2;
            head.Color = ConsoleColor.Red;
            
            var movementDirection = Direction.Right;
            var bodyXPositions = new List<int>();
            var bodyYPositions = new List<int>();

            var berryX = randomNumber.Next(1, screenWidth - 1);
            var berryY = randomNumber.Next(1, screenHeight - 1);

            while (true)
            {
                Console.Clear();
                
                if (head.XPos == screenWidth - 1 || head.XPos == 0 || head.YPos == screenHeight - 1 || head.YPos == 0)
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

                if (berryX == head.XPos && berryY == head.YPos)
                {
                    score++;
                    berryX = randomNumber.Next(1, screenWidth - 2);
                    berryY = randomNumber.Next(1, screenHeight - 2);
                }

                for (var i = 0; i < bodyXPositions.Count; i++)
                {
                    Console.SetCursorPosition(bodyXPositions[i], bodyYPositions[i]);
                    Console.Write("■");
                    if (bodyXPositions[i] == head.XPos && bodyYPositions[i] == head.YPos)
                    {
                        isGameOver = true;
                    }
                }

                if (isGameOver)
                {
                    break;
                }

                Console.SetCursorPosition(head.XPos, head.YPos);
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
                
                bodyXPositions.Add(head.XPos);
                bodyYPositions.Add(head.YPos);
                
                switch (movementDirection)
                {
                    case Direction.Up:
                        head.YPos--;
                        break;
                    case Direction.Down:
                        head.YPos++;
                        break;
                    case Direction.Left:
                        head.XPos--;
                        break;
                    case Direction.Right:
                        head.XPos++;
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

        class Pixel
        {
            public int XPos { get; set; }
            public int YPos { get; set; }
            public ConsoleColor Color { get; set; }
        }
    }
}
//¦