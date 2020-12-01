using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DA.BE;
using DA.BE.Composite;
using DA.SS;

namespace DA.BLL
{
    public class Permiso
    {
        private readonly DAL.Permiso _dalManagerPermiso = new DAL.Permiso();


        public bool TienePermiso(int id, List<PermisoComponente> lstPermisos)
        {
            var componente = _dalManagerPermiso.ObtenerComponente(id, lstPermisos);

            return componente != null;
        }

        public List<PermisoComponente> ObtenerPermisosDeUsuario(int idUsuario)
        {
            return _dalManagerPermiso.ObtenerPermisosDeUsuario(idUsuario);
        }

        public List<PermisoComponente> ObtenerPermisos()
        {
            return _dalManagerPermiso.ObtenerPermisos();
        }

        public bool QuitarPermiso(PermisoComponente permiso, List<PermisoComponente> permisos)
        {
            bool resultado = false;

            if (TienePermiso(permiso.Id, permisos))
            {
                if (!permisos.Remove(permiso))
                {
                    foreach (var permisoComponente in permisos)
                    {
                        if (permisoComponente.Id == permiso.Id)
                        {
                            permisoComponente.Eliminar(permiso);
                            return true;
                        }
                        else
                        {
                            resultado = QuitarPermisoHijo( permiso, permisoComponente.ObtenerHijos());
                        }

                    }
                }
                else
                    return true;

                return resultado;
            }

            return resultado;
        }

        private bool QuitarPermisoHijo(PermisoComponente permiso, List<PermisoComponente> permisos)
        {
            bool resultado = false;


            if (!permisos.Remove(permiso))
            {
                foreach (var permisoComponente in permisos)
                {
                    if (permisoComponente.Id == permiso.Id)
                    {
                        permisoComponente.Eliminar(permiso);
                        return true;
                    }
                    else
                    {
                        resultado = QuitarPermisoHijo(permiso, permisoComponente.ObtenerHijos());
                    }

                }
            }
            else
                return true;

            return resultado;

            return resultado;
        }

        public bool AgregarPermiso(PermisoComponente permisoPadre, PermisoComponente permisoNuevo, List<PermisoComponente> permisos)
        {
            bool resultado = false;

            if (!TienePermiso(permisoNuevo.Id, permisos))
            {
                
                if (permisoPadre == null || !TienePermiso(permisoPadre.Id, permisos))
                {
                    permisos?.Add(permisoNuevo);

                    return true;
                }
                else
                {
                    foreach (var permisoComponente in permisos)
                    {
                        if (permisoComponente.Id == permisoPadre.Id)
                        {
                            permisoComponente.Agregar(permisoNuevo);
                            return true;
                        }
                        else
                        {
                            resultado = AgregarPermisoHijo(permisoPadre.Id, permisoNuevo, permisoComponente.ObtenerHijos());
                        }



                    }

                }



                return resultado;
            }

            return resultado;
        }

        private bool AgregarPermisoHijo(int permisoPadreId, PermisoComponente permisoNuevo, List<PermisoComponente> permisos)
        {
            bool resultado = false;

            
            foreach (var permisoComponente in permisos)
            {
                if (permisoComponente.Id == permisoPadreId)
                {
                    permisoComponente.Agregar(permisoNuevo);
                    return true;
                }
                else
                {
                    resultado = AgregarPermisoHijo(permisoPadreId, permisoNuevo, permisoComponente.ObtenerHijos());
                }

            }

            return resultado;
        }

        public List<PermisoComponente> ObtenerGruposPermisos()
        {
            return _dalManagerPermiso.ObtenerGruposPermisos();
        }

        public List<PermisoComponente> ObtenerPermisosDelGrupo(int idGrupo)
        {
            return _dalManagerPermiso.ObtenerPermisosHijos(idGrupo);
        }

        public Resultado Agregar(PermisoComponente permiso)
        {
            ResultadoBd result = _dalManagerPermiso.Insertar(permiso);

            return result == ResultadoBd.OK ? new Resultado(false, "Se agrego el grupo de permisos", TipoMensaje.CORRECTO, "Agregar permiso") : new Resultado(true, "Ocurrió un error al agregar el grupo de permisos", TipoMensaje.ERROR, "Agregar permiso");
        }

        public Resultado Quitar(PermisoComponente permiso)
        {
            ResultadoBd result = _dalManagerPermiso.Borrar(permiso);

            return result == ResultadoBd.OK ? new Resultado(false, "Se borro el grupo de permisos", TipoMensaje.CORRECTO, "Borrar permiso") : new Resultado(true, "Ocurrió un error al borrar el grupo de permisos", TipoMensaje.ERROR, "Borrar permiso");
        }

        public Resultado ActualizarPermisosDeGrupo(PermisoComponente grupoPermisoSeleccionado)
        {

            ResultadoBd result = _dalManagerPermiso.Actualizar(grupoPermisoSeleccionado);

            return result == ResultadoBd.OK ? new Resultado(false, "Se actualizó el grupo de permisos", TipoMensaje.CORRECTO, "Actualizar permiso") : new Resultado(true, "Ocurrió un error al actualizar el grupo de permisos", TipoMensaje.ERROR, "Actualizar permiso");

        }

        public List<PermisoComponente> ObtenerPermisosSinPerfiles()
        {
            return _dalManagerPermiso.ObtenerPermisosSinPerfiles();
        }
    }
}
