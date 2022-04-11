using VectorAlgebra;

namespace GeometricFigures
{
    public abstract class MyGeometricFigure
    {
        public string? Name { get; set; }
        public Color Color { get; set; }
        public PointF Position { get; set; }
        public PointF[]? VerticesCoordinates;
        public PointF[]? GetVerticesCoordinates()
        {
            return VerticesCoordinates;
        }
        public static Color GetRandomColor(/*Color Color*/)
        {
            Random random = new Random();
            int R = random.Next(0, 256),
                G = random.Next(0, 256),
                B = random.Next(0, 256);

            return Color.FromArgb(R, G, B);
        }
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract PointF GetCenter();
        public abstract void DrawFigure(Graphics gr);
        public string? GetName()
        {
            return Name;
        }
        public virtual void GetInfo()
        {
            Console.WriteLine
            (
                $"Имя фигруры: { GetName() }\n" +
                $"Периметр: { GetPerimeter() }\n" +
                $"Площадь: { GetArea() }"
            );
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
            gr.DrawString(GetCenter().ToString(), new Font("Consolas", 10), Brushes.Black, new PointF(GetCenter().X, GetCenter().Y + 7.5F));
            gr.FillEllipse(Brushes.Red, GetCenter().X - 7.5F, GetCenter().Y - 7.5F, 15.0F, 15.0F);
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine
            (
                $"Радиус: R = { Radius }\n" +
                $"Координаты центра окружности: { Position }\n"
            );
        }
    }

    public class MyRegularPolygon : MyGeometricFigure
    {
        public double SideLength { get; set; }
        protected double NumberOfSides;
        protected double RotateAngle;
        // public double NumberOfSides;
        // protected double RotateAngle;

        public MyRegularPolygon()
        {
            VerticesCoordinates = new PointF[(long)NumberOfSides];
            SetCoordinatesOfTheVertices();
        }

        public MyRegularPolygon(double NumberOfSides, double SideLength, PointF Position) : base()
        {
            this.NumberOfSides = NumberOfSides;
            this.SideLength = SideLength;
            this.Position = Position;

            RotateAngle = (-1.0) * GetRotateAngle(this.NumberOfSides);

            VerticesCoordinates = new PointF[(long)this.NumberOfSides];
            SetCoordinatesOfTheVertices();

            Color = GetRandomColor(/*new Color()*/);
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
            return new PointF(Position.X, Position.Y);
        }

        public static double GetRotateAngle(double NumberOfSides)
        {
            if (NumberOfSides == 4.0)
            {
                return Math.PI * (1.0 - (NumberOfSides - 2.0) / NumberOfSides) * 1.0 / 2.0;
            }
            if (NumberOfSides % 2.0 == 0)
            {
                return Math.PI * (1.0 - (NumberOfSides - 2.0) / NumberOfSides) * 1.0 / 2.0;
            }

            return Math.PI * (1.0 - (NumberOfSides - 2.0) / NumberOfSides) * 1.0 / 4.0;
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
            gr.DrawPolygon(new Pen(Color, 3), GetVerticesCoordinates());
            gr.DrawString(GetCenter().ToString(), new Font("Consolas", 10), Brushes.Black, new PointF(GetCenter().X, GetCenter().Y + (float)GetCircumscribedCircleRadius()));
        }

        public PointF[]? GetVerticesCoordinates()
        {
            return VerticesCoordinates;
        }

        public string GetVerticesCoordinatesInfo()
        {
            string VerticesCoordinatesStr = "";

            foreach (PointF VertexCoordinates in VerticesCoordinates)
            {
                VerticesCoordinatesStr += " " + VertexCoordinates.ToString();
            }

            return VerticesCoordinatesStr;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine
            (
                $"Длина стороны: { SideLength }\n" +
                $"Радиус вписанной окружности: { GetInscribedCircleRadius() }\n" +
                $"Радиус описанной окружности: { GetCircumscribedCircleRadius() }\n" +
                $"Координаты вершин:{ GetVerticesCoordinatesInfo() }\n"
            );
        }
    }

    public class MyTriangle : MyGeometricFigure
    {
        public PointF A { get; set; }
        public PointF B { get; set; }
        public PointF C { get; set; }

        public double AB, BC, CA;

        public MyTriangle(PointF A, PointF B, PointF C)
        {
            this.A = A;
            this.B = B;
            this.C = C;

            VerticesCoordinates = new PointF[] { this.A, this.B, this.C };

            AB = MyVectorAlgebra.GetVectorLength(this.A, this.B);
            BC = MyVectorAlgebra.GetVectorLength(this.B, this.C);
            CA = MyVectorAlgebra.GetVectorLength(this.C, this.A);
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
            Position = new PointF()
            {
                X = (A.X + B.X + C.X) / 3.0F,
                Y = (A.Y + B.Y + C.Y) / 3.0F
            };
            return Position;
        }

        public override void DrawFigure(Graphics gr)
        {
            gr.DrawPolygon(new Pen(Color, 3), GetVerticesCoordinates());
            gr.DrawString(GetCenter().ToString(), new Font("Consolas", 10), Brushes.Black, new PointF(GetCenter().X, GetCenter().Y + (float)GetCircumscribedCircleRadius()));
            gr.FillEllipse(Brushes.Red, GetCenter().X - 7.5F, GetCenter().Y - 7.5F, 15.0F, 15.0F);
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine
            (
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

        public MyQuadrangle(PointF A, PointF B, PointF C, PointF D)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;

            VerticesCoordinates = new PointF[] { this.A, this.B, this.C, this.D };

            AB = MyVectorAlgebra.GetVectorLength(this.A, this.B);
            BC = MyVectorAlgebra.GetVectorLength(this.B, this.C);
            CD = MyVectorAlgebra.GetVectorLength(this.C, this.D);
            DA = MyVectorAlgebra.GetVectorLength(this.D, this.A);

            AngleAlpha = MyVectorAlgebra.GetAngleV(MyVectorAlgebra.GetVectorCoordinatesV(this.A, this.B), MyVectorAlgebra.GetVectorCoordinatesV(this.A, this.D));
            AngleBeta = MyVectorAlgebra.GetAngleV(MyVectorAlgebra.GetVectorCoordinatesV(this.C, this.B), MyVectorAlgebra.GetVectorCoordinatesV(this.C, this.D));
        }

        public override double GetArea()
        {
            double p = GetPerimeter() / 2.0;
            return Math.Sqrt((p - AB) * (p - BC) * (p - CD) * (p - DA) - AB * BC * CD * DA * Math.Pow(Math.Cos((AngleAlpha + AngleBeta) / 2.0), 2.0));
        }

        public override double GetPerimeter()
        {
            return AB + BC + CD + DA;
        }

        public override PointF GetCenter()
        {
            /*float[] X = new[] { A.X, B.X, C.X, D.X };
            float[] Y = new[] { A.Y, B.Y, C.Y, D.Y };
            float Area = 0.0F, TempX = 0.0F, TempY = 0.0F;*/
            PointF Barycenter;

            // Area = 0.5 * (A.X * B.Y + B.X * C.Y + C.X * D.Y + D.X * A.Y - B.X * A.Y + C.X * B.Y + D.X * C.Y + A.X * D.Y);

            // Формула площади многоугольника (Формула площади Гаусса)

            /*for (long i = 0; i < 3; i++)
            {
                Area += 0.5F * (X[i] * Y[i + 1] - X[i + 1] * Y[i]);
            }*/

            /*for (long i = 0; i < 3; i++)
            {
                TempX += 1.0F / (6.0F * Area) * (X[i] + X[i + 1]) * (X[i] * Y[i + 1] - X[i + 1] * Y[i]);
                TempY += 1.0F / (6.0F * Area) * (Y[i] + Y[i + 1]) * (X[i] * Y[i + 1] - X[i + 1] * Y[i]);
            }*/

            // float AreaTest = 0.5F * (A.X * B.Y + B.X * C.Y + C.X * D.Y + D.X * A.Y - B.X * A.Y - C.X * B.Y - D.X * C.Y - A.X * D.Y);

            /*for (long i = 0; i < 3; i++)
            {
                TempX += 1.0F / (6.0F * AreaTest) * (X[i] + X[i + 1]) * (X[i] * Y[i + 1] - X[i + 1] * Y[i]);
                TempY += 1.0F / (6.0F * AreaTest) * (Y[i] + Y[i + 1]) * (X[i] * Y[i + 1] - X[i + 1] * Y[i]);
            }*/

            /*Barycenter = new PointF()
            {
                X = TempX,
                Y = TempY
            };*/

            Barycenter = new PointF()
            {
                X = (A.X + B.X + C.X + D.X) / 4.0F,
                Y = (A.Y + B.Y + C.Y + D.Y) / 4.0F
            };

            return Barycenter;
        }

        public override void DrawFigure(Graphics gr)
        {
            gr.DrawPolygon(new Pen(Color, 3), GetVerticesCoordinates());
            gr.DrawString(GetCenter().ToString(), new Font("Consolas", 10), Brushes.Black, new PointF(GetCenter().X, GetCenter().Y + 7.5F));
            gr.FillEllipse(Brushes.Red, GetCenter().X - 7.5F, GetCenter().Y - 7.5F, 15.0F, 15.0F);
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine
            (
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
            gr.DrawString(GetCenter().ToString(), new Font("Consolas", 10), Brushes.Black, new PointF(GetCenter().X, GetCenter().Y + 7.5F));
            gr.FillEllipse(Brushes.Red, GetCenter().X - 7.5F, GetCenter().Y - 7.5F, 15.0F, 15.0F);
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine
            (
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

        public MyTrapeze(PointF A, PointF B, PointF C, PointF D) : base(A, B, C, D)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;

            VerticesCoordinates = new PointF[] { this.A, this.B, this.C, this.D };

            AB = MyVectorAlgebra.GetVectorLength(this.A, this.B);
            BC = MyVectorAlgebra.GetVectorLength(this.B, this.C);
            CD = MyVectorAlgebra.GetVectorLength(this.C, this.D);
            DA = MyVectorAlgebra.GetVectorLength(this.D, this.A);

            Height = DA * Math.Sin(MyVectorAlgebra.GetAngleV(MyVectorAlgebra.GetVectorCoordinatesV(this.A, this.B), MyVectorAlgebra.GetVectorCoordinatesV(this.A, this.D)));
        }

        public override double GetArea()
        {
            return (AB + CD) / 2.0 * Height;
        }

        /*public override PointF GetCenter()
        {
            PointF Barycenter;

            Barycenter = new PointF()
            {
                X = (A.X + B.X + C.X + D.X) / 4.0F,
                Y = (A.Y + B.Y + C.Y + D.Y) / 4.0F
            };

            return Barycenter;
        }*/

        /*public override void DrawFigure(Graphics gr)
        {
            gr.DrawPolygon(new Pen(Color, 3), GetVerticesCoordinates(VerticesCoordinates));
            gr.DrawString(GetCenter().ToString(), new Font("Consolas", 10), Brushes.Black, new PointF(GetCenter().X, GetCenter().Y + 7.5F));
        }*/

        public override void GetInfo()
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

        public MyParallelogram(PointF A, PointF B, PointF C, PointF D) : base(A, B, C, D)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;

            VerticesCoordinates = new PointF[] { this.A, this.B, this.C, this.D };

            AB = MyVectorAlgebra.GetVectorLength(this.A, this.B);
            BC = MyVectorAlgebra.GetVectorLength(this.B, this.C);
            CD = MyVectorAlgebra.GetVectorLength(this.C, this.D);
            DA = MyVectorAlgebra.GetVectorLength(this.D, this.A);

            Angle = MyVectorAlgebra.GetAngleV(MyVectorAlgebra.GetVectorCoordinatesV(this.A, this.B), MyVectorAlgebra.GetVectorCoordinatesV(this.A, this.D));
        }

        public override double GetArea()
        {
            return AB * DA * Math.Sin(MyVectorAlgebra.GetAngleV(MyVectorAlgebra.GetVectorCoordinatesV(A, B), MyVectorAlgebra.GetVectorCoordinatesV(A, D)));
        }

        /*public override void DrawFigure(Graphics gr)
        {
            gr.DrawPolygon(new Pen(Color, 3), GetVerticesCoordinates(VerticesCoordinates));
            gr.DrawString(GetCenter().ToString(), new Font("Consolas", 8), Brushes.Black, GetCenter());
        }*/

        public override void GetInfo()
        {
            Console.WriteLine
            (
                $"Имя фигруры: { GetName() }\n" +
                $"Периметр: { GetPerimeter() }\n" +
                $"Площадь: { GetArea() }\n" +
                $"Длины сторон: AB = CD = { AB }, BC = DA = { DA }\n" +
                $"Угол между сторонами AB и DA: { Angle * 180.0 / Math.PI}\n"
            );
        }
    }

    public class MyRhombus : MyParallelogram
    {
        public MyRhombus(PointF A, PointF B, PointF C, PointF D) : base(A, B, C, D)
        {
        }

        public override double GetArea()
        {
            return Math.Pow(AB, 2.0) * Math.Sin(MyVectorAlgebra.GetAngleV(MyVectorAlgebra.GetVectorCoordinatesV(A, B), MyVectorAlgebra.GetVectorCoordinatesV(A, D)));
        }

        public override void GetInfo()
        {
            Console.WriteLine
            (
                $"Имя фигруры: { GetName() }\n" +
                $"Периметр: { GetPerimeter() }\n" +
                $"Площадь: { GetArea() }\n" +
                $"Длина стороны: { AB }\n" +
                $"Угол между сторонами AB и DA: { Angle * 180.0 / Math.PI }\n"
            );
        }

    }

    public class MySquare : MyRegularPolygon
    {
        // protected override double NumberOfSides { get; } = 4.0;
        // protected override double RotateAngle { get; } = (-1.0) * Math.PI / 4.0;

        /*public MySquare()
        {
            NumberOfSides = 4.0;
            SetCoordinatesOfTheVertices();
        }*/
        public MySquare(double NumberOfSides, double SideLength, PointF Position) : base(NumberOfSides, SideLength, Position)
        {
        }
    }

    public class Pentagon : MyRegularPolygon
    {
        // protected override double NumberOfSides { get; } = 5.0;
        // protected override double RotateAngle { get; } = (-1.0) * Math.PI / 10.0;

        /*public Pentagon()
        {
            NumberOfSides = 5.0;
            SetCoordinatesOfTheVertices();
        }*/
        public Pentagon(double NumberOfSides, double SideLength, PointF Position) : base(NumberOfSides, SideLength, Position)
        {
        }
    }

    public class Hexagon : MyRegularPolygon
    {
        //protected override double NumberOfSides { get; } = 6.0;
        /*public Hexagon()
        {
            NumberOfSides = 6.0;
        }*/
        public Hexagon(double NumberOfSides, double SideLength, PointF Position) : base(NumberOfSides, SideLength, Position)
        {
        }
    }

    public class Heptagon : MyRegularPolygon
    {
        //protected override double NumberOfSides { get; } = 7.0;
        /*public Heptagon()
        {
            NumberOfSides = 7.0;
        }*/
        public Heptagon(double NumberOfSides, double SideLength, PointF Position) : base(NumberOfSides, SideLength, Position)
        {
        }
    }

    public class Octagon : MyRegularPolygon
    {
        //protected override double NumberOfSides { get; } = 8.0;
        /*public Octagon()
        {
            NumberOfSides = 8.0;
        }*/
        public Octagon(double NumberOfSides, double SideLength, PointF Position) : base(NumberOfSides, SideLength, Position)
        {
        }
    }

    public class Nonagon : MyRegularPolygon
    {
        //protected override double NumberOfSides { get; } = 9.0;
        /*public Nonagon()
        {
            NumberOfSides = 9.0;
        }*/
        public Nonagon(double NumberOfSides, double SideLength, PointF Position) : base(NumberOfSides, SideLength, Position)
        {
        }
    }

    public class Decagon : MyRegularPolygon
    {
        //protected override double NumberOfSides { get; } = 10.0;
        /*public Decagon()
        {
            NumberOfSides = 10.0;
        }*/
        public Decagon(double NumberOfSides, double SideLength, PointF Position) : base(NumberOfSides, SideLength, Position)
        {
        }
    }
}