﻿using System;
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
            selectedid++;
            datenAbfragen(selectedid);
        }
        public Detailview(int column, int row)
        {
            InitializeComponent();
            int selectedid = getId(column, row);
            Console.WriteLine(selectedid);
            if (selectedid != 0)
            {
                datenAbfragen(selectedid);
            }else
            {
                fillFilminCB();
            }

        }
        private void datenAbfragen(int selectedid)
        {
   
            Reservation reservation = Bibliothek.Reservation_nach_ID(selectedid);

            fillFilminCB();

            lblId.Content = reservation.ID;
            tbKunde.Text = reservation.Kunde;
            tbPlatzPos.Text = Convert.ToString(reservation.Platz.Position);
            tbPlatzReihe.Text = Convert.ToString(reservation.Platz.Reihe);
            cbFilm.SelectedIndex = cbFilm.Items.IndexOf(reservation.Film.Name);
            tbDatum.Text = Convert.ToString(reservation.Datum);
        }
        private void fillFilminCB()
        {
            foreach (Film film in Bibliothek.Film_Alle())
            {
                cbFilm.Items.Add(film.Name);
            }
        }

        private void speichern_Click(object sender, RoutedEventArgs e)
        {
            Reservation reservation = new Reservation();

            reservation.ID = Convert.ToInt16(lblId.Content);
            reservation.Kunde = tbKunde.Text;
            reservation.Film = Bibliothek.Film_nach_Name(Convert.ToString(cbFilm.SelectedItem));
            reservation.Platz = Bibliothek.Platz_nach_PosRes(Convert.ToInt16(tbPlatzPos.Text), Convert.ToInt16(tbPlatzReihe.Text));
            reservation.Datum = Convert.ToDateTime(tbDatum.Text);
            Console.WriteLine("Platz:" + tbPlatzPos.Text + " + " + tbPlatzReihe.Text);
            Bibliothek.Reservation_Neu(reservation);

            zeigeListe();
        }

        private void zeigeListe()
        {
            Listview liste = new Listview();
            liste.HorizontalAlignment = HorizontalAlignment.Left;
            liste.VerticalAlignment = VerticalAlignment.Top;
            inhalt.Children.Clear();
            inhalt.Children.Add(liste);
        }
        private int getId(int column, int row)
        {
            Platz place = Bibliothek.Platz_nach_PosRes(column, row);
            if (place == null)
            {
                return 0;
            }

            Reservation reservation = Bibliothek.Reservation_nach_Platz(place);

            if (reservation == null)
            {
                return 0;
            }
            return reservation.ID;
        }
    }
}
