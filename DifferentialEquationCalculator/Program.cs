using DifferentialEquationCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifferentialEquationCalculator
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            float Function(float x, float y) => (float) Math.Sin(x) - 2 * y;
            MathFunction mathFunction = new MathFunction(Function);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(mathFunction));
            AdamsMethod eulerMethod = new AdamsMethod(mathFunction);
            Point<float>[] result = eulerMethod.Solve(0, 10, 5, 0.001f);
        }
    }
}
