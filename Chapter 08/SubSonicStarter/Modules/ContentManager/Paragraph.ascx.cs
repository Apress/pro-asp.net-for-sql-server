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

public partial class Modules_Content_Paragraph : System.Web.UI.UserControl
{

    private string contentName;

    public string ContentName {
        get { return contentName; }
        set { contentName = value; }
    }
	
    public string Title = "";
    protected string ContentText = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (ContentName != string.Empty)
        {

            CMS.Content text = CMS.ContentService.GetContent(contentName);
            if (text.IsLoaded)
            {
                ContentText = text.Body;
            }
        }
        else
        {
            ContentText = "Set both the ContentID and PageName";
        }

    }
}

