using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class GOL
    {

        private bool[,] cells;
        private int width;
        private int height;
        private Random rnd = new Random();
        public int GENERATION = 0;

        public GOL(int w, int h)
        {
            width = w;
            height = h;
        }

        public void SetPlayfield()
        {
            cells = new bool[width, height];
        }

        public void ClearPlayfield()
        {
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    cells[x, y] = false;
                }
            }
        }

        public void DrawPlayfield()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.SetCursorPosition(x, y);
                    switch (cells[x,y])
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

        public void InitPlayfield()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int thresh = rnd.Next(0, 100);
                    if(thresh > 90)
                    {
                        cells[x, y] = true;
                    }
                }
            }
        }

        public void ComputeNextGeneration()
        {
            GENERATION++;
            bool[,] oldGen = cells;

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    int neighbours = GetNeighbours(x, y);

                    if(oldGen[x,y] == false)
                    {
                        if(neighbours == 3)
                        {
                            cells[x, y] = true;
                        }
                    }

                    if(oldGen[x,y] == true)
                    {
                        if(neighbours < 2)
                        {
                            cells[x, y] = false;
                        }
                        if(neighbours == 2 || neighbours == 3)
                        {
                            cells[x, y] = true;
                        }
                        if(neighbours > 3)
                        {
                            cells[x, y] = false;
                        }
                    }

                }
            }

        }

        private int GetNeighbours(int x, int y)
        {
            int n = 0;
            if (x == 0 || x == width-1 || y == 0 || y == height-1)
            {
                return 0;
            }
            
            if(cells[x-1,y-1] == true)
            {
                n++;
            }

            if(cells[x,y-1] == true)
            {
                n++;
            }

            if(cells[x+1,y-1] == true)
            {
                n++;
            }

            if(cells[x-1,y] == true)
            {
                n++;
            }

            if(cells[x+1,y] == true)
            {
                n++;
            }

            if(cells[x-1,y+1] == true)
            {
                n++;
            }

            if(cells[x,y+1] == true)
            {
                n++;
            }

            if(cells[x+1,y+1] == true)
            {
                n++;
            }

            return n;
        }

    }
}
