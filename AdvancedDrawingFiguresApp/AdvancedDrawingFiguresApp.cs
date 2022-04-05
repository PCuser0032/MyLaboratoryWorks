using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometricFigures;
using System.Windows.Forms;

namespace AdvancedDrawingFiguresApp
{
    class AdvancedDrawingFiguresApp
    {
        public static MyGeometricFigure[] MyFigures = {
            new Rectangle() {
                Name = "Прямоугольник ABCD",
                Width = 120.0,
                Height = 80.0,
                Color = System.Drawing.Color.Red,
                Position = new System.Drawing.Point(50, 50)
            },
            new Rectangle() {
                Name = "Прямоугольник EFGH",
                Width = 55.0,
                Height = 25.0,
                Color = System.Drawing.Color.Green,
                Position = new System.Drawing.Point(70, 80)
            },
            new Rectangle() {
                Name = "Прямоугольник IJKL",
                Width = 225.0,
                Height = 105.0,
                Color = System.Drawing.Color.Purple,
                Position = new System.Drawing.Point(105, 200)
            }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Implementation of the polymorphism on the example of geometric shapes on C#.");
            Console.WriteLine("Created by Kozlov D., group VPI-31.");

            Console.WriteLine();

            Form MyForm = new Form()
            {
                Text = "Advanced Drawing Figures",
                Size = new System.Drawing.Size(800, 800),
                StartPosition = FormStartPosition.CenterScreen
            };

            MyForm.Paint += FormPaint;

            Application.Run(MyForm);
        }

        public static void FormPaint(object sender, PaintEventArgs e)
        {
            foreach (MyGeometricFigure Figure in MyFigures)
            {
                Figure.DrawFigure(e.Graphics);
            }
        }
    }
}
