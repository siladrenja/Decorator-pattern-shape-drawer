using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_pattern_shape_drawer.Helpers
{
    public static class MathHelper
    {
        public static float ToRadians(this float angle)
        {
            return (float)(Math.PI / 180) * angle;
        }

        public static float ToDegrees(this float angle)
        {
            return (float)(180 / Math.PI) * angle;
        }
    }
}
