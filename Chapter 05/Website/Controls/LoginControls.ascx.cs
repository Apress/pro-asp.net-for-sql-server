using System;
using System.Web.UI;

public partial class Controls_LoginControls : UserControl
{
    protected void ddlViewChanger_SelectedIndexChanged(object sender, EventArgs e)
    {
        int viewIndex;
        int.TryParse(ddlViewChanger.SelectedValue, out viewIndex);
        mvLoginControls.ActiveViewIndex = viewIndex;
        if (2 == viewIndex)
        {
            CreateCustomUserControl1.Reset();
        }
    }
}
