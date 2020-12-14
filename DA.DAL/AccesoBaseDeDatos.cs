using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using DA.BE;
using DA.SS;

namespace DA.DAL
{
    /// <summary>
    /// Clase para proporciona los metodos para interactuar con la base de datos
    /// </summary>
    public class AccesoBaseDeDatos
    {
        /// <summary>
        /// The connection
        /// </summary>
        private readonly SqlConnection _connection;
        /// <summary>
        /// The database provider factory
        /// </summary>
        private readonly DbProviderFactory _dbProviderFactory;

        /// <summary>
        /// Opens the connection.
        /// </summary>
        public void AbrirConexion()
        {

            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStringDesignacionArbitral"].ConnectionString;
    
            _connection.Open();

        }

        /// <summary>
        /// Closes the connection.
        /// </summary>
        public void CerrarConexion()
        {
            _connection.Close();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccesoBaseDeDatos"/> class.
        /// </summary>
        public AccesoBaseDeDatos()
        {
            _connection = new SqlConnection();
            _dbProviderFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["ConnStringDesignacionArbitral"].ProviderName);

        }

        /// <summary>
        /// Inserta el objeto entidad.
        /// </summary>
        /// <param name="objetoEntidad">The objeto entidad.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(object objetoEntidad)
        {
            try
            {
                //return ResultadoBd.ERROR;
                DbCommand command = CrearComandoInsert(objetoEntidad);
                command.Connection = _connection;

                AbrirConexion();

                int fa = ((SqlCommand)command).ExecuteNonQuery();

                CerrarConexion();

                if (fa >= 1)
                    return ResultadoBd.OK;

                return ResultadoBd.ERROR;

            }
            catch (Exception ex)
            {
                CerrarConexion();
                Logger.Log.Debug("Error en metodo Insertar en DAL", ex);
                return ResultadoBd.ERROR;
            }

        }

        /// <summary>
        /// Actualiza el objeto entidad.
        /// </summary>
        /// <param name="objetoEntidad">The objeto entidad.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(object objetoEntidad)
        {
            try
            {

                DbCommand command = CrearComandoUpdate(objetoEntidad);
                command.Connection = _connection;

                AbrirConexion();

                int fa = ((SqlCommand)command).ExecuteNonQuery();

                CerrarConexion();

                if (fa >= 1)
                    return ResultadoBd.OK;

                return ResultadoBd.ERROR;

            }
            catch (Exception ex)
            {
                CerrarConexion();
                Logger.Log.Debug("Error en metodo Actualizar en DAL", ex);
                return ResultadoBd.ERROR;
            }

        }

        /// <summary>
        /// Borra el objeto entidad.
        /// </summary>
        /// <param name="objetoEntidad">The objeto entidad.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(object objetoEntidad)
        {
            try
            {

                DbCommand command = CrearComandoDelete(objetoEntidad);
                command.Connection = _connection;

                AbrirConexion();

                int fa = ((SqlCommand)command).ExecuteNonQuery();

                CerrarConexion();

                if (fa >= 1)
                    return ResultadoBd.OK;

                return ResultadoBd.ERROR;

            }
            catch (Exception ex)
            {
                CerrarConexion();
                Logger.Log.Debug("Error en metodo Borrar en DAL", ex);
                return ResultadoBd.ERROR;
            }

        }

        /// <summary>
        /// Obtiene las entidades que coinciden con el objeto entidad.
        /// </summary>
        /// <param name="objetoEntidad">The objeto entidad.</param>
        /// <param name="conFiltros"></param>
        /// <returns></returns>
        public DataTable Seleccionar(object objetoEntidad, bool conFiltros)
        {
            try
            {
                var tabla = new DataTable();
                DbCommand command = CrearComandoSelect(objetoEntidad, conFiltros);
                command.Connection = _connection;

                var da = new SqlDataAdapter
                {
                    SelectCommand = (SqlCommand)command,
                };


                AbrirConexion();
                da.Fill(tabla);
                CerrarConexion();

                return tabla;

            }
            catch (Exception ex)
            {
                CerrarConexion();
                Logger.Log.Debug("Error en método Seleccionar en DAL", ex);
                return null;

            }

        }

        public DataTable Seleccionar(object objetoEntidad, bool llavePrimaria ,bool conFiltros)
        {
            try
            {
                var tabla = new DataTable();
                DbCommand command = CrearComandoSelect(objetoEntidad,llavePrimaria, conFiltros);
                command.Connection = _connection;

                var da = new SqlDataAdapter
                {
                    SelectCommand = (SqlCommand)command,
                };


                AbrirConexion();
                da.Fill(tabla);
                CerrarConexion();

                return tabla;

            }
            catch (Exception ex)
            {
                CerrarConexion();
                Logger.Log.Debug("Error en método Seleccionar en DAL", ex);
                return null;

            }

        }

        public DataTable Seleccionar(object objetoEntidad)
        {
            try
            {
                var tabla = new DataTable();
                DbCommand command = CrearComandoSelect(objetoEntidad);
                command.Connection = _connection;

                var da = new SqlDataAdapter
                {
                    SelectCommand = (SqlCommand)command,
                };


                AbrirConexion();
                da.Fill(tabla);
                CerrarConexion();

                return tabla;

            }
            catch (Exception ex)
            {
                CerrarConexion();
                Logger.Log.Debug("Error en método Seleccionar en DAL", ex);
                return null;

            }

        }

        public DataTable Seleccionar(string query, IDbDataParameter[] parameters = null)
        {
            try
            {
                var tabla = new DataTable();
                var da = new SqlDataAdapter
                {
                    SelectCommand = new SqlCommand
                    {
                        CommandType = CommandType.Text,
                        CommandText = query,
                        Connection = _connection
                    }

                };

                if (parameters != null)
                    da.SelectCommand.Parameters.AddRange(parameters);


                AbrirConexion();
                da.Fill(tabla);
                CerrarConexion();

                return tabla;

            }
            catch (Exception ex)
            {
                CerrarConexion();
                Logger.Log.Debug("Error en metodo Seleccionar en DAL", ex);
                return null;

            }

        }
        
        public ResultadoBd Ejecutar(string query, IDbDataParameter[] parameters = null)
        {
            try
            {
                var tabla = new DataTable();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = query,
                    CommandType = CommandType.Text,
                    Connection = _connection

                };

                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                AbrirConexion();

                int fa = cmd.ExecuteNonQuery();

                CerrarConexion();

                if (fa >= 1)
                    return ResultadoBd.OK;

                return ResultadoBd.ERROR;

            }
            catch (Exception ex)
            {
                CerrarConexion();
                Logger.Log.Debug("Error en metodo Ejecutar en DAL", ex);
                return ResultadoBd.ERROR;

            }

        }

        public ResultadoBd Ejecutar(string query)
        {
            try
            {
                var tabla = new DataTable();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = query,
                    CommandType = CommandType.Text,
                    Connection = _connection

                };

                AbrirConexion();

                int fa = cmd.ExecuteNonQuery();

                CerrarConexion();

                return ResultadoBd.OK;


            }
            catch (Exception ex)
            {
                CerrarConexion();
                Logger.Log.Debug("Error en metodo Ejecutar en DAL", ex);
                return ResultadoBd.ERROR;

            }

        }

        public DataTable ObtenerTabla(string query)
        {
            SqlDataAdapter adapter;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = query,
                    CommandType = CommandType.Text,
                    Connection = _connection

                };

                AbrirConexion();

                adapter = new SqlDataAdapter(query, cmd.Connection);

                adapter.Fill(ds);

                CerrarConexion();

            }
            catch (Exception ex)
            {
                CerrarConexion();
                Logger.Log.Debug("Error en metodo Ejecutar en DAL", ex);
                return null;
            }
            return ds.Tables[0]; 
        }

        /// <summary>
        /// Crea el comando select.
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        /// <param name="conFiltros"></param>
        /// <returns></returns>
        private DbCommand CrearComandoSelect(object dataObject, bool conFiltros)
        {
            Type t = dataObject.GetType();
            DbCommand cmd = _dbProviderFactory.CreateCommand();
            StringCollection fields = new StringCollection();
            StringBuilder sbWhere = new StringBuilder(" WHERE ");
            bool hasCondition = false; //Indicates that there is a WHERE Condition
            string tableName = "";
            IDbDataParameter[] parametros = null;

            if(conFiltros)
                 parametros = CrearParametrosParaComando(dataObject, false);

            // Get instance of the attribute.
            Tabla atributoTabla = (Tabla)Attribute.GetCustomAttribute(t, typeof(Tabla));

            if (atributoTabla != null)
                tableName = atributoTabla.Nombre;
            
            foreach (MethodInfo mi in t.GetMethods()) //Go thru each method of the object
            {
                foreach (Attribute att in Attribute.GetCustomAttributes(mi))  //Go thru the attributes for the method
                {
                    if (typeof(Columna).IsAssignableFrom(att.GetType())) //Checks that the Attribute is of the right type
                    {
                        var dao = (Columna)att;
                        fields.Add(dao.NombreColumna); //Append the Fields 

                        if (parametros != null)
                        {
                            foreach (IDbDataParameter parametro in parametros)
                            {
                                if (parametro.Value != null)
                                {
                                    if (parametro.ParameterName.Equals(dao.NombreColumna))
                                    {
                                        if (hasCondition)
                                            sbWhere.Append(" AND ");

                                        if (parametro.DbType == DbType.String)
                                            sbWhere.AppendFormat("{0} LIKE '%{1}%'", parametro.ParameterName, parametro.Value.ToString().Replace("'",""));
                                        else
                                            sbWhere.AppendFormat("{0} = {1}", parametro.ParameterName, parametro.Value);

                                        hasCondition = true; //Set the HasCondition flag to true

                                    }
                                }
                            }
                            
                        }

                    }
                }
            }

            string[] arrField = new string[fields.Count];
            fields.CopyTo(arrField, 0);
            cmd.CommandText = "SELECT " + string.Join(",", arrField) + " FROM " + tableName + (hasCondition ? sbWhere.ToString() : " ");

            return cmd;
        }

        private DbCommand CrearComandoSelect(object dataObject)
        {
            Type t = dataObject.GetType();
            DbCommand cmd = _dbProviderFactory.CreateCommand();
            StringCollection fields = new StringCollection();
            StringBuilder sbWhere = new StringBuilder(" WHERE ");
            bool hasCondition = false; //Indicates that there is a WHERE Condition
            string tableName = "";
            IDbDataParameter[] parametros = null;

            parametros = CrearParametrosParaComando(dataObject, true);

            // Get instance of the attribute.
            Tabla atributoTabla = (Tabla)Attribute.GetCustomAttribute(t, typeof(Tabla));

            if (atributoTabla != null)
                tableName = atributoTabla.Nombre;
            
            foreach (MethodInfo mi in t.GetMethods()) //Go thru each method of the object
            {
                foreach (Attribute att in Attribute.GetCustomAttributes(mi))  //Go thru the attributes for the method
                {
                    if (typeof(Columna).IsAssignableFrom(att.GetType())) //Checks that the Attribute is of the right type
                    {
                        var dao = (Columna)att;
                        fields.Add(dao.NombreColumna); //Append the Fields 

                        if (parametros != null)
                        {
                            foreach (IDbDataParameter parametro in parametros)
                            {
                                if (parametro.Value != null)
                                {
                                    if (parametro.ParameterName.Equals(dao.NombreColumna))
                                    {
                                        if (hasCondition)
                                            sbWhere.Append(" AND ");

                                        if (parametro.DbType == DbType.String)
                                            sbWhere.AppendFormat("{0} LIKE '%{1}%'", parametro.ParameterName, parametro.Value.ToString().Replace("'",""));
                                        else
                                            sbWhere.AppendFormat("{0} = {1}", parametro.ParameterName, parametro.Value);

                                        hasCondition = true; //Set the HasCondition flag to true

                                    }
                                }
                            }
                            
                        }

                    }
                }
            }

            string[] arrField = new string[fields.Count];
            fields.CopyTo(arrField, 0);
            cmd.CommandText = "SELECT " + string.Join(",", arrField) + " FROM " + tableName + (hasCondition ? sbWhere.ToString() : " ");

            return cmd;
        }
        
        private DbCommand CrearComandoSelect(object dataObject, bool llavePrimaria, bool conFiltros)
        {
            Type t = dataObject.GetType();
            DbCommand cmd = _dbProviderFactory.CreateCommand();
            StringCollection fields = new StringCollection();
            StringBuilder sbWhere = new StringBuilder(" WHERE ");
            bool hasCondition = false; //Indicates that there is a WHERE Condition
            string tableName = "";
            IDbDataParameter[] parametros = null;

            parametros = CrearParametrosParaComandoSelect(dataObject, llavePrimaria, conFiltros);

            // Get instance of the attribute.
            Tabla atributoTabla = (Tabla)Attribute.GetCustomAttribute(t, typeof(Tabla));

            if (atributoTabla != null)
                tableName = atributoTabla.Nombre;
            
            foreach (MethodInfo mi in t.GetMethods()) //Go thru each method of the object
            {
                foreach (Attribute att in Attribute.GetCustomAttributes(mi))  //Go thru the attributes for the method
                {
                    if (typeof(Columna).IsAssignableFrom(att.GetType())) //Checks that the Attribute is of the right type
                    {
                        var dao = (Columna)att;
                        fields.Add(dao.NombreColumna); //Append the Fields 

                        if (parametros != null)
                        {
                            foreach (IDbDataParameter parametro in parametros)
                            {
                                if (parametro.Value != null)
                                {
                                    if (parametro.ParameterName.Equals(dao.NombreColumna))
                                    {
                                        if (hasCondition)
                                            sbWhere.Append(" AND ");

                                        if (parametro.DbType == DbType.String)
                                            sbWhere.AppendFormat("{0} LIKE '%{1}%'", parametro.ParameterName, parametro.Value.ToString().Replace("'",""));
                                        else
                                            sbWhere.AppendFormat("{0} = {1}", parametro.ParameterName, parametro.Value);

                                        hasCondition = true; //Set the HasCondition flag to true

                                    }
                                }
                            }
                            
                        }

                    }
                }
            }

            string[] arrField = new string[fields.Count];
            fields.CopyTo(arrField, 0);
            cmd.CommandText = "SELECT " + string.Join(",", arrField) + " FROM " + tableName + (hasCondition ? sbWhere.ToString() : " ");

            return cmd;
        }

        private DbCommand CrearComandoSelectConFiltroPorId(object dataObject, bool conFiltros)
        {
            Type t = dataObject.GetType();
            DbCommand cmd = _dbProviderFactory.CreateCommand();
            StringCollection fields = new StringCollection();
            StringBuilder sbWhere = new StringBuilder(" WHERE ");
            bool hasCondition = false; //Indicates that there is a WHERE Condition
            string tableName = "";
            IDbDataParameter[] parametros = null;

            if(conFiltros)
                 parametros = CrearParametrosParaComando(dataObject, true);

            // Get instance of the attribute.
            Tabla atributoTabla = (Tabla)Attribute.GetCustomAttribute(t, typeof(Tabla));

            if (atributoTabla != null)
                tableName = atributoTabla.Nombre;
            
            foreach (MethodInfo mi in t.GetMethods()) //Go thru each method of the object
            {
                foreach (Attribute att in Attribute.GetCustomAttributes(mi))  //Go thru the attributes for the method
                {
                    if (typeof(Columna).IsAssignableFrom(att.GetType())) //Checks that the Attribute is of the right type
                    {
                        var dao = (Columna)att;
                        fields.Add(dao.NombreColumna); //Append the Fields 

                        if (parametros != null)
                        {
                            foreach (IDbDataParameter parametro in parametros)
                            {
                                if (parametro.Value != null)
                                {
                                    if (parametro.ParameterName.Equals(dao.NombreColumna))
                                    {
                                        if (hasCondition)
                                            sbWhere.Append(" AND ");

                                        if (parametro.DbType == DbType.String)
                                            sbWhere.AppendFormat("{0} LIKE '%{1}%'", parametro.ParameterName, parametro.Value.ToString().Replace("'",""));
                                        else
                                            sbWhere.AppendFormat("{0} = {1}", parametro.ParameterName, parametro.Value);

                                        hasCondition = true; //Set the HasCondition flag to true

                                    }
                                }
                            }
                            
                        }

                    }
                }
            }

            string[] arrField = new string[fields.Count];
            fields.CopyTo(arrField, 0);
            cmd.CommandText = "SELECT " + string.Join(",", arrField) + " FROM " + tableName + (hasCondition ? sbWhere.ToString() : " ");

            return cmd;
        }

        /// <summary>
        /// Crea el comando insert.
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        /// <returns></returns>
        private DbCommand CrearComandoInsert(object dataObject)
        {
            Type type = dataObject.GetType();
            DbCommand cmd = _dbProviderFactory.CreateCommand();
            string tableName = "";
            IDbDataParameter[] parametros = CrearParametrosParaComando(dataObject, false);

            StringCollection campos = new StringCollection();
            StringCollection valores = new StringCollection();

            Tabla atributoTabla = (Tabla)Attribute.GetCustomAttribute(type, typeof(Tabla));

            if (atributoTabla != null)
                tableName = atributoTabla.Nombre;

            foreach (MethodInfo mi in type.GetMethods()) //Go thru each method of the object
            {
                foreach (Attribute att in Attribute.GetCustomAttributes(mi))  //Go thru the attributes for the method
                {
                    if (typeof(Columna).IsAssignableFrom(att.GetType())) //Checks that the Attribute is of the right type
                    {
                        var dao = (Columna)att;

                        if (dao.LlavePrimaria == false)
                        {
                            campos.Add(dao.NombreColumna); //Append the Fields 

                            foreach (IDbDataParameter parametro in parametros)
                            {
                                if (parametro.ParameterName.Equals(dao.NombreColumna))
                                {//////////////////////////////PREGUNTAR POR PARAMETRO TIPO STRING!!!!!!!!!!!
                                    if (parametro.Value == null)
                                        valores.Add("''"); //sbValues.AppendFormat("{0}, ", "''");
                                    else
                                        valores.Add(parametro.Value.ToString());  //sbValues.AppendFormat("{0}, ", parametro.Value);
                                }

                            }
                        }
                        else
                        {
                            if (dao.Filtro == true)
                            {
                                campos.Add(dao.NombreColumna); //Append the Fields 

                                foreach (IDbDataParameter parametro in parametros)
                                {
                                    if (parametro.ParameterName.Equals(dao.NombreColumna))
                                    {//////////////////////////////PREGUNTAR POR PARAMETRO TIPO STRING!!!!!!!!!!!
                                        if (parametro.Value == null)
                                            valores.Add("''"); 
                                        else
                                            valores.Add(parametro.Value.ToString());  
                                    }

                                }
                            }
                        }
                    }
                }
            }

            string[] arrCampos = new string[campos.Count];
            string[] arrValores = new string[valores.Count];

            campos.CopyTo(arrCampos, 0);
            valores.CopyTo(arrValores, 0);
            cmd.CommandText = "INSERT INTO " + tableName + "(" + string.Join(",", arrCampos) + ")" + " VALUES " + "(" +
                              string.Join(",", arrValores) + ")";

            return cmd;
            
        }

        /// <summary>
        /// Crea el comando update.
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        /// <returns></returns>
        private DbCommand CrearComandoUpdate(object dataObject)
        {
            Type t = dataObject.GetType();
            DbCommand cmd = _dbProviderFactory.CreateCommand();
            StringCollection camposValores = new StringCollection();
            string llavePrimaria = "";
            string tableName = "";

            IDbDataParameter[] parametros = CrearParametrosParaComando(dataObject, true);
            Tabla atributoTabla = (Tabla)Attribute.GetCustomAttribute(t, typeof(Tabla));

            if (atributoTabla != null)
                tableName = atributoTabla.Nombre;

            foreach (MethodInfo mi in t.GetMethods()) 
            {
                foreach (Attribute att in Attribute.GetCustomAttributes(mi))  
                {
                    if (typeof(Columna).IsAssignableFrom(att.GetType()))
                    {
                        var dao = (Columna)att;

                        if (parametros != null)
                        {
                            foreach (IDbDataParameter parametro in parametros)
                            {
                                if (parametro.Value != null)
                                {
                                    if (parametro.ParameterName.Equals(dao.NombreColumna))
                                    {
                                        if (dao.LlavePrimaria)
                                            llavePrimaria = $"{parametro.ParameterName} = {parametro.Value}";

                                        else
                                            camposValores.Add($"{parametro.ParameterName} = {parametro.Value}");
                                    }
                                }
                            }

                        }
                    }
                }
            }

            string[] arrCamposValores = new string[camposValores.Count];
            camposValores.CopyTo(arrCamposValores, 0);
            cmd.CommandText = "UPDATE " +  tableName + " SET " + string.Join(",", arrCamposValores) + " WHERE " + llavePrimaria;

            return cmd;
        }

        /// <summary>
        /// Crea el comando delete.
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        /// <returns></returns>
        private DbCommand CrearComandoDelete(object dataObject)
        {
            Type t = dataObject.GetType();
            DbCommand cmd = _dbProviderFactory.CreateCommand();
            string llavePrimaria = "";
            string tableName = "";

            IDbDataParameter[] parametros = CrearParametrosParaDelete(dataObject);
            Tabla atributoTabla = (Tabla)Attribute.GetCustomAttribute(t, typeof(Tabla));

            if (atributoTabla != null)
                tableName = atributoTabla.Nombre;

            foreach (MethodInfo mi in t.GetMethods())
            {
                foreach (Attribute att in Attribute.GetCustomAttributes(mi))
                {
                    if (typeof(Columna).IsAssignableFrom(att.GetType()))
                    {
                        var dao = (Columna)att;

                        if (dao.LlavePrimaria)
                        {
                            if (parametros != null)
                            {
                                foreach (IDbDataParameter parametro in parametros)
                                {
                                    if (parametro.Value != null)
                                    {
                                        if (parametro.ParameterName.Equals(dao.NombreColumna))
                                        {
                                            if(llavePrimaria.Equals(""))
                                                llavePrimaria = $"{parametro.ParameterName} = {parametro.Value}";
                                            else
                                            {
                                                llavePrimaria += " AND " + $"{parametro.ParameterName} = {parametro.Value}";
                                            }
                                        }                                        
                               
                                    }
                                }

                            }
                        }
                    }
                }
            }

            cmd.CommandText = "DELETE FROM " + tableName + " WHERE " + llavePrimaria;

            return cmd;
        }

        /// <summary>
        /// Crea los distintos tipos de parametro.
        /// </summary>
        /// <param name="nombre">The nombre.</param>
        /// <param name="valor">The valor.</param>
        /// <returns></returns>
        public IDbDataParameter CrearParametro(string nombre, object valor)
        {
            var param = new SqlParameter
            {
                ParameterName = nombre,
                Value = valor
            };

            if (valor is string)
            {
                param.DbType = DbType.String;
                param.Value = "'" + param.Value + "'";
            }

            if (valor is long)
                param.DbType = DbType.Int64;

            if (valor is double)
                param.DbType = DbType.Double;

            if (valor is DateTime)
            {
                param.DbType = DbType.DateTime;
                param.Value = "'" + ((DateTime) param.Value).ToString("MM/dd/yyyy HH:mm:ss") + "'";
            }
        
            if (valor is Byte)
                param.DbType = DbType.Byte;

            if (valor is bool)
            {
                param.DbType = DbType.Boolean;
                if (Boolean.Parse(param.Value.ToString()))
                    param.Value = 1;
                else
                    param.Value = 0;
            }

            if (valor is int)
                param.DbType = DbType.Int32;

            if (valor is TipoEvento)
            {
                param.DbType = DbType.String;
                param.Value = "'" + param.Value + "'";
            }

            if (valor is Genero)
            {
                param.DbType = DbType.String;
                param.Value = "'" + param.Value + "'";
            }

            return param;
        }

        /// <summary>
        /// Crea los parametros para un comando.
        /// </summary>
        /// <param name="pObjeto">The p objeto.</param>
        /// <param name="llavePrimaria">if set to <c>true</c> [llave primaria].</param>
        /// <returns></returns>
        private IDbDataParameter[] CrearParametrosParaComando(object pObjeto, bool llavePrimaria)
        {
            Dictionary<string, string> atributosColumnas = ObtenerNombresDeColumnasYAtributos(pObjeto, llavePrimaria);

            var pars = new IDbDataParameter[atributosColumnas.Count];
            int i = 0;

            foreach (KeyValuePair<string, string> atributoColumna in atributosColumnas)
            {
                var valor = pObjeto.GetType().GetProperty(atributoColumna.Value).GetValue(pObjeto, null);

                if (valor != null && valor.GetType().BaseType == typeof(BE.EntidadBase))
                {
                    pars[i] = CrearParametro(atributoColumna.Key, ((BE.EntidadBase)valor).Id);
                }
                else
                    pars[i] = CrearParametro(atributoColumna.Key, valor);
                i++;
            }

            return pars;
        }

        private IDbDataParameter[] CrearParametrosParaComandoSelect(object pObjeto, bool llavePrimaria, bool conFiltros)
        {
            Dictionary<string, string> atributosColumnas = ObtenerNombresDeColumnasYAtributosParaSelect(pObjeto, llavePrimaria, conFiltros);

            var pars = new IDbDataParameter[atributosColumnas.Count];
            int i = 0;

            foreach (KeyValuePair<string, string> atributoColumna in atributosColumnas)
            {
                var valor = pObjeto.GetType().GetProperty(atributoColumna.Value).GetValue(pObjeto, null);

                if (valor != null && valor.GetType().BaseType == typeof(BE.EntidadBase))
                {
                    pars[i] = CrearParametro(atributoColumna.Key, ((BE.EntidadBase)valor).Id);
                }
                else
                    pars[i] = CrearParametro(atributoColumna.Key, valor);
                i++;
            }

            return pars;
        }

        //private IDbDataParameter[] CrearParametrosParaInsert(object pObjeto, bool llavePrimaria)
        //{
        //    Dictionary<string, string> atributosColumnas = ObtenerNombresDeColumnasYAtributos(pObjeto, llavePrimaria);

        //    var pars = new IDbDataParameter[atributosColumnas.Count];
        //    int i = 0;

        //    foreach (KeyValuePair<string, string> atributoColumna in atributosColumnas)
        //    {
        //        var valor = pObjeto.GetType().GetProperty(atributoColumna.Value).GetValue(pObjeto, null);

        //        if (valor != null && valor.GetType().BaseType == typeof(BE.EntidadBase))
        //        {
        //            pars[i] = CrearParametro(atributoColumna.Key, ((BE.EntidadBase)valor).Id);
        //        }
        //        else
        //            pars[i] = CrearParametro(atributoColumna.Key, valor);
        //        i++;
        //    }

        //    return pars;
        //}

        /// <summary>
        /// Crea los parametros para delete.
        /// </summary>
        /// <param name="pObjeto">The p objeto.</param>
        /// <returns></returns>
        private IDbDataParameter[] CrearParametrosParaDelete(object pObjeto)
        {
            Dictionary<string, string> atributosColumnas = ObtenerLlavePrimaria(pObjeto);

            var pars = new IDbDataParameter[atributosColumnas.Count];
            int i = 0;

            foreach (KeyValuePair<string, string> atributoColumna in atributosColumnas)
            {
                var valor = pObjeto.GetType().GetProperty(atributoColumna.Value).GetValue(pObjeto, null);

                pars[i] = CrearParametro(atributoColumna.Key, valor);
                i++;
            }

            return pars;
        }

        /// <summary>
        /// Obtiene los nombres de columnas y atributos.
        /// </summary>
        /// <param name="pObjeto">The p objeto.</param>
        /// <param name="llavePrimaria">if set to <c>true</c> [llave primaria].</param>
        /// <returns></returns>
        private Dictionary<string, string> ObtenerNombresDeColumnasYAtributos(object pObjeto, bool llavePrimaria)
        {
            Dictionary<string, string> atributosColumnas = new Dictionary<string, string>();

            Type t = pObjeto.GetType();

            foreach (MethodInfo mi in t.GetMethods()) 
            {
                foreach (Attribute att in Attribute.GetCustomAttributes(mi)) 
                {
                    if (typeof(Columna).IsAssignableFrom(att.GetType())) 
                    {
                        var dao = (Columna)att;

                        if (llavePrimaria)
                        {
                            atributosColumnas.Add(dao.NombreColumna, dao.NombreAtributo);
                        }
                        else
                        {
                            if (dao.LlavePrimaria == false)
                            {
                                atributosColumnas.Add(dao.NombreColumna, dao.NombreAtributo);
                            }
                            else
                            {
                                if (dao.Filtro == true)
                                {
                                    atributosColumnas.Add(dao.NombreColumna, dao.NombreAtributo);
                                }
                            }
                        }
                    }
                }
            }

            return atributosColumnas;
        }

        private Dictionary<string, string> ObtenerNombresDeColumnasYAtributosParaSelect(object pObjeto, bool llavePrimaria, bool conFiltros)
        {
            Dictionary<string, string> atributosColumnas = new Dictionary<string, string>();

            Type t = pObjeto.GetType();

            foreach (MethodInfo mi in t.GetMethods()) 
            {
                foreach (Attribute att in Attribute.GetCustomAttributes(mi)) 
                {
                    if (typeof(Columna).IsAssignableFrom(att.GetType())) 
                    {
                        var dao = (Columna)att;

                        //if (llavePrimaria && conFiltros)
                        //{
                        //    if (dao.Filtro == true || dao.LlavePrimaria == true)
                        //    {
                        //        atributosColumnas.Add(dao.NombreColumna, dao.NombreAtributo);
                        //    }
                        //    //atributosColumnas.Add(dao.NombreColumna, dao.NombreAtributo);
                        //}
                        //else
                        //{
                        //    if (dao.LlavePrimaria == false)
                        //    {
                        //        atributosColumnas.Add(dao.NombreColumna, dao.NombreAtributo);
                        //    }
                        //    else
                        //    {
                        //        if (dao.Filtro == true)
                        //        {
                        //            atributosColumnas.Add(dao.NombreColumna, dao.NombreAtributo);
                        //        }
                        //    }
                        //}

                        if (llavePrimaria)
                        {
                            if (dao.LlavePrimaria == true)
                            {
                                atributosColumnas.Add(dao.NombreColumna, dao.NombreAtributo);
                            }
                        }
                        else
                        {
                            
                            if (conFiltros)
                            {
                                //if (dao.Filtro == true)
                                //{
                                atributosColumnas.Add(dao.NombreColumna, dao.NombreAtributo);
                                //}
                            }
                        }
                    }
                }
            }

            return atributosColumnas;
        }

        /// <summary>
        /// Obtiene la llave primaria de la entidad.
        /// </summary>
        /// <param name="pObjeto">The p objeto.</param>
        /// <returns></returns>
        private Dictionary<string, string> ObtenerLlavePrimaria(object pObjeto)
        {
            Dictionary<string, string> atributosColumnas = new Dictionary<string, string>();

            Type t = pObjeto.GetType();

            foreach (MethodInfo mi in t.GetMethods())
            {
                foreach (Attribute att in Attribute.GetCustomAttributes(mi))
                {
                    if (typeof(Columna).IsAssignableFrom(att.GetType()))
                    {
                        var dao = (Columna)att;

                        if (dao.LlavePrimaria)
                        {
                            atributosColumnas.Add(dao.NombreColumna, dao.NombreAtributo);
                        }
              
                    }
                }
            }

            return atributosColumnas;
        }

    }
}
