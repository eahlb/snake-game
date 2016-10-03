using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalVersion
{
    class Point
    {
        //Points for objects in game

        protected int posX;
        protected int posY;
        protected ConsoleColor color;
        protected char c;

        public Point()
        {
            posX = 0;
            posY = 0;
            color = ConsoleColor.Black;
            c = ' ';
        }
        public Point(int X, int Y, ConsoleColor color, char character)
        {
            posX = X;
            posY = Y;
            this.color = color;
            c = character;
        }

        public int X { get { return posX; } set { posX = value; } }
        public int Y { get { return posY; } set { posY = value; } }
        public char Character { get { return c; } set { c = value; } }

        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(posX, posY);
            Console.Write(c);
        }

        public void Remove()
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write(" ");
        }
    }

    class BodyPoint : Point
    {
        //Points for the snake

        public BodyPoint()
        {
            posX = 0;
            posY = 0;
            color = ConsoleColor.White;
            c = '*';
        }
        public BodyPoint(int X, int Y)
        {
            posX = X;
            posY = Y;
            color = ConsoleColor.White;
            c = '*';
        }
    }

    class FoodPoint : Point
    {
        //Points for food
        
        public FoodPoint()
        {
            posX = 0;
            posY = 0;
            color = ConsoleColor.Green;
            c = '1';
        }
        public FoodPoint(Food sender)
        {
            posX = X;
            posY = Y;
            color = ConsoleColor.Green;
            c = sender.Value.ToString()[0];
        }
    }

    class ObstaclePoint : Point
    {
        //Points for obstacles, border etc.

        public ObstaclePoint()
        {
            posX = 0;
            posY = 0;
            color = ConsoleColor.Red;
            c = '*';
        }
        public ObstaclePoint(int X, int Y)
        {
            posX = X;
            posY = Y;
            color = ConsoleColor.Red;
            c = '*';
        }
    }
}
