using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_CMSPageList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int pageID = SubSonic.Utilities.Utility.GetIntParameter("id");
        if(pageID!=0){
            CMS.Page p = CMS.ContentService.GetPage(pageID);
            if (p.IsLoaded) {
                Response.Redirect("~/view/" + p.PageUrl);
            }
        }
    }
}
