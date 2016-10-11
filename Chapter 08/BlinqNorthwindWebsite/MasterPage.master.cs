using System;
using System.Web;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{       
    protected void mainMenu_MenuItemDataBound(object sender, MenuEventArgs e)
    {
        bool isVisible = true;

        if (Boolean.TryParse(((SiteMapNode)e.Item.DataItem)["displayInMenu"], out isVisible))
        {
            if (!isVisible)
            {
                e.Item.Parent.ChildItems.Remove(e.Item);
            }
        }     
    } 
}
