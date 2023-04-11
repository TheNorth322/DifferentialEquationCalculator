using DifferentialEquationCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialEquationCalculator
{
    public class EulerMethod
    {
        private MathFunction _mathFunction;
        public EulerMethod(MathFunction mathFunction) {
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
                points[index] = new Point<float>(left_border, points[index - 1].Y + step * _mathFunction.Calculate(left_border, points[index - 1].Y));
                index++;
            }

            return points;
        }
    }
}
