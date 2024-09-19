using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_pattern_shape_drawer.DrawingHandler
{
    public abstract class DrawerDecorator : IDrawer
    {
        public void AddDrawer(IDrawer drawer)
        {
            if (nextDrawer == null)
            {
                nextDrawer = drawer;
            }
            else
            {
                if(nextDrawer.GetType().IsSubclassOf(typeof(DrawerDecorator)))
                {
                    ((DrawerDecorator)nextDrawer).AddDrawer(drawer);
                }
                else
                {
                    throw new Exception("Cannot add drawer to non-decorator drawer");
                }
            }
        }

        public abstract void Draw(Bitmap bitmap);

        protected IDrawer nextDrawer;
    }
}
