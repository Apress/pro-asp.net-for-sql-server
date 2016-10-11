using System;
using System.ComponentModel;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Chapter07.Website;

public partial class Controls_TagCloudControl : UserControl
{

    [Browsable(true), Category("Tags")]
    public event EventHandler<TagCloudEventArgs> TagSelected;

    [Category("Tags")]
    protected virtual void OnTagSelected(TagCloudEventArgs e)
    {
        if (TagSelected != null)
        {
            TagSelected(this, e);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        rptLinkTags.DataBind();
        
        string startupKey = "startupHandleLinks";
        if (!Page.ClientScript.IsStartupScriptRegistered(startupKey))
        {
            string script = "handleTagCloudLinks();";
            Page.ClientScript.RegisterStartupScript(GetType(), startupKey, script, true);
        }
    }

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["profileID"] = Utility.GetProfile().ProfileID;
    }

    protected void rptLinkTags_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem ||
                e.Item.ItemType == ListItemType.Item)
            {
                if (e.Item.DataItem is DataRowView)
                {
                    DataRow row = ((DataRowView) e.Item.DataItem).Row;
                    int count = (int) row["Count"];
                    LinkButton lb = e.Item.FindControl("lbLinkTag") as LinkButton;
                    if (lb != null)
                    {
                        //lb.Text = token;
                        lb.CommandName = "SelectTag";
                        if (count > 18)
                        {
                            lb.CssClass = "tagLink1";
                        }
                        else if (count > 12)
                        {
                            lb.CssClass = "tagLink2";
                        }
                        else if (count > 6)
                        {
                            lb.CssClass = "tagLink3";
                        }
                        else if (count > 2)
                        {
                            lb.CssClass = "tagLink4";
                        }
                        else
                        {
                            lb.CssClass = "tagLink5";
                        }
                    }
                }
            }
        }
    }

    protected void rptLinkTags_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if ("SelectTag".Equals( e.CommandName))
        {
            TagCloudEventArgs ea = new TagCloudEventArgs((string)e.CommandArgument);
            OnTagSelected(ea);
        }
    }
}

public class TagCloudEventArgs : EventArgs
{

    public TagCloudEventArgs (string token)
    {
        Token = token;
    }

    private string _token;
    public string Token
    {
        get { return _token; }
        set { _token = value; }
    }

}