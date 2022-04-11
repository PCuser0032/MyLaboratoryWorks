using GeometricFigures;

Console.WriteLine("Implementation of the polymorphism on the example of geometric shapes on C#.");
Console.WriteLine("Created by Kozlov D., group VPI-31.");

Console.WriteLine();

//MyRectangle Rectangle1 = new MyRectangle() { Name = "Прямоугольник ABCD", Width = 120.0, Height = 80.0, Color = Color.Red, Position = new Point(50, 50) };

MyGeometricFigure[] MyFigures = {
    new MyRegularPolygon(4.0, 75.0, new PointF(301.0F, 320.0F))
    {
        Name = "Квадрат ABCD"
    },
    new MyRegularPolygon(5.0, 100.0, new PointF(295.0F, 320.0F))
    {
        Name = "Пятиугольник ABCDE"
    },
    new MyRegularPolygon(6.0, 125.0, new PointF(295.0F, 320.0F))
    {
        Name = "Шестиугольник ABCDEF"
    },
    new MyRegularPolygon(7.0, 150.0, new PointF(315.0F, 315.0F))
    {
        Name = "Семиугольник ABCDEFG"
    },
    new MyRegularPolygon(8.0, 175.0, new PointF(335.0F, 335.0F))
    {
        Name = "Восьмиугольник ABCDEFGH"
    },
    new MyRegularPolygon(9.0, 200.0, new PointF(355.0F, 355.0F))
    {
        Name = "Девятиугольник ABCDEFGHI"
    },
    new MyRegularPolygon(10.0, 225.0, new PointF(375.0F, 375.0F))
    {
        Name = "Десятиугольник ABCDEFGHIJ"
    },
    new MyCircle()
    {
        Name = "Окружность O",
        Radius = 125.0,
        Position = new PointF(700.0F, 25.0F),
        Color = Color.Red
    },
    new MyTriangle(new PointF(951.254F, 25.7852F), new PointF(1220.45F,165.62475F), new PointF(1021.717F, 275.785F))
    {
        Name = "Треугольник ABC",
        Color = Color.Green
    },
    // new PointF(1200.0F, 25.0F), new PointF(1475.0F, 285.0F), new PointF(1820.0F, 275.0F), new PointF(1700.0F, 100.0F)
    // new PointF(1700.0F, 100.0F), new PointF(1820.0F, 275.0F), new PointF(1475.0F, 285.0F), new PointF(1200.0F, 25.0F)
    new MyQuadrangle(new PointF(1200.0F, 25.0F), new PointF(1475.0F, 285.0F), new PointF(1820.0F, 275.0F), new PointF(1700.0F, 100.0F))
    {
        Name = "Четырёхугольник ABCD",
        Color = Color.Purple
    },
    new MyRectangle()
    {
        Name = "Прямоугольник ABCD",
        Color = Color.DarkMagenta,
        Width = 400.0,
        Height = 250.0,
        Position = new PointF(800.1257F, 353.33F)
    },
    new MyTrapeze(new PointF(1875.0F, 575.0F), new PointF(1250.0F, 575.0F), new PointF(1355.0F, 325.0F), new PointF(1675.0F, 325.0F))
    {
        Name = "Трапеция ABCD",
        Color = Color.DeepSkyBlue
    },
    new MyParallelogram(new PointF(875.0F, 875.0F), new PointF(500.0F, 875.0F), new PointF(855.0F, 650.0F), new PointF(1175.0F, 650.0F))
    {
        Name = "Параллелограм ABCD",
        Color = Color.DarkSlateGray
    },
    new MyRhombus(new PointF(1400.0F, 850.0F), new PointF(1200.0F, 750.0F), new PointF(1400.0F, 650.0F), new PointF(1600.0F, 750.0F))
    {
        Name = "Ромб ABCD",
        Color = Color.Coral
    }
};

foreach (MyGeometricFigure Figure in MyFigures)
{
    Figure.GetInfo();
}

Form MyForm = new Form()
{
    BackColor = Color.FromArgb(255, 255, 255),
    Text = "Advanced Drawing Figures",
    Size = new Size(1920, 1080),
    StartPosition = FormStartPosition.CenterScreen
};

void FormPaint(object sender, PaintEventArgs e)
{
    foreach (MyGeometricFigure Figure in MyFigures)
    {
        Figure.DrawFigure(e.Graphics);
    }
}

MyForm.Paint += FormPaint;

Application.Run(MyForm);

/*Circle Circle1 = new Circle() { Name = "Окружность", Radius = 5.0 };

Triangle Triangle1 = new Triangle() { Name = "Треугольник ABC", AB = 3.0, BC = 4.0, CA = 5.0 };

Quadrangle Quadrangle1 = new Quadrangle() { Name = "Четырёхугольник ABCD", AB = 5.9, BC = 3.2, CD = 4.0, DA = 2.2, AngleAlpha = 127.0, AngleBeta = 68.5 };

Trapeze Trapeze1 = new Trapeze() { Name = "Трапеция ABCD", AB = 3.1875, CD = 9.25, Height = 7.4 };

Parallelogram Parallelogram1 = new Parallelogram() { Name = "Параллелограмм ABCD", AB = 81.0, DA = 11.75, Angle = 33.0 };

Rhombus Rhombus1 = new Rhombus() { Name = "Ромб ABCD", AB = 81.0, Angle = 13.31 };

Square Square1 = new Square() { Name = "Квадрат ABCD", SideLength = 19.716 };

Pentagon Pentagon1 = new Pentagon() { Name = "Правильный пятиугольник ABCDE", SideLength = 7.17 };

Hexagon Hexagon1 = new Hexagon() { Name = "Правильный шестиугольник ABCDEF", SideLength = 3.81254 };

Heptagon Heptagon1 = new Heptagon() { Name = "Правильный семиугольник ABCDEFG", SideLength = 21.3138 };

Octagon Octagon1 = new Octagon() { Name = "Правильный восьмиугольник ABCDEFGH", SideLength = 2.7890445 };

Nonagon Nonagon1 = new Nonagon() { Name = "Правильный девятиугольник ABCDEFGHI", SideLength = 743.568 };

Decagon Decagon1 = new Decagon() { Name = "Правильный десятиугольник ABCDEFGHIJ", SideLength = 1.734 };*/