using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricAreasHelper
{
    public abstract class GeometricalType
    {
        public double TotalArea { get; set; }
        public abstract void Area();
    }
    public class Rectangle : GeometricalType
    {
        private double length, width;
        public override void Area()
        {
            Console.WriteLine("Enter the Length for Rectangle");
            length = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the breadth for Rectangle");
            width = Convert.ToDouble(Console.ReadLine());
            TotalArea = length * width;
            Console.WriteLine($"Area of Rectangle of Length : {length} and Width : {width} is {TotalArea}");
        }
    }
    public class Square : GeometricalType
    {
        private double side;
        public override void Area()
        {
            Console.WriteLine("Enter side of square");
            side = Convert.ToDouble(Console.ReadLine());
            TotalArea = side*side;
            Console.WriteLine($"Area of Square of side : {side} is {TotalArea}");
        }
    }
    public class Circle : GeometricalType
    {
        private double radius;
        public override void Area()
        {
            Console.WriteLine("Enter radius of Circle");
            radius = Convert.ToDouble(Console.ReadLine());
            TotalArea = (float)(3.14 *radius*radius);
            Console.WriteLine($"Area of Circle of radius : {radius} is {TotalArea}");
        }
    }
    public class Triangle : GeometricalType
    {
        private double width, height;
        public override void Area()
        {
            Console.WriteLine("Enter base of Triangle");
            width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter height of Triangle");
            height = Convert.ToDouble(Console.ReadLine());
            TotalArea = (float)((0.5)*width*height);
            Console.WriteLine($"Area of Triangle of base : {width} and height : {height} is {TotalArea}");
        }
    }
}
