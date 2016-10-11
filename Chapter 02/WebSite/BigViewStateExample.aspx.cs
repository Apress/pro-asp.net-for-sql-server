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
using Chapter02;

public partial class BigViewStateExample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PersonDomain pd = new PersonDomain();
        GridView1.DataSource = pd.GetAllPeopleDataSet();
        GridView1.DataBind();
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        //GridView1.Visible = false;
    }
}
