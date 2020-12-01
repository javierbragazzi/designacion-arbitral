using System;

namespace DA.BE
{
    public class Columna : Attribute
    {
        public string NombreAtributo { get; set; }

        public string NombreColumna { get; set; }

        public Type TipoDelValor { get; set; }

        public bool LlavePrimaria { get; set; }

        public bool Filtro { get; set; }

        public Columna(string nombreColumna, string nombreAtributo, Type tipoDelValor, bool llavePrimaria, bool filtro)
        {
            NombreColumna = nombreColumna;
            TipoDelValor = tipoDelValor;
            LlavePrimaria = llavePrimaria;
            NombreAtributo = nombreAtributo;
            Filtro = filtro;
        }


    }
}
