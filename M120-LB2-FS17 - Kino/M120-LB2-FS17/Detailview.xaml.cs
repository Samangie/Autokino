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
    /// Interaktionslogik für Detailview.xaml
    /// </summary>
    public partial class Detailview : UserControl
    {
        public Detailview(int selectedid)
        {
            InitializeComponent();
            datenAbfragen(selectedid);
        }
        private void datenAbfragen(int selectedid)
        {
            selectedid++;
            Reservation reservation = Bibliothek.Reservation_nach_ID(selectedid);

            foreach (Film film in Bibliothek.Film_Alle())
            {
                cbFilm.Items.Add(film.Name);
            }

            lblId.Content = reservation.ID;
            tbKunde.Text = reservation.Kunde;
            tbPlatzPos.Text = Convert.ToString(reservation.Platz.Position);
            tbPlatzReihe.Text = Convert.ToString(reservation.Platz.Reihe);
            cbFilm.SelectedIndex = cbFilm.Items.IndexOf(reservation.Film.Name);
            tbDatum.Text = Convert.ToString(reservation.Datum);
        }

        private void speichern_Click(object sender, RoutedEventArgs e)
        {
            Bibliothek.Reservation_Update(Convert.ToInt16(lblId.Content), tbKunde.Text, tbPlatzPos.Text, tbPlatzReihe.Text, cbFilm.SelectedItem, tbDatum.Text );
        }
    }
}
