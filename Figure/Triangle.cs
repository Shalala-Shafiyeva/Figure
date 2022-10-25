using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    internal class Triangle: Figure
    {
       
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(List<Point> Points) : base(Points) { }


        public override void FindArea()
        {
            double S=(SideA+SideB+SideC)/2;
            this.Area = Math.Sqrt(S * (S - SideA) * (S - SideB) * (S - SideC));
        }
        public override void FindPerimeter()
        {
            Perimeter=SideA+SideB+SideC;
        }
        public override void FindCenter()
        {
            double sumX = 0, sumY = 0;
            foreach (var p in Points)
            {
                sumX += p.CoordinateX;
                sumY += p.CoordinateY;
                Center = new Point(sumX / 3, sumY / 3);
            }
        }
        public override void MoveFigure(double X, double Y)
        {
            foreach (var p in Points)
            {
                p.CoordinateX += X;
                p.CoordinateY += Y;
            }
        }
        public override void ScaleFigure(double Scale)
        {
            SideA *= Scale;
            SideB *= Scale;
            SideC *= Scale;
            FindArea();
            FindPerimeter();
        }
        public override void RotateFigure(double Degree)
        {
            foreach (var p in Points)
            {
                p.CoordinateX += p.CoordinateX * Math.Cos(Degree) - p.CoordinateY * Math.Sin(Degree);
                p.CoordinateY += p.CoordinateY * Math.Cos(Degree) - p.CoordinateX * Math.Sin(Degree);

            }
        }
       /* public override string ToString()
        {

        }*/
    }
}
