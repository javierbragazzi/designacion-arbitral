namespace DA.UI
{
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Configuration.Install;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Reflection;
    using System.Security.Permissions;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="SetupInstaller" />.
    /// </summary>
    [RunInstaller(true)]
    public partial class SetupInstaller : Installer
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SetupInstaller"/> class.
        /// </summary>
        public SetupInstaller()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The ExecuteTransaction.
        /// </summary>
        /// <param name="script">The script<see cref="string"/>.</param>
        /// <param name="isMaster">The isMaster<see cref="bool"/>.</param>
        public void ExecuteTransaction(string script, bool isMaster)
        {
            using (Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(isMaster ? Properties.Settings.Default.ConnStringWithSA : Properties.Settings.Default.ConnStringToRefereeDB))
            {
                Server server = new Server(new ServerConnection(connection));
                try
                {
                    server.ConnectionContext.BeginTransaction();
                    server.ConnectionContext.ExecuteNonQuery(script);
                    server.ConnectionContext.CommitTransaction();
                }
                catch (Exception ex)
                {
                    server.ConnectionContext.RollBackTransaction();
                    MessageBox.Show(@"Error al restaurar la base por script. Error: " + ex.Message, "Instalación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        /// <summary>
        /// The Install.
        /// </summary>
        /// <param name="stateSaver">The stateSaver<see cref="IDictionary"/>.</param>
        public override void Install(IDictionary stateSaver)
        {
            string dataBaseName = Properties.Settings.Default.DataBaseName;

            //if (Debugger.IsAttached == false)
            //    Debugger.Launch();

            base.Install(stateSaver);

            //Debugger.Break();

            string query = "USE MASTER \n";
            query += "CREATE DATABASE " + dataBaseName + " \n";
            query += "RESTORE DATABASE " + dataBaseName + " FROM DISK = '" + GetExecutionDirectory() + "\\" + dataBaseName + ".bak" + "' WITH REPLACE;";

            string script = File.ReadAllText(GetExecutionDirectory() + "\\Script.sql");
            // MessageBox.Show(query, "Instalación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //GetExecutionDirectory();
            //ExecuteSql(true, query);
            ExecuteTransaction(script, true);
        }

        /// <summary>
        /// The Uninstall.
        /// </summary>
        /// <param name="savedState">The savedState<see cref="IDictionary"/>.</param>
        [SecurityPermission(SecurityAction.Demand)]
        public override void Uninstall(IDictionary savedState)
        {
            //if (Debugger.IsAttached == false)
            //    Debugger.Launch();

            //Debugger.Break();


            string dataBaseName = Properties.Settings.Default.DataBaseName;

            base.Uninstall(savedState);

            string query = "USE MASTER \n";
            query += "ALTER DATABASE " + dataBaseName + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE \n";
            query += "DROP DATABASE " + dataBaseName + " \n";

            ExecuteSql(true, query);
        }

        /// <summary>
        /// The ExecuteSql.
        /// </summary>
        /// <param name="isMaster">The isMaster<see cref="bool"/>.</param>
        /// <param name="query">The query<see cref="string"/>.</param>
        private void ExecuteSql(bool isMaster, string query)
        {

            try
            {

                SqlCommand command = new SqlCommand
                {
                    CommandText = query,
                    CommandType = CommandType.Text,
                    Connection = new SqlConnection(isMaster ? Properties.Settings.Default.ConnStringWithSA : Properties.Settings.Default.ConnStringToRefereeDB)

                };


                command.Connection.Open();

                int fa = command.ExecuteNonQuery();

                command.Connection.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error al restaurar la base. Error: " + ex.Message, "Instalación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        /// <summary>
        /// The GetExecutionDirectory.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        private string GetExecutionDirectory()
        {

            try
            {

                //Debugger.Break();
                // Gets the current assembly.
                Assembly asm = Assembly.GetExecutingAssembly();

                return Path.GetDirectoryName(asm.Location);


            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error al obtener el SQL. Error: " + ex.Message, "Instalación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        /// <summary>
        /// The GetSql.
        /// </summary>
        /// <param name="name">The name<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private string GetSql(string name)
        {

            try
            {

                //  Debugger.Break();
                // Gets the current assembly.
                Assembly asm = Assembly.GetExecutingAssembly();

                // Resources are named using a fully qualified name.
                Stream strm = asm.GetManifestResourceStream(asm.GetName().Name + "." + name);

                // Reads the contents of the embedded file.
                StreamReader reader = new StreamReader(strm);

                return reader.ReadToEnd();

            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error al obtener el SQL. Error: " + ex.Message, "Instalación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        #endregion
    }
}
