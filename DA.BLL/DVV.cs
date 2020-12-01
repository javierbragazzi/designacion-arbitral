using System;
using System.Collections.Generic;
using System.Data;
using DA.SS;

namespace DA.BLL
{
    /// <summary>
    /// Clase BLL de DVV
    /// </summary>
    public class DVV
    {
        /// <summary>
        /// Dal manager DVV
        /// </summary>
        private readonly DAL.DVV _dalManagerDvv = new DAL.DVV();

        /// <summary>
        /// Agrega un nuevo DVV al sistema.
        /// </summary>
        /// <param name="pDvv">DVV a agregar.</param>
        /// <returns></returns>
        public ResultadoBd Agregar(BE.DVV pDvv)
        {
            return _dalManagerDvv.Insertar(pDvv);
        }

        /// <summary>
        /// Edita un DVV.
        /// </summary>
        /// <param name="pDvv">DVV a editar.</param>
        /// <returns></returns>
        public ResultadoBd Editar(BE.DVV pDvv)
        {
            return _dalManagerDvv.Actualizar(pDvv);
        }

        /// <summary>
        /// Quita un DVV.
        /// </summary>
        /// <param name="pDvv">DVV a quitar.</param>
        /// <returns></returns>
        public ResultadoBd Quitar(BE.DVV pDvv)
        {
            return _dalManagerDvv.Borrar(pDvv);
        }

        /// <summary>
        /// Obtiene todos los DVVs.
        /// </summary>
        /// <returns></returns>
        public List<BE.DVV> ObtenerLosDvv()
        {
            return _dalManagerDvv.Leer();
        }

        /// <summary>
        /// Obtiene un DVV por nombre de tabla.
        /// </summary>
        /// <param name="nombreDvv">The nombre DVV.</param>
        /// <returns></returns>
        public BE.DVV ObtenerDvvPorNombreDeTabla(string nombreDvv)
        {
            var aDvv = _dalManagerDvv.ObtenerDVVPorNombreDeTabla(nombreDvv);

            return aDvv;
        }


        public ResultadoBd ActualizarDvvDeTabla(string nombreTabla, List<string> lstDvh)
        {
            string dvvNuevo = null;

            foreach (string dvh in lstDvh)
            {
                dvvNuevo += dvh;
            }

            dvvNuevo = DigitoVerificador.CrearHash(dvvNuevo);

            BE.DVV dvvBase = ObtenerDvvPorNombreDeTabla(nombreTabla);

            if (dvvBase != null)
                dvvBase.Valor = dvvNuevo;
            else
            {
                dvvBase = new BE.DVV {NombreTabla = nombreTabla, Valor = dvvNuevo};

                return Agregar(dvvBase);

            }


            return Editar(dvvBase);
        }

        public EstadoBaseDeDatos ValidarBasedeDatos(bool resultado)
        {
            return new EstadoBaseDeDatos() {EsValida = resultado, RegistrosCorruptos = new List<string>()};
        }

        public EstadoBaseDeDatos ValidarBasedeDatos()
        {
            BLL.Sistema bllSistema = new BLL.Sistema();
            EstadoBaseDeDatos resultado = new EstadoBaseDeDatos();

            try
            {
                string todosLosDvh = null;
                resultado.EsValida = true;

                //CALCULO DE TODOS LOS DVH
                //Obtengo todos los nombres de las tablas de la base de datos
                List<string> nombresDeTablas = ObtenerNombresDeTablas();

                foreach (string nombreTabla in nombresDeTablas)
                {
                    //Obtengo el contenido de la tabla actual
                    DataTable tabla = bllSistema.LeerTablaPorNombre(nombreTabla);
                    string dvvCalculado = "";
                    bool tablaValida = true;

                    for (int row = 0; row <= tabla.Rows.Count - 1; row++)
                    {
                        //Calculo el DVH 
                        string dvhCalculado = DigitoVerificador.CalcularDvhDeFila(tabla, row);

                        todosLosDvh = todosLosDvh + dvhCalculado;

                        if (!tabla.Rows[row]["DVH"].ToString().Equals(dvhCalculado))
                        {
                            //Si el DVH guardado en la base es distinto al DVH recien calculado
                            //indica que hubo una modificacion del registro, sin actualizar el DVH
                            resultado.RegistrosCorruptos.Add("Error de integridad en la tabla -" + nombreTabla +
                                                             "- en el registro " + tabla.Rows[row][0].ToString());
                            resultado.EsValida = false;
                            tablaValida = false;

                        }

                        dvvCalculado += tabla.Rows[row]["DVH"].ToString();
                    }

                    if (tablaValida)
                    {
                        BE.DVV aDvv = _dalManagerDvv.ObtenerDVVPorNombreDeTabla(nombreTabla);
                        dvvCalculado = DigitoVerificador.CrearHash(dvvCalculado);

                        resultado.EsValida = dvvCalculado.Equals(aDvv.Valor);

                        if (!resultado.EsValida)
                        {
                            resultado.RegistrosCorruptos.Add(
                                "Error de integridad en la tabla -" + nombreTabla + "-. DVV vertical corrupto");
                        }
                    }

                }
                
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Error al validar la integridad de la base.", ex);
                resultado.RegistrosCorruptos.Add("No se pudo validar la integridad de la base.");
                resultado.EsValida = false;

                return resultado;
            }

            return resultado;
        }

        private List<string> ObtenerNombresDeTablas()
        {
            List<string> lstTablas = new List<string>();

            var lstDvv = _dalManagerDvv.Leer();

            foreach (BE.DVV dvv in lstDvv)
            {
                lstTablas.Add(dvv.NombreTabla);
            }

            return lstTablas;
        }
    }
}
