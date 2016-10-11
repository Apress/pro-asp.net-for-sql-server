using System;
using System.Diagnostics;
using System.Web;
using Chapter09.Database;

namespace Chapter09.Website
{

    /// <summary>
    /// Summary description for Global
    /// </summary>
    public class Global : HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            DatabaseManager dbm = new DatabaseManager();
            dbm.InitializeDatabase();
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception lastError = Server.GetLastError();
            Trace.WriteLine(lastError.Message);
        }
    }

}