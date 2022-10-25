using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    internal class Circle : Figure
    {
        public double Radius { get; set; }
        public Circle(List<Point> Points) : base(Points) { FindRadius(); }
        public void FindRadius()
        {
            this.Radius = Math.Sqrt((Points[0].CoordinateX - Points[1].CoordinateX) * (Points[0].CoordinateX - Points[1].CoordinateX)
                + (Points[0].CoordinateY - Points[1].CoordinateY) * (Points[0].CoordinateY - Points[1].CoordinateY));
        }
        public override void FindArea()
        {
            this.Area = Math.PI * Radius * Radius;
        }
        public override void FindPerimeter()
        {
            this.Perimeter = 2 * Math.PI * Radius;
        }
        public override void MoveFigure(double X, double Y)
        {
            Center.CoordinateX=Center.CoordinateX+X;
            Center.CoordinateY=Center.CoordinateY+Y;
        }

        public override void ScaleFigure(double Scale)
        {
            Radius *= Scale;
            FindArea();
            FindPerimeter();
        }
        public override void RotateFigure(double Degree)
        {
            Console.WriteLine("No matter how you spin it, it's a circle");
        }
        
        public override void FindCenter()
        {
            Console.WriteLine("We already have ceneter coordinates");
        }
       /* public override string ToString()
        {
            return 
        }*/
    }
}
