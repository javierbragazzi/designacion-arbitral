using System;
using System.Collections.Generic;
using DA.BE;
using DA.SS;
using System.Linq;

namespace DA.BLL
{
    public class Bitacora
    {
        /// <summary>
        /// Dal manager Bitacora
        /// </summary>
        private readonly DAL.Bitacora _dalManagerBitacora = new DAL.Bitacora();

        /// <summary>
        /// Agrega un nuevo Bitacora al sistema.
        /// </summary>
        /// <param name="pBitacora">Bitacora a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.Bitacora pBitacora)
        {
            var resultado = _dalManagerBitacora.Insertar(pBitacora);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta la Bitacora.");
        }

        /// <summary>
        /// Edita un Bitacora.
        /// </summary>
        /// <param name="pBitacora">Bitacora a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.Bitacora pBitacora)
        {
            ResultadoBd resultado = _dalManagerBitacora.Actualizar(pBitacora);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar la Bitacora.");
        }

        /// <summary>
        /// Quita un Bitacora.
        /// </summary>
        /// <param name="pBitacora">Bitacora a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.Bitacora pBitacora)
        {
            ResultadoBd resultado = _dalManagerBitacora.Borrar(pBitacora);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar la Bitacora.");

        }

        public List<BE.Bitacora> ObtenerBitacoras()
        {
            BLL.Usuario bllUsuario = new BLL.Usuario();
            List<BE.Bitacora> bitacoras = _dalManagerBitacora.Leer();
            List<BE.Usuario> lstUsuarios = bllUsuario.ObtenerUsuarios();

            foreach (BE.Bitacora bitacora in bitacoras)
            {
                bitacora.Usuario = lstUsuarios.Find(usuario => usuario.Id == bitacora.Usuario.Id);
            }

            return bitacoras;
        }


        public int ObtenerBitacoraMaxId()
        {
            BLL.Usuario bllUsuario = new BLL.Usuario();
            List<BE.Bitacora> bitacoras = _dalManagerBitacora.Leer();
            return bitacoras.Max(x => x.Id);
        }


        public void GrabarBitacora(BE.Usuario usuario, string mensaje, TipoEvento evento)
        {
            BE.Bitacora beBitacora = new BE.Bitacora();

            beBitacora.Usuario = usuario;
            beBitacora.Descripcion = mensaje;
            beBitacora.Fecha = DateTime.Now;
            beBitacora.TipoEvento = evento;

             _dalManagerBitacora.Insertar(beBitacora);

        }
    }
}
