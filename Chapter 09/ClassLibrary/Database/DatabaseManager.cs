using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Text;
using Chapter09.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccess = Microsoft.Practices.EnterpriseLibrary.Data;

namespace Chapter09.Database
{
    public class DatabaseManager
    {

        private DataAccess.Database db;
        private const string CommandDelimiter = "GO";
        private const string ScriptsPrefix = "Chapter09.Database.Scripts.";
        
        public DatabaseManager()
        {
            Chapter09SectionGroup chapter09Config = Chapter09Configuration.GetConfig();
            Chapter09Section section = chapter09Config.Chapter09Section;

            db = DatabaseFactory.CreateDatabase(section.ConnectionStringName);
        }

        public void InitializeDatabase()
        {
            if (IsAutoUpdatesEnabled())
            {
                bool success = true;
                if (!IsInitialized())
                {
                    List<string> initCommands = GetSqlCommands(ScriptsPrefix + "init.sql");
                    success = RunSqlCommands(initCommands);
                }
                if (success)
                {
                    UpdateDatabase();
                }
            }
        }

        public bool IsAutoUpdatesEnabled()
        {
            // Use AppSettings
            //string setting = ConfigurationManager.AppSettings["EnableAutoUpdates"];
            //bool isAutoUpdatesEnabled = false;
            //bool.TryParse(setting, out isAutoUpdatesEnabled);
            //return isAutoUpdatesEnabled;

            // Use custom configuration section
            Chapter09SectionGroup chapter09Config = Chapter09Configuration.GetConfig();
            Chapter09Section section = chapter09Config.Chapter09Section;
            return section.EnableAutoUpdates;
        }

        public bool IsInitialized()
        {
            bool isInitialized = false;
            DataSet ds = new DataSet();
            string sql = "SELECT COUNT(*) FROM sysobjects WHERE type = 'U' AND name = 'chpt09_SchemaVersions'";
            using (DbCommand dbCmd = db.GetSqlStringCommand(sql))
            {
                ds = db.ExecuteDataSet(dbCmd);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    int count = (int)ds.Tables[0].Rows[0][0];
                    isInitialized = (count == 1);
                }
            }
            return isInitialized;
        }

        public int GetSchemaVersion(string name)
        {
            int version = 0;
            using (DbCommand dbCmd = db.GetStoredProcCommand("chpt09_GetSchemaVersion"))
            {
                db.AddInParameter(dbCmd, "@Name", DbType.String, name);
                db.AddOutParameter(dbCmd, "@Version", DbType.Int32, 0);

                db.ExecuteNonQuery(dbCmd);
                version = (int)db.GetParameterValue(dbCmd, "@Version");
            }
            return version;
        }

        public List<string> GetSqlCommands(string scriptName)
        {
            List<string> commands = new List<string>();
            Type type = GetType();

            Stream stream = type.Assembly.GetManifestResourceStream(scriptName);
            if (stream != null)
            {
                StringBuilder sb = new StringBuilder();
                StreamReader sr = new StreamReader(stream);
                string line = null;

                while (sr.Peek() >= 0)
                {
                    line = sr.ReadLine();
                    if (!CommandDelimiter.Equals(line))
                    {
                        sb.AppendLine(line);
                    }
                    else
                    {
                        commands.Add(sb.ToString());
                        sb = new StringBuilder();
                    }
                }
                if (!String.IsNullOrEmpty(sb.ToString()))
                {
                    commands.Add(sb.ToString());
                }
            }

            return commands;
        }

        private void UpdateDatabase()
        {
            int version = GetSchemaVersion("names");

            if (version == 0)
            {
                List<string> commands =
                    GetSqlCommands(ScriptsPrefix + "NamesUpdate.00.sql");
                if (RunSqlCommands(commands))
                {
                    version = GetSchemaVersion("names");
                }
            }

            if (version == 1)
            {
                List<string> commands =
                    GetSqlCommands(ScriptsPrefix + "NamesUpdate.01.sql");
                if (RunSqlCommands(commands))
                {
                    version = GetSchemaVersion("names");
                }
            }

            if (version == 2)
            {
                List<string> commands =
                    GetSqlCommands(ScriptsPrefix + "NamesUpdate.02.sql");
                if (RunSqlCommands(commands))
                {
                    version = GetSchemaVersion("names");
                }
            }
        }

        private bool RunSqlCommands(List<string> commands)
        {
            bool success = true;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    foreach (string command in commands)
                    {
                        using (DbCommand dbCmd = db.GetSqlStringCommand(command))
                        {
                            db.ExecuteNonQuery(dbCmd, transaction);
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    success = false;
                    Trace.WriteLine(ex.Message);
                    // Rollback transaction 
                    transaction.Rollback();
                }
                connection.Close();
            }
            return success;
        }

    }
}
