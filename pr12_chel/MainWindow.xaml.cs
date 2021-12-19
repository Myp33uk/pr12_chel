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
using System.Windows.Threading;

namespace pr12_chel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            task.Text = "Произведение отрезков;Сумма и произведение цифр";
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.IsEnabled = true;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            time.Text = d.ToString("HH:mm");
            date.Text = d.ToString("dd.MM.yyyy");
        }

        private void InputProtection(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int a) == false) e.Handled = true;
        }

        private void CompositionCounter(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(startC.Text) < Convert.ToInt32(startA.Text) || Convert.ToInt32(startC.Text) > Convert.ToInt32(startB.Text)) MessageBox.Show("Неверное расположение координат");
                else
                {
                    compositionBox.Text = ((Convert.ToInt32(startC.Text) - Convert.ToInt32(startA.Text)) * (Convert.ToInt32(startB.Text) - Convert.ToInt32(startC.Text))).ToString();
                }
            }
            catch { MessageBox.Show("Неверные либо незаполненные данные."); }

            startA.Focus();
        }

        private void Task2(object sender, RoutedEventArgs e)
        {
            if (numberBox.Text.Length < 3) MessageBox.Show("Число не является трехзначным");
            else
            {
                int number = Convert.ToInt32(numberBox.Text);
                int sum = 0;
                int compos = 1;
                for (int i = 0; i < 3; i++)
                {
                    sum += number % 10;
                    compos *= number % 10;
                    number = number / 10;
                }
                digitsSum.Text = sum.ToString();
                digitsCompos.Text = compos.ToString();
                numberBox.Focus();
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
