using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGOL.CORE
{
    public class GOL
    {
        public bool[,] currentGen;
        public int width;
        public int height;
        private Random rnd = new Random();
        public int GENERATION = 0;
        public bool IsDone = false;

        public GOL(int w, int h)
        {
            width = w;
            height = h;
        }

        public void SetPlayfield()
        {
            currentGen = new bool[width, height];
        }

        public void ClearPlayfield()
        {
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    currentGen[x, y] = false;
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
                        currentGen[x, y] = true;
                    }
                }
            }
        }

        public void ComputeNextGeneration()
        {
            GENERATION++;
            bool[,] lastGen = currentGen;

            for (int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    int neighbours = GetNeighbours(x, y);

                    if(lastGen[x,y] == false)
                    {
                        if(neighbours == 3)
                        {
                            currentGen[x, y] = true;
                        }
                    }

                    if(lastGen[x,y] == true)
                    {
                        if(neighbours < 2)
                        {
                            currentGen[x, y] = false;
                        }
                        if(neighbours == 2 || neighbours == 3)
                        {
                            currentGen[x, y] = true;
                        }
                        if(neighbours > 3)
                        {
                            currentGen[x, y] = false;
                        }
                    }

                }
            }
        }

        private int GetNeighbours(int x, int y)
        {
            int n = 0;
            if (x == 0 || x == width- 1 || y == 0 || y == height- 1)
            {
                return 0;
            }
            
            if(currentGen[x-1,y-1] == true)
            {
                n++;
            }

            if(currentGen[x,y-1] == true)
            {
                n++;
            }

            if(currentGen[x+1,y-1] == true)
            {
                n++;
            }

            if(currentGen[x - 1,y] == true)
            {
                n++;
            }

            if(currentGen[x+1,y] == true)
            {
                n++;
            }

            if(currentGen[x-1,y+1] == true)
            {
                n++;
            }

            if(currentGen[x,y+1] == true)
            {
                n++;
            }

            if(currentGen[x+1,y+1] == true)
            {
                n++;
            }

            return n;
        }

    }
}
