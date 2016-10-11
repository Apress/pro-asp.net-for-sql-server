using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageState_Default : Page
{

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBox1.Text = "My Text Value";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        GridView GridView1 = new GridView();
        
        if (! IsPostBack)
        {
            GridView1.DataSource = GetDataSource();
            GridView1.DataBind();
        }
        else if (! IsViewStateEnabled)
        {
            GridView1.DataSource = GetDataSource();
            GridView1.DataBind();
        }

    }

    public object GetDataSource()
    {
        return null;
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}
