using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    internal abstract class Figure 
    {
        public double Area { get; protected set; }
        public double Perimeter { get; protected set; }
        public List<Point> Points { get; protected set; }
        public Point Center { get; protected set; }
        public Figure(List<Point> Points)
        {
            this.Points = Points;
            this.FindCenter();
            this.FindArea();
            this.FindPerimeter();
            
        }
        public abstract void FindArea();
        public abstract void FindPerimeter();
        public abstract void FindCenter();
        public abstract void MoveFigure(double X, double Y);
        public abstract void RotateFigure(double Degree);
        public abstract void ScaleFigure(double Scale);
        public abstract override string ToString();
        
    }
}
