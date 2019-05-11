using System;
using CGOL.CORE;
using SFML.Graphics;
using SFML.Window;

namespace ConwaysGameOfLife
{
    public class CSGOLSFML : DrawablePlayfield
    {
        RenderWindow mainWindow;

        public CSGOLSFML(int w, int h)
        {
            g = new GOL(w, h);
            var mode = new VideoMode((uint)w, (uint)h);
            mainWindow = new RenderWindow(mode, "SFML", Styles.Default);
        }

        public override void SetTitle()
        {
            mainWindow.SetTitle("Generation: " + g.GENERATION);
        }

        public override void DrawPlayfield()
        {
            mainWindow.DispatchEvents();
            mainWindow.Clear();
            for (int y = 0; y < g.height; y++)
            {
                for (int x = 0; x < g.width; x++)
                {
                    switch (g.currentGen[x, y])
                    {
                        case true:
                            RectangleShape cell = new RectangleShape(new SFML.System.Vector2f(1, 1));
                            cell.FillColor = Color.Blue;
                            cell.Position = new SFML.System.Vector2f(x, y);
                            mainWindow.Draw(cell);
                            break;
                    }
                }
            }
            mainWindow.Display();
        }
    }
}
