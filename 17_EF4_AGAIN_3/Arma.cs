using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _17_EF4_AGAIN_3
{
    public class Arma
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Calibre { get; set; }
        public List<Cazador> Cazadores { get; set; }
    }
}