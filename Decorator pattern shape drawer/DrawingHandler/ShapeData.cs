using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_pattern_shape_drawer.DrawingHandler
{
    public struct ShapeData
    {
        public ShapeData(int x, int y, int width, int height, float rotation = 0, int color=unchecked((int)0xffff0000))
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Rotation = rotation;
            Color = color;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float Rotation { get; set; }
        public int Color { get; set; }

        public static ShapeData operator+(ShapeData data, Point point)
        {
            return new ShapeData(data.X + point.X, data.Y + point.Y, data.Width, data.Height, data.Rotation, data.Color);
        }
        public static ShapeData operator+(Point point, ShapeData data)
        {
            return data + point;
        }
    }
}
