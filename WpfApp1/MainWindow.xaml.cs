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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int hossz = 0;
        readonly List<string> betuk = new(){"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z" };
        readonly List<string> symbols = new() {"|","Ä","€","Í","÷","×","¤","ß","$","Ł","ł","]","[","Đ","đ","ä","<",">","#","&","@","{","}",";",".","*","-","_"};
        public MainWindow()
        {
            InitializeComponent();
            btnGenerate.Click += (s, e) =>
            {
                string jelszo = "";
                for (int i = 0; i < hossz; i++)
                {
                    Random betuVagySzamVagySymbol = new Random();
                    int szam = betuVagySzamVagySymbol.Next(1,3);
                    switch (szam)
                    {
                        case 1:
                            if (cbKissBetu.IsChecked == true || cbNagyBetu.IsChecked == true)
                            {
                                Random betu = new Random();
                                string x = betuk[betu.Next(0, betuk.Count)];
                                if (cbNagyBetu.IsChecked == true)
                                    x = x.ToUpper();

                                jelszo += x;
                            }
                            break;
                        case 2:
                            if (cbSzamok.IsChecked == true)
                            {
                                Random RandomSzam = new Random();
                                jelszo += RandomSzam.Next(0, 10);
                            }
                            break;
                        case 3:
                            if (cbSymbol.IsChecked == true)
                            {
                                Random RandomSymbol = new Random();
                                jelszo += symbols[RandomSymbol.Next(0, symbols.Count)];
                            }
                            break;
                        default:
                            break;
                    }
                }
                MessageBox.Show(jelszo);
            };
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblHossz.Content = sldCsuszka.Value;
            hossz = Convert.ToInt32(lblHossz.Content);
        }
    }
}
