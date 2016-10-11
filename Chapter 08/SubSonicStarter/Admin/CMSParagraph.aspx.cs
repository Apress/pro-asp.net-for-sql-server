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

public partial class CMSParagraph : System.Web.UI.Page
{
    protected string ContentName = "";
    protected string ContentText = "";


    //This is the secret sauce to get the uploader to work properly
    protected void Page_Init(object sender, EventArgs e){
        txtContent.SkinPath = "skins/office2003/";
        Session["FCKeditor:UserFilesPath"] = Page.ResolveUrl("~/CMSFiles");

    }
    protected void Page_Load(object sender, EventArgs e)
    {

        ContentName = SubSonic.Utilities.Utility.GetParameter("id");
        if (!Page.IsPostBack)
        {
            if (ContentName != string.Empty)
            {

                CMS.Content text = CMS.ContentService.GetContent(ContentName);
                if (text.Body != null)
                {
                    
                    txtContent.Value = text.Body;
                }

            }

            //load the locale list
            string [] locales=Enum.GetNames(typeof(CMS.SupportedLocales));
            foreach (string s in locales) {
                string localeName = s.Replace("_", "-");
                LocaleList.Items.Add(new ListItem(localeName));
            }

        }

    }


    protected void btnSave_Click(object sender, System.EventArgs e)
    {
        CMS.Content text = CMS.ContentService.GetContent(ContentName);
        if (!text.IsLoaded) {
            text.IsNew = true;
            text.ContentGUID = Guid.NewGuid();
        }
        text.Locale = LocaleList.SelectedValue;
        text.ContentName = ContentName;
        text.Body = txtContent.Value;
        text.Save(Page.User.Identity.Name);
        ResultMessage1.ShowSuccess("Content Saved");
    }
}
