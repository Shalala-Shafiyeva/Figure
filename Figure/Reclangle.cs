using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    internal class Rectangle : Figure
    {
      
        public double SideA { get; set; }
        public double SideB { get; set; }
        public Rectangle (List<Point> Points) : base(Points) { }
        public void FindSides(out double SideA, out double SideB)
        {
            SideA= Math.Sqrt((Points[0].CoordinateX - Points[1].CoordinateX) * (Points[0].CoordinateX - Points[1].CoordinateX)
                + (Points[0].CoordinateY - Points[1].CoordinateY) * (Points[0].CoordinateY - Points[1].CoordinateY));
            SideB = Math.Sqrt((Points[3].CoordinateX - Points[2].CoordinateX) * (Points[3].CoordinateX - Points[2].CoordinateX)
                + (Points[3].CoordinateY - Points[2].CoordinateY) * (Points[3].CoordinateY - Points[2].CoordinateY));
        }
        public override void FindArea()
        {
            double SideA, SideB;
            FindSides(out SideA, out SideB);
            Area = SideA * SideB;
        }
        public override void FindPerimeter()
        {
            double SideA, SideB;
            FindSides(out SideA, out SideB);
            Perimeter = (SideA + SideB) * 2;
        }

        public override void FindCenter()
        {
            double sumX = 0, sumY = 0;
            foreach(var p in Points)
            {
                sumX+=p.CoordinateX;
                sumY+=p.CoordinateY;
                Center=new Point (sumX/4, sumY/4);
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
        public override void RotateFigure(double Degree)
        {
            foreach (var p in Points)
            {
                p.CoordinateX += p.CoordinateX*Math.Cos(Degree)-p.CoordinateY*Math.Sin(Degree);
                p.CoordinateY += p.CoordinateY*Math.Cos(Degree)-p.CoordinateX*Math.Sin(Degree);
               
            }
        }
        public override void ScaleFigure(double Scale)
        {
            SideA *= Scale;
            SideB *= Scale;
            FindArea();
            FindPerimeter();
        }
        public override string ToString()
        {
            return $"{nameof(Rectangle)} Sides: {SideA},{SideB} Area: {Area} Perimeter: {Perimeter}";   
        }
    }
}
