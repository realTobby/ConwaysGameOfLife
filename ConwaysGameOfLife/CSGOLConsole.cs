using CGOL.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class CSGOLConsole : DrawablePlayfield
    {
        public CSGOLConsole(int w, int h)
        {
            g = new GOL(w, h);
        }

        public override void SetTitle()
        {
            Console.Title = "Generation: " + g.GENERATION;
        }

        public override void DrawPlayfield()
        {
            for (int y = 0; y < g.height; y++)
            {
                for (int x = 0; x < g.width; x++)
                {
                    Console.SetCursorPosition(x, y);
                    switch (g.currentGen[x, y])
                    {
                        case true:
                            Console.Write("█");
                            break;
                        case false:
                            Console.Write(" ");
                            break;
                    }
                }
            }
        }
    }
}
