using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120_LB2_FS17
{
    class Platz
    {
        public Int32 ID { get; set; }
        public Film Film { get; set; }
        public Int16 Reihe { get; set; }
        public Int16 Position { get; set; }
        public List<Reservation>Reservationen { get; set; }

        public Platz()
        {
            Reservationen = new List<Reservation>();
        }
        public override string ToString()
        {
            return ID.ToString();
        }

    }
}
