///█ ■
////https://www.youtube.com/watch?v=SGZgvMwjq2U
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
            
            var movement = "RIGHT";
            var bodyXPositions = new List<int>();
            var bodyYPositions = new List<int>();

            var berryX = randomNumber.Next(0, screenWidth);
            var berryY = randomNumber.Next(0, screenHeight);

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
                        if (keyPressed.Key.Equals(ConsoleKey.UpArrow) && movement != "DOWN" && !hasMovedThisTick)
                        {
                            movement = "UP";
                            hasMovedThisTick = true;
                        }
                        if (keyPressed.Key.Equals(ConsoleKey.DownArrow) && movement != "UP" && !hasMovedThisTick)
                        {
                            movement = "DOWN";
                            hasMovedThisTick = true;
                        }
                        if (keyPressed.Key.Equals(ConsoleKey.LeftArrow) && movement != "RIGHT" && !hasMovedThisTick)
                        {
                            movement = "LEFT";
                            hasMovedThisTick = true;
                        }
                        if (keyPressed.Key.Equals(ConsoleKey.RightArrow) && movement != "LEFT" && !hasMovedThisTick)
                        {
                            movement = "RIGHT";
                            hasMovedThisTick = true;
                        }
                    }
                }
                
                bodyXPositions.Add(head.XPos);
                bodyYPositions.Add(head.YPos);
                
                switch (movement)
                {
                    case "UP":
                        head.YPos--;
                        break;
                    case "DOWN":
                        head.YPos++;
                        break;
                    case "LEFT":
                        head.XPos--;
                        break;
                    case "RIGHT":
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