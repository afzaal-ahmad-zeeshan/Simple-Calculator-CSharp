using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Simple_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool first = true;
        string op1 = "";
        string op2 = "";
        char op;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Value_Click(object sender, RoutedEventArgs e)
        {
            Button button = (sender) as Button;
            string buttonValue = button.Name.ToString().Replace("Value", "");
            if (first)
            {
                // first operand must be filled here..
                switch (buttonValue)
                {
                    case "One":
                        op1 = op1 + "1";
                        break;
                    case "Two":
                        op1 = op1 + "2";
                        break;
                    case "Three":
                        op1 = op1 + "3";
                        break;
                    case "Four":
                        op1 = op1 + "4";
                        break;
                    case "Five":
                        op1 = op1 + "5";
                        break;
                    case "Six":
                        op1 = op1 + "6";
                        break;
                    case "Seven":
                        op1 = op1 + "7";
                        break;
                    case "Eight":
                        op1 = op1 + "8";
                        break;
                    case "Nine":
                        op1 = op1 + "9";
                        break;
                    case "Zero":
                        op1 = op1 + "0";
                        break;
                }
                Numeric.Text = op1;
            }
            else
            {
                // second operand must be filled here..
                switch (buttonValue)
                {
                    case "One":
                        op2 = op2 + "1";
                        break;
                    case "Two":
                        op2 = op2 + "2";
                        break;
                    case "Three":
                        op2 = op2 + "3";
                        break;
                    case "Four":
                        op2 = op2 + "4";
                        break;
                    case "Five":
                        op2 = op2 + "5";
                        break;
                    case "Six":
                        op2 = op2 + "6";
                        break;
                    case "Seven":
                        op2 = op2 + "7";
                        break;
                    case "Eight":
                        op2 = op2 + "8";
                        break;
                    case "Nine":
                        op2 = op2 + "9";
                        break;
                    case "Zero":
                        op2 = op2 + "0";
                        break;
                }
                if (Numeric.Text == "√")
                {
                    Numeric.Text = Numeric.Text + op2;
                }
                else
                {
                    Numeric.Text = op2;
                }
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = (sender) as Button;
            string oprtr = button.Name;
            switch (oprtr)
            {
                case "Plus":
                    op = '+';
                    first = false;
                    break;
                case "Minus":
                    op = '-';
                    first = false;
                    break;
                case "Divide":
                    op = '/';
                    first = false;
                    break;
                case "Modulus":
                    op = '%';
                    first = false;
                    break;
                case "SquareRoot":
                    op = 's';
                    Numeric.Text = "√";
                    break;
                case "Factorial":
                    op = '!';
                    Numeric.Text = Numeric.Text + "!";
                    first = false;
                    break;
                case "Multiply":
                    op = '*';
                    first = false;
                    break;
                case "Equals":
                    if (op == 's')
                    {
                        Evaluate(Convert.ToInt64(op1), (long) 0, 's');
                    } 
                    else if (op == '!') 
                    {
                        Evaluate(Convert.ToInt64(op1), (long) 0, '!');
                    }
                    else
                    {
                        if (first)
                        {
                            // first operand was being filled, now switch to second one!
                            MessageBox.Show("Fill in first value, press any operator you want to use, then click Equal button.");
                        }
                        else
                        {
                            // second operand was being filled. Now evaluate
                            if (op1 != "" && op2 != "" && op != ' ')
                            {
                                Evaluate(Convert.ToInt64(op1), Convert.ToInt64(op2), op);
                            }
                            else
                            {
                                op1 = "";
                                op2 = "";
                                op = ' ';
                                Numeric.Text = "0";

                                MessageBox.Show("Please fill the values first and try again.");
                            }
                        }
                    }

                    // flush the values and operator
                    op1 = "";
                    op2 = "";
                    op = ' ';
                    break;
            }
        }

        private int GetFactorial(int i)
        {
            if (i <= 1)
            {
                return 1;
            }
            return i * GetFactorial(i - 1);
        }

        private void Evaluate(Int64 op1, Int64 op2, char op)
        {
            string result = "";
            switch (op)
            {
                case '+':
                    result = (op1 + op2).ToString();
                    break;
                case '-':
                    result = (op1 - op2).ToString();
                    break;
                case '*':
                    result = (op1 * op2).ToString();
                    break;
                case '/':
                    result = (op1 / op2).ToString();
                    break;
                case '%':
                    result = (op1 % op2).ToString();
                    break;
                case 's':
                    result = Math.Sqrt((double) op1).ToString();
                    break;
                case '!':
                    result = GetFactorial((int) op1).ToString();
                    break;
                default:
                    MessageBox.Show("Please select an operator.");
                    break;
            }
            Numeric.Text = result;
        }
    }
}
