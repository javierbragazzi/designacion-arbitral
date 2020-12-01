using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DA.BE.Composite;
using DA.SS;

namespace DA.DAL
{
    public class Permiso
    {
        /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un Permiso.
        /// </summary>
        /// <param name="pPermiso">Permiso.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.Composite.PermisoComponente pPermiso)
        {
            ResultadoBd resultadoPermiso =  _accesoBaseDeDatos.Insertar(pPermiso);

            var dtPermiso = _accesoBaseDeDatos.Seleccionar(new BE.Composite.Permiso() { Descripcion = pPermiso.Descripcion}, true);

            var row = dtPermiso.Rows[0];
  
            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdPermiso", Convert.ToInt32(row["Id"]));
    
            string query = @"Insert into PermisoPermiso ( IdPadre, IdHijo )
                            Values (null, @IdPermiso) ";

            ResultadoBd resultadoPermisoPermiso = _accesoBaseDeDatos.Ejecutar(query, pars);

            if (resultadoPermiso == ResultadoBd.OK && resultadoPermisoPermiso == ResultadoBd.OK)
            {
                return ResultadoBd.OK;
            }
            else
            {
                return ResultadoBd.ERROR;
            }

        }


        /// <summary>
        /// Actualiza un Permiso.
        /// </summary>
        /// <param name="pPermiso">Permiso.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(PermisoComponente pPermiso)
        {
            try
            {
                
                Borrar(pPermiso);
                Insertar(pPermiso);
                int idPadre = ObtenerIdPermisoPorNombre(pPermiso.Descripcion);
                InsertarPermisos(pPermiso.ObtenerHijos(), idPadre);

                return ResultadoBd.OK;
            }
            catch (Exception e)
            {
               Logger.Log.Error("Error al actualizar los permisos.", e);
               return ResultadoBd.ERROR;
            }
         

        }

        public int ObtenerIdPermisoPorNombre(string nombre)
        {
            //var pars = new IDbDataParameter[1];
            //pars[0] = _accesoBaseDeDatos.CrearParametro("@Nombre", nombre);
    
            string query = @"Select Id
                             from Permiso p  
                             Where p.Descripcion = '"+ nombre +"'";

            var dtPermisos = _accesoBaseDeDatos.Seleccionar(query, null);

            if (dtPermisos.Rows.Count == 0)
                return -1;

            foreach (DataRow row in dtPermisos.Rows)
            {
 
                return Convert.ToInt32(row["Id"].ToString());

            }

            return -1;
        }

        private void InsertarPermisos(List<PermisoComponente> permisos, int idPadre)
        {
            if (permisos != null)
            {
                foreach (PermisoComponente permiso in permisos)
                {

                    //if (permiso.ObtenerHijos().Count != 0)
                    //{
                    //    InsertarHijos(permiso.ObtenerHijos(), permiso.Id);
                    //}

                    InsertarPermisoPermiso(idPadre, permiso.Id);

                }
            }

   
        }

        private void InsertarHijos(List<PermisoComponente> permisos, int idPadre)
        {
            foreach (PermisoComponente permiso in permisos)
            {
        
                if (permiso.ObtenerHijos().Count != 0)
                {
                    InsertarHijos(permiso.ObtenerHijos(), permiso.Id);

                }

                InsertarPermisoPermiso(idPadre, permiso.Id);
                
            }

        }

        private ResultadoBd InsertarPermisoPermiso(int idPadre, int idHijo)
        {
            var pars = new IDbDataParameter[2];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdPadre", idPadre);
            pars[1] = _accesoBaseDeDatos.CrearParametro("@IdHijo", idHijo);
      
            string query = @"Insert into PermisoPermiso ( IdPadre, IdHijo )
                            Values (@IdPadre, @IdHijo) ";

            ResultadoBd resultadoPermisoPermiso = _accesoBaseDeDatos.Ejecutar(query, pars);

            return resultadoPermisoPermiso;
        }

        /// <summary>
        /// Borra un Permiso.
        /// </summary>
        /// <param name="pPermiso">Permiso.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(PermisoComponente pPermiso)
        {
            ResultadoBd resultadoPermiso =  _accesoBaseDeDatos.Borrar(pPermiso);

            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdPermiso", pPermiso.Id);
      
            string query = @"Delete 
                                from PermisoPermiso
                                where IdPadre = @IdPermiso
                                or IdHijo = @IdPermiso";

            ResultadoBd resultadoPermisoPermiso = _accesoBaseDeDatos.Ejecutar(query, pars);

            if (resultadoPermiso == ResultadoBd.OK && resultadoPermisoPermiso == ResultadoBd.OK)
            {
                return ResultadoBd.OK;
            }
            else
            {
                return ResultadoBd.ERROR;
            }
        }

        /// <summary>
        /// Obtiene un Permiso por Id de Permiso.
        /// </summary>
        /// <param name="idPermiso">Nombre del Permiso.</param>
        /// <returns></returns>
        public BE.Composite.Permiso ObtenerPermisoPorId(int idPermiso)
        {
            var dtPermiso = _accesoBaseDeDatos.Seleccionar(new BE.Composite.Permiso() { Id = idPermiso}, true);

            if (dtPermiso.Rows.Count == 0)
                return null;

            var row = dtPermiso.Rows[0];
            var aPermiso = new BE.Composite.Permiso
            {
                Id = Convert.ToInt32(row["Id"]),
                Descripcion = row["Descripcion"].ToString().Trim(),
             
            };

            //var dtPerfil = _accesoBaseDeDatos.Seleccionar(new BE.Permiso() { NombrePermiso = objPermiso, Activo = null });

            return aPermiso;

        }

        public List<PermisoComponente> ObtenerPermisosDeUsuario(int idUsuario)
        {
            List<PermisoComponente> lstPermisos = new List<PermisoComponente>();

            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdUsuario", idUsuario);
      
            string query = @"Select per.Id
                             FROM Usuario usu
                             INNER JOIN UsuarioPermiso usper ON ( usu.Id = usper.IdUsuario )
                             INNER JOIN Permiso per ON ( usper.IdPermiso = per.Id )
                             WHERE usu.Id = @IdUsuario ";

            var dtPerfil = _accesoBaseDeDatos.Seleccionar(query, pars);

            if (dtPerfil.Rows.Count == 0)
                return lstPermisos;

            foreach (DataRow row in dtPerfil.Rows)
            {

               //lstPermisos = ObtenerPermisos(row["Id"].ToString());
               lstPermisos.Add(ObtenerPermisos(row["Id"].ToString()));
               
            }

        
            return lstPermisos;


        }

        //private List<PermisoComponente> ObtenerPermisos(string idPermiso)
        //{
        //    try
        //    {
        //        var lstPermisos = new List<PermisoComponente>();
        //        var pars = new IDbDataParameter[1];
        //        string query = "";

        //        if (!String.IsNullOrEmpty(idPermiso))
        //        {
        //            var where = idPermiso;
        //            pars[0] = _accesoBaseDeDatos.CrearParametro("@Condicion", Convert.ToInt32(where));

        //            //query = $@"with Recursivo as ( select sp2.IdPadre, sp2.IdHijo  
        //            //          from PermisoPermiso SP2
        //            //                         where sp2.IdPadre = @Condicion 
        //            //                         UNION ALL 
        //            //                         select sp.IdPadre, sp.IdHijo 
        //            //          from PermisoPermiso sp 
        //            //                         inner join Recursivo r on r.IdHijo = sp.IdPadre
        //            //                         )
        //            //                         select r.IdPadre, r.IdHijo, p.Id, p.Descripcion, p.EsPermiso
        //            //                         from recursivo r 
        //            //                         inner join Permiso p on (r.IdHijo = p.Id) 						
        //            //    ";


        //            query = $@"with Recursivo as ( select sp2.IdPadre, sp2.IdHijo  
        //                      from PermisoPermiso SP2
        //                                     where sp2.IdPadre = @Condicion 
        //                                     UNION ALL 
        //                                     select sp.IdPadre, sp.IdHijo 
        //                                     from PermisoPermiso sp 
        //                                     inner join Recursivo r on r.IdHijo = sp.IdPadre
        //                                     )
        //                                     select perper.IdPadre, perper.IdHijo, p.Id, p.Descripcion, p.EsPermiso
        //                                     from PermisoPermiso perper
        //                                     inner join Permiso p on (perper.IdHijo = p.Id) 		
								//			 where p.Id = @Condicion 
        //                                     union all
        //                                     select r.IdPadre, r.IdHijo, p.Id, p.Descripcion, p.EsPermiso
        //                                     from recursivo r 
        //                                     inner join Permiso p on (r.IdHijo = p.Id)
                                          
                                      
        //                ";
        //        }
        //        else
        //        {
        //            pars = null;

        //            query = $@"with Recursivo as ( select sp2.IdPadre, sp2.IdHijo  
					   //                      from PermisoPermiso SP2
        //                                     where sp2.IdPadre is null 
        //                                     UNION ALL 
        //                                     select sp.IdPadre, sp.IdHijo 
					   //                      from PermisoPermiso sp 
        //                                     inner join Recursivo r on r.IdHijo = sp.IdPadre
        //                                     )
        //                                     select r.IdPadre, r.IdHijo, p.Id, p.Descripcion, p.EsPermiso
        //                                     from recursivo r 
        //                                     inner join Permiso p on (r.IdHijo = p.Id) 						
        //                ";
        //        }

        //        var dtPermisos = _accesoBaseDeDatos.Seleccionar(query, pars);

        //        if (dtPermisos.Rows.Count == 0)
        //            return null;

        //        foreach (DataRow row in dtPermisos.Rows)
        //        {
        //            int idPadre = 0;

        //            if (row["IdPadre"] != DBNull.Value)
        //            {
        //                idPadre = Convert.ToInt32(row["IdPadre"]);
        //            }

        //            var id = Convert.ToInt32(row["Id"]);
        //            var descripcion = row["Descripcion"].ToString().Trim();
        //            var esPermiso = Convert.ToBoolean(row["EsPermiso"].ToString().Trim());
                    
        //            PermisoComponente componente;

        //            if (!esPermiso)
        //                componente = new GrupoPermiso();
        //            else
        //                componente = new BE.Composite.Permiso();

        //            componente.Id = id;
        //            componente.Descripcion = descripcion;

        //            var padre = ObtenerComponente(idPadre, lstPermisos);

        //            if (padre == null)
        //            {
        //                lstPermisos.Add(componente);
        //            }
        //            else
        //            {
        //                padre.Agregar(componente);
        //            }

        //        }

        //        return lstPermisos;

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }

        //}

        private PermisoComponente ObtenerPermisos(string idPermiso)
        {
            try
            {
                var lstPermisos = new List<PermisoComponente>();
  
                var pars = new IDbDataParameter[1];
                string query = "";

                if (!String.IsNullOrEmpty(idPermiso))
                {
                    var where = idPermiso;
                    pars[0] = _accesoBaseDeDatos.CrearParametro("@Condicion", Convert.ToInt32(where));

                    //query = $@"with Recursivo as ( select sp2.IdPadre, sp2.IdHijo  
                    //          from PermisoPermiso SP2
                    //                         where sp2.IdPadre = @Condicion 
                    //                         UNION ALL 
                    //                         select sp.IdPadre, sp.IdHijo 
                    //          from PermisoPermiso sp 
                    //                         inner join Recursivo r on r.IdHijo = sp.IdPadre
                    //                         )
                    //                         select r.IdPadre, r.IdHijo, p.Id, p.Descripcion, p.EsPermiso
                    //                         from recursivo r 
                    //                         inner join Permiso p on (r.IdHijo = p.Id) 						
                    //    ";


                    query = $@"with Recursivo as ( select sp2.IdPadre, sp2.IdHijo  
                              from PermisoPermiso SP2
                                             where sp2.IdPadre = @Condicion 
                                             UNION ALL 
                                             select sp.IdPadre, sp.IdHijo 
                                             from PermisoPermiso sp 
                                             inner join Recursivo r on r.IdHijo = sp.IdPadre
                                             )
                                             select perper.IdPadre, perper.IdHijo, p.Id, p.Descripcion, p.EsPermiso
                                             from PermisoPermiso perper
                                            right join Permiso p on (perper.IdHijo = p.Id) 			
											 where p.Id = @Condicion 
                                             union all
                                             select r.IdPadre, r.IdHijo, p.Id, p.Descripcion, p.EsPermiso
                                             from recursivo r 
                                             inner join Permiso p on (r.IdHijo = p.Id)
                                          
                                      
                        ";
                }
                else
                {
                    pars = null;

                    query = $@"	with Recursivo as ( select sp2.IdPadre, sp2.IdHijo  
					                         from PermisoPermiso SP2
                                             where sp2.IdPadre is null 
                                             UNION ALL 
                                             select sp.IdPadre, sp.IdHijo 
					                         from PermisoPermiso sp 
                                             inner join Recursivo r on r.IdHijo = sp.IdPadre
                                             )
                                             select r.IdPadre, r.IdHijo, p.Id, p.Descripcion, p.EsPermiso
                                             from recursivo r 
                                             right join Permiso p on (r.IdHijo = p.Id) 						
                        ";
                }

                var dtPermisos = _accesoBaseDeDatos.Seleccionar(query, pars);

                if (dtPermisos.Rows.Count == 0)
                    return null;

                foreach (DataRow row in dtPermisos.Rows)
                {
                    int idPadre = 0;

                    if (row["IdPadre"] != DBNull.Value)
                    {
                        idPadre = Convert.ToInt32(row["IdPadre"]);
                    }

                    var id = Convert.ToInt32(row["Id"]);
                    var descripcion = row["Descripcion"].ToString().Trim();
                    var esPermiso = Convert.ToBoolean(row["EsPermiso"].ToString().Trim());

                    PermisoComponente componente;

                    if (!esPermiso)
                        componente = new GrupoPermiso();
                    else
                        componente = new BE.Composite.Permiso();

                    componente.Id = id;
                    componente.Descripcion = descripcion;

                    var padre = ObtenerComponente(idPadre, lstPermisos);

                    if (padre == null)
                    {
                        lstPermisos.Add(componente);
                    }
                    else
                    {
                        padre.Agregar(componente);
                    }

                }

                return lstPermisos[0];

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public List<PermisoComponente> ObtenerPermisos()
        {
            try
            {
                var lstPermisos = new List<PermisoComponente>();
                string query = "";

   
                query = $@"with Recursivo as ( select sp2.IdPadre, sp2.IdHijo  
					                     from PermisoPermiso SP2
                                         where sp2.IdPadre is null 
                                         UNION ALL 
                                         select sp.IdPadre, sp.IdHijo 
					                     from PermisoPermiso sp 
                                         inner join Recursivo r on r.IdHijo = sp.IdPadre
                                         )
                                         select r.IdPadre, r.IdHijo, p.Id, p.Descripcion, p.EsPermiso
                                         from recursivo r 
                                         inner join Permiso p on (r.IdHijo = p.Id) 						
                    ";
             
                var dtPermisos = _accesoBaseDeDatos.Seleccionar(query, null);

                if (dtPermisos.Rows.Count == 0)
                    return null;

                foreach (DataRow row in dtPermisos.Rows)
                {
                    int idPadre = 0;

                    if (row["IdPadre"] != DBNull.Value)
                    {
                        idPadre = Convert.ToInt32(row["IdPadre"]);
                    }

                    var id = Convert.ToInt32(row["Id"]);
                    var descripcion = row["Descripcion"].ToString().Trim();
                    var esPermiso = Convert.ToBoolean(row["EsPermiso"].ToString().Trim());

                    PermisoComponente componente;

                    if (!esPermiso)
                        componente = new GrupoPermiso();
                    else
                        componente = new BE.Composite.Permiso();

                    componente.Id = id;
                    componente.Descripcion = descripcion;

                    var padre = ObtenerComponente(idPadre, lstPermisos);

                    if (padre == null)
                    {
                        lstPermisos.Add(componente);
                    }
                    else
                    {
                        padre.Agregar(componente);
                    }

                }

                return lstPermisos;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public PermisoComponente ObtenerComponente(int id, List<PermisoComponente> lista)
        {

            PermisoComponente componente = lista != null ? lista.Where(i => i.Id.Equals(id)).FirstOrDefault() : null;

            if (componente == null && lista != null)
            {
                foreach (var permisoComponente in lista)
                {

                    var lst = ObtenerComponente(id, permisoComponente.ObtenerHijos());

                    if (lst != null && lst.Id == id) return lst;
                    else
                    if (lst != null)
                        return ObtenerComponente(id, lst.ObtenerHijos());

                }
            }

            return componente;

        }

        //public List<PermisoComponente> ObtenerPermisosHijos(int idPermiso)
        //{
        //    List<PermisoComponente> lstPermisos = new List<PermisoComponente>();
        //    var pars = new IDbDataParameter[1];
        //    pars[0] = _accesoBaseDeDatos.CrearParametro("@IdPermiso", idPermiso);

        //    string query = @"SELECT perper.IdHijo as Id, (SELECT Descripcion FROM Permiso pe WHERE pe.Id = perper.IdHijo) as Descripcion
        //                     FROM Permiso per 
        //                     LEFT JOIN PermisoPermiso perper ON ( perper.IdPadre = per.Id )
        //                     WHERE per.Id = @IdPermiso";

        //    var dtPermisos = _accesoBaseDeDatos.Seleccionar(query, pars);

        //    if (dtPermisos.Rows.Count == 0)
        //        return null;

        //    foreach (DataRow row in dtPermisos.Rows)
        //    {
        //        var aPermiso = new BE.Composite.Permiso
        //        {
        //            Id = Convert.ToInt32(row["Id"]),
        //            Descripcion = row["Descripcion"].ToString().Trim(),

        //        };

        //        lstPermisos.Add(aPermiso);
        //    }

        //    return lstPermisos;

        //}

        //public int ObtenerIdPadre(int idPermiso)
        //{


        //    var pars = new IDbDataParameter[1];
        //    pars[0] = _accesoBaseDeDatos.CrearParametro("@IdPermiso", idPermiso);

        //    string query = @"   SELECT IdPadre
        //                        FROM PermisoPermiso per
        //                        WHERE per.IdHijo = 5	 = @IdPermiso ";

        //    var dtPerfil = _accesoBaseDeDatos.Seleccionar(query, pars);

        //    if (dtPerfil.Rows.Count == 0)
        //        return -1;

        //    foreach (DataRow row in dtPerfil.Rows)
        //    {

        //        lstPermisos = ObtenerPermisos(row["Id"].ToString());

        //    }


        //    return lstPermisos;


        //}

        //public bool IsInRole(int id)
        //{
        //    //var lista = GetAll(string.Empty);

        //    var c = GetComponent(id, lista);

        //    return c != null;
        //}

        public List<PermisoComponente> ObtenerPermisosHijos(int idPermiso)
        {
            List<PermisoComponente> lstPermisos = new List<PermisoComponente>();
            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdPermiso", idPermiso);

            string query = @"SELECT perper.IdHijo as Id, (SELECT Descripcion FROM Permiso pe WHERE pe.Id = perper.IdHijo) as Descripcion
                             FROM Permiso per 
                             LEFT JOIN PermisoPermiso perper ON ( perper.IdPadre = per.Id )
                             WHERE per.Id = @IdPermiso";

            var dtPermisos = _accesoBaseDeDatos.Seleccionar(query, pars);

            if (dtPermisos.Rows.Count == 0)
                return null;

            foreach (DataRow row in dtPermisos.Rows)
            {
                var aPermiso = new BE.Composite.Permiso
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Descripcion = row["Descripcion"].ToString().Trim(),

                };

                lstPermisos.Add(aPermiso);
            }

            return lstPermisos;

        }

        public List<PermisoComponente> ObtenerGruposPermisos()
        {
            List<PermisoComponente> lstPermisos = new List<PermisoComponente>();

            //string query = @"select per.Id, per.Descripcion
            //                from Permiso per
            //                Where per.EsPermiso = 0";

            string query = @"select per.Id, per.Descripcion
                            from Permiso per
                            Where per.Id in ( Select perp.IdHijo 
                                            from PermisoPermiso perp
                                            where perp.IdPadre is null)";

         

            var dtPermisos = _accesoBaseDeDatos.Seleccionar(query, null);

            if (dtPermisos.Rows.Count == 0)
                return null;

            foreach (DataRow row in dtPermisos.Rows)
            {
 
                PermisoComponente permiso = ObtenerPermisos(row["Id"].ToString());

                lstPermisos.Add(permiso);
            }

            return lstPermisos;
        }

        public List<PermisoComponente> ObtenerPermisosSinPerfiles()
        {
            List<PermisoComponente> lstPermisos = new List<PermisoComponente>();

            //string query = @"select per.Id, per.Descripcion
            //                from Permiso per
            //                Where per.Id in ( Select perp.IdHijo 
            //                                from PermisoPermiso perp
            //                                where perp.IdPadre is not null)";

            string query = @" select per.Id, per.Descripcion
                                from Permiso per
                            Where per.EsPermiso = 1 
                            and per.Id in ( Select perp.IdHijo 
                                from PermisoPermiso perp
                            where perp.IdPadre is not null)";
           
         

            var dtPermisos = _accesoBaseDeDatos.Seleccionar(query, null);

            if (dtPermisos.Rows.Count == 0)
                return null;

            foreach (DataRow row in dtPermisos.Rows)
            {
 
                PermisoComponente permiso = ObtenerPermisos(row["Id"].ToString());

                lstPermisos.Add(permiso);
            }

            return lstPermisos;
        }
    }

}
