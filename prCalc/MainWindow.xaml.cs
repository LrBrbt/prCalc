using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace prCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string forSolve = string.Empty;
        string errorMessage = "meow^^";
        int result = 0;
        int resultForFactorial = 1;

        Regex numbers = new Regex("[0-9]");


        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ToSolveTXT.Text += button.Content.ToString();
            forSolve += button.Content.ToString();
        }

        private void CE_BTN_Click(object sender, RoutedEventArgs e)
        {
            ToSolveTXT.Clear();
            forSolve = "";
        }

        private void C_BTN_Click(object sender, RoutedEventArgs e)
        {
            ToSolveTXT.Clear();
            forSolve = "";
        }

        private void Minus1PowBTN_Click(object sender, RoutedEventArgs e)
        {
            ToSolveTXT.Text += "1/";
        }

        private void MeowBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(errorMessage);
        }

        private void xPow2BTN_Click(object sender, RoutedEventArgs e)
        {
            ToSolveTXT.Text += "^2";
            forSolve += "^2";
        }

        private void FactorialBTN_Click(object sender, RoutedEventArgs e)
        {
            ToSolveTXT.Text += "!";
            forSolve += "!";
        }

        private void xPowYBTN_Click(object sender, RoutedEventArgs e)
        {
            ToSolveTXT.Text += "^";
            forSolve += "^";
        }

        private void ySqrtXBTN_Click(object sender, RoutedEventArgs e)
        {
            ToSolveTXT.Text += "√";
            forSolve += "√";
        }

        private void xPow3BTN_Click(object sender, RoutedEventArgs e)
        {
            ToSolveTXT.Text += "^3";
            forSolve += "^3";
        }

        private void _1SqrtXBTN_Click(object sender, RoutedEventArgs e)
        {
            ToSolveTXT.Text += "1√";
        }

        private void TenPowXBTN_Click(object sender, RoutedEventArgs e)
        {
            ToSolveTXT.Text += "10^";
        }

        private void RadRB_Checked(object sender, RoutedEventArgs e)
        {
            TypeSolveTXT.Content = "";
            TypeSolveTXT.Content = "RAD";
        }

        private void GradRB_Checked(object sender, RoutedEventArgs e)
        {
            TypeSolveTXT.Content = "";
            TypeSolveTXT.Content = "GRAD";
        }

        private void DegRB_Checked(object sender, RoutedEventArgs e)
        {
            TypeSolveTXT.Content = "";
            TypeSolveTXT.Content = "DEG";
        }

        private void SolveBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] solve = new string[forSolve.Length];

                for (int i = 0; i < solve.Length; i++)
                {
                    solve[i] = forSolve[i].ToString();
                }

                if (solve.Length == 3)
                {
                    int firstNumber = Convert.ToInt32(solve[0]);
                    int secondNumber = Convert.ToInt32(solve[2]);

                    char oper = Convert.ToChar(solve[1]);

                    switch (oper)
                    {
                        case '+':
                            {
                                result = firstNumber + secondNumber;
                                break;
                            }
                        case '-':
                            {
                                result = firstNumber - secondNumber;
                                break;
                            }
                        case '*':
                            {
                                result = firstNumber * secondNumber;
                                break;
                            }
                        case '/':
                            {
                                result = firstNumber / secondNumber;
                                break;
                            }
                        case '^':
                            {
                                result = firstNumber ^ secondNumber;
                                break;
                            }

                    }
                    ToSolveTXT.Text += "=" + result.ToString();

                }
                else if (solve.Length == 2)
                {

                    int firstNumber = Convert.ToInt32(solve[0]);
                    char oper = Convert.ToChar(solve[1]);

                    switch (oper)
                    {
                        case '!':
                            {
                                result = 1;
                                for (int i = 1; i < firstNumber + 1; i++)
                                {
                                    result *= i;
                                }
                                break;
                            }
                        case '√':
                            {
                                result = Convert.ToInt32(Math.Sqrt(firstNumber));
                                break;
                            }
                    }
                    ToSolveTXT.Text += "=" + result.ToString();
                }
                else
                {
                    throw new Exception("Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            ToSolveTXT.Text = ToSolveTXT.Text.Remove(ToSolveTXT.Text.Length - 1);
        }
    }
}

