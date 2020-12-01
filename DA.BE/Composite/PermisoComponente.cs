using System.Collections.Generic;

namespace DA.BE.Composite
{

    [Tabla("Permiso")]
    public abstract class PermisoComponente : EntidadBase
    {
        public string Descripcion
        {
            [Columna("Descripcion", "Descripcion", typeof(string), false, false)]
            get;
            set;
        }

        public bool? EsPermiso
        {
            [Columna("EsPermiso", "EsPermiso", typeof(bool?), false, false)]
            get;
            set;
        }

        protected PermisoComponente()
        {

        }

        protected PermisoComponente(string descripcion)
        {
            Descripcion = descripcion;
        }

        public abstract void Agregar(PermisoComponente permisoComponente);

        public abstract void Eliminar(PermisoComponente permisoComponente);

        public abstract List<PermisoComponente> ObtenerHijos();

        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
