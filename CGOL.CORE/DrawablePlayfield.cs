using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGOL.CORE
{
    public abstract class DrawablePlayfield
    {
        public GOL g;
        public abstract void DrawPlayfield();
        public abstract void SetTitle();
    }
}
