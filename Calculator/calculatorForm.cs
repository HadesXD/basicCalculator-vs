using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class calculatorForm : Form
    {
        double fValue;
        double fTotal = 0;
        bool bOperation = false;
        bool pressed = false;
        char cOpeartion;
        char old = '+';

        public calculatorForm()
        {
            InitializeComponent();
        }

        private void buttonNum_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "0")
                textBox.Clear();

            Button num = (Button)sender;

            if (num.Text == ".")
                num.Text = ",";

            textBox.Text += num.Text; 
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox.Clear();
        }

        private void buttonOperator_Click(object sender, EventArgs e)
        {
            if (textBox.Text != "")
            {
                Button operation = (Button)sender;

                if (operation.Text == "x")
                    operation.Text = "*";

                cOpeartion = operation.Text[0];

                fValue = Double.Parse(textBox.Text);

                if (old == '/' && textBox.Text == "0")
                {
                    MessageBox.Show("You cannot divide with 0");
                }

                if (label.Text == "_")
                {
                    fTotal = fValue;
                    old = cOpeartion;
                    label.Text = fValue + " " + cOpeartion + " ";
                }

                else if (label.Text != "_" && bOperation == true)
                {
                    operationFunction(old, fValue);
                    old = cOpeartion;
                    label.Text = label.Text + ' ' + old + ' ';
                }

                bOperation = true;
                textBox.Clear();
            }
            else
            {
                MessageBox.Show("Stop it faggot!");
            }

        }


        private void buttonEquels_Click(object sender, EventArgs e)
        {
            operationFunction(old, fValue);
        }

        public void operationFunction(char cOpeartion, double value)
        {
            bOperation = false;
            switch (cOpeartion)
            {
                case '+':
                    fTotal += Convert.ToInt32(textBox.Text);
                    label.Text = label.Text + value.ToString();
                    fTotalLabel.Text = fTotal.ToString();
                    break;
                case '-':
                    fTotal -= Convert.ToInt32(textBox.Text);
                    label.Text = label.Text + value.ToString();
                    fTotalLabel.Text = fTotal.ToString();
                    break;
                case '*':
                    fTotal *= Convert.ToInt32(textBox.Text);
                    label.Text = label.Text + value.ToString();
                    fTotalLabel.Text = fTotal.ToString();
                    textBox.Text = (fValue * Double.Parse(textBox.Text)).ToString();
                    break;
                case '/':
                    fTotal /= Convert.ToInt32(textBox.Text);
                    label.Text = label.Text + value.ToString();
                    fTotalLabel.Text = fTotal.ToString();
                    textBox.Text = (fValue / Double.Parse(textBox.Text)).ToString();
                    break;
                default:
                    break;
            }
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            textBox.Text = "";
            label.Text = "";
            fValue = 0;
            fTotal = 0;
        }
    }
}
