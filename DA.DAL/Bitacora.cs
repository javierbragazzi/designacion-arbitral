using System;
using System.Collections.Generic;
using System.Data;
using DA.BE;
using DA.SS;

namespace DA.DAL
{
    public class Bitacora
    {
        /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un Bitacora.
        /// </summary>
        /// <param name="pBitacora">Bitacora.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.Bitacora pBitacora)
        {
            ResultadoBd resultado = _accesoBaseDeDatos.Insertar(pBitacora);

            if (resultado == ResultadoBd.ERROR)
            {
                Serializer.XmlSerialization(pBitacora, "Bitacora-" + pBitacora.Fecha.ToFileTime());
            }

            return resultado;
        }


        /// <summary>
        /// Actualiza un Bitacora.
        /// </summary>
        /// <param name="pBitacora">Bitacora.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.Bitacora pBitacora)
        {
            return _accesoBaseDeDatos.Actualizar(pBitacora);
        }

        /// <summary>
        /// Borra un Bitacora.
        /// </summary>
        /// <param name="pBitacora">Bitacora.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.Bitacora pBitacora)
        {
            return _accesoBaseDeDatos.Borrar(pBitacora);
        }

        public List<BE.Bitacora> Leer()
        {
            var ls = new List<BE.Bitacora>();

            BE.Bitacora beBitacora = new BE.Bitacora();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.Bitacora(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aBitacora = new BE.Bitacora
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Usuario = new BE.Usuario() { Id = Convert.ToInt32(row["IdUsuario"]) },
                    TipoEvento = new BE.TipoEvento(){ Id = Convert.ToInt32(row["IdTipoEvento"])},
                    Descripcion = row["Descripcion"].ToString().Trim(),
                    Fecha = Convert.ToDateTime((row["Fecha"]))
                };


                ls.Add(aBitacora);
            }

            return ls;
        }

        public int ObtenerMaxId()
        {
            var ls = new List<BE.Bitacora>();

            BE.Bitacora beBitacora = new BE.Bitacora();

            DataTable dt = _accesoBaseDeDatos.ObtenerTabla("SELECT MAX(ID) FROM BITACORA");
            if (dt?.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0][0].ToString());
            }
            return 0;
        }

        //private TipoEvento ResolverTipoEvento(string tipoEvento)
        //{
        //    switch (tipoEvento)
        //    {
        //        case "MENSAJE":
        //            return TipoEvento.MENSAJE;
        //        break;

        //        case "ERROR":
        //            return TipoEvento.ERROR;
        //            break;

        //        case "ADVERTENCIA":
        //            return TipoEvento.ADVERTENCIA;
        //            break;
         
        //        default:
        //            return TipoEvento.MENSAJE;  
        //    }
        //}
    }
}
