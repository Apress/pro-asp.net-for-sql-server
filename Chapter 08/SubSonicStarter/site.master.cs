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

public partial class site : System.Web.UI.MasterPage
{

    CMS.PageCollection pageCollection;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            Head1.Controls.Add(new LiteralControl("<script type='text/javascript' src='" + Page.ResolveUrl("~/js/modal/common.js") + "'></script>"));
            Head1.Controls.Add(new LiteralControl("<script type='text/javascript' src='" + Page.ResolveUrl("~/js/modal/subModal.js") + "'></script>"));
            siteMenu.PreRender += new EventHandler(siteMenu_PreRender);

        }
    }

    void siteMenu_PreRender(object sender, EventArgs e) {
        
        //if you want to add your own links to the SiteMenu,
        //do it here
        //MenuItem item = new MenuItem("My Item Name", "menuKey","imageUrl","navigateUrl","target");
        
        //you can insert the item
        //siteMenu.Items.AddAt(0, item);

        //or add it to a submenu
        //siteMenu.Items[0].ChildItems.Add(item);

        //if you add to a submenu - the hierarchy is 
        //Home
        //--Dynamic Pages
        //-- --SubDynamic Pages
        //so everything has to go under "Home"
        //you can get around that by using "AddAt()", which will insert your links anywhere

        if (SiteUtility.UserCanEdit()) {
            MenuItem adminRoot = new MenuItem("Admin", "admin_root");
            
            MenuItem adminSecurityRoot = new MenuItem("Membership", "admin_membership");
            MenuItem adminCMSRoot = new MenuItem("CMS", "admin_cms");
            
            MenuItem adminItem = new MenuItem("Users", "admin_users", "", "~/admin/users.aspx", "");
            adminSecurityRoot.ChildItems.Add(adminItem);
            
            adminItem = new MenuItem("Roles", "admin_roles", "", "~/admin/roles.aspx", "");
            adminSecurityRoot.ChildItems.Add(adminItem);

            adminItem = new MenuItem("Pages", "admin_cms", "", "~/admin/cmspagelist.aspx", "");
            adminCMSRoot.ChildItems.Add(adminItem);

            adminItem = new MenuItem("New Page", "admin_cms_new", "", "~/view/newpage.aspx", "");
            adminCMSRoot.ChildItems.Add(adminItem);
            
            adminRoot.ChildItems.Add(adminSecurityRoot);
            adminRoot.ChildItems.Add(adminCMSRoot);

            //find the "Home" menu
            //this is a little wonky - but there's just no other way to do it
            //sorry...
            foreach (MenuItem item in siteMenu.Items) {
                if (item.Text == "Home") {
                    item.ChildItems.Add(adminRoot);
                    break;
                }
            }

        }
    
    }



    protected void lnkLogout_Click1(object sender, EventArgs e) {

         FormsAuthentication.SignOut();
	        Response.Redirect("default.aspx", false);
   }
}
