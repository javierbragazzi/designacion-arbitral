namespace DA.BE
{
    [Tabla("UsuarioPermiso")]
    public class UsuarioPermiso
    {
        public int IdPermiso
        {
            [Columna("IdPermiso", "IdPermiso", typeof(int), true, true)]
            get;
            set;
        }

        public int IdUsuario
        {
            [Columna("IdUsuario", "IdUsuario", typeof(int), true, true)]
            get;
            set;
        }
    }
}
