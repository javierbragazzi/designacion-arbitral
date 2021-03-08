using DA.BE.Composite;

namespace DA.BE
{
    [Tabla("UsuarioPermiso")]
    public class UsuarioPermiso
    {
        //public int IdPermiso
        //{
        //    [Columna("IdPermiso", "IdPermiso", typeof(int), true, true)]
        //    get;
        //    set;
        //}

        //public int IdUsuario
        //{
        //    [Columna("IdUsuario", "IdUsuario", typeof(int), true, true)]
        //    get;
        //    set;
        //}

        public PermisoComponente Permiso
        {
            [Columna("IdPermiso", "Permiso", typeof(long), true, true)]
            get;
            set;
        }

        public BE.Usuario Usuario
        {
            [Columna("IdUsuario", "Usuario", typeof(long), true, true)]
            get;
            set;
        }
    }
}
