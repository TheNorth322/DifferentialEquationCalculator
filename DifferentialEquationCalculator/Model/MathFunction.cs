using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialEquationCalculator.Model
{
    public class MathFunction
    {
        private Func<float, float, float> _function;

        public MathFunction(Func<float, float, float> function)
        {
            _function = function;
        }

        public float Calculate(float x, float y)
        {
            return _function(x, y);
        }
    }
}
