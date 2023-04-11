using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialEquationCalculator.Model
{
    public class AdamsMethod
    {
        private MathFunction _mathFunction;
        private RungeKuttaMethod _rungeKuttaMethod;
        public AdamsMethod(MathFunction mathFunction) {
            if (mathFunction == null)
                throw new ArgumentNullException(nameof(mathFunction));
            _mathFunction = mathFunction;
            _rungeKuttaMethod = new RungeKuttaMethod(_mathFunction);
        }

        public Point[] Solve(float left_border, float right_border, float y0, float step)
        {
            int index = 3;
            
            Point[] points = new Point[Convert.ToInt32((right_border - left_border) / step)];
            Point[] F = _rungeKuttaMethod.Solve(left_border, left_border + 7 * step, y0, step);

            for (int i = 0; i < 4; i++)
            {
                points[i] = F[i];
                F[i] = new Point(-1, _mathFunction.Calculate(F[i].X, F[i].Y));
            }

            left_border += 4 * step;
             
            while (left_border <= right_border)
            {
                points[index + 1] = new Point(left_border, points[index].Y + step / 24.0f 
                    * (55 * F[3].Y 
                    - 59 * F[2].Y 
                    + 37 * F[1].Y 
                    - 9 * F[0].Y));

                ShiftArray(F);
                F[3] = new Point(-1, _mathFunction.Calculate(points[index + 1].X, points[index + 1].Y));
                left_border += step;
                index++;
            }

            return points;
        }

        private void ShiftArray(Point[] points)
        {
            for (int i = 0; i < points.Length - 1; i++)
                points[i] = points[i + 1];
        }
    }
}
