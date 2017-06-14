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
    /// Interaktionslogik für Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        int column, row;
        public Menu()
        {
            InitializeComponent();
        }
        public Menu(int column, int row)
        {
            this.column = column;
            this.row = row;
            InitializeComponent();
            loadOverview();
       
        }

        private void showList_Click(object sender, RoutedEventArgs e)
        {
            int counterRes = 0;
            foreach (Reservation reservation in Bibliothek.Reservation_Alle())
            {
                counterRes++;
            }
            if (counterRes != 0)
            {
                Listview liste = new Listview();
                liste.HorizontalAlignment = HorizontalAlignment.Left;
                liste.VerticalAlignment = VerticalAlignment.Top;
                inhaltmenu.Children.Clear();
                inhaltmenu.Children.Add(liste);
            }else
            {
                MessageBox.Show("Bitte erstellen Sie eine Reservation!");
            }   

        }

        private void showOverview_Click(object sender, RoutedEventArgs e)
        {
            loadOverview();
        }

        private void addFilm_Click(object sender, RoutedEventArgs e)
        {
            CreateFilm film = new CreateFilm();
            film.HorizontalAlignment = HorizontalAlignment.Left;
            film.VerticalAlignment = VerticalAlignment.Top;
            inhaltmenu.Children.Clear();
            inhaltmenu.Children.Add(film);
        }

        private void loadOverview()
        {
            Overview overview = new Overview(column, row);
            overview.HorizontalAlignment = HorizontalAlignment.Left;
            overview.VerticalAlignment = VerticalAlignment.Top;
            inhaltmenu.Children.Clear();
            inhaltmenu.Children.Add(overview);
        }
    }
}
