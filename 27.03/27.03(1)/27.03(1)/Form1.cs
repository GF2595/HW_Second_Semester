using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorNamespace
{
    public partial class Form1 : Form
    {
        private Calculator calc;
        private bool operationResultPrinted = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            calc = new Calculator();
        }

        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            Output.Text = calc.BackSpace();
        }

        private void CEButton_Click(object sender, EventArgs e)
        {
            calc.DeleteLastRecordedNumber();

            Output.Text = "";
        }

        private void CButton_Click(object sender, EventArgs e)
        {
            calc.CleanMemory();

            Output.Text = "";
        }

        private void ChangeSignButton_Click(object sender, EventArgs e)
        {
            Output.Text = calc.ChangeSign();
        }

        private void SqrtButton_Click(object sender, EventArgs e)
        {
            Output.Text = calc.Sqrt();
        }

        private void DigitButtonClick(object sender, EventArgs e)
        {
            if (operationResultPrinted)
            {
                operationResultPrinted = false;
                Output.Text = "";
                calc.DeleteLastRecordedNumber();
            }

            Button buttonNumber = (Button)sender;

            int digit = Convert.ToInt32(buttonNumber.Text);

            calc.AddDigitToMemory(digit);
            Output.Text = Output.Text + digit.ToString();
        }

        private void DotButton_Click(object sender, EventArgs e)
        {
            if (operationResultPrinted)
            {
                operationResultPrinted = false;
                Output.Text = "";
                calc.DeleteLastRecordedNumber();
            }

            calc.ActivateDot();

            if (Output.Text == "")
            {
                Output.Text = "0,";
            }
            else
            {
                Output.Text += ",";
            }
        }

        private void OperationButtonClick(object sender, EventArgs e)
        {
            Button operationButton = (Button)sender;

            calc.AddOperation(operationButton.Text[0]);
            operationResultPrinted = false;
            Output.Text = "";
        }

        private void PercentButton_Click(object sender, EventArgs e)
        {
            Output.Text = calc.Percent();
        }

        private void InvertButton_Click(object sender, EventArgs e)
        {
            operationResultPrinted = false;

            try
            {
                Output.Text = calc.InvertNumber().ToString();
            }
            catch(DivisionByZeroException)
            {
                Output.Text = "Деление на ноль запрещено";
            }
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            try
            {
                Output.Text = calc.CommitOperation().ToString();
                operationResultPrinted = true;
            }
            catch(DivisionByZeroException)
            {
                Output.Text = "Деление на ноль запрещено";
            }
        }
    }
}
