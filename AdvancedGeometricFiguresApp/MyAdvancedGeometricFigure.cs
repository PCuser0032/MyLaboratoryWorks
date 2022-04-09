using VectorAlgebra;

namespace GeometricFigures
{
    public abstract class MyGeometricFigure
    {
        public string? Name { get; set; }
        public Color Color { get; set; }
        public PointF Position { get; set; }
        public PointF[]? VerticesCoordinates;
        public static PointF[] GetVerticesCoordinates(PointF[] VerticesCoordinates)
        {
            return VerticesCoordinates;
        }
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract PointF GetCenter();
        public abstract void DrawFigure(Graphics gr);
        public string? GetName()
        {
            return Name;
        }
    }

    public class MyCircle : MyGeometricFigure
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

        public override PointF GetCenter()
        {
            return new PointF((float)(Position.X + Radius), (float)(Position.Y + Radius));
        }

        public override void DrawFigure(Graphics gr)
        {
            gr.DrawEllipse(new Pen(Color, 3), new RectangleF((float)Position.X, (float)Position.Y, (float)(2.0 * Radius), (float)(2.0 * Radius)));
            gr.DrawString(GetCenter().ToString(), new Font("Consolas", 10), Brushes.Black, GetCenter());
        }

        public void GetInfo()
        {
            Console.WriteLine
            (
                $"Имя фигруры: { GetName() }\n" +
                $"Длина окружности: { GetPerimeter() }\n" +
                $"Площадь: { GetArea() }\n" +
                $"Радиус: R = { Radius }\n" +
                $"Координаты центра окружности: { Position }\n"
            );
        }
    }

    public class MyRegularPolygon : MyGeometricFigure
    {
        public double SideLength { get; set; }
        protected virtual double NumberOfSides { get; }
        protected virtual double RotateAngle { get; }
        // public double NumberOfSides;
        // protected double NumberOfSides;

        public MyRegularPolygon()
        {
            VerticesCoordinates = new PointF[(int)NumberOfSides];
        }

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

        public override PointF GetCenter()
        {
            return new PointF((float)(Position.X + GetCircumscribedCircleRadius()), (float)(Position.Y + GetCircumscribedCircleRadius()));
        }

        public void SetCoordinatesOfTheVertices()
        {
            for (long i = 0; i < NumberOfSides; i++)
            {
                VerticesCoordinates[i].X = (float)(Position.X + GetCircumscribedCircleRadius() * Math.Cos(RotateAngle + 2.0 * Math.PI / NumberOfSides * i));
                VerticesCoordinates[i].Y = (float)(Position.Y + GetCircumscribedCircleRadius() * Math.Sin(RotateAngle + 2.0 * Math.PI / NumberOfSides * i));
            }
        }

        public override void DrawFigure(Graphics gr)
        {
            SetCoordinatesOfTheVertices();
            gr.DrawPolygon(new Pen(Color, 3), GetVerticesCoordinates(VerticesCoordinates));
            gr.DrawString(GetCenter().ToString(), new Font("Consolas", 10), Brushes.Black, GetCenter());
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
                $"Радиус описанной окружности: { GetCircumscribedCircleRadius() }\n" +
                $"Координаты вершин: { GetVerticesCoordinates(VerticesCoordinates) }\n"
            );
        }
    }

    public class MyTriangle : MyGeometricFigure
    {
        public PointF A { get; set; }
        public PointF B { get; set; }
        public PointF C { get; set; }

        public double AB, BC, CA;

        public MyTriangle()
        {
            VerticesCoordinates = new PointF[] { A, B, C };

            AB = MyVectorAlgebra.GetVectorLength(A, B);
            BC = MyVectorAlgebra.GetVectorLength(B, C);
            CA = MyVectorAlgebra.GetVectorLength(C, A);
        }

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

        public override PointF GetCenter()
        {
            return new PointF((float)(Position.X + GetCircumscribedCircleRadius()), (float)(Position.Y + GetCircumscribedCircleRadius()));
        }

        public override void DrawFigure(Graphics gr)
        {
            gr.DrawPolygon(new Pen(Color, 3), GetVerticesCoordinates(VerticesCoordinates));
            gr.DrawString(GetCenter().ToString(), new Font("Consolas", 10), Brushes.Black, GetCenter());
        }

        public void GetInfo()
        {
            Console.WriteLine
            (
                $"Имя фигруры: { GetName() }\n" +
                $"Периметр: { GetPerimeter() }\n" +
                $"Площадь: { GetArea() }\n" +
                $"Длины сторон: AB = { AB }, BC = { BC }, CA = { CA }\n" +
                $"Координаты вершин: A{ A }, B{ B }, C{ C }\n"
            );
        }
    }

    public class MyQuadrangle : MyGeometricFigure
    {
        public PointF A { get; set; }
        public PointF B { get; set; }
        public PointF C { get; set; }
        public PointF D { get; set; }

        public double AB, BC, CD, DA;
        public double AngleAlpha, AngleBeta;

        public MyQuadrangle()
        {
            VerticesCoordinates = new PointF[] { A, B, C, D };

            AB = MyVectorAlgebra.GetVectorLength(A, B);
            BC = MyVectorAlgebra.GetVectorLength(B, C);
            CD = MyVectorAlgebra.GetVectorLength(C, D);
            DA = MyVectorAlgebra.GetVectorLength(D, A);

            AngleAlpha = MyVectorAlgebra.GetAngleV(MyVectorAlgebra.GetVectorCoordinatesV(A, B), MyVectorAlgebra.GetVectorCoordinatesV(A, D));
            AngleBeta = MyVectorAlgebra.GetAngleV(MyVectorAlgebra.GetVectorCoordinatesV(C, B), MyVectorAlgebra.GetVectorCoordinatesV(C, D));
        }

        public override double GetArea()
        {
            double p = GetPerimeter() / 2.0;
            return Math.Sqrt((p - AB) * (p - BC) * (p - CD) * (p - DA) - AB * BC * CD * DA * Math.Pow(Math.Cos(((AngleAlpha + AngleBeta) * Math.PI / 180.0) / 2.0), 2.0));
        }

        public override double GetPerimeter()
        {
            return AB + BC + CD + DA;
        }

        public override PointF GetCenter()
        {
            return new (0, 0);
        }

        public override void DrawFigure(Graphics gr)
        {
            gr.DrawPolygon(new Pen(Color, 3), GetVerticesCoordinates(VerticesCoordinates));
            gr.DrawString(GetCenter().ToString(), new Font("Consolas", 10), Brushes.Black, GetCenter());
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

    public class MyRectangle : MyGeometricFigure
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

        public override PointF GetCenter()
        {
            return new PointF((float)(Position.X + Width / 2.0), (float)(Position.Y + Height / 2.0));
        }

        public override void DrawFigure(Graphics gr)
        {
            gr.DrawRectangle(new Pen(Color, 3), (float)Position.X, (float)Position.Y, (float)Width, (float)Height);
            gr.DrawString(GetCenter().ToString(), new Font("Consolas", 10), Brushes.Black, GetCenter());
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

    public class MyTrapeze : MyQuadrangle
    {
        public double Height { get; set; }

        public MyTrapeze()
        {
            VerticesCoordinates = new PointF[] { A, B, C, D };

            AB = MyVectorAlgebra.GetVectorLength(A, B);
            BC = MyVectorAlgebra.GetVectorLength(B, C);
            CD = MyVectorAlgebra.GetVectorLength(C, D);
            DA = MyVectorAlgebra.GetVectorLength(D, A);

            Height = DA * Math.Sin(MyVectorAlgebra.GetAngleV(MyVectorAlgebra.GetVectorCoordinatesV(A, B), MyVectorAlgebra.GetVectorCoordinatesV(A, D)));
        }

        public override double GetArea()
        {
            return (AB + CD) / 2.0 * Height;
        }

        public override void DrawFigure(Graphics gr)
        {
            gr.DrawPolygon(new Pen(Color, 3), GetVerticesCoordinates(VerticesCoordinates));
            gr.DrawString(GetCenter().ToString(), new Font("Consolas", 10), Brushes.Black, GetCenter());
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

    public class MyParallelogram : MyQuadrangle
    {
        public double Angle { get; set; }
        public override double GetArea()
        {
            return AB * DA * Math.Sin(MyVectorAlgebra.GetAngleV(MyVectorAlgebra.GetVectorCoordinatesV(A, B), MyVectorAlgebra.GetVectorCoordinatesV(A, D)));
        }

        /*public override void DrawFigure(Graphics gr)
        {
            gr.DrawPolygon(new Pen(Color, 3), GetVerticesCoordinates(VerticesCoordinates));
            gr.DrawString(GetCenter().ToString(), new Font("Consolas", 8), Brushes.Black, GetCenter());
        }*/

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

    public class MyRhombus : MyParallelogram
    {
        public override double GetArea()
        {
            return Math.Pow(AB, 2.0) * Math.Sin(MyVectorAlgebra.GetAngleV(MyVectorAlgebra.GetVectorCoordinatesV(A, B), MyVectorAlgebra.GetVectorCoordinatesV(A, D)));
        }

        /*public override double GetPerimeter()
        {
            return 4.0 * AB;
        }*/
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

    public class MySquare : MyRegularPolygon
    {
        protected override double NumberOfSides { get; } = 4.0;
        protected override double RotateAngle { get; } = (-1.0) * Math.PI / 4.0;
        /*public MySquare()
        {
            NumberOfSides = 4.0;
        }*/
    }

    public class Pentagon : MyRegularPolygon
    {
        protected override double NumberOfSides { get; } = 5.0;
        protected override double RotateAngle { get; } = (-1.0) * Math.PI / 10.0;
        /*public Pentagon()
        {
            NumberOfSides = 5.0;
        }*/
    }

    public class Hexagon : MyRegularPolygon
    {
        protected override double NumberOfSides { get; } = 6.0;
        /*public Hexagon()
        {
            NumberOfSides = 6.0;
        }*/
    }

    public class Heptagon : MyRegularPolygon
    {
        protected override double NumberOfSides { get; } = 7.0;
        /*public Heptagon()
        {
            NumberOfSides = 7.0;
        }*/
    }

    public class Octagon : MyRegularPolygon
    {
        protected override double NumberOfSides { get; } = 8.0;
        /*public Octagon()
        {
            NumberOfSides = 8.0;
        }*/
    }

    public class Nonagon : MyRegularPolygon
    {
        protected override double NumberOfSides { get; } = 9.0;
        /*public Nonagon()
        {
            NumberOfSides = 9.0;
        }*/
    }

    public class Decagon : MyRegularPolygon
    {
        protected override double NumberOfSides { get; } = 10.0;
        /*public Decagon()
        {
            NumberOfSides = 10.0;
        }*/
    }
}