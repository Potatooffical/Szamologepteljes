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
        private void tbx_szambeir_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double szam1 = double.Parse(tbx_szambeir1.Text);
                double szam2 = double.Parse(tbx_szambeir2.Text);
                if (string.IsNullOrWhiteSpace(tbx_szambeir1.Text) || string.IsNullOrWhiteSpace(tbx_szambeir2.Text))
                {
                    tb_eredmeny.Text = "Mindkét számot meg kell adni!";
                    return;
                }
                string muvelet = Muveletjelkivalszt();
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
                    case "√":
                        gyokkivon(szam1, szam2);
                        break;
                    case "^":
                        Hatvanykiszamol(szam1, szam2);
                        break;
                    default:
                        tb_eredmeny.Text = "Ismeretlen művelet.";
                        break;
                }
            }
            catch (DivideByZeroException ex)
            {
                tb_eredmeny.Text = ex.Message;
            }
            catch (Exception ex)
            {
                tb_eredmeny.Text = $"Hiba történt: {ex.Message}";
            }
        }
        private string Muveletjelkivalszt()
        {
            if (rd_osszead.IsChecked == true)
                return "+";
            if (rd_kivon.IsChecked == true)
                return "-";
            if (rd_szoroz.IsChecked == true)
                return "*";
            if (rd_eloszt.IsChecked == true)
                return "/";
            if (rd_gyokvon.IsChecked == true)
                return "√";
            if (rd_hatvanyoz.IsChecked == true)
                return "^";
            return "+";
        }
        private void gyokkivon(double a, double b)
        {
            tb_eredmeny.Text=$"Az √{a} és √{b}={Math.Round(Math.Sqrt(a),2)} és {Math.Round(Math.Sqrt(b), 2)}";
        }

        private void Hatvanykiszamol(double a, double b)
        {
            tb_eredmeny.Text = $"Az {a}^{b} = {Math.Round(Math.Pow(a, b), 3)}";
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
                throw new DivideByZeroException("Nullával nem lehet osztani!");
            tb_eredmeny.Text = $"Az {a} / {b} = {Math.Round(a / b),3}";
        }
        private void btn_8_Click(object sender, RoutedEventArgs e)
        {
            tb_eredmeny.Text = "";
            tbx_szambeir1.Clear();
            tbx_szambeir2.Clear();
            rd_eloszt.IsChecked = false;
            rd_gyokvon.IsChecked = false;
            rd_hatvanyoz.IsChecked = false;
            rd_kivon.IsChecked = false;
            rd_osszead.IsChecked = false;
            rd_szoroz.IsChecked = false;
        }
    }
}