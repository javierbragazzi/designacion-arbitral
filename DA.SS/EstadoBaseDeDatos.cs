using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.SS
{
    public class EstadoBaseDeDatos
    {
        public bool EsValida { get; set; }
        public List<string> RegistrosCorruptos { get; set; }

        public EstadoBaseDeDatos()
        {
            RegistrosCorruptos = new List<string>();
        }
    }
}
