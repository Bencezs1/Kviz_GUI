using System;
using System.Collections.Generic;
using System.IO;
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

namespace KvizProbaGUI
{
    public delegate void ButtonClickEventHandler(object sender, RoutedEventArgs e);

    public partial class MainWindow : Window
    {
        List<Kerdes> l = new List<Kerdes>();
        int pont = 0;
        int aktualiskerdes = 0;
        Label pontLabel;
        Button newGameButton;
        void Beolvas(string fajlnev)
        {
            var be = File.ReadAllLines(fajlnev);
            foreach (var item in be)
            {
                l.Add(new Kerdes(item));
            }
        }
        void Elhelyezes(Button v1, Button v2, Button v3, Button v4, Label k)
        {
            v1.Click += ButtonClickHandler;
            v2.Click += ButtonClickHandler;
            v3.Click += ButtonClickHandler;
            v4.Click += ButtonClickHandler;

            v1.Width = 120;
            v1.Height = 70;
            v2.Width = 120;
            v2.Height = 70;
            v3.Width = 120;
            v3.Height = 70;
            v4.Width = 120;
            v4.Height = 70;
            k.Width = 555;
            k.Height = 84;

            Thickness t1 = new Thickness(89, 100, 0, 0);
            v1.Margin = t1;
            v1.HorizontalAlignment = HorizontalAlignment.Left;

            Thickness t2 = new Thickness(300, 100, 0, 0);
            v2.Margin = t2;
            v2.HorizontalAlignment = HorizontalAlignment.Left;

            Thickness t3 = new Thickness(89, 320, 0, 0);
            v3.Margin = t3;
            v3.HorizontalAlignment = HorizontalAlignment.Left;

            Thickness t4 = new Thickness(300, 320, 0, 0);
            v4.Margin = t4;
            v4.HorizontalAlignment = HorizontalAlignment.Left;

            Thickness t5 = new Thickness(38, 49, 0, 0);
            k.Margin = t5;
            k.VerticalAlignment = VerticalAlignment.Top;
            k.HorizontalAlignment = HorizontalAlignment.Left;

            pontLabel = new Label();
            pontLabel.Content = $"Pontok: {pont}";
            pontLabel.HorizontalAlignment = HorizontalAlignment.Center;
            pontLabel.VerticalAlignment = VerticalAlignment.Top;
            pontLabel.Margin = new Thickness(0, 10, 0, 0);
            mainGrid.Children.Add(pontLabel);

            mainGrid.Children.Add(v1);
            mainGrid.Children.Add(v2);
            mainGrid.Children.Add(v3);
            mainGrid.Children.Add(v4);
            mainGrid.Children.Add(k);
        } // Nem lehet a B és a D gombra kattintani

        void Ujjatek()
        {
            Button v1 = new Button();
            Button v2 = new Button();
            Button v3 = new Button();
            Button v4 = new Button();
            Label k = new Label();
            v1.Content = l[0].Valasz1;
            v2.Content = l[0].Valasz2;
            v3.Content = l[0].Valasz3;
            v4.Content = l[0].Valasz4;
            k.Content = l[0].Kerdeszoveg;
            Elhelyezes(v1, v2, v3, v4, k);
            mainGrid.Children.Remove(b);
            mainGrid.Children.Remove(newGameButton);

        }
        void Gratulacio(int pontszam)
        {
            MessageBox.Show($"Gratulálok! {pontszam} pontod lett.");
            mainGrid.Children.Clear();
            newGameButton = new Button();
            newGameButton.Content = "Új játék";
            newGameButton.Width = 50;
            newGameButton.Height = 29;
            HorizontalAlignment = HorizontalAlignment.Center; VerticalAlignment = VerticalAlignment.Center;
            newGameButton.Click += b_Click;
            Thickness buttonMargin = new Thickness(10, 10, 0, 0);
            newGameButton.Margin = buttonMargin;
            mainGrid.Children.Add(newGameButton);
        }
        void Kovetkezokerdes()
        {
            mainGrid.Children.Clear();
            Button v1 = new Button();
            Button v2 = new Button();
            Button v3 = new Button();
            Button v4 = new Button();
            Label k = new Label();
            v1.Content = l[aktualiskerdes].Valasz1;
            v2.Content = l[aktualiskerdes].Valasz2;
            v3.Content = l[aktualiskerdes].Valasz3;
            v4.Content = l[aktualiskerdes].Valasz4;
            k.Content = l[aktualiskerdes].Kerdeszoveg;
            Elhelyezes(v1, v2, v3, v4, k);
        }
        public MainWindow()
        {
            InitializeComponent();
            Beolvas("kerdesek.txt");
        }

        public void Ellenoriz(object sender, RoutedEventArgs e)
        {
            ButtonClickEventHandler handler = ButtonClickHandler;
            if (handler != null)
            {
                handler(sender, e);
            }
        }
        private void ButtonClickHandler(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            string helyes = b.Content.ToString().Split(':')[0];
            if (helyes == l[aktualiskerdes].Helyesvalasz)
            {
                pont++;
                MessageBox.Show("Helyes válasz");
            }
            else
            {
                MessageBox.Show($"Helytelen válasz. A helyes válasz a(z) {l[aktualiskerdes].Helyesvalasz}");
            }
            aktualiskerdes++;

            if (aktualiskerdes < l.Count)
            {
                Kovetkezokerdes();
            }
            else
            {
                Gratulacio(pont);
                pont = 0;
                aktualiskerdes = 0;
            }
        }
        private void b_Click(object sender, RoutedEventArgs e)
        {
            Ujjatek();
        }
    }
}
