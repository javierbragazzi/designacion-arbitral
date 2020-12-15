using System;
using System.Collections.Generic;
using System.Data;
using DA.SS;

namespace DA.DAL
{
    public class Traduccion
    {
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        public ResultadoBd Insertar(BE.Traduccion pTraduccion, int idIdioma, int idLeyenda)
        {
            string query = string.Format(@"INSERT INTO TRADUCCION([IdIdioma],[IdLeyenda],[TextoTraducido]) VALUES('{0}','{1}','{2}')",
                            idIdioma,
                            idLeyenda,
                            pTraduccion.TextoTraducido
            );

            return _accesoBaseDeDatos.Ejecutar(query);

        }

        public ResultadoBd Actualizar(BE.Traduccion pTraduccion)
        {
            return _accesoBaseDeDatos.Actualizar(pTraduccion);
        }

        public ResultadoBd Borrar(BE.Traduccion pTraduccion)
        {
            return _accesoBaseDeDatos.Borrar(pTraduccion);
        }

        public List<BE.Traduccion> Leer()
        {
            var ls = new List<BE.Traduccion>();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.Traduccion(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aTraduccion = new BE.Traduccion
                {
                    Id = Convert.ToInt32(row["Id"]),
                    TextoTraducido = row["TextoTraducido"].ToString().Trim(),
                };

                ls.Add(aTraduccion);
            }

            return ls;
        }
    }
    
}
