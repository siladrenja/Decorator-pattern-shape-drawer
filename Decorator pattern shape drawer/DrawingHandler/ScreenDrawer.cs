using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Decorator_pattern_shape_drawer.DrawingHandler
{
    public class ScreenDrawer : IDrawer
    {
        public ScreenDrawer(Graphics screen)
        {
            this.screen = screen;
        }

        public void Draw(Bitmap bitmap)
        {
            
            screen.DrawImage(bitmap, 0,0);
        }

        private Graphics screen;
    }
}
