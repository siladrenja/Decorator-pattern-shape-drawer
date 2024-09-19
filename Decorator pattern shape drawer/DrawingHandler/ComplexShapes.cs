using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_pattern_shape_drawer.DrawingHandler
{
    public class House : DrawerDecorator
    {
        public House(ShapeData data)
        {
            nextDrawer = new RectangleDrawer(data);
            ((DrawerDecorator)nextDrawer).AddDrawer(new TriangleDrawer(data+ new Point(0, data.Height)));
        }

        public override void Draw(System.Drawing.Bitmap bitmap)
        {
            nextDrawer.Draw(bitmap);
        }
    }
}
