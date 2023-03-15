using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace AssertAccounting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>   
    public partial class MainWindow : Window
    {
        public static Entities DB = new Entities();       
        public static string CAPTHA;
        public static  DispatcherTimer Timer;
        public static int time;
        public MainWindow()
        {
            InitializeComponent();
            Password.IsEnabled = false;
            Code.IsEnabled = false;
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 1);
            GenereteCode.IsEnabled = false;
            Entrance.IsEnabled = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time--;
            Time.Text = "До окончания действия кода " + time + " с";


            if (time == 0)
            {
                Timer.Stop();
                Time.Text = "";
                Code.Clear();
                GenereteCode.IsEnabled = true;
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
                        List<Employee> employees = DB.Employee.Where(x => x.Phone == Number.Text).ToList();
                        if (employees.Count != 0)
                        {
                            Password.IsEnabled = true;
                            Password.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Номер не найден");
                            Number.Clear();
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
                        List<Employee> employees = DB.Employee.Where(x => x.Phone == Number.Text && x.Password == Password.Password).ToList();

                        if (employees.Count != 0)
                        {
                            Code.IsEnabled = true;
                            Password.IsEnabled = false;
                            Number.IsEnabled = false; 
                            Captha captha = new Captha();                          
                            captha.ShowDialog();                           
                            Code.Focus();
                            Entrance.IsEnabled = true;
                         }
                        else
                        {
                            MessageBox.Show("Пароль не найден");
                            Password.Clear();
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
            GenereteCode.IsEnabled = false;
            Entrance.IsEnabled= false;
        }
     
        private void Entrance_Click(object sender, RoutedEventArgs e)
        {
            if (CAPTHA == Code.Text)
            {
                Employee employees = DB.Employee.FirstOrDefault(x => x.Phone == Number.Text && x.Role == x.Role1.IDRole);
                MessageBox.Show(employees.Role1.NameRole);
                Timer.Stop();
                Time.Text = "";
                Cancel_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Вы неправильно ввели код!");             
                Code.Clear();
            }
        }
        private void GenereteCode_Click(object sender, RoutedEventArgs e)
        {
            Code.Clear();
            Code.IsEnabled = true;
            Password.IsEnabled = false;
            Number.IsEnabled = false;
            Captha captha = new Captha();
            captha.ShowDialog();
            Code.Focus();
        }               

        private void StackPanel_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                if (Number.Text != "")
                {

                    if (Password.Password != "")
                    {
                        if (Code.Text != "")
                        {
                            Entrance_Click(sender, e);
                        }
                    }
                }
            }
        }
    }
}
