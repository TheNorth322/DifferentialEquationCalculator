using DifferentialEquationCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialEquationCalculator.ViewModels
{
    public class DifferentialEquationCalculatorViewModel
    {
        private EulerMethod eulerMethod;
        private PredicterCorrecterEulerMethod predicterCorrecterEulerMethod;
        private ModifiedEulerMethod modifiedEulerMethod;
        private RungeKuttaMethod rungeKuttaMethod;
        private RungeKuttaMersonMethod rungeKuttaMersonMethod;
        private AdamsMethod adamsMethod;
        private MathFunctionVisualizer mathFunctionVisualizer; 
        public DifferentialEquationCalculatorViewModel(MathFunction mathFunction)
        {
            
            if (mathFunction == null)
                throw new ArgumentNullException(nameof(mathFunction));
            float PreciseFunction(float x, float y) => (float) (26 * Math.Exp(-2 * x) + 2 * Math.Sin(x) - Math.Cos(x)) / 5.0f;
            eulerMethod= new EulerMethod(mathFunction);
            predicterCorrecterEulerMethod = new PredicterCorrecterEulerMethod(mathFunction);
            modifiedEulerMethod = new ModifiedEulerMethod(mathFunction);
            rungeKuttaMethod = new RungeKuttaMethod(mathFunction);
            rungeKuttaMersonMethod = new RungeKuttaMersonMethod(mathFunction);
            adamsMethod = new AdamsMethod(mathFunction);
            mathFunctionVisualizer = new MathFunctionVisualizer(new MathFunction(PreciseFunction));
        }

        public Point<float>[] SolveEulerMethod(float left_border, float right_border, float y0, float step) 
            => eulerMethod.Solve(left_border, right_border, y0, step);
        public Point<float>[] SolvePredicterCorrecterEulerMethod(float left_border, float right_border, float y0, float step) 
            => predicterCorrecterEulerMethod.Solve(left_border, right_border, y0, step);
        public Point<float>[] SolveModifiedEulerMethod(float left_border, float right_border, float y0, float step) 
            => modifiedEulerMethod.Solve(left_border, right_border, y0, step);
        public Point<float>[] SolveRungeKuttaMethod(float left_border, float right_border, float y0, float step) 
            => rungeKuttaMethod.Solve(left_border, right_border, y0, step);
        public List<Point<float>> SolveRungeKuttaMersonMethod(float left_border, float right_border, float y0, float step) 
            => rungeKuttaMersonMethod.Solve(left_border, right_border, y0, step, 0.001f);
        public Point<float>[] SolveAdamsMethod(float left_border, float right_border, float y0, float step) 
            => adamsMethod.Solve(left_border, right_border, y0, step);
        public Point<float>[] SolvePrecise(float left_border, float right_border, float y0, float step) 
            => mathFunctionVisualizer.CalculatePoints(left_border, right_border, step);

    }
}
