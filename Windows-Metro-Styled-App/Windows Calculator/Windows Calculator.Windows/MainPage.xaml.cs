using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Numerics;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_Calculator
{
    /// <summary>
    /// The MainPage class which includes all the C# codes that execute and handle the Calculating events.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string op1;
        string op2;
        string op;
        bool first = true;
        bool evaluated = false;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!evaluated)
            {
                Button button = (sender) as Button;
                string val = button.Content.ToString();

                switch (val)
                {
                    // values setting
                    case "1":
                        if (first) { op1 = op1 + val; FinalResult.Text = op1; } else { op2 = op2 + val; FinalResult.Text = op2; };
                        break;
                    case "2":
                        if (first) { op1 = op1 + val; FinalResult.Text = op1; } else { op2 = op2 + val; FinalResult.Text = op2; };
                        break;
                    case "3":
                        if (first) { op1 = op1 + val; FinalResult.Text = op1; } else { op2 = op2 + val; FinalResult.Text = op2; };
                        break;
                    case "4":
                        if (first) { op1 = op1 + val; FinalResult.Text = op1; } else { op2 = op2 + val; FinalResult.Text = op2; };
                        break;
                    case "5":
                        if (first) { op1 = op1 + val; FinalResult.Text = op1; } else { op2 = op2 + val; FinalResult.Text = op2; };
                        break;
                    case "6":
                        if (first) { op1 = op1 + val; FinalResult.Text = op1; } else { op2 = op2 + val; FinalResult.Text = op2; };
                        break;
                    case "7":
                        if (first) { op1 = op1 + val; FinalResult.Text = op1; } else { op2 = op2 + val; FinalResult.Text = op2; };
                        break;
                    case "8":
                        if (first) { op1 = op1 + val; FinalResult.Text = op1; } else { op2 = op2 + val; FinalResult.Text = op2; };
                        break;
                    case "9":
                        if (first) { op1 = op1 + val; FinalResult.Text = op1; } else { op2 = op2 + val; FinalResult.Text = op2; };
                        break;
                    case "0":
                        if (first) { op1 = op1 + val; FinalResult.Text = op1; } else { op2 = op2 + val; FinalResult.Text = op2; };
                        break;
                    case ".":
                        if (first) { op1 = op1 + val; FinalResult.Text = op1; } else { op2 = op2 + val; FinalResult.Text = op2; };
                        break;

                    // operators selection
                    case "+":
                        if (first) { first = false; } else { OperatorLocked(Convert.ToChar(val)); }
                        Expression.Text = op1 + " " + val;
                        FinalResult.Text = "0";
                        op = val;
                        break;
                    case "-":
                        if (first) { first = false; } else { OperatorLocked(Convert.ToChar(val)); }
                        Expression.Text = op1 + " " + val;
                        FinalResult.Text = "0";
                        op = val;
                        break;
                    case "*":
                        if (first) { first = false; } else { OperatorLocked(Convert.ToChar(val)); }
                        Expression.Text = op1 + " " + val;
                        FinalResult.Text = "0";
                        op = val;
                        break;
                    case "/":
                        if (first) { first = false; } else { OperatorLocked(Convert.ToChar(val)); }
                        Expression.Text = op1 + " " + val;
                        FinalResult.Text = "0";
                        op = val;
                        break;
                    case "%":
                        if (first)
                        {
                            new MessageDialog("Please select a statement of which you want to get the percentage.").ShowAsync();
                        }
                        else
                        {
                            if (op == "/")
                            {
                                // get percentage
                                FinalResult.Text = ((Convert.ToDouble(op1) / Convert.ToDouble(op2)) * 100).ToString();

                                op1 = "";
                                op2 = "";
                                op = "";
                                evaluated = true;
                            }
                            else
                            {
                                new MessageDialog("Only percentage is allowed.\n\nFor instance, Only division operator is allowed. value1 / value 2 and then press % to get their percentage.").ShowAsync();
                            }
                        }
                        break;
                    case "n!":
                        if (first)
                        {
                            if (op1 == null || op1.Length < 1)
                            {
                                Expression.Text = "factorial(0)";
                                FinalResult.Text = "1";

                                op1 = "";
                                op2 = "";
                                op = "";
                                evaluated = true;
                            }
                            else
                            {
                                Expression.Text = "factorial(" + op1 + ")";
                                FinalResult.Text = GetFactorial(Convert.ToInt64(op1)).ToString();

                                op1 = "";
                                op2 = "";
                                op = "";
                                evaluated = true;
                            }
                        }
                        else
                        {
                            Expression.Text = "factorial(" + op1 + ")";
                            FinalResult.Text = GetFactorial(Convert.ToInt16(op1)).ToString();

                            op1 = "";
                            op2 = "";
                            op = "";
                            evaluated = true;
                        }
                        break;
                    case "negate":
                        if (first)
                        {
                            if (op1 != null && op1.Length > 0)
                            {
                                if (op1.ToCharArray()[0] == '-')
                                {
                                    // already a negative
                                    op1 = op1.Substring(1, op1.Length);
                                    FinalResult.Text = op1;
                                }
                                else
                                {
                                    op1 = "-" + op1;
                                    FinalResult.Text = op1;
                                }
                            }
                        }
                        else
                        {
                            if (op2 != null && op2.Length > 0)
                            {
                                if (op2.ToCharArray()[0] == '-')
                                {
                                    // already a negative
                                    op2 = op2.Substring(1, op2.Length);
                                    FinalResult.Text = op2;
                                }
                                else
                                {
                                    op2 = "-" + op2;
                                    FinalResult.Text = op2;
                                }
                            }
                        }
                        break;
                    case "←":
                        if (first)
                        {
                            if (op1 != null && op1.Length > 0)
                            {
                                op1 = op1.Substring(0, op1.Length - 1);
                                FinalResult.Text = op1;
                            }
                            else
                            {
                                FinalResult.Text = "0";
                            }
                        }
                        else
                        {
                            if (op2 != null && op2.Length > 0)
                            {
                                op2 = op2.Substring(0, op2.Length - 1);
                                FinalResult.Text = op2;
                            }
                            else
                            {
                                FinalResult.Text = "0";
                            }
                        }
                        break;
                    case "sin":
                        Expression.Text = "sin(x)";
                        op = val;
                        break;
                    case "cos":
                        Expression.Text = "cos(x)";
                        op = val;
                        break;
                    case "tan":
                        Expression.Text = "tan(x)";
                        op = val;
                        break;
                    case "asin":
                        Expression.Text = "arcsin(x)";
                        op = val;
                        break;
                    case "acos":
                        Expression.Text = "arccos(x)";
                        op = val;
                        break;
                    case "atan":
                        Expression.Text = "arctan(x)";
                        op = val;
                        break;
                    case "C":
                        FinalResult.Text = "0";
                        Expression.Text = "";
                        op1 = "";
                        op2 = "";
                        evaluated = false;
                        first = true;
                        break;
                    case "CE":
                        FinalResult.Text = "0";
                        op1 = "";
                        break;
                    case "√":
                        if (first)
                        {
                            if (op1 != null && op1.Length > 0)
                            {
                                Expression.Text = "sqrt(" + op1 + ")";
                                FinalResult.Text = Math.Sqrt(Convert.ToDouble(op1)).ToString();
                                op1 = "";
                                op2 = "";
                                op = "";
                                evaluated = true;
                            }
                            else
                            {
                                new MessageDialog("Add some values to the operand first.").ShowAsync();
                            }
                        }
                        else
                        {
                            new MessageDialog("Square root operator doesnot take two operands.").ShowAsync();
                        }
                        break;
                    case "log()":
                        // find log
                        if (first)
                        {
                            if (op1 != null && op1.Length > 0)
                            {
                                Expression.Text = "log(" + op1 + ")";
                                FinalResult.Text = Math.Log10(Convert.ToDouble(op1)).ToString();
                                op1 = "";
                                op2 = "";
                                op = "";
                                evaluated = true;
                            }
                            else
                            {
                                new MessageDialog("Add some values to the operand first.").ShowAsync();
                            }
                        }
                        else
                        {
                            new MessageDialog("Logarithm operator doesnot take two operands.").ShowAsync();
                        }
                        break;
                    case "=":
                        switch (op)
                        {
                            case "sin":
                                Expression.Text = "sin(" + op1 + ")";
                                double angle = 0;
                                if (Degrees.IsOn)
                                {
                                    // give value in Degrees.
                                    angle = (Convert.ToDouble(op1) * Math.PI / 180);
                                }
                                else
                                {
                                    // angle is radian.
                                    angle = Convert.ToDouble(op1);
                                }
                                FinalResult.Text = Math.Sin(Convert.ToDouble(angle)).ToString();
                                op1 = "";
                                op2 = "";
                                op = "";
                                evaluated = true;
                                break;
                            case "cos":
                                Expression.Text = "cos(" + op1 + ")";
                                if (Degrees.IsOn)
                                {
                                    // give value in Degrees.
                                    angle = (Convert.ToDouble(op1) * Math.PI / 180);
                                }
                                else
                                {
                                    // angle is radian.
                                    angle = Convert.ToDouble(op1);
                                }
                                FinalResult.Text = Math.Cos(Convert.ToDouble(angle)).ToString();
                                op1 = "";
                                op2 = "";
                                op = "";
                                evaluated = true;
                                break;
                            case "tan":
                                Expression.Text = "tan(" + op1 + ")";
                                if (Degrees.IsOn)
                                {
                                    // give value in Degrees.
                                    angle = (Convert.ToDouble(op1) * Math.PI / 180);
                                }
                                else
                                {
                                    // angle is radian.
                                    angle = Convert.ToDouble(op1);
                                }
                                FinalResult.Text = Math.Tan(Convert.ToDouble(angle)).ToString();
                                op1 = "";
                                op2 = "";
                                op = "";
                                evaluated = true;
                                break;

                            // Inverse Trig Identities...
                            case "asin":
                                Expression.Text = "arcsin(" + op1 + ")";
                                string result = "";
                                if (Degrees.IsOn)
                                {
                                    result = ((180 / Math.PI) * Math.Asin(Convert.ToDouble(op1))).ToString();
                                }
                                else
                                {
                                    result = Math.Asin(Convert.ToDouble(op1)).ToString();
                                }
                                FinalResult.Text = result;
                                op1 = "";
                                op2 = "";
                                op = "";
                                evaluated = true;
                                break;
                            case "acos":
                                Expression.Text = "arccos(" + op1 + ")";
                                if (Degrees.IsOn)
                                {
                                    result = ((180 / Math.PI) * Math.Acos(Convert.ToDouble(op1))).ToString();
                                }
                                else
                                {
                                    result = Math.Acos(Convert.ToDouble(op1)).ToString();
                                }
                                FinalResult.Text = result;
                                op1 = "";
                                op2 = "";
                                op = "";
                                evaluated = true;
                                break;
                            case "atan":
                                Expression.Text = "arctan(" + op1 + ")";
                                if (Degrees.IsOn)
                                {
                                    result = ((180 / Math.PI) * Math.Atan(Convert.ToDouble(op1))).ToString();
                                }
                                else
                                {
                                    result = Math.Atan(Convert.ToDouble(op1)).ToString();
                                }
                                FinalResult.Text = result;
                                op1 = "";
                                op2 = "";
                                op = "";
                                evaluated = true;
                                break;

                            default:
                                if (!first)
                                {
                                    Evaluate(Convert.ToDouble(op1), Convert.ToDouble(op2), op);
                                    op1 = "";
                                    op2 = "";
                                    op = "";
                                    evaluated = true;
                                }
                                else
                                {
                                    new MessageDialog("Two operands must be selected and an operator must be selected, before you can evaluate them.").ShowAsync();
                                }
                                break;
                        }
                        break;
                }
            }
            else
            {
                FinalResult.Text = "0";
                Expression.Text = "";
                evaluated = false;

                Button_Click(sender, e);
            }
        }

        private void Evaluate(double op1, double op2, string op)
        {
            // Evaluate 
            switch (op)
            {
                case "+":
                    FinalResult.Text = (op1 + op2).ToString();
                    Expression.Text = op1 + " + " + op2 + " =";
                    break;
                case "-":
                    FinalResult.Text = (op1 - op2).ToString();
                    Expression.Text = op1 + " - " + op2 + " =";
                    break;
                case "*":
                    FinalResult.Text = (op1 * op2).ToString();
                    Expression.Text = op1 + " x " + op2 + " =";
                    break;
                case "/":
                    FinalResult.Text = (op1 / op2).ToString();
                    Expression.Text = op1 + " / " + op2 + " =";
                    break;
            }
        }

        private void OperatorLocked(char op)
        {
            new MessageDialog(op.ToString() + " is currently not available. \n\nYou can only select two operands currently.");
        }

        private BigInteger GetFactorial(Int64 value)
        {
            if (value <= 1)
            {
                return 1;
            }
            return value * GetFactorial(value - 1);
        }
    }
}
