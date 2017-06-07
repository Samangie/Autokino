using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120_LB2_FS17
{
    class Film
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public List<Reservation> Reservationen { get; set; }
        public List<Platz> Plaetze { get; set; }

        public Film()
        {
            Reservationen = new List<Reservation>();
            Plaetze = new List<Platz>();
        }
        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
