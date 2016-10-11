using System;
using System.Web.UI;

public partial class PageState_Controls_BottomUserControl : UserControl
{
    private string _controlStateData = String.Empty;
    
    protected void Page_Init(object sender, EventArgs e)
    {
        Page.RegisterRequiresControlState(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["Label2Data"] = "456";
            _controlStateData = "abc";
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        Label1.Text = IsViewStateEnabled.ToString();
        Label2.Text = (string)ViewState["Label2Data"];
        Label3.Text = _controlStateData;
    }

    #region "  Control State  "

    protected override object SaveControlState()
    {
        Pair state = new Pair();
        state.First = base.SaveControlState();
        state.Second = _controlStateData;

        return state;
    }

    protected override void LoadControlState(object savedState)
    {
        Pair pair = savedState as Pair;
        if (pair != null)
        {
            base.LoadControlState(pair.First);
            _controlStateData = (string)pair.Second;
        }
        else
        {
            base.LoadControlState(null);
        }
    }

    #endregion
}
