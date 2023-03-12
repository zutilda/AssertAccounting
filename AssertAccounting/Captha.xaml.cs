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
using System.Windows.Shapes;

namespace AssertAccounting
{
    /// <summary>
    /// Логика взаимодействия для Captha.xaml
    /// </summary>
    public partial class Captha : Window
    {      
        public Captha()
        {
            InitializeComponent();
            GetCAPTHA();
        }
        private string GetCAPTHA()
        {
            Canvas.Children.Clear();
            Random rand = new Random();

            string result = "";
            char c = '0';
            int count = rand.Next(7, 11);

            for (int i = 0; i < 9; i++)
            {
                switch (rand.Next(0, 4))
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
                    case 3:
                        c = (char)rand.Next(32, 47);
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

                Canvas.Children.Add(tb);
            }

            for (int i = 0; i < 15; i++)
            {
                Line line = new Line()
                {
                    X1 = rand.Next(251),
                    Y1 = rand.Next(51),
                    X2 = rand.Next(251),
                    Y2 = rand.Next(51),
                    Stroke = new SolidColorBrush(Color.FromRgb((byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256)))
                };
                Canvas.Children.Add(line);
            }

            return result;
        }      

        private void codeAuth_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
               
                MainWindow.CAPTHA = codeAuth.Text;
                MainWindow.Timer.Start();
                MainWindow.time = 10;
                this.Close();
                
            }
        }
    }}

