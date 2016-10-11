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
using SubSonic;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected override void OnLoad(EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;
        DataService.LoadProviders();
        base.OnLoad(e);
    }
}
