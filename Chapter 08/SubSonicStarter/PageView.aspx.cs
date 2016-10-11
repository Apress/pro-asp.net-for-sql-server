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

public partial class PageView : System.Web.UI.Page
{

    protected CMS.Page thisPage=new CMS.Page();
    //This is the secret sauce to get the uploader to work properly
    protected void Page_Init(object sender, EventArgs e) {
        Body.SkinPath = "skins/office2003/";
        Session["FCKeditor:UserFilesPath"] = Page.ResolveUrl("~/CMSFiles");

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string pageUrl = SubSonic.Utilities.Utility.GetParameter("p");
        if (pageUrl != "newpage.aspx") {
            //this will throw an error if the page doesn't exist
            try {
                thisPage = CMS.ContentService.GetPage(pageUrl);
                this.Title = thisPage.Title;

                //add the keywords
                HtmlHead head = (System.Web.UI.HtmlControls.HtmlHead)Header;

                //Create a htmlMeta object
                HtmlMeta meta = new HtmlMeta();

                //Specify meta attributes
                meta.Attributes.Add("name", "keywords");
                meta.Attributes.Add("content", thisPage.Keywords);

                // Add the meta object to the htmlhead's control collection
                head.Controls.Add(meta);

            } catch {
                lnkEdit.Enabled = false;
                thisPage.Title = "Oops! Can't find that page...";

                //you can show whichever 404 page you like. I like this one...
                string FourOFourText = SubSonic.Utilities.Utility.GetFileText(Server.MapPath("~/CMSFiles/404.htm"));
                thisPage.Body = FourOFourText;

            }
            ToggleEditor(false);
        } else {
            SetupNewPage();
            this.Title = "Create a New Page";
        }

    }

    #region Page State Methods
    void SetupNewPage() {
        ToggleEditor(true);
        editorTitle.Text = "Create New Page";
        btnDelete.Visible = false;
        lnkEdit.Enabled = false;
        //ParentID.Enabled = false;
        btnSetParent.Enabled = false;
        
        
        LoadRoles();
        LoadParentDrop();

    }
    void ToggleEditor(bool showIt) {
        pnlEdit.Visible = showIt;
        pnlPublic.Visible = !showIt;
    }
    void LoadEditor() {
        ToggleEditor(true);
        editorTitle.Text = "Edit " + thisPage.Title;
        lnkEdit.Enabled = false;
        //set the editor
        txtTitle.Text = thisPage.Title;
        txtSummary.Text = thisPage.Summary;
        Body.Value = thisPage.Body;
        txtMenuTitle.Text = thisPage.MenuTitle;

        //set the delete confirmation
        btnDelete.Attributes.Add("onclick", "return CheckDelete();");

        LoadRoles();
        LoadPageHierarchy();
        LoadParentDrop();

    }
    #endregion

    #region Button Events

    protected void lnkEdit_Click(object sender, EventArgs e) {
        LoadEditor();
    }
    protected void btnCancel_Click(object sender, EventArgs e) {
        Response.Redirect("~/view/" + thisPage.PageUrl);
    }
    protected void btnSave_Click(object sender, EventArgs e) {

        SavePage();
    }
    protected void lnkNewPage_Click(object sender, EventArgs e) {
        //redirect to "newpage.aspx"
        //this is a trigger that tells the page to setup for an add
        Response.Redirect("~/view/newpage.aspx");
    }


    protected void btnDelete_Click(object sender, EventArgs e) {
        DeletePage();
    }

    protected void btnSetParent_Click(object sender, EventArgs e) {
        ResetParent();
    }


    #endregion

    #region Control loaders

    void LoadRoles() {
        if (chkRoles.Items.Count == 0) {
            string[] roles = Roles.GetAllRoles();
            chkRoles.Items.Clear();
            foreach (string s in roles) {
                ListItem item = new ListItem(s);
                chkRoles.Items.Add(item);
            }

            //set the roles
            foreach (ListItem item in chkRoles.Items) {
                if (thisPage.Roles == "*") {
                    item.Selected = true;
                } else {
                    if (thisPage.Roles.Contains(item.Value)) {
                        item.Selected = true;
                    }
                }
            }
        }
    }

    void LoadParentDrop() {
        if (ParentID.Items.Count == 0) {
            ListItemCollection items = GetPageHierarchy();
            foreach (ListItem item in items) {
                ParentID.Items.Add(item);
            }        //remove this page from the list, since it can't
            //be it's own parent
            foreach (ListItem item in items) {
                if (item.Value == thisPage.PageID.ToString()) {
                    items.Remove(item);
                    break;
                }
            }


            //set the default
            ParentID.Items.Insert(0, new ListItem("--None--", "0"));

            //set the selection
            if (thisPage.ParentID != null) {
                ParentID.SelectedValue = thisPage.ParentID.ToString();
            } else {
                ParentID.SelectedIndex = 0;
            }
        }
    }

    ListItemCollection pageHierarchy=null;
    ListItemCollection GetPageHierarchy() {
        CMS.PageCollection pages = CMS.ContentService.GetHierarchicalPageCollection();

        if (pageHierarchy == null) {
            pageHierarchy = new ListItemCollection();
            lstHierarchy.Items.Clear();
            ListItem item;
            foreach(CMS.Page page in pages) {
                
                string lvlIndicator = string.Empty;
                for (int i = 0; i < page.Level; i++)
                    lvlIndicator += " - ";

                item = new ListItem(lvlIndicator + page.Title, page.PageID.ToString());

                pageHierarchy.Add(item);
            }
        }
        return pageHierarchy;
    }
    
    void LoadPageHierarchy() {
        ListItemCollection items = GetPageHierarchy();
        lstHierarchy.Items.Clear();
        foreach (ListItem item in items) {
            lstHierarchy.Items.Add(item);
        }
        try {
            lstHierarchy.SelectedValue = thisPage.PageID.ToString();
        } catch {

        }


    }

    #endregion

    #region Service Calls

    void SavePage() {
        //set the editor
        thisPage.Title = txtTitle.Text;
        thisPage.Summary = txtSummary.Text;
        thisPage.Body = Body.Value;
        thisPage.MenuTitle = txtMenuTitle.Text;
        thisPage.Keywords = txtKeywords.Text;

        string selectedRoles = string.Empty;
        bool isAllRoles = true;
        foreach (ListItem item in chkRoles.Items) {
            if (item.Selected) {
                selectedRoles += item.Value + ",";
            } else {
                isAllRoles = false;
            }
        }
        if (isAllRoles) {
            selectedRoles = "*";
        } else {
            if (selectedRoles.Length > 0) {
                selectedRoles = selectedRoles.Remove(selectedRoles.Length - 1, 1);
            } else {
                selectedRoles = "*";
            }
        }

        thisPage.Roles = selectedRoles;

        if (ParentID.SelectedIndex != 0) {
            thisPage.ParentID = int.Parse(ParentID.SelectedValue);
        } else {
            thisPage.ParentID = null;
        }

        bool haveError = false;
        try {
            CMS.ContentService.SavePage(thisPage);
            ResetSiteMap();
        } catch (Exception x){
            haveError = true;
            ResultMessage1.ShowFail(x.Message);
        }

        //redirect to it
        if(!haveError)
            Response.Redirect("view/" + thisPage.PageUrl);
    }

    void DeletePage() {
        //delete the page and send to the admin page list
        bool haveError = false;
        try {
            CMS.ContentService.DeletePage(thisPage.PageID);
            this.ResetSiteMap();
        } catch (Exception x) {
            ResultMessage1.ShowFail(x.Message);
            haveError = true;
            ToggleEditor(true);
        }
        if (!haveError)
            Response.Redirect("~/admin/cmspagelist.aspx");
    }

    void ResetParent() {
        ToggleEditor(true);
        //reset the parent and reload the page
        try {
            int? newParentID = null;
            if(ParentID.SelectedIndex!=0)
                newParentID=int.Parse(ParentID.SelectedValue);

            CMS.ContentService.ChangeParent(thisPage.PageID, newParentID);
            LoadPageHierarchy();
            ResetSiteMap();

        } catch (Exception x) {
            ResultMessage1.ShowFail(x.Message);
        }

    }

    void ResetSiteMap() {
        SubSonicSiteMapProvider siteMap = (SubSonicSiteMapProvider)SiteMap.Provider;
        siteMap.Reload();

    }

    #endregion
}
