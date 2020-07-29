using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Kalkulator
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

        /// <summary>
        /// Get the value from the clicked button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns> The value of clicked Number in double </returns>
        private void btnNumberClick(object sender, RoutedEventArgs e)
        {
            Button clickedNumber = (Button)sender; // cast sender to Button
            string number = clickedNumber.Content.ToString(); // get the string of clicked number
            tbWynik.Text += number; // insert the number to textbox
        }

        /// <summary>
        /// Calculating a result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWynikClick(object sender, RoutedEventArgs e)
        {
            string text = tbWynik.Text.Trim(); // text from the text box
            char[] sep = new char[] { '+', '-', '*', '/' };
            string[] numbers = text.Split(sep);
            double[] dNumbers = new double[numbers.Length]; // array of input numbers
            for (int i = 0; i < numbers.Length; ++i)
            {
                dNumbers[i] = double.Parse(numbers[i]);
            }
            char[] del = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',' '};
            

            string[] chars = text.Split(del);
            List<string> signs = new List<string>();

            for(int i=0;i<chars.Length;++i)
            {
                if(chars[i] != "" && chars[i]!=" ")
                {
                    signs.Add(chars[i]);
                }
            }

            double result = dNumbers[0];

            for (int i = 0; i <signs.Count; ++i)
            {
                switch (signs[i])
                {
                    case "+":
                        result += dNumbers[i+1];
                        break;
                    case "-":
                        result -= dNumbers[i+1];
                        break;
                    case "*":
                        result *= dNumbers[i+1];
                        break;
                    case "/":
                        if(dNumbers[i+1] == 0)
                        {
                            MessageBox.Show("Do not divide by 0!");
                            tbWynik.Text = string.Empty;
                            return;
                        }
                        result /= dNumbers[i+1];
                        break;
                }
            }
            tbWynik.Text = result.ToString();
        }

        /// <summary>
        /// Adds a sign to textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperationClick(object sender, RoutedEventArgs e)
        {
            string text = tbWynik.Text; // text of the textBox contains numbers, commas and +-*/
            if (text == string.Empty || text[text.Length - 1] == '+' || text[text.Length - 1] == '+'
                || text[text.Length - 1] == '*' || text[text.Length - 1] == '/') return; // checked if string isnt empty
            tbWynik.Text += ((Button)sender).Content.ToString();
        }

        /// <summary>
        /// Clear the textBox showing result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearClick(object sender, RoutedEventArgs e)
        {
            tbWynik.Text = string.Empty; // clear the text box 
        }

        /// <summary>
        /// Insert the comma to textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommaClick(object sender, RoutedEventArgs e)
        {
            string text = tbWynik.Text;
            if (tbWynik.Text == string.Empty || text[text.Length - 1].Equals(","))
            {
                return;
            }
            tbWynik.Text += ",";
        }

        
    }
}
