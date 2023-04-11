using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialEquationCalculator.Model
{
    internal class PredicterCorrecterEulerMethod
    {
        private MathFunction _mathFunction;
        public PredicterCorrecterEulerMethod(MathFunction mathFunction) {
            if (mathFunction == null)
                throw new ArgumentNullException(nameof(mathFunction));
            _mathFunction = mathFunction;
        }

        public Point<float>[] Solve(float left_border, float right_border, float y0, float step)
        {
            int index = 1;
            Point<float>[] points = new Point<float>[Convert.ToInt32((right_border - left_border) / step)];

            points[0] = new Point<float>(left_border, y0);

            for (left_border += step; left_border <= right_border; left_border += step)
            {
                float xn = points[index - 1].X, yn = points[index - 1].Y;
                float f = (_mathFunction.Calculate(xn, yn) + _mathFunction.Calculate(xn + step, yn + step * _mathFunction.Calculate(xn, yn))) / 2;
                points[index] = new Point<float>(left_border, points[index - 1].Y + step * f);
                index++;
            }

            return points;
        }
    }
}
