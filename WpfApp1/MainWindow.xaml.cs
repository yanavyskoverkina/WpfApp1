using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement element in Calculator.Children)//Переборка элементов решетки
            {
                if (element is Button)
                {
                    ((Button)element).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;//Строка для передачи названия кнопки (цифр) в поле TextField

            if (str == "Clear")
            {
                TextField.Text = "";
            }
            if (str == "!")
            {
                TextField.Text = "(" + TextField.Text + ")!=" + Convert.ToString(Factorial(Convert.ToInt32(TextField.Text)));
            }
            if (str == "sin()")
            {
                TextField.Text = "sin(" + Convert.ToString(Math.Sin(Convert.ToInt32(TextField.Text))) + ")";
            }
            if (str == "cos()")
            {
                TextField.Text = "cos(" + Convert.ToString(Math.Cos(Convert.ToInt32(TextField.Text))) + ")";
            }
            if (str == "X^2")
            {
                TextField.Text = Convert.ToString(Math.Pow(Convert.ToInt32(TextField.Text), 2));
            }
            else if (str == "=")
            {
                if (TextField.Text != "")
                {
                    TextField.Text = new DataTable().Compute(TextField.Text, null).ToString();//Расчет результата
                }
            }
            else if (str != "Clear" && str != "sin()" && str != "cos()" && str != "!" && str != "X^2")
            {
                TextField.Text += str;//Передача названия кнопки (цифр) в поле TextField
            }
        }

        public int Factorial(int num)
        {
            if (num == 0)
            {
                return 1;
            }
            else
            {
                return num * Factorial(num - 1);
            }
        }
    }
}

