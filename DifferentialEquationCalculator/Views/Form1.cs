using DifferentialEquationCalculator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DifferentialEquationCalculator.Model;
using System.Drawing;

namespace DifferentialEquationCalculator
{
    public partial class Form1 : Form
    {
        private DifferentialEquationCalculatorViewModel _vm; 
        public Form1(MathFunction func)
        {
            InitializeComponent();
            _vm = new DifferentialEquationCalculatorViewModel(func);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float x0 = (float) Convert.ToDouble(x0TextBox.Text);
            float y0 = (float) Convert.ToDouble(y0TextBox.Text);    
            float xn = (float) Convert.ToDouble(xnTextBox.Text);
            float step = (float) Convert.ToDouble(hTextBox.Text);

            BuildPlot(_vm.SolveEulerMethod(x0, xn, y0, step), "Метод Эйлера", ChartDashStyle.Solid, Color.Black, 21);
            BuildPlot(_vm.SolvePredicterCorrecterEulerMethod(x0, xn, y0, step), "Метод Эйлера исп.", ChartDashStyle.Solid, Color.Yellow, 18); 
            BuildPlot(_vm.SolveModifiedEulerMethod(x0, xn, y0, step), "Метод Эйлера мод.", ChartDashStyle.Solid, Color.Green, 15); 
            BuildPlot(_vm.SolveRungeKuttaMethod(x0, xn, y0, step), "Метод Рунге-Кутта", ChartDashStyle.Solid, Color.Red, 12); 
            BuildPlot(_vm.SolveRungeKuttaMersonMethod(x0, xn, y0, step), "Метод Рунге-Кутта-Мерсон", ChartDashStyle.Solid, Color.Blue, 9); 
            BuildPlot(_vm.SolveAdamsMethod(x0, xn, y0, step), "Метод Адамса", ChartDashStyle.Solid, Color.Pink, 6); 
            BuildPlot(_vm.SolvePrecise(x0, xn, y0, step), "Теор. реш.", ChartDashStyle.Solid, Color.Orange, 3); 
        }

        private void BuildPlot(Point<float>[] points, string name, ChartDashStyle style, Color color,
            int borderWidth, SeriesChartType seriesChartType = SeriesChartType.Spline)
        {
            chart.Series.Add(name);
            chart.Series.FindByName(name).BorderDashStyle = style;
            chart.Series.FindByName(name).ChartType = seriesChartType;
            chart.Series.FindByName(name).Color = color;
            chart.Series.FindByName(name).BorderWidth = borderWidth;
            chart.Series.FindByName(name).MarkerSize = borderWidth;


            for (int i = 0; i < points.Length - 1; i++)
                chart.Series.FindByName(name).Points.AddXY(points[i].X, points[i].Y);
        }
        private void BuildPlot(List<Point<float>> points, string name, ChartDashStyle style, Color color,
            int borderWidth, SeriesChartType seriesChartType = SeriesChartType.Spline)
        {
            chart.Series.Add(name);
            chart.Series.FindByName(name).BorderDashStyle = style;
            chart.Series.FindByName(name).ChartType = seriesChartType;
            chart.Series.FindByName(name).Color = color;
            chart.Series.FindByName(name).BorderWidth = borderWidth;
            chart.Series.FindByName(name).MarkerSize = borderWidth;


            for (int i = 0; i < points.Count - 1; i++)
                chart.Series.FindByName(name).Points.AddXY(points[i].X, points[i].Y);
        }
    }
}
