using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialEquationCalculator.Model
{
    public class RungeKuttaMethod
    {
        private MathFunction _mathFunction;
        public RungeKuttaMethod(MathFunction mathFunction) {
            if (mathFunction == null)
                throw new ArgumentNullException(nameof(mathFunction));
            _mathFunction = mathFunction;
        }

        public Point[] Solve(float left_border, float right_border, float y0, float step)
        {
            int index = 1;
            Point[] points = new Point[Convert.ToInt32((right_border - left_border) / step)];
            points[0] = new Point(left_border, y0);
            
            for (left_border += step; left_border <= right_border; left_border += step)
            {
                float xn = points[index - 1].X, yn = points[index - 1].Y;
                
                float k1 = _mathFunction.Calculate(xn, yn);
                float k2 = _mathFunction.Calculate(xn + step / 2.0f, yn + step * k1 / 2.0f);
                float k3 = _mathFunction.Calculate(xn + step / 2.0f, yn + step * k2 / 2.0f);
                float k4 = _mathFunction.Calculate(xn + step, yn + step * k3);

                points[index] = new Point(left_border, points[index - 1].Y + step / 6.0f * (k1 + 2 * k2 + 2 * k3 + k4));
                index++;
            }

            return points;
        }
    }
}
