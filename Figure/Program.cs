using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
            /* List <Figure> figures = new List <Figure> ();
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
             }*/

            List<Figure> figures = new List<Figure>();
           // static void Initialize() { 
            Triangle tr1 = new Triangle(new List<Point>()
            {
                new Point(0, 0),
                new Point(3, 0),
                new Point(0, 4)
            });
            figures.Add(tr1);

            Rectangle rec1 = new Rectangle(new List<Point>()
            {
                new Point(0, 0),
                new Point(3, 0),
                new Point(0, 5),
                new Point(3, 5)
            });
            figures.Add(rec1);

            Circle cir1 = new Circle(new List<Point>()
            {
                new Point(0,0),
              new Point(5,0)
            });
            figures.Add(cir1);

            string path = @"C:\Users\User\Desktop\Figure.txt";

            //using var st = new StreamWriter(path);

            while (true)
            {
                Console.WriteLine("Please select one of the following option: ");
                Console.WriteLine("1. Show all figure\n " +
                              "2. Create a figure\n " +
                              "3. Change figure\n " +
                              "4. Save to file\n " +
                              "0. Exit");
                int Choice = Convert.ToInt32(Console.ReadLine());

                switch (Choice)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        ShowAllFigures(figures);
                        break;
                    case 2:
                        CreateFigure(figures);
                        break;
                    case 3:
                        ChangeFigure(figures);
                        break;
                    case 4:
                        SaveToFile(path, figures);
                        /*string txt;
                        while ((txt = st.ReadLine()) != null)
                        {
                            Console.WriteLine(txt);
                        }*/
                        break;
                    default:
                        Console.WriteLine("Please input correct option!");
                        break;
                }
            }
        }

        private static void SaveToFile(string path, List<Figure> figures)
        {
            using var sw = new StreamWriter(path, true);
            foreach (var line in figures)
            {
                sw.WriteAsync(line.ToString());
            }
        }

        private static void ShowAllFigures(List<Figure> figures)
        {
            foreach (var fig in figures)
            {
                fig.FindCenter();
                fig.FindArea();
                fig.FindPerimeter();
                Console.WriteLine(fig.ToString());
            }
        }

        private static void CreateFigure(List<Figure> figures)
        {
            Console.WriteLine("Please Select Figure:");
            Console.WriteLine("1. Triagle\n" +
                              "2. Rectangle\n" +
                              "3. Circle");
            int choi = Convert.ToInt32(Console.ReadLine());
            switch (choi)
            {
                case 1:
                    figures.Add(CreateTriangle());
                    break;
                case 2:
                    figures.Add(CreateRectangle());
                    break;
                case 3:
                    figures.Add(CreateCircle());
                    break;
                default:
                    Console.WriteLine("Please input correct option!");
                    break;

            }
        }

        private static void ChangeFigure(List<Figure> figures)
        {
            Console.WriteLine("Please select figure which one you want to change: ");
            int figchoi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please select one of the following option to change figure: ");
            Console.WriteLine("1. Move figure\n " +
                          "2. Rotate figure\n " +
                          "3. Scale figure\n ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Please input coordinates:");
                    double x = Convert.ToDouble(Console.ReadLine());
                    double y = Convert.ToDouble(Console.ReadLine());
                    figures[figchoi - 1].MoveFigure(x, y);
                    break;
                case 2:
                    Console.WriteLine("Please input angle:");
                    double degree = Convert.ToDouble(Console.ReadLine());
                    figures[figchoi - 1].RotateFigure(degree);
                    break;
                case 3:
                    Console.WriteLine("Please input scale:");
                    double scale = Convert.ToDouble(Console.ReadLine());
                    figures[figchoi - 1].ScaleFigure(scale);
                    break;
                default:
                    break;
            }

        }

        private static Triangle CreateTriangle()
        {
            Console.WriteLine("Please input coordinates:");
            Console.WriteLine("Coordinates of first angle:");
            double x1 = Convert.ToDouble(Console.ReadLine());
            double y1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Coordinates of second angle:");
            double x2 = Convert.ToDouble(Console.ReadLine());
            double y2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Coordinates of third angle:");
            double x3 = Convert.ToDouble(Console.ReadLine());
            double y3 = Convert.ToDouble(Console.ReadLine());
            Triangle triangle = new Triangle(new List<Point>()
                    {
                    new Point(x1, y1),
                    new Point(x2, y2),
                    new Point(x3, y3)
                    });
            return triangle;
        }

        private static Rectangle CreateRectangle()
        {
            Console.WriteLine("Please input coordinates:");
            Console.WriteLine("Coordinates of first angle:");
            double x1 = Convert.ToDouble(Console.ReadLine());
            double y1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Coordinates of second angle:");
            double x2 = Convert.ToDouble(Console.ReadLine());
            double y2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Coordinates of third angle:");
            double x3 = Convert.ToDouble(Console.ReadLine());
            double y3 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Coordinates of fourth angle:");
            double x4 = Convert.ToDouble(Console.ReadLine());
            double y4 = Convert.ToDouble(Console.ReadLine());
            Rectangle rectangle = new Rectangle(new List<Point>()
                    {
                    new Point(x1, y1),
                    new Point(x2, y2),
                    new Point(x3, y3),
                    new Point(x4, y4)
                    });
            return rectangle;
        }

        private static Circle CreateCircle()
        {
            Console.WriteLine("Please input coordinates:");
            Console.WriteLine("Coordinates of center:");
            double x1 = Convert.ToDouble(Console.ReadLine());
            double y1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Coordinates of point on circle:");
            double x2 = Convert.ToDouble(Console.ReadLine());
            double y2 = Convert.ToDouble(Console.ReadLine());
            Circle circle = new Circle(new List<Point>()
                    {
                    new Point(x1, y1),
                    new Point(x2, y2)
                    });
            return circle;
        }

    } 
}