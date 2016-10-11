using System;
using System.Web.UI;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Context.Items["CurrentProduct"] = Utility.GetProduct(Context);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String key = "x";
        Utility.AddToCache(key, "x1");
        Utility.AddToCache(key, "x2");
        String value = Cache[key] as String;
        if (value == null)
        {
            Label1.Text = "null";
        }
        else
        {
            Label1.Text = value;
        }
    }
}
