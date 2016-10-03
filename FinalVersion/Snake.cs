using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalVersion
{
    class Snake
    {
        Game currentGame;
        BodyPoint snHead;
        List<BodyPoint> snBody;
        ConsoleKey direction;
        int length;
        bool alive;

        public Snake(Game currentGame, int length)
        {
            this.currentGame = currentGame;
            this.length = length;
            direction = ConsoleKey.RightArrow;
            alive = true;
            snHead = new BodyPoint(length, 1);
            snBody = new List<BodyPoint>();
            for (int i = 1; i < length; i++)
            {
                snBody.Add(new BodyPoint(length - i, 1));
            }
        }

        public ConsoleKey Direction { get { return direction; } set { direction = value; } }
        public bool Alive { get { return alive; } }

        public void Draw()
        {
            snHead.Draw();
            foreach (BodyPoint bp in snBody)
            {
                bp.Draw();
            }
        }

        public void Remove()
        {
            snHead.Draw();
            foreach (BodyPoint bp in snBody)
            {
                bp.Remove();
            }
        }

        public void Eat()
        {
            currentGame.SB.Score += currentGame.FoodP.Value;
            currentGame.SB.Update();

            length += currentGame.FoodP.Value;

            currentGame.FoodP.RandomizePos();
            currentGame.FoodP.Draw();

            Console.Beep();
        }

        public void Move()
        {
            List<BodyPoint> temp = new List<BodyPoint>();
            temp.Add(snHead);
            for (int i = 0; i < snBody.Count; i++)
            {
                temp.Add(snBody[i]);
            }

            if (length > temp.Count)
            {
                temp.Add(snBody[snBody.Count - 1]);
            }
            else
            {
                temp[temp.Count - 1].Remove();
                temp.RemoveAt(temp.Count - 1);
            }
            snBody = temp;

            snHead = new BodyPoint(snBody[0].X, snBody[0].Y);
            switch (direction)
            {
                case ConsoleKey.UpArrow:
                    snHead.Y--;
                    break;
                case ConsoleKey.DownArrow:
                    snHead.Y++;
                    break;
                case ConsoleKey.RightArrow:
                    snHead.X++;
                    break;
                case ConsoleKey.LeftArrow:
                    snHead.X--;
                    break;
            }
            snHead.Draw();
            CheckPos();
        }

        public void Die()
        {
            alive = false;
            Console.Beep(1000, 500);
            currentGame.EndGame();
        }

        private void CheckPos()
        {
            if (snHead.X == currentGame.FoodP.PosX && snHead.Y == currentGame.FoodP.PosY)
            {
                Eat();
            }
            else
            {
                foreach (ObstaclePoint op in currentGame.Bord.BorderPoints)
                {
                    if (snHead.X == op.X && snHead.Y == op.Y)
                    {
                        Die();
                        alive = false;
                    }
                }
                foreach (BodyPoint bp in snBody)
                {
                    if (snHead.X == bp.X && snHead.Y == bp.Y)
                    {
                        Die();
                        alive = false;
                    }
                }
            }
        }
    }
}
