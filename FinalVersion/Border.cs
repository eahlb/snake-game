using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalVersion
{
    class Border
    {
        List<ObstaclePoint> op;
        Game currentGame;

        public Border(Game currentGame)
        {
            op = new List<ObstaclePoint>();

            this.currentGame = currentGame;

            for (int i = 0; i < currentGame.Width; i++)
            {
                op.Add(new ObstaclePoint(i, 0));
                op.Add(new ObstaclePoint(i, currentGame.Height - 2));
            }
            for (int i = 1; i < currentGame.Height - 1; i++)
            {
                op.Add(new ObstaclePoint(0, i));
                op.Add(new ObstaclePoint(currentGame.Width - 1, i));
            }
        }

        public List<ObstaclePoint> BorderPoints { get { return op; } }

        public void Draw()
        {
            foreach (ObstaclePoint p in op)
            {
                p.Draw();
            }
        }

        public void Remove()
        {
            foreach (ObstaclePoint p in op)
            {
                p.Remove();
            }
        }
    }
}
