using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Chapter07.Website;

public partial class Controls_LinksControl : UserControl
{

    #region "  Events  "

    protected void Page_Load(object sender, EventArgs e)
    {
        rptLinks.DataBind();
        rptLinks.Visible = rptLinks.Items.Count > 0;
    }

    protected void ObjectDataSource1_Selecting(
        object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["profileId"] = Utility.GetProfile().ProfileID;
        e.InputParameters["startDaysBack"] = StartDaysBack;
        e.InputParameters["endDaysBack"] = EndDaysBack;
    }

    protected void ObjectDataSource2_Selecting(
        object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["profileId"] = Utility.GetProfile().ProfileID;
        e.InputParameters["startDaysBack"] = StartDaysBack;
        e.InputParameters["endDaysBack"] = EndDaysBack;
    }

    protected void ObjectDataSource3_Selecting(
        object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["profileId"] = Utility.GetProfile().ProfileID;
        e.InputParameters["startDaysBack"] = StartDaysBack;
        e.InputParameters["endDaysBack"] = EndDaysBack;
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
            HtmlGenericControl h3Title = e.Item.FindControl("h3Title") as HtmlGenericControl;
            if (h3Title != null)
            {
                h3Title.Visible = TitleVisible;
            }
        }
    }

    #endregion

    #region "  Methods  "
    #endregion

    #region "  Properties  "

    private string _title;

    [Browsable(true), DefaultValue("Links"), Category("Links")]
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

    private int _startDaysBack = 7;

    [Browsable(true), DefaultValue(7), Category("Links")]
    public int StartDaysBack
    {
        get { return _startDaysBack; }
        set { _startDaysBack = value; }
    }

    private int _endDaysBack = 0;

    [Browsable(true), DefaultValue(0), Category("Links")]
    public int EndDaysBack
    {
        get { return _endDaysBack; }
        set { _endDaysBack = value; }
    }

    private bool _isTitleVisible = true;

    [Browsable(true), DefaultValue(true), Category("Links")]
    public bool TitleVisible
    {
        get { return _isTitleVisible;  }
        set { _isTitleVisible = value; }
    }

    #endregion

}
