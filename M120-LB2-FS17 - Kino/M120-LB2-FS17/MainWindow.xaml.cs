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

namespace M120_LB2_FS17
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            datenBereitstellen();
        }

        #region Testdaten
        private void datenBereitstellen()
        {
            demoDatenFilm();
            demoDatenPlaetze();
            demoDatenReservationen();
        }
        private void demoDatenFilm()
        {
            Film f1 = new Film();
            f1.Name = "Film 1";
            Bibliothek.Film_Neu(f1);
            Film f2 = new Film();
            f2.Name = "Film 2";
            Bibliothek.Film_Neu(f2);
        }
        private void demoDatenPlaetze()
        {
            Platz p11 = new Platz();
            p11.Reihe = 1;
            p11.Position = 1;
            p11.Film = Bibliothek.Film_nach_ID(1);
            Bibliothek.Platz_Neu(p11);
            Platz p12 = new Platz();
            p12.Reihe = 1;
            p12.Position = 2;
            p12.Film = Bibliothek.Film_nach_ID(1);
            Bibliothek.Platz_Neu(p12);
            Platz p21 = new Platz();
            p21.Reihe = 1;
            p21.Position = 1;
            p21.Film = Bibliothek.Film_nach_ID(2);
            Bibliothek.Platz_Neu(p21);
            Platz p22 = new Platz();
            p22.Reihe = 1;
            p22.Position = 2;
            p22.Film = Bibliothek.Film_nach_ID(2);
            Bibliothek.Platz_Neu(p22);
        }
        private void demoDatenReservationen()
        {
            Reservation r11 = new Reservation();
            r11.Kunde = "Kunde 1";
            r11.Datum = new DateTime(2017, 8, 1);
            r11.Platz = Bibliothek.Platz_nach_ID(1);
            r11.Film = Bibliothek.Platz_nach_ID(1).Film;
            Bibliothek.Reservation_Neu(r11);

            Reservation r21 = new Reservation();
            r21.Kunde = "Kunde 2";
            r21.Datum = new DateTime(2017, 8, 2);
            r21.Platz = Bibliothek.Platz_nach_ID(3);
            r21.Film = Bibliothek.Platz_nach_ID(3).Film;
            Bibliothek.Reservation_Neu(r21);
        }
        #endregion

        private void addFilm_Click(object sender, RoutedEventArgs e)
        {
            String filmname = tbfilm.Text;
            Film film = new Film();
            film.Name = filmname;
            Bibliothek.Film_Neu(film);

            loadKinoConfig();

        }

        private void loadKinoConfig()
        {
            KinoConfig kinoConfig = new KinoConfig();
            kinoConfig.HorizontalAlignment = HorizontalAlignment.Left;
            kinoConfig.VerticalAlignment = VerticalAlignment.Top;
            inhalt.Children.Clear();
            inhalt.Children.Add(kinoConfig);
        }
    }
}
