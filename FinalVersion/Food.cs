using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalVersion
{
    class Food
    {
        FoodPoint fp;
        Game currentGame;
        int foodValue;

        public Food(Game currentGame)
        {
            this.currentGame = currentGame;
            fp = new FoodPoint();
            RandomizePos();
        }

        public int PosX { get { return fp.X; } }
        public int PosY { get { return fp.Y; } }
        public int Value { get { return foodValue; } set { foodValue = value; } }
        public FoodPoint FP { get { return fp; } set { fp = value; } }

        public void Draw()
        {
            fp.Draw();
        }

        public void Remove()
        {
            fp.Remove();
        }

        public void RandomizePos()
        {
            Random rdm = new Random();
            fp.X = rdm.Next(1, currentGame.Width - 2);
            fp.Y = rdm.Next(1, currentGame.Height - 2);
            foodValue = rdm.Next(1, 9);
            fp.Character = foodValue.ToString()[0];
        }
    }
}
