using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorWithMem
{
    public partial class Form1 : Form
    {
        double lastInput;
        //double stored;
        string selectedOperator;
        bool isFistInputAfterOperator;
        string divZero = "div by zero";
        public Form1()
        {
            InitializeComponent();
            lastInput = 0;
            selectedOperator = "";
            isFistInputAfterOperator = false;
        }

        private void btnNR_Click(object sender, EventArgs e) // NUMBERS
        {
            if (isFistInputAfterOperator)
            {
                display.Text = "0";
                isFistInputAfterOperator = false;
            }
            Button button = (Button)sender;
            if(display.Text == "0")
                display.Text = button.Text;
            else if (display.Text == "-0")
                display.Text = "-"+button.Text;
            else
                display.Text += button.Text;
            
        }

        private void btnDOT_Click(object sender, EventArgs e) // DOT
        {
            if (isFistInputAfterOperator)
            {
                display.Text = "0";
                isFistInputAfterOperator = false;
            }
            if (!display.Text.Contains('.'))
            {
                if (display.Text == "-")
                {
                    display.Text += "0.";
                }
                else
                    display.Text += ".";
            }
        }

        private void btnNEG_Click(object sender, EventArgs e) // NEGATIVE SIGN
        {
            if (display.Text != divZero && Double.TryParse(display.Text,out _))
            {
                display.Text = Convert.ToString((Convert.ToDouble(display.Text) * -1));
                if (display.Text == "-0") display.Text = "0";
            }
            
        }
        private void btnClear_Click(object sender, EventArgs e) // CLEAR
        {
            if (display.Text == "0") // clears all
            {
                lastInput = 0;
                selectedOperator = "";
                isFistInputAfterOperator = false;
            }
            else if (display.Text != "0") // clears just the current displayed value
            {
                display.Text = "0";
            }

        }

        

        private void btnST_Click(object sender, EventArgs e) //STORE
        {
            if (Double.TryParse(display.Text, out _))
            {
                memDisplay.Text = display.Text;
            }
            isFistInputAfterOperator = true;
            
        }

        private void btnRC_Click(object sender, EventArgs e) //RECALL
        {
            display.Text = memDisplay.Text;
            isFistInputAfterOperator = true;
        }

        private void btnOperator_Click(object sender, EventArgs e) //OPERATORS
        {
            btnEqual_Click(new object(), new EventArgs());
            Button opBtn = (Button)sender;
            selectedOperator = opBtn.Text;
            Double.TryParse(display.Text, out lastInput);
            isFistInputAfterOperator = true;
        }

        private void btnEqual_Click(object sender, EventArgs e) // EQUAL
        {
            switch (selectedOperator)
            {
                case "+":
                    if (isFistInputAfterOperator)
                        display.Text = Convert.ToString(lastInput + lastInput);
                    else
                        display.Text = Convert.ToString(lastInput + Convert.ToDouble(display.Text));
                    break;
                case "-":
                    if (isFistInputAfterOperator)
                        display.Text = Convert.ToString(lastInput - lastInput);
                    else
                        display.Text = Convert.ToString(lastInput - Convert.ToDouble(display.Text));
                    break;
                case "x":
                    if (isFistInputAfterOperator)
                        display.Text = Convert.ToString(lastInput * lastInput);
                    else
                        display.Text = Convert.ToString(lastInput * Convert.ToDouble(display.Text));
                    break;
                case "/":

                    if (display.Text == "0")
                    {
                        display.Text = divZero;
                        isFistInputAfterOperator = true;
                        break;

                    }
                    if (isFistInputAfterOperator)
                        display.Text = Convert.ToString(lastInput / lastInput);
                    else
                        display.Text = Convert.ToString(lastInput / Convert.ToDouble(display.Text));
                    break;
                default:
                    break;
            }
            Double.TryParse(display.Text, out lastInput);
            selectedOperator = "";
            isFistInputAfterOperator = true;

        }
    }
}
