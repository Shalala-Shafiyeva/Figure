using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Figure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <Figure> figures = new List <Figure> ();
            Console.WriteLine("Please select one of the option:");
            Console.WriteLine("1. Show all figure\n " +
                              "2. Create a figure\n " +
                              "3. Change figure\n " +
                              "4. Save to file\n " +
                              "0. Exit");
            int Choice=Convert.ToInt32(Console.ReadLine());
           
            switch (Choice)
            {
                case 0: 
                    Environment.Exit(0);
                    break;
                case 1:
                    foreach (var figure in figures)
                    {
                        figure.FindArea();
                        figure.FindPerimeter();
                        figure.FindCenter();    
                    };
                    break;
                case 2:
                    Console.WriteLine("Please select one of the figure:");
                    Console.WriteLine("1. Circle \n" +
                                     " 2. Rectangle \n 3." +
                                     " 3. Triangle \n");
                    int ChoiceofFigure=Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Input coordinates");
                    List<Point> newPoints = new List<Point>();
                    string pointsStr = Console.ReadLine();
                    string[] points = pointsStr.Split(',');
                    foreach (var item in points)
                    {
                        string[] pointStr = item.Split(':');
                        Point newPoint = new Point(Convert.ToDouble(pointStr[0]), Convert.ToDouble(pointStr[1]));
                        newPoints.Add(newPoint);
                    }
                    switch (ChoiceofFigure)
                    {
                        case 1:

                            break;
                        case 2:
                            
                            
                            Rectangle newRectangle = new Rectangle(newPoints);

                            break;
                    }
                    break;
            }
        }
    }
}
