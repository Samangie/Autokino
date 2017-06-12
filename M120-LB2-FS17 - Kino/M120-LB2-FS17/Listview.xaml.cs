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
    /// Interaktionslogik für Listview.xaml
    /// </summary>
    public partial class Listview : UserControl
    {

        public Listview()
        {
            InitializeComponent();
            datenAbfragen();
        }

        private void datenAbfragen()
        {
            foreach (Reservation reservation in Bibliothek.Reservation_Alle())
            {
                DataGridTest.Items.Add(reservation);
            }
        }

        private void zeigeDetail(object sender, MouseButtonEventArgs e) {

            int selectedid = DataGridTest.SelectedIndex;
            Detailview liste = new Detailview(selectedid);
            liste.HorizontalAlignment = HorizontalAlignment.Left;
            liste.VerticalAlignment = VerticalAlignment.Top;
            inhalt.Content = null;
            inhalt.Content = liste;
        }            
}
}
