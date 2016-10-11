using System;
using System.Web.UI;
using Chapter08.Website;

public partial class _Default : Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string vp1 = SampleClass.GetVirtualPath();
        string vp2 = AnotherClass.GetVirtualPath();
        Person p = new Person();
        p.FirstName = "Joe";
        p.LastName = "Public";
        p.BirthDate = DateTime.Now.AddYears(-30);
        p.Location = "Milwaukee, WI";

        lbl1.Text = vp1;
        lbl2.Text = vp2;
    }

}
