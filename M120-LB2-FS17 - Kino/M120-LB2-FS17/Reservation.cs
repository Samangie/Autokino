using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120_LB2_FS17
{
    class Reservation
    {
        public Int32 ID { get; set; }
        public DateTime Datum { get; set; }
        public String Kunde { get; set; }
        public Film Film { get; set; }
        public Platz Platz { get; set; }
        public Reservation()
        {

        }
        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
