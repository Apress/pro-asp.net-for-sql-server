using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Chapter05.PhotoAlbumProvider;

/// <summary>
/// Summary description for Utility
/// </summary>
public class Utility
{

    public static void Load()
    {
        // Get the current configuration file.
        PhotoAlbumSection x = ConfigurationManager.GetSection("PhotoAlbumProvider") as PhotoAlbumSection;
        ProviderSettings settings = x.Providers[x.DefaultProvider];
    }
}
