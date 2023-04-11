using DifferentialEquationCalculator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifferentialEquationCalculator
{
    public partial class Form1 : Form
    {
        private DifferentialEquationCalculatorViewModel _vm; 
        public Form1()
        {
            InitializeComponent();
            _vm = new DifferentialEquationCalculatorViewModel();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
