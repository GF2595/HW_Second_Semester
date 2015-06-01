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
            calc.BackSpace();

            string temp = "";

            for (int i = 0; i < Output.Text.Length - 1; i++)
            {
                temp += Output.Text[i];
            }

            Output.Text = temp;
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
            calc.ChangeSign();

            if (Output.Text != "")
            {
                if (Output.Text[0] == '-')
                {
                    string temp = "";

                    for (int i = 1; i < Output.Text.Length; i++)
                    {
                        temp += Output.Text[i];
                    }

                    Output.Text = temp;
                }
                else
                {
                    Output.Text = "-" + Output.Text;
                }
            }
        }

        private void SqrtButton_Click(object sender, EventArgs e)
        {
            Output.Text = calc.Sqrt().ToString();
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            if (operationResultPrinted)
            {
                operationResultPrinted = false;
                Output.Text = "";
                calc.DeleteLastRecordedNumber();
            }

            calc.AddDigitToMemory(7);
            Output.Text = Output.Text + "7";
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            if (operationResultPrinted)
            {
                operationResultPrinted = false;
                Output.Text = "";
                calc.DeleteLastRecordedNumber();
            }

            calc.AddDigitToMemory(8);
            Output.Text = Output.Text + "8";
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            if (operationResultPrinted)
            {
                operationResultPrinted = false;
                Output.Text = "";
                calc.DeleteLastRecordedNumber();
            }

            calc.AddDigitToMemory(9);
            Output.Text = Output.Text + "9";
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            if (operationResultPrinted)
            {
                operationResultPrinted = false;
                Output.Text = "";
                calc.DeleteLastRecordedNumber();
            }

            calc.AddDigitToMemory(4);
            Output.Text = Output.Text + "4";
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            if (operationResultPrinted)
            {
                operationResultPrinted = false;
                Output.Text = "";
                calc.DeleteLastRecordedNumber();
            }

            calc.AddDigitToMemory(5);
            Output.Text = Output.Text + "5";
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            if (operationResultPrinted)
            {
                operationResultPrinted = false;
                Output.Text = "";
                calc.DeleteLastRecordedNumber();
            }

            calc.AddDigitToMemory(6);
            Output.Text = Output.Text + "6";
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            if (operationResultPrinted)
            {
                operationResultPrinted = false;
                Output.Text = "";
                calc.DeleteLastRecordedNumber();
            }

            calc.AddDigitToMemory(1);
            Output.Text = Output.Text + "1";
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            if (operationResultPrinted)
            {
                operationResultPrinted = false;
                Output.Text = "";
                calc.DeleteLastRecordedNumber();
            }

            calc.AddDigitToMemory(2);
            Output.Text = Output.Text + "2";
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            if (operationResultPrinted)
            {
                operationResultPrinted = false;
                Output.Text = "";
                calc.DeleteLastRecordedNumber();
            }

            calc.AddDigitToMemory(3);
            Output.Text = Output.Text + "3";
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            if (operationResultPrinted)
            {
                operationResultPrinted = false;
                Output.Text = "";
                calc.DeleteLastRecordedNumber();
            }

            calc.AddDigitToMemory(0);
            Output.Text = Output.Text + "0";
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

        private void DivisionButton_Click(object sender, EventArgs e)
        {
            calc.AddOperation('/');
            operationResultPrinted = false;
            Output.Text = "";
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            calc.AddOperation('*');
            operationResultPrinted = false;
            Output.Text = "";
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            calc.AddOperation('+');
            operationResultPrinted = false;
            Output.Text = "";
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            calc.AddOperation('-');
            operationResultPrinted = false;
            Output.Text = "";
        }

        private void PercentButton_Click(object sender, EventArgs e)
        {
            Output.Text = calc.Percent().ToString();
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
