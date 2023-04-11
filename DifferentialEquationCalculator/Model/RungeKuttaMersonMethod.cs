using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialEquationCalculator.Model
{
    public class RungeKuttaMersonMethod
    {
        private MathFunction _mathFunction;
        public RungeKuttaMersonMethod(MathFunction mathFunction) {
            if (mathFunction == null)
                throw new ArgumentNullException(nameof(mathFunction));
            _mathFunction = mathFunction;
        }

        public List<Point> Solve(float left_border, float right_border, float y0, float step, float epsilon)
        {
            List<Point> points = new List<Point>();
            points.Add(new Point(left_border, y0));
            left_border += step;
            while (left_border <= right_border)
            {
                float xn = points[points.Count - 1].X, yn = points[points.Count - 1].Y;
                
                float k1 = step * _mathFunction.Calculate(xn, yn);
                float k2 = step * _mathFunction.Calculate(xn + step / 3.0f, yn + k1 / 3.0f);
                float k3 = step * _mathFunction.Calculate(xn + step / 3.0f, yn + k1 / 6.0f + k2 / 6.0f);
                float k4 = step * _mathFunction.Calculate(xn + step / 2.0f, yn + k1 / 8.0f + 3 * k3 / 8.0f);
                float k5 = step * _mathFunction.Calculate(xn + step, yn + k1 / 2.0f - 3 * k3 / 2.0f + 2 * k4);
                float localError = 1 / 30.0f * (2 * k1 - 9 * k3 + 8 * k4 - k5);

                if (Math.Abs(localError) >= epsilon)
                {
                    step /= 2;
                    continue;
                }
                
                points.Add(new Point(left_border, yn + k1 / 6.0f + 2 * k4 / 3.0f + k5 / 6.0f));
                if (Math.Abs(localError) <= epsilon / 32)
                    step *= 2;

                left_border += step;
            }

            return points;
        }
    }
}
