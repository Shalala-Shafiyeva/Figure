using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    [Serializable()]
    internal class Point
    {
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public Point(double coordinateX, double coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }
        public override string ToString()
        {
            return "("+CoordinateX+","+CoordinateY+")";
        }
    }
}
