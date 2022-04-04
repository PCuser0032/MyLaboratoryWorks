using GeometricFigures;

Console.WriteLine("Implementation of the inheritance mechanism on the example of geometric shapes on C#.");
Console.WriteLine("Created by Kozlov D., group VPI-31.");

Console.WriteLine();

Circle Circle1 = new Circle() { Name = "Окружность", Radius = 5.0 };
Circle1.GetInfo();

Triangle Triangle1 = new Triangle() { Name = "Треугольник ABC", AB = 3.0, BC = 4.0, CA = 5.0 };
Triangle1.GetInfo();

Quadrangle Quadrangle1 = new Quadrangle() { Name = "Четырёхугольник ABCD", AB = 5.9, BC = 3.2, CD = 4.0, DA = 2.2, AngleAlpha = 127.0, AngleBeta = 68.5 };
Quadrangle1.GetInfo();

Rectangle Rectangle1 = new Rectangle() { Name = "Прямоугольник ABCD", Width = 17.0, Height = 3.0 };
Rectangle1.GetInfo();

Trapeze Trapeze1 = new Trapeze() { Name = "Трапеция ABCD", AB = 3.1875, CD = 9.25, Height = 7.4 };
Trapeze1.GetInfo();

Parallelogram Parallelogram1 = new Parallelogram() { Name = "Параллелограмм ABCD", AB = 81.0, DA = 11.75, Angle = 33.0 };
Parallelogram1.GetInfo();

Rhombus Rhombus1 = new Rhombus() { Name = "Ромб ABCD", AB = 81.0, Angle = 13.31 };
Rhombus1.GetInfo();

Square Square1 = new Square() { Name = "Квадрат ABCD", SideLength = 19.716 };
Square1.GetInfo();

Pentagon Pentagon1 = new Pentagon() { Name = "Правильный пятиугольник ABCDE", SideLength = 7.17 };
Pentagon1.GetInfo();

Hexagon Hexagon1 = new Hexagon() { Name = "Правильный шестиугольник ABCDEF", SideLength = 3.81254 };
Hexagon1.GetInfo();

Heptagon Heptagon1 = new Heptagon() { Name = "Правильный семиугольник ABCDEFG", SideLength = 21.3138 };
Heptagon1.GetInfo();

Octagon Octagon1 = new Octagon() { Name = "Правильный восьмиугольник ABCDEFGH", SideLength = 2.7890445 };
Octagon1.GetInfo();

Nonagon Nonagon1 = new Nonagon() { Name = "Правильный девятиугольник ABCDEFGHI", SideLength = 743.568 };
Nonagon1.GetInfo();

Decagon Decagon1 = new Decagon() { Name = "Правильный десятиугольник ABCDEFGHIJ", SideLength = 1.734 };
Decagon1.GetInfo();