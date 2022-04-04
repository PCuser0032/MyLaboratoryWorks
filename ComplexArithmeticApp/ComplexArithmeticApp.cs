using MyComplexArithmetic;
using MyFormatOutput;

Console.WriteLine("Complex number arithmetic implementation on C#.");
Console.WriteLine("Created by Kozlov D., group VPI-31.");

Console.WriteLine();

// MyComplex a = new MyComplex() { Re = 3.0, Im = 7.0 };

MyComplex a = new() { Re = 3.0, Im = 7.0 };
MyComplex b = new() { Re = 2.0, Im = 3.0 };
MyComplex c = new() { Re = 20.0, Im = 47.0 };
MyComplex d = new() { Re = 4.0, Im = 11.0 };
MyComplex e = new() { Re = 15.78, Im = 91.14 };
MyComplex f = new() { Re = 7.78541, Im = 53.917 };

// Console.Write("a Addition b : "); MyFormat.GetResult(MyComplex.Add(a, b));
Console.WriteLine($"a Addition b : { MyComplex.Add(a, b).GetResult() }");

// Console.Write("a Subtract b : "); MyFormat.GetResultVoid(MyComplex.Subtract(a, b));
Console.WriteLine($"a Subtract b : { MyComplex.Subtract(a, b).GetResult() }");

// Console.Write("a Multiply b : "); MyFormat.GetResultVoid(MyComplex.Multiply(a, b));
Console.WriteLine($"a Multiply b : { MyComplex.Multiply(a, b).GetResult() }");

// Console.Write("a Divide b : "); MyFormat.GetResultVoid(MyComplex.Divide(a, b));
Console.WriteLine($"a Divide b : { MyComplex.Divide(a, b).GetResult() }");

// Console.WriteLine("c addition d : " + MyFormat.GetResultStr(MyComplex.Add(c, d)));

Console.WriteLine();

Console.WriteLine($"c Addition d : { MyComplex.Add(c, d).GetResult() }");

Console.WriteLine($"c Subtract d : { MyComplex.Subtract(c, d).GetResult() }");

Console.WriteLine($"c Multiply d : { MyComplex.Multiply(c, d).GetResult() }");

Console.WriteLine($"c Divide d : { MyComplex.Divide(c, d).GetResult() }");

Console.WriteLine();

Console.Write($"e Addition f : "); MyFormat.GetResultVoid(MyComplex.Add(e, f));

Console.Write($"f Subtract e : "); MyFormat.GetResultVoid(MyComplex.Subtract(f, e));

Console.Write($"e Multiply f : "); MyFormat.GetResultVoid(MyComplex.Multiply(e, f));

Console.Write($"f Divide e : "); MyFormat.GetResultVoid(MyComplex.Divide(f, e));