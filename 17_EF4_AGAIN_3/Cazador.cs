using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _17_EF4_AGAIN_3
{
    public class Cazador
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public Arma Arma { get; set; }
    }
}