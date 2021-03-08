using System;

namespace DA.BE
{
    [Serializable]
    [Tabla("Bitacora")]
    public class Bitacora : EntidadBase
    {
        public Usuario Usuario
        {
            [Columna("IdUsuario", "Usuario", typeof(long), false, false)]
            get;
            set;
        }

        public BE.TipoEvento TipoEvento
        {
            [Columna("IdTipoEvento", "TipoEvento", typeof(long), false, false)]
            get;
            set;
        }

        public string Descripcion
        {
            [Columna("Descripcion", "Descripcion", typeof(string), false, false)]
            get;
            set;
        }

        public DateTime Fecha
        {
            [Columna("Fecha", "Fecha", typeof(DateTime), false, false)]
            get;
            set;
        }

        public Bitacora()
        {
            TipoEvento = new TipoEvento(){Id = 1, Descripcion = "NULO"};
        }
    }
}
