﻿using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace AssertAccounting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>   
    public partial class MainWindow : Window
    {
        public static Entities DB = new Entities();
        string captha;
        private DispatcherTimer Timer;
        private int time;
        public MainWindow()
        {
            InitializeComponent();
            Password.IsEnabled = false;
            Code.IsEnabled = false;
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 1);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time--;
            Time.Text = "До окончания действия кода " + time + " с";

            if (time == 0)
            {
                Timer.Stop();
                Time.Text = "";
            }
        }
        private void Number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (Number.Text != "")
                {
                    try
                    {
                        List<Employee> employees = DB.Employee.Where(x => x.phone == Number.Text).ToList();
                        if (employees.Count != 0)
                        {
                            Password.IsEnabled = true;
                            Password.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Код не найден");
                            return;
                        }
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("Что-то пошло не по плану");
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Введите номер");
                    return;
                }
            }
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (Password.Password != "")
                {
                    try
                    {
                        List<Employee> employees = DB.Employee.Where(x => x.phone == Number.Text && x.password == Password.Password).ToList();

                        if (employees.Count != 0)
                        {
                            Code.IsEnabled = true;
                            Password.IsEnabled = false;
                            Number.IsEnabled = false;
                            GetCode();
                            Code.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Пароль не найден");
                            return;
                        }
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("Что-то пошло не по плану");
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Введите номер");
                    return;
                }
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Number.Text = "";
            Password.Password = "";
            Code.Text = "";
            Number.IsEnabled = true;
            Password.IsEnabled = false;
            Code.IsEnabled = false;
        }
        private void GetCode()
        {

            Random rand = new Random();
            string result = "";
            char c = '0';
          
            for (int i = 0; i < 9; i++)
            {
                switch (rand.Next(0, 3))
                {
                    case 0:
                        c = (char)rand.Next(49, 58);
                        break;
                    case 1:
                        c = (char)rand.Next(65, 91);
                        break;
                    case 2:
                        c = (char)rand.Next(97, 123);
                        break;
                }
                result += c;

                TextBlock tb = new TextBlock()
                {
                    Text = c.ToString(),
                    Padding = new Thickness(i * 25 + 5, rand.Next(21), rand.Next(21), 10),
                    FontSize = rand.Next(20, 26)
                };

                switch (rand.Next(0, 3))
                {
                    case 0:
                        tb.FontStyle = FontStyles.Italic;
                        break;
                    case 1:
                        tb.FontWeight = FontWeights.Bold;
                        break;
                    case 2:
                        tb.FontStyle = FontStyles.Italic;
                        tb.FontWeight = FontWeights.Bold;
                        break;
                }
            }
            MessageBox.Show(result, "Код", MessageBoxButton.OK);
            captha = result;
        }

        private void Entrance_Click(object sender, RoutedEventArgs e)
        {
            if (captha == Code.Text)
            {
                Employee employees = DB.Employee.FirstOrDefault(x => x.phone == Number.Text && x.role == x.Role1.idRole);
                MessageBox.Show(employees.Role1.nameRole);                
            }
            else 
            {
                MessageBox.Show("Вы неправильно ввели код!");
                Timer.Start();
                time = 10;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Code.Clear();
            Code.IsEnabled = true;
            Password.IsEnabled = false;
            Number.IsEnabled = false;
            GetCode();
            Code.Focus();
        }
    }
}
