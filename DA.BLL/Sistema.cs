using System.Data;
using DA.SS;

namespace DA.BLL
{
    public class Sistema
    {
        private readonly DAL.Sistema _dalSistema = new DAL.Sistema();

        public DataTable LeerTablaPorNombre(string nombre)
        {
            return _dalSistema.LeerTablaPorNombre(nombre);
        }


        public bool Backup(string nombreBase, string directorio, string nombreArchivo)
        {
            bool retorno = false;

            ResultadoBd resultado = _dalSistema.Backup(nombreBase, directorio, nombreArchivo);

            switch (resultado)
            {
                case ResultadoBd.OK:
                    retorno = true;
                    break;

                case ResultadoBd.ERROR:
                    retorno = false;
                    break;
            }

            return retorno;
        }

        public bool Restore(string nombreBase, string directorio, string nombreArchivo)
        {
            bool retorno = false;

            ResultadoBd resultado = _dalSistema.Restore(nombreBase, directorio, nombreArchivo);

            switch (resultado)
            {
                case ResultadoBd.OK:
                    retorno = true;
                    break;

                case ResultadoBd.ERROR:
                    retorno = false;
                    break;
            }

            return retorno;
        }
    }
}
