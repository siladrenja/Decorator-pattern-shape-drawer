using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_pattern_shape_drawer.DrawingHandler
{
    public interface IDrawer
    {
        void Draw(Bitmap bitmap);
    }
}
