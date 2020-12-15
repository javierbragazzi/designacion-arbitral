using System;

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
