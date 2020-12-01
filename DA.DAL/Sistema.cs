using System;
using System.Data;
using DA.SS;

namespace DA.DAL
{
    public class Sistema
    {
        /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        public DataTable LeerTablaPorNombre(string nombreTabla)
        {
            string query = @"SELECT * FROM " + nombreTabla;
            
            DataTable dt = _accesoBaseDeDatos.Seleccionar(query);

            return dt;
        }

        public ResultadoBd Backup(string nombreBase, string directorio, string nombreArchivo)
        {
            string query = @"USE MASTER BACKUP DATABASE " + nombreBase + " TO DISK = '" + directorio + @"\" + nombreArchivo + ".bak'";

            return _accesoBaseDeDatos.Ejecutar(query);
            
        }

        public ResultadoBd Restore(string nombreBase, string directorio, string nombreArchivo)
        {
            ResultadoBd resultado = ResultadoBd.OK;

            try
            {
                string query = "USE MASTER \n";
                query += "ALTER DATABASE " + nombreBase + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE \n";
                query += "DROP DATABASE " + nombreBase + " \n";
                query += "RESTORE DATABASE " + nombreBase + " FROM DISK = '" + directorio + nombreArchivo + "' WITH REPLACE;";

                return _accesoBaseDeDatos.Ejecutar(query);
            }
            catch (Exception ex)
            {
                resultado = ResultadoBd.ERROR;
            }

            return resultado;
        }

        //public ResultadoBd ActualizarGenerico(string nombreTabla, DataTable dataTable)
        //{
        //    return _accesoBaseDeDatos.Actualizar(nombreTabla, dataTable);
        //}
    }
}
