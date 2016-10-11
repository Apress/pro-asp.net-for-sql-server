using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Chapter07.Domain;
using Chapter07.Website;

public partial class Controls_TaggedLinksControl : UserControl
{

    public override void DataBind()
    {
        base.DataBind();
        if (String.IsNullOrEmpty(Token))
        {
            string token = (string)Context.Items["token"];
            if (String.IsNullOrEmpty(token))
            {
                token = "news";
            }
            Token = token;
        }
        if (String.IsNullOrEmpty(Title))
        {
            Title = "Tagged with " + Token;
        }

        rptLinks.DataBind();
    }
    
    protected void Page_PreRender(object sender, EventArgs e)
    {
        DataBind();
        if (!String.Empty.Equals(Token))
        {
            rptLinks.Visible = rptLinks.Items.Count > 0;
        }
    }

    protected void ObjectDataSource_Selecting(object sender, 
        ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["profileId"] = Utility.GetProfile().ProfileID;
        e.InputParameters["token"] = Token;
    }

    protected void rptLinks_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            Literal ltTitle = e.Item.FindControl("ltTitle") as Literal;
            if (ltTitle != null)
            {
                ltTitle.Text = Title;
            }
        }
        else if (e.Item.ItemType == ListItemType.AlternatingItem ||
            e.Item.ItemType == ListItemType.Item)
        {
            FavoriteLink lm = e.Item.DataItem as FavoriteLink;
            if (lm != null)
            {
                Literal lt1 = e.Item.FindControl("lt1") as Literal;
                if (lt1 != null)
                {
                    lt1.Text = lm.Rating.ToString();
                }
                HyperLink hl1 = e.Item.FindControl("hl1") as HyperLink;
                if (hl1 != null)
                {
                    hl1.Text = lm.Title;
                    hl1.NavigateUrl = lm.Url;
                }
            }
        }
    }

    private string _title;
    [Browsable(true), DefaultValue("Links"), Category("Links")]
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

    private string _token = String.Empty;
    [Browsable(true), DefaultValue("Links"), Category("Links")]
    public string Token
    {
        get { return _token; }
        set { _token = value; }
    }
}
