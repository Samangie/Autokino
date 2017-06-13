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
            //datenBereitstellen();
        }

        

        private void zeigeListe_Click(object sender, RoutedEventArgs e)
        {
            Listview liste = new Listview();
            liste.HorizontalAlignment = HorizontalAlignment.Left;
            liste.VerticalAlignment = VerticalAlignment.Top;
            inhalt.Children.Clear();
            inhalt.Children.Add(liste);
        }

        private void zeigeOverview_Click(object sender, RoutedEventArgs e)
        {
            Overview overview = new Overview();
            overview.HorizontalAlignment = HorizontalAlignment.Left;
            overview.VerticalAlignment = VerticalAlignment.Top;
            inhalt.Children.Clear();
            inhalt.Children.Add(overview);
        }

        private void addFilm_Click(object sender, RoutedEventArgs e)
        {
            String filmname = tbfilm.Text;
            Film film = new Film();
            film.Name = filmname;
            Bibliothek.Film_Neu(film);

            tbfilm.Clear();

        }
    }
}
