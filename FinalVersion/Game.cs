using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalVersion
{
    class Game
    {
        int W, H;
        Border b;
        Food fp;
        Snake snk;
        Scoreboard sb;
        ConsoleKey[] arrows = { ConsoleKey.LeftArrow, ConsoleKey.UpArrow, ConsoleKey.RightArrow, ConsoleKey.DownArrow };

        public Game(int width, int height)
        {
            W = width;
            H = height;

            b = new Border(this);
            fp = new Food(this);
            snk = new Snake(this, 10);
            sb = new Scoreboard(this);

            b.Draw();
            snk.Draw();
            sb.Update();
            fp.Draw();
        }

        public int Width { get { return W; } set { W = value; } }
        public int Height { get { return H; } set { H = value; } }
        public Border Bord { get { return b; } set { b = value; } }
        public Food FoodP { get { return fp; } set { fp = value; } }
        public Snake Snk { get { return snk; } set { snk = value; } }
        public Scoreboard SB { get { return sb; } set { sb = value; } }
        public ConsoleKey[] Arrows { get { return arrows; } }

        private void ClearScreen()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < H + 4; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public void Run()
        {
            while (snk.Alive)
            {
                System.Threading.Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo k = Console.ReadKey();
                    if (arrows.Contains(k.Key))
                    {
                        if ((snk.Direction == ConsoleKey.DownArrow || snk.Direction == ConsoleKey.UpArrow) && (k.Key == ConsoleKey.LeftArrow || k.Key == ConsoleKey.RightArrow))
                        {
                            snk.Direction = k.Key;
                        }
                        else if ((snk.Direction == ConsoleKey.LeftArrow || snk.Direction == ConsoleKey.RightArrow) && (k.Key == ConsoleKey.DownArrow || k.Key == ConsoleKey.UpArrow))
                        {
                            snk.Direction = k.Key;
                        }
                    }
                }
                snk.Move();
            }
        }

        public void EndGame()
        {
            sb.SaveScore();
            ClearScreen();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You died! Your score was: {0}. Play again?(y/n)", sb.Score);
        }
    }
}
