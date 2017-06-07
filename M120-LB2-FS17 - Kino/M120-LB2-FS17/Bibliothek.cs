using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120_LB2_FS17
{
    static class Bibliothek
    {
        private static List<Platz> Platz { get; set; }
        private static List<Film> Film { get; set; }
        private static List<Reservation> Reservation { get; set; }

        private static Int32 IDPlatz = 1;
        private static Int32 IDFilm = 1;
        private static Int32 IDReservation = 1;

        #region Film       
        public static void Film_Neu(Film film)
        {
            if(Film == null)
            {
                Film = new List<M120_LB2_FS17.Film>();
            }
            if (film.ID == 0)
            {
                film.ID = IDFilm;
                IDFilm++;
            }
            Film.Add(film);
        }
        public static List<Film>Film_Alle()
        {
            return Film;
        }
        public static Film Film_nach_Name(String filmname)
        {
            return Film selctedRes = (from element in Film where element.Name == filmname select element).FirstOrDefault();
        }
        public static Film Film_nach_ID(Int32 id)
        {
            return (from element in Film where element.ID == id select element).FirstOrDefault();
        }
        #endregion
        #region Platz
        public static void Platz_Neu(Platz platz)
        {
            if (Platz == null)
            {
                Platz = new List<M120_LB2_FS17.Platz>();
            }
            if (platz.ID == 0)
            {
                platz.ID = IDPlatz;
                IDPlatz++;
            }
            Platz.Add(platz);
            // Film nachtragen
            Film_nach_ID(platz.Film.ID).Plaetze.Add(platz);
            
        }
        public static List<Platz> Platz_Alle()
        {
            return Platz;
        }
        public static Platz Platz_nach_PosRes(int pos, int row)
        {
            return (from element in Platz where element.Position == pos && element.Reihe == row select element).FirstOrDefault();
        }
        public static Platz Platz_nach_ID(Int32 id)
        {
            return (from element in Platz where element.ID == id select element).FirstOrDefault();
        }
        #endregion
        #region Reservation
        public static void Reservation_Neu(Reservation reservation)
        {
            if (Reservation == null)
            {
                Reservation = new List<M120_LB2_FS17.Reservation>();
            }
            if (reservation.ID == 0)
            {
                reservation.ID = IDReservation;
                IDReservation++;
            }
            Reservation.Add(reservation);
            // Nachtragen Film
            Film_nach_ID(reservation.Film.ID).Reservationen.Add(reservation);
            // Nachtragen Platz
            Platz_nach_ID(reservation.Platz.ID).Reservationen.Add(reservation);
        }

        public static void Reservation_Update(int id, String kunde, String pos, String row, String film, String date)
        {

            Reservation selctedRes = (from element in Reservation where element.ID == id select element).FirstOrDefault();
            if (selctedRes != null)
            {
                selctedRes.Kunde = kunde;
                selctedRes.Platz = Bibliothek.Platz_nach_PosRes(Convert.ToInt16(pos), Convert.ToInt16(row));
                selctedRes.Film = Bibliothek.Film_nach_Name(film);
                selctedRes.Datum = Convert.ToDateTime(date);  
            }

        }

        public static List<Reservation> Reservation_Alle()
        {
            return Reservation;
        }

        public static Reservation Reservation_nach_ID(Int32 id)
        {
            return (from element in Reservation where element.ID == id select element).FirstOrDefault();
        }
        public static List<Reservation> Reservation_nach_Film_Datum(Film film, DateTime datum)
        {
            return (from element in Reservation where element.Film == film && element.Datum == datum select element).ToList();
        }
        #endregion
    }
}
