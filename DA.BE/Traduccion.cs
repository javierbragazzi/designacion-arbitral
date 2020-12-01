using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BE
{
    [Tabla("Traduccion")]
    public class Traduccion : EntidadBase
    {
        public string TextoTraducido
        {
            [Columna("TextoTraducido", "TextoTraducido", typeof(string), false, false)]
            get;
            set;
        }
    }
}
