using System.Collections.Generic;

namespace DA.BE.Composite
{
    public class Permiso : PermisoComponente
    {
        public Permiso(string descripcion) : base(descripcion)
        {

        }

        public Permiso() : base()
        {

        }

        public override void Agregar(PermisoComponente permisoComponente)
        {
      
        }

        public override void Eliminar(PermisoComponente permisoComponente)
        {
           
        }

        public override List<PermisoComponente> ObtenerHijos()
        {
            return new List<PermisoComponente>();
        }

 
    }
}
