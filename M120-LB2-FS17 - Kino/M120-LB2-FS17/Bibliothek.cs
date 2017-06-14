using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120_LB2_FS17
{
    static class Bibliothek
    {
        private static List<Platz> Platz { get; set; } = new List<M120_LB2_FS17.Platz>();
        private static List<Film> Film { get; set; } = new List<M120_LB2_FS17.Film>();
        private static List<Reservation> Reservation { get; set; } = new List<M120_LB2_FS17.Reservation>();

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
            return (from element in Film where element.Name == filmname select element).FirstOrDefault();
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
            if (reservation.ID == 0 )
            {
                reservation.ID = IDReservation;
                IDReservation++;
                if (checkPos(reservation.Platz.ID, reservation.Film.Name, reservation.Datum, IDReservation))
                {
                    Reservation.Add(reservation);
                    // Nachtragen Film
                    Film_nach_ID(reservation.Film.ID).Reservationen.Add(reservation);
                    // Nachtragen Platz
                    Platz_nach_ID(reservation.Platz.ID).Reservationen.Add(reservation);
                }

            }
            else
            {
                Reservation selctedRes = (from element in Reservation where element.ID == reservation.ID select element).FirstOrDefault();
                if (selctedRes != null)
                {
                    selctedRes.Kunde = reservation.Kunde;
                    selctedRes.Platz = reservation.Platz;
                    selctedRes.Film = reservation.Film;
                    selctedRes.Datum = reservation.Datum;
                }
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
        public static Reservation Reservation_nach_Platz(Platz platz)
        {
            return (from element in Reservation where element.Platz == platz select element).FirstOrDefault();
        }
        public static Reservation Reservation_nach_Film_Datum_Platz(Film film, DateTime datum, Platz platz)
        {
            return (from element in Reservation where element.Film == film && element.Datum == datum && element.Platz == platz select element).FirstOrDefault();
        }
        #endregion
        private static bool checkPos(int selectedPlatz, String filmname, DateTime date, int id)
        {

            Platz place = Bibliothek.Platz_nach_ID(selectedPlatz);

            Film film = Bibliothek.Film_nach_Name(filmname);

            Reservation reservation = Bibliothek.Reservation_nach_Film_Datum_Platz(film, date, place);

            if (reservation == null || reservation.ID == id)
            {
                return true;
            }
            return false;
        }
    }
}
