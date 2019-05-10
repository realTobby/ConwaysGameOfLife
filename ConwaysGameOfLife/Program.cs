using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    class Program
    {
        static GOL g = new GOL(50, 25);


        static void NewPlayfield()
        {
            g.SetPlayfield();
            g.ClearPlayfield();
            g.InitPlayfield();
        }

        static void Main(string[] args)
        {
            NewPlayfield();
            

            while (true)
            {
                g.DrawPlayfield();
                g.ComputeNextGeneration();
                Console.Title = "GENERATION: " + g.GENERATION;
                //Thread.Sleep(200);
            }

            Console.ReadLine();

        }
    }
}
