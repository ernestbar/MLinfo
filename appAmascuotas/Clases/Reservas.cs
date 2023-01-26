using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appAmascuotas.Clases
{
    public class Reservas
    {
        public string pnr { get; set; }
        public string tipo { get; set; }
        public List<string> ticket { get; set; }
        public string itinerario { get; set; }
        //public class Ticket
        //{
        //    public string ticket { get; set; }
        //}
    }
}