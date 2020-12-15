using System;
using System.Collections.Generic;
using DA.BE;
using DA.BE.Composite;
using DA.SS;

namespace DA.BLL
{
    public class Usuario
    {
        private readonly DAL.Usuario _dalManagerUsuario = new DAL.Usuario();

        private readonly BLL.DVV _bllDvv = new BLL.DVV();

        private readonly string USUARIO_SERVICIO = "servicio";
        private readonly string PASS_USUARIO_SERVICIO = "servicio1";

        public Resultado Agregar(BE.Usuario pUsuario, int idPermiso)
        {
            pUsuario.Password = Encriptador.EncriptarCadena(pUsuario.Password);

            pUsuario.DVH = GenerarDvh(pUsuario);

            var resultado = _dalManagerUsuario.Insertar(pUsuario);

            if (resultado == ResultadoBd.OK)
            {
                var usuarioBase = _dalManagerUsuario.ObtenerUsuarioPorNombreDeUsuario(pUsuario.NombreUsuario);

                usuarioBase.DVH = GenerarDvh(usuarioBase);

                _dalManagerUsuario.Actualizar(usuarioBase);

                BLL.UsuarioPermiso bllUsuarioPermiso = new UsuarioPermiso();

                bllUsuarioPermiso.Agregar(new BE.UsuarioPermiso() {IdPermiso = idPermiso, IdUsuario = usuarioBase.Id});

                if (ActualizarDvv() == ResultadoBd.OK)
                    return new Resultado(false, "Ok"); 
                else
                {
                    Logger.Log.Error("Error al actualizar el DVV de la tabla usuario.");
                    return new Resultado(true, "Error al actualizar el DVV de la tabla usuario.");
                }
            }

            return new Resultado(false, "No se dio de alta el usuario.");
        }

        public ResultadoBd Editar(BE.Usuario pUsuario)
        {
            pUsuario.DVH = GenerarDvh(pUsuario);

            ResultadoBd resultado = _dalManagerUsuario.Actualizar(pUsuario); 
            
            if (resultado == ResultadoBd.OK)
            {
                if (ActualizarDvv() == ResultadoBd.OK)
                    return ResultadoBd.OK;

                Logger.Log.Error("Error al actualizar el DVV de la tabla usuario.");
            }


            return resultado;
        }

        public ResultadoBd Quitar(BE.Usuario pUsuario)
        {
            pUsuario.DVH = GenerarDvh(pUsuario);

            ResultadoBd resultado = _dalManagerUsuario.Borrar(pUsuario);
            
            if (resultado == ResultadoBd.OK)
            {
                if (ActualizarDvv() == ResultadoBd.OK)
                    return ResultadoBd.OK;

                Logger.Log.Error("Error al actualizar el DVV de la tabla usuario.");
            }


            return resultado;

        }

        public List<BE.Usuario> ObtenerUsuarios()
        {
            BLL.Idioma bllIdioma = new BLL.Idioma();
            BLL.Permiso bllPermiso = new BLL.Permiso();
            List<BE.Usuario> usuarios = _dalManagerUsuario.Leer();

            foreach (BE.Usuario usuario in usuarios)
            {
                usuario.Permisos = bllPermiso.ObtenerPermisosDeUsuario(usuario.Id);

                usuario.Idioma = bllIdioma.ObtenerIdiomaDeUsuario(usuario.Id);
            }

            return usuarios;
        }

        public BE.Usuario ObtenerUsuarioPorNombreDeUsuario(string nombreUsuario)
        {
            BLL.Idioma bllIdioma = new BLL.Idioma();
            BLL.Permiso bllPermiso = new BLL.Permiso();
            var aUsuario = _dalManagerUsuario.ObtenerUsuarioPorNombreDeUsuario(nombreUsuario);

            if (aUsuario != null)
            {
                aUsuario.Permisos = bllPermiso.ObtenerPermisosDeUsuario(aUsuario.Id);

                aUsuario.Idioma = bllIdioma.ObtenerIdiomaDeUsuario(aUsuario.Id);

            }

            return aUsuario;
          
        }

        public BE.Usuario ObtenerUsuarioPorId(int id)
        {
            BLL.Idioma bllIdioma = new BLL.Idioma();
            BLL.Permiso bllPermiso = new BLL.Permiso();
            var aUsuario = _dalManagerUsuario.ObtenerUsuarioPorId(id);

            aUsuario.Permisos = bllPermiso.ObtenerPermisosDeUsuario(aUsuario.Id);

            aUsuario.Idioma = bllIdioma.ObtenerIdiomaDeUsuario(aUsuario.Id);

            return aUsuario;
        }

        public Resultado IniciarSesion(BE.Usuario usuario, EstadoBaseDeDatos estadoBaseDeDatos)
        {
            BLL.Bitacora bllBitacora = new BLL.Bitacora();

            if (String.IsNullOrEmpty(usuario.NombreUsuario) || String.IsNullOrEmpty(usuario.Password))
                return new Resultado(true, "Debe ingresar el usuario y la contraseña", TipoMensaje.NORMAL, "Campos vacios");

            if (estadoBaseDeDatos.EsValida)
            {

                BE.Usuario usuarioBase = ObtenerUsuarioPorNombreDeUsuario(usuario.NombreUsuario);

                if (usuarioBase != null)
                {

                    if (Encriptador.ValidarCadena(usuario.Password, usuarioBase.Password))
                    {
                        ManejadorSesion manejadorSesion = ManejadorSesion.Instancia;

                        bllBitacora.GrabarBitacora(usuarioBase, "Inicio de sesión", TipoEvento.MENSAJE);

                        manejadorSesion.EstablecerSesion(usuarioBase, estadoBaseDeDatos);

                        return new Resultado(false, "Ok");
                    }

                    return new Resultado(true, "Usuario o contraseña incorrectos", TipoMensaje.ERROR, "Error");
                }

                return new Resultado(true, "Usuario o contraseña incorrectos", TipoMensaje.ERROR, "Error");
            }
            else
            {
                if (usuario.NombreUsuario.Equals(USUARIO_SERVICIO) && usuario.Password.Equals(PASS_USUARIO_SERVICIO))
                {
                    BE.Usuario beUsuario = new BE.Usuario();

                    beUsuario.NombreUsuario = USUARIO_SERVICIO;
                    beUsuario.Password = PASS_USUARIO_SERVICIO;
                    
                    ManejadorSesion.Instancia.EstablecerSesion(beUsuario, estadoBaseDeDatos);

                    return new Resultado(false, "Ok");
                }
                else
                {
                    return new Resultado(true, "Usuario o contraseña incorrectos", TipoMensaje.ERROR, "Error");
                }
            }
        }

        public bool CerrarSesion(BE.Usuario usuario)
        {
            if (usuario != null)
            {
                ManejadorSesion manejadorSesion = ManejadorSesion.Instancia;

                if (usuario.NombreUsuario.Equals(manejadorSesion.ObtenerSesion().Usuario.NombreUsuario))
                {
                    manejadorSesion.BorrarSesion();

                    return true;
                }

                return false;
            }

            return false;
        }

        public  string GenerarDvh(BE.Usuario usuario)
        {
            return DigitoVerificador.CrearHash(usuario.Id + usuario.Apellido + usuario.Nombre + usuario.NombreUsuario +
                                               usuario.Password + (usuario.Activo == true ? "True" : "False") + usuario.Idioma.Id);
        }

  
        public ResultadoBd ActualizarDvv()
        {
            List<string> lstDvh = ObtenerDvh(ObtenerUsuarios());

            Tabla atributoTabla = (Tabla)Attribute.GetCustomAttribute(new BE.Usuario().GetType(), typeof(Tabla));

            return _bllDvv.ActualizarDvvDeTabla(atributoTabla.Nombre, lstDvh);
        }

        private List<string> ObtenerDvh(List<BE.Usuario> lstUsuarios)
        {
            List<string> lstDvh = new List<string>();

            foreach (BE.Usuario usuario in lstUsuarios)
            {
                lstDvh.Add(usuario.DVH);
            }

            return lstDvh;
        }

        public Resultado ActualizarPermisos(BE.Usuario usuario)
        {
            try
            {
                BLL.Permiso bllPermiso = new BLL.Permiso();
                BLL.UsuarioPermiso bllUsuarioPermiso = new BLL.UsuarioPermiso();

                List<PermisoComponente> permisosOriginales = bllPermiso.ObtenerPermisosDeUsuario(usuario.Id);

                foreach (PermisoComponente permiso in usuario.Permisos)
                {
                    if (!bllPermiso.TienePermiso(permiso.Id, permisosOriginales))
                        bllUsuarioPermiso.Agregar(new BE.UsuarioPermiso() { IdPermiso = permiso.Id, IdUsuario = usuario.Id });
                }

                foreach (PermisoComponente permiso in permisosOriginales)
                {
                    if (!bllPermiso.TienePermiso(permiso.Id, usuario.Permisos))
                        bllUsuarioPermiso.Quitar(new BE.UsuarioPermiso() { IdPermiso = permiso.Id, IdUsuario = usuario.Id });
                }

                return new Resultado(false, "Permisos actualizados correctamente", TipoMensaje.CORRECTO, "Actualizar permisos");
            }
            catch (Exception e)
            {
                return new Resultado(true, "Error al actualizar los permisos", TipoMensaje.ERROR, "Actualizar permisos");
            }



        }
    }
}
