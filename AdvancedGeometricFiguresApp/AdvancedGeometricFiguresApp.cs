using GeometricFigures;

Console.WriteLine("Implementation of the polymorphism on the example of geometric shapes on C#.");
Console.WriteLine("Created by Kozlov D., group VPI-31.");

Console.WriteLine();

MyRectangle Rectangle1 = new MyRectangle() { Name = "Прямоугольник ABCD", Width = 120.0, Height = 80.0, Color = Color.Red, Position = new Point(50, 50) };

MyGeometricFigure[] MyFigures = {
    new MyRectangle() {
    Name = "Прямоугольник ABCD",
    Width = 120.0,
    Height = 80.0,
    Color = Color.Red,
    Position = new Point(50, 50)
    },
    new MyRectangle() {
        Name = "Прямоугольник EFGH",
        Width = 55.0,
        Height = 25.0,
        Color = Color.Green,
        Position = new Point(50, 100)
    },
    new MyRectangle() {
        Name = "Прямоугольник IJKL",
        Width = 225.0,
        Height = 105.0,
        Color = Color.Purple,
        Position = new Point(50, 150)
    }
};

Form MyForm = new Form()
{
    BackColor = Color.FromArgb(156, 156, 156),
    Text = "Advanced Drawing Figures",
    Size = new Size(800, 800),
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