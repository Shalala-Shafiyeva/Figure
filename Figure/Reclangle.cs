using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    [Serializable()]
    internal class Rectangle : Figure
    {
      
        public double SideA { get; set; }
        public double SideB { get; set; }
        public Rectangle (List<Point> Points) : base(Points) { }
        public void FindSides()
        {
            double lengthX, lengthY;
            lengthX = Points[0].CoordinateX - Points[1].CoordinateX;
            lengthY = Points[0].CoordinateY - Points[1].CoordinateY;
            SideA = Math.Sqrt((lengthX * lengthX) + (lengthY * lengthY));

            lengthX = Points[2].CoordinateX - Points[1].CoordinateX;
            lengthY = Points[2].CoordinateY - Points[1].CoordinateY;
            SideB = Math.Sqrt((lengthX * lengthX) + (lengthY * lengthY));
        }
        public override void FindArea()
        {
            
            FindSides();
            Area = SideA * SideB;
        }
        public override void FindPerimeter()
        {
           
            FindSides();
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
            return $"{nameof(Rectangle)} Sides: {SideA},{SideB}  Area:{Area} Perimeter:{Perimeter}";   
        }

        public override string ToFileString()
        {
            return $"{nameof(Circle)} Points: {this.Points[0]}, {this.Points[1]}, {this.Points[2]}, {this.Points[3]}; Area: {Area} Perimeter:{Perimeter} Center: {Points[0].CoordinateX}, {Points[0].CoordinateY}";
        }
    }
}
