using Decorator_pattern_shape_drawer.DrawingHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Decorator_pattern_shape_drawer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Bitmap bitmap = new Bitmap(Width, Height);

            IDrawer drawer;
            drawer = new FillScreen(unchecked((int)0xFF0000FF));
            ((DrawerDecorator)drawer).AddDrawer(new RectangleDrawer(new ShapeData(200, 100, 100, 100, 0, unchecked((int)0xFF555500))));

            ((DrawerDecorator)drawer).AddDrawer(new TriangleDrawer(new ShapeData(500, 400, 100, 100, 3.14f/2)));
            ((DrawerDecorator)drawer).AddDrawer(new House(new ShapeData(20, 50, 100, 100, 0, unchecked((int)0xFF555500))));
            ((DrawerDecorator)drawer).AddDrawer(new ScreenDrawer(e.Graphics));

            drawer.Draw(bitmap);

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();

        }
    }
}
