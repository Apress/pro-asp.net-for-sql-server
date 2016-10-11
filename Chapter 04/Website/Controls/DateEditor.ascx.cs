using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DateEditor : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public DateTime Date
    {
        get
        {
            DateTime tmpDate = DateTime.MinValue;
            DateTime.TryParse(TextBox1.Text, out tmpDate);
            return tmpDate;
        }
        set
        {
            TextBox1.Text = value.ToString("MM/dd/yyyy");
        }
    }

    protected void cvDate_ServerValidate(object source, ServerValidateEventArgs args)
    {
        DateTime tmpDate;
        if (!DateTime.TryParse(TextBox1.Text, out tmpDate))
        {
            args.IsValid = false;
            return;
        }
        // these are the database constraints
        DateTime minDate = new DateTime(1753,1,1);
        DateTime maxDate = new DateTime(9999,12,31);
        if (tmpDate < minDate || tmpDate > maxDate)
        {
            args.IsValid = false;
            return;
        }
    }
}
