using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_pattern_shape_drawer.Helpers
{
    public static class PointHelper
    {
        public static Point Rotate(this Point oldPoint, Point center, float angle)
        {
            Point translated = Point.Subtract(oldPoint, (Size)(center));
            
            int rotatedX = (int)(translated.X * (float)Math.Cos(angle) - translated.Y * (float)Math.Sin(angle));
            translated.Y = (int)(translated.X * (float)Math.Sin(angle) + translated.Y * (float)Math.Cos(angle));
            translated.X = rotatedX;

            translated += (Size)center;

            return translated;
        }

        public static Point CalculateCenter(this Point[] points)
        {
            int averageX = 0;
            int averageY = 0;

            foreach (Point point in points)
            {
                averageX += point.X;
                averageY += point.Y;
            }
            return new Point(averageX / points.Length, averageY / points.Length);
        }

        public static Point[] Rotate(this Point[] points, float angle)
        {
            Point center = points.CalculateCenter();

            Point[] rotatedPoints = new Point[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                rotatedPoints[i] = points[i].Rotate(center, angle);
            }


            return rotatedPoints;
        }
    }

    
}
