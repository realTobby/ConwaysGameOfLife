using CGOL.CORE;
using System;

namespace ConwaysGameOfLife
{
    class Program
    {
        static DrawablePlayfield playfield = new CSGOLSFML(150, 150);

        static void NewPlayfield()
        {
            playfield.g.SetPlayfield();
            playfield.g.ClearPlayfield();
            playfield.g.InitPlayfield();
        }

        static void Main(string[] args)
        {
            NewPlayfield();
            
            while (playfield.g.IsDone == false)
            {
                playfield.DrawPlayfield();
                playfield.g.ComputeNextGeneration();
                playfield.SetTitle();
            }
            Console.WriteLine("\nDONE.");

            Console.ReadLine();

        }
    }
}
