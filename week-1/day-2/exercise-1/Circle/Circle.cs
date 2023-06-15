using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    internal class Circle
    {
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double CalculateArea()
        {
            return 3.14 * radius * radius;
        }

        public double CalculateCircumference()
        {
            return 2 * 3.14 * radius;
        }
    }
}
