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

namespace Szamologepteljes
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

        private void tbx_szambeir1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double szam1 = double.Parse(tbx_szambeir1.Text);
                double szam2 = double.Parse(tbx_szambeir2.Text);
                string muvelet = "+"; // Itt írd át a kívánt műveletre pl. "-", "*", "/"

                switch (muvelet)
                {
                    case "+":
                        Szamosszead(szam1, szam2);
                        break;
                    case "-":
                        Szamkivon(szam1, szam2);
                        break;
                    case "*":
                        Szamszoroz(szam1, szam2);
                        break;
                    case "/":
                        Szamoszt(szam1, szam2);
                        break;
                    default:
                        tb_eredmeny.Text = "Ismeretlen művelet.";
                        break;
                }
            }
            catch (FormatException)
            {
                tb_eredmeny.Text = "Hibás számformátum!";
            }
            catch (DivideByZeroException)
            {
                tb_eredmeny.Text = "Nullával nem lehet osztani!";
            }
            catch (Exception ex)
            {
                tb_eredmeny.Text = $"Hiba történt: {ex.Message}";
            }
        }

        private void Szamosszead(double a, double b)
        {
            tb_eredmeny.Text = $"Az {a} + {b} = {a + b}";
        }
        private void Szamkivon(double a, double b)
        {
            tb_eredmeny.Text = $"Az {a} - {b} = {a - b}";
        }
        private void Szamszoroz(double a, double b)
        {
            tb_eredmeny.Text = $"Az {a} * {b} = {a * b}";
        }
        private void Szamoszt(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            tb_eredmeny.Text = $"Az {a} / {b} = {a / b}";
        }

        private void btn_8_Click(object sender, RoutedEventArgs e)
        {
            tb_eredmeny.Clear();
        }
    }
}
