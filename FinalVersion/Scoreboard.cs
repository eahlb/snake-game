using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FinalVersion
{
    class Scoreboard
    {
        Game currentGame;
        int score;
        int highscore;

        public Scoreboard(Game currentGame)
        {
            this.currentGame = currentGame;
            score = 0;
            highscore = GetHighscore();
        }

        public int Score { get { return score; } set { score = value; } }
        public int Highscore { get { return highscore; } }

        public void Update()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, currentGame.Height + 2);
            Console.WriteLine("Score: {0}", score);
            Console.WriteLine("Highscore: {0}", highscore);
        }

        private int GetHighscore()
        {
            StreamReader sr = new StreamReader("highscore.txt");
            int i = int.Parse(sr.ReadLine());
            sr.Close();
            return i;
        }

        public void SaveScore()
        {
            if (score > highscore)
            {
                StreamWriter sw = new StreamWriter("highscore.txt");
                sw.WriteLine("{0}", score);
                sw.Close();
            }
        }
    }
}
