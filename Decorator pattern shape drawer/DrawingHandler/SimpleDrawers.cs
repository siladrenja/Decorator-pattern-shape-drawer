using Decorator_pattern_shape_drawer.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_pattern_shape_drawer.DrawingHandler
{
    public class TriangleDrawer : DrawerDecorator
    {
        public TriangleDrawer(ShapeData shapeData)
        {
            this.shapeData = shapeData;
            nextDrawer = null;
        }

        public override void Draw(Bitmap bitmap)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                ShapeData newShapeData = new ShapeData(shapeData.X, bitmap.Height - shapeData.Y, shapeData.Width, -shapeData.Height,shapeData.Rotation, shapeData.Color);
                Point[] points = new Point[]{
                    new Point(newShapeData.X,  newShapeData.Y),
                    new Point(newShapeData.X + newShapeData.Width,  newShapeData.Y),
                    new Point(newShapeData.X + newShapeData.Width / 2, newShapeData.Y + newShapeData.Height)
                }.Rotate(newShapeData.Rotation);

                g.FillPolygon(new SolidBrush(Color.FromArgb(newShapeData.Color)), points);
                
            }

            if (nextDrawer != null)
            {
                nextDrawer.Draw(bitmap);
            }
        }
        

        private ShapeData shapeData;

    }

    public class RectangleDrawer : DrawerDecorator
    {
        public RectangleDrawer(ShapeData shapeData)
        {
            this.shapeData = shapeData;
            nextDrawer = null;
        }

        public override void Draw(Bitmap bitmap)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                ShapeData newShapeData = new ShapeData(shapeData.X, bitmap.Height - shapeData.Y, shapeData.Width, -shapeData.Height, shapeData.Rotation, shapeData.Color);

                Point[] points = new Point[]{
                    new Point(newShapeData.X, newShapeData.Y),
                    new Point(newShapeData.X + newShapeData.Width, newShapeData.Y),
                    new Point(newShapeData.X + newShapeData.Width, newShapeData.Y + newShapeData.Height),
                    new Point(newShapeData.X, newShapeData.Y + newShapeData.Height)
                }.Rotate(newShapeData.Rotation);

                g.FillPolygon(new SolidBrush(Color.FromArgb(newShapeData.Color)), points);

            }
            if (nextDrawer != null)
            {
                nextDrawer.Draw(bitmap);
            }
        }

        
        private ShapeData shapeData;

    }

    public class ElypseDrawer : DrawerDecorator
    {
        public ElypseDrawer(ShapeData shapeData)
        {
            this.shapeData = shapeData;
            nextDrawer = null;
        }

        public override void Draw(Bitmap bitmap)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.RotateTransform(shapeData.Rotation.ToDegrees());

                ShapeData newShapeData = new ShapeData(shapeData.X, bitmap.Height - shapeData.Y, shapeData.Width, -shapeData.Height, shapeData.Rotation, shapeData.Color);

                g.FillEllipse(new SolidBrush(Color.FromArgb(newShapeData.Color)), newShapeData.X, newShapeData.Y, newShapeData.Width, newShapeData.Height);
            }
            if (nextDrawer != null)
            {
                nextDrawer.Draw(bitmap);
            }
        }

        private ShapeData shapeData;
    }

    public class CircleDrawer : ElypseDrawer
    {
        public CircleDrawer(ShapeData shapeData) : base(new ShapeData(shapeData.X, shapeData.Y, 0, shapeData.Color))
        {
        }
    }

    public class FillScreen : DrawerDecorator
    {
        public FillScreen(int color)
        {
            this.color = color;
            nextDrawer = null;
        }

        public override void Draw(Bitmap bitmap)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.FromArgb(color));
            }
            if (nextDrawer != null)
            {
                nextDrawer.Draw(bitmap);
            }
        }

        private int color;
    }
}

