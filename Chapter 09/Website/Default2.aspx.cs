using System;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using Chapter09.Database;

public partial class Default2 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DatabaseManager dbm = new DatabaseManager();
        dbm.InitializeDatabase();

        //System.Configuration.Configuration config;
        //HttpContext context = HttpContext.Current;
        //string path = context.Request.ApplicationPath;
        //if (!path.EndsWith("/"))
        //{
        //    path += "/";
        //}
        //config = WebConfigurationManager.OpenWebConfiguration(path);
    }
}
