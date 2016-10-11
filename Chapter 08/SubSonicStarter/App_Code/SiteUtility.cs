using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// A class for you to use as needed; extend's SubSonic's core utility set
/// </summary>
public class SiteUtility:SubSonic.Utilities.Utility
{
    /// <summary>
    /// This is the Role that we evaluate for CMS editing privvies
    /// Change as needed
    /// </summary>
    const string CONTENT_EDITOR_ROLE = "Content Editor";
    
    public static bool UserCanEdit() {
        return HttpContext.Current.User.IsInRole(CONTENT_EDITOR_ROLE);
    }
}
