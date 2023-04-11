using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialEquationCalculator.Model
{
    public class MathFunctionVisualizer
    {
        private MathFunction _mathFunction;
        public MathFunctionVisualizer(MathFunction mathFunction)
        {
            if (mathFunction == null) 
                throw new ArgumentNullException(nameof(mathFunction));
            _mathFunction = mathFunction; 
        }
        
        public Point<float>[] CalculatePoints(float left_border, float right_border, float step)
        {
            int index = 0;
            Point<float>[] points = new Point<float>[Convert.ToInt32((right_border - left_border) / step)];
            for (; left_border < right_border; left_border += step)
            {
                points[index] = new Point<float>(left_border, _mathFunction.Calculate(left_border, -1));
                index++;
            }
            return points;
        }
    }
}
