using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BE
{
    public class Tabla : Attribute
    {
        public string Nombre { get; set; }

        public Tabla(string nombre)
        {
            Nombre = nombre;
        }
    
    }
}
