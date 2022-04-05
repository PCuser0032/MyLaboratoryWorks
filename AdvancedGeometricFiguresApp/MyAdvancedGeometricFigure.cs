using System.Drawing;

namespace GeometricFigures
{
    public abstract class MyGeometricFigure
    {
        public string? Name { get; set; }
        public Color Color { get; set; }
        public Point Position { get; set; }
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract Point GetCenter();
        public string GetName()
        {
            return Name;
        }
    }

    public class Circle : MyGeometricFigure
    {
        public double Radius { get; set; }
        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2.0);
        }

        public override double GetPerimeter()
        {
            return 2.0 * Math.PI * Radius;
        }

        public override Point GetCenter()
        {
            return new Point((int)(Position.X + Radius), (int)(Position.Y + Radius));
        }

        public void GetInfo()
        {
            Console.WriteLine
            (
                $"Имя фигруры: { GetName() }\n" +
                $"Длина окружности: { GetPerimeter() }\n" +
                $"Площадь: { GetArea() }\n" +
                $"Радиус: R = { Radius }\n"
            );
        }
    }

    public class RegularPolygon : MyGeometricFigure
    {
        public double SideLength { get; set; }
        protected virtual double NumberOfSides { get; }
        // public double NumberOfSides;

        public override double GetArea()
        {
            return NumberOfSides / 4.0 * Math.Pow(SideLength, 2.0) * 1.0 / Math.Tan(Math.PI / NumberOfSides);
        }

        public override double GetPerimeter()
        {
            return NumberOfSides * SideLength;
        }
        public double GetInscribedCircleRadius()
        {
            return GetCircumscribedCircleRadius() * Math.Cos(Math.PI / NumberOfSides);
        }

        public double GetCircumscribedCircleRadius()
        {
            return SideLength * 1 / 2.0 * 1.0 / Math.Sin(Math.PI / NumberOfSides);
        }

        public override Point GetCenter()
        {
            return new Point((int)(Position.X + GetCircumscribedCircleRadius()), (int)(Position.Y + GetCircumscribedCircleRadius()));
        }

        public void GetInfo()
        {
            Console.WriteLine
            (
                $"Имя фигруры: { GetName() }\n" +
                $"Периметр: { GetPerimeter() }\n" +
                $"Площадь: { GetArea() }\n" +
                $"Длина стороны: { SideLength }\n" +
                $"Радиус вписанной окружности: { GetInscribedCircleRadius() }\n" +
                $"Радиус описанной окружности: { GetCircumscribedCircleRadius() }\n"
            );
        }
    }

    public class Triangle : MyGeometricFigure
    {
        public double AB { get; set; }
        public double BC { get; set; }
        public double CA { get; set; }

        public override double GetArea()
        {
            double p = GetPerimeter() / 2.0;
            return Math.Sqrt(p * (p - AB) * (p - BC) * (p - CA));
        }

        public override double GetPerimeter()
        {
            return AB + BC + CA;
        }

        public double GetInscribedCircleRadius()
        {
            return 1.0 / GetPerimeter() * GetArea();
        }

        public double GetCircumscribedCircleRadius()
        {
            return (AB * BC * CA) / (4.0 * GetArea());
        }

        public override Point GetCenter()
        {
            return new Point((int)(Position.X + GetCircumscribedCircleRadius()), (int)(Position.Y + GetCircumscribedCircleRadius()));
        }

        public void GetInfo()
        {
            Console.WriteLine
            (
                $"Имя фигруры: { GetName() }\n" +
                $"Периметр: { GetPerimeter() }\n" +
                $"Площадь: { GetArea() }\n" +
                $"Длины сторон: AB = { AB }, BC = { BC }, CA = { CA }\n"
            );
        }
    }

    public class Quadrangle : MyGeometricFigure
    {
        public double AB { get; set; }
        public double BC { get; set; }
        public double CD { get; set; }
        public double DA { get; set; }
        public double AngleAlpha { get; set; }
        public double AngleBeta { get; set; }

        public override double GetArea()
        {
            double p = GetPerimeter() / 2.0;
            return Math.Sqrt((p - AB) * (p - BC) * (p - CD) * (p - DA) - AB * BC * CD * DA * Math.Pow(Math.Cos(((AngleAlpha + AngleBeta) * Math.PI / 180.0) / 2.0), 2.0));
        }

        public override double GetPerimeter()
        {
            return AB + BC + CD + DA;
        }

        public override Point GetCenter()
        {
            return new (0, 0);
        }

        public void GetInfo()
        {
            Console.WriteLine
            (
                $"Имя фигруры: { GetName() }\n" +
                $"Периметр: { GetPerimeter() }\n" +
                $"Площадь: { GetArea() }\n" +
                $"Длины сторон: AB = { AB }, BC = { BC }, CD = { CD }, DA = { DA }\n" +
                $"Величины углов:  Alpha = { AngleAlpha }, Beta = { AngleBeta }\n"
            );
        }
    }

    public class Rectangle : MyGeometricFigure
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double GetArea()
        {
            return Width * Height;
        }

        public override double GetPerimeter()
        {
            return 2.0 * (Height + Width);
        }

        public override Point GetCenter()
        {
            return new Point((int)(Position.X + Width / 2), (int)(Position.Y + Height / 2));
        }

        public void GetInfo()
        {
            Console.WriteLine
            (
                $"Имя фигруры: { GetName() }\n" +
                $"Периметр: { GetPerimeter() }\n" +
                $"Площадь: { GetArea() }\n" +
                $"Длины сторон: AB = CD = { Width }, BC = DA = { Height }\n" +
                $"Цвет: { Color }\n" +
                $"Положение фигуры: { Position }\n" +
                $"Координаты центра: { GetCenter() }\n"
            );
        }
    }

    public class Trapeze : Quadrangle
    {
        public double Height { get; set; }

        public override double GetArea()
        {
            return (AB + CD) / 2.0 * Height;
        }

        public new void GetInfo()
        {
            Console.WriteLine
            (
                $"Имя фигруры: { GetName() }\n" +
                $"Периметр: { GetPerimeter() }\n" +
                $"Площадь: { GetArea() }\n" +
                $"Длины сторон: AB = { AB }, BC = { BC }, CD = { CD }, DA = { DA }\n" +
                $"Высота трапеции: h = { Height }\n"
            );
        }
    }

    public class Parallelogram : Quadrangle
    {
        public double Angle { get; set; }
        public override double GetArea()
        {
            return AB * DA * Math.Sin(Angle * Math.PI / 180.0);
        }

        public new void GetInfo()
        {
            Console.WriteLine
            (
                $"Имя фигруры: { GetName() }\n" +
                $"Периметр: { GetPerimeter() }\n" +
                $"Площадь: { GetArea() }\n" +
                $"Длины сторон: AB = CD = { AB }, BC = DA = { DA }\n" +
                $"Угол между сторонами AB и DA: { Angle }\n"
            );
        }
    }

    public class Rhombus : Parallelogram
    {
        public override double GetArea()
        {
            return Math.Pow(AB, 2.0) * Math.Sin(Angle * Math.PI / 180.0);
        }

        public override double GetPerimeter()
        {
            return 4.0 * AB;
        }
        public new void GetInfo()
        {
            Console.WriteLine
            (
                $"Имя фигруры: { GetName() }\n" +
                $"Периметр: { GetPerimeter() }\n" +
                $"Площадь: { GetArea() }\n" +
                $"Длина стороны: { AB }\n" +
                $"Угол между сторонами AB и DA: { Angle }\n"
            );
        }

    }

    public class Square : RegularPolygon
    {
        protected override double NumberOfSides { get; } = 4.0;
        /*public Square()
        {
            NumberOfSides = 4.0;
        }*/
    }

    public class Pentagon : RegularPolygon
    {
        protected override double NumberOfSides { get; } = 5.0;
        /*public Pentagon()
        {
            NumberOfSides = 5.0;
        }*/
    }

    public class Hexagon : RegularPolygon
    {
        protected override double NumberOfSides { get; } = 6.0;
        /*public Hexagon()
        {
            NumberOfSides = 6.0;
        }*/
    }

    public class Heptagon : RegularPolygon
    {
        protected override double NumberOfSides { get; } = 7.0;
        /*public Heptagon()
        {
            NumberOfSides = 7.0;
        }*/
    }

    public class Octagon : RegularPolygon
    {
        protected override double NumberOfSides { get; } = 8.0;
        /*public Octagon()
        {
            NumberOfSides = 8.0;
        }*/
    }

    public class Nonagon : RegularPolygon
    {
        protected override double NumberOfSides { get; } = 9.0;
        /*public Nonagon()
        {
            NumberOfSides = 9.0;
        }*/
    }

    public class Decagon : RegularPolygon
    {
        protected override double NumberOfSides { get; } = 10.0;
        /*public Decagon()
        {
            NumberOfSides = 10.0;
        }*/
    }
}