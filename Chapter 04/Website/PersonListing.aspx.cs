using System;
using System.Web.UI;

public partial class PersonListing : Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        btnPrev.Visible = plc1.EnablePaging && plc1.PageIndex != 0;
        btnNext.Visible = plc1.EnablePaging && plc1.MaxIndex > plc1.PageIndex;
    }

    protected void btnPrev_Click(object sender, EventArgs e)
    {
        plc1.PageIndex = plc1.PageIndex - 1;
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        plc1.PageIndex = plc1.PageIndex + 1;
    }

    protected override PageStatePersister PageStatePersister
    {
        get
        {
            return new HiddenFieldPageStatePersister(Page);
            //return new SessionPageStatePersister(Page);
        }
    }

}
