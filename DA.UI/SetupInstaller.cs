﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.Windows.Forms;

namespace DA.UI
{
    [RunInstaller(true)]
    public partial class SetupInstaller : Installer
    {
        public SetupInstaller()
        {
            InitializeComponent();
        }

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
                MessageBox.Show(@"Error al obtener el SQL. Error: " + ex.Message,"Instalación",MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw ex;
            }
        }

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

           // MessageBox.Show(query, "Instalación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //GetExecutionDirectory();
            ExecuteSql(true, query);
            //ExecuteSql(true , GetSql("CreateBD.txt"));
        }

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
    }
}
