using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        abstract class Shape
        {
            protected int dim1, dim2;

            public Shape() { dim1 = dim2 = 0; }

            public Shape(int m) { dim1 = dim2 = m; }

            public Shape(int m, int n) { dim1 = m; dim2 = n; }

            public void SetD1(int m) { dim1 = m; }
            public void SetD2(int n) { dim2 = n; }
            public int GetD1() { return dim1; }
            public int GetD2() { return dim2; }

            public abstract float Area();
        }

        class Circle : Shape
        {
            public Circle() { }
            public Circle(int r) : base(r) { }
            public override float Area()
            { return (float)(3.14 * dim1 * dim2); }

        }
        class Rectangle : Shape
        {
            public Rectangle() { }
            public Rectangle(int l, int w) : base(l, w) { }
            public override float Area()
            { return (float)(1.0 * dim1 * dim2); }
        }
        class Triangle : Shape
        {
            public Triangle() { }
            public Triangle(int b, int h) : base(b, h) { }
            public override float Area()
            { return (float)(0.5 * dim1 * dim2); }
        }

        class Square : Rectangle
        {
            public Square() { }
            public Square(int s) : base(s, s) { }
        }

        class GeoShape
        {
            private Shape[] shapes;
            public GeoShape(params Shape[] arr)
            {
                shapes = arr;
            }
            public float TotalArea(params Shape[] arr)
            {
                float total = 0;
                foreach (Shape s in arr)
                {
                    total += s.Area();
                }
                return total;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Interactive Shape Area Calculator!");
            Console.WriteLine("------------------------------------------------");

            //ask user how many shapes
            Console.Write("Enter number of shapes: ");
            int n;
            do
            {
                Console.Write("Your number: ");
                n = int.Parse(Console.ReadLine());
            } while (n <= 0);

            Shape[] shapes = new Shape[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nEnter shape {i + 1} type:");
                Console.WriteLine("circle: 1");
                Console.WriteLine("rectangle: 2");
                Console.WriteLine("triangle: 3");
                Console.WriteLine("square: 4");
                Console.Write("Your choice: ");

                int type;
                do
                {
                    Console.Write("Your choice: ");
                    type = int.Parse(Console.ReadLine());
                } while (type < 1 || type > 4);


                switch (type)
                {
                    case 1:
                        Console.Write("Enter radius: ");
                        int r = int.Parse(Console.ReadLine());
                        shapes[i] = new Circle(r);
                        break;
                    case 2:
                        Console.Write("Enter length: ");
                        int l = int.Parse(Console.ReadLine());
                        Console.Write("Enter width: ");
                        int w = int.Parse(Console.ReadLine());
                        shapes[i] = new Rectangle(l, w);
                        break;
                    case 3:
                        Console.Write("Enter base: ");
                        int b = int.Parse(Console.ReadLine());
                        Console.Write("Enter height: ");
                        int h = int.Parse(Console.ReadLine());
                        shapes[i] = new Triangle(b, h);
                        break;
                    case 4:
                        Console.Write("Enter side length: ");
                        int s = int.Parse(Console.ReadLine());
                        shapes[i] = new Square(s);
                        break;
                }
            }
            GeoShape geo = new GeoShape(shapes);

            Console.WriteLine("\n------------------------------------------------");
            Console.WriteLine("Total Area: " + geo.TotalArea(shapes));
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
