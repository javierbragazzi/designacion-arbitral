using System;
using System.Collections.Generic;
using DA.SS;

namespace DA.BLL
{
    public class Idioma
    {
        private readonly DAL.Idioma _dalManagerIdioma = new DAL.Idioma();

        public Resultado Agregar(BE.Idioma pIdioma)
        {
            BLL.Traduccion bllTraduccion = new Traduccion();
            var resultado = _dalManagerIdioma.Insertar(pIdioma);

            pIdioma = ObtnerIdiomaPorNombre(pIdioma.Descripcion);

            foreach (BE.Leyenda leyenda in pIdioma.Leyendas)
            {
                leyenda.Traduccion.TextoTraducido = "Sin traducir";
                bllTraduccion.Agregar(leyenda.Traduccion, pIdioma.Id, leyenda.Id);
            }
            
            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el Idioma.");
        }

        public Resultado Editar(BE.Idioma pIdioma)
        {
            try
            {
                BLL.Leyenda bllLeyenda = new BLL.Leyenda();
                BLL.Traduccion bllTraduccion = new BLL.Traduccion();

                foreach (BE.Leyenda leyenda in pIdioma.Leyendas)
                {
                    bllTraduccion.Editar(leyenda.Traduccion);
                }

                return new Resultado(false, "Ok");
            }
            catch (Exception e)
            {
                Logger.Log.Error("No se pudo editar el Idioma.", e);
                return new Resultado(false, "No se pudo editar el Idioma.");
            }
 
        }

        public Resultado Quitar(BE.Idioma pIdioma)
        {
            ResultadoBd resultado = _dalManagerIdioma.Borrar(pIdioma);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el Idioma.");

        }

        public List<BE.Idioma> ObtenerIdiomas()
        {
            BLL.Leyenda bllLeyenda = new BLL.Leyenda();
            List<BE.Idioma> lstIdiomas = _dalManagerIdioma.Leer();

            foreach (BE.Idioma idioma in lstIdiomas)
            {
                idioma.Leyendas = bllLeyenda.ObtenerLeyendasPorIdIdioma(idioma.Id) ?? bllLeyenda.ObtenerLeyendas();
            }

            return lstIdiomas;
        }


        public BE.Idioma ObtenerIdiomaDeUsuario(int idUsuario)
        {
            BLL.Leyenda bllLeyenda = new BLL.Leyenda();
            BE.Idioma beIdioma = _dalManagerIdioma.ObtenerIdiomaDeUsuario(idUsuario);

            beIdioma.Leyendas = bllLeyenda.ObtenerLeyendasPorIdIdioma(beIdioma.Id);

            return beIdioma;

        }

        public BE.Idioma ObtnerIdiomaPorId(int idIdioma)
        {
            BLL.Leyenda bllLeyenda = new BLL.Leyenda();
            BE.Idioma beIdioma = _dalManagerIdioma.ObtenerIdiomaPorId(idIdioma);

            beIdioma.Leyendas = bllLeyenda.ObtenerLeyendasPorIdIdioma(beIdioma.Id) ?? bllLeyenda.ObtenerLeyendas();

            return beIdioma;

        }

        public BE.Idioma ObtnerIdiomaPorNombre(string nombreIdioma)
        {
            BLL.Leyenda bllLeyenda = new BLL.Leyenda();
            BE.Idioma beIdioma = _dalManagerIdioma.ObtenerIdiomaPorNombre(nombreIdioma);

            beIdioma.Leyendas = bllLeyenda.ObtenerLeyendasPorIdIdioma(beIdioma.Id) ?? bllLeyenda.ObtenerLeyendas();

            return beIdioma;

        }
    }
}
