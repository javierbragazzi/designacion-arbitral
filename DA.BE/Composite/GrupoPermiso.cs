using System.Collections.Generic;

namespace DA.BE.Composite
{
    public class GrupoPermiso : PermisoComponente
    {
        private readonly List<PermisoComponente> _hijos;

        public GrupoPermiso(string descripcion) : base(descripcion)
        {
            _hijos = new List<PermisoComponente>();
        }

        public GrupoPermiso() 
        {
            _hijos = new List<PermisoComponente>();
        }

        public override void Agregar(PermisoComponente permisoComponente)
        {
            _hijos.Add(permisoComponente);
        }

        public override void Eliminar(PermisoComponente permisoComponente)
        {
            _hijos.Remove(permisoComponente);
        }

        public override List<PermisoComponente> ObtenerHijos()
        {
            return _hijos;
        }
    }
}
