using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Game gm = new Game(50, 20);
                gm.Run();

                while (true)
                {
                    string str = Console.ReadLine();
                    if (str == "y")
                        break;
                    else if (str == "n")
                        Environment.Exit(0);
                }
            }
        }
    }
}
