using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for SubstitutionFragment
/// </summary>
public abstract class SubstitutionFragment : UserControl
{

    public abstract void BindToContext();

    private HttpContext _currentContext;
    public HttpContext CurrentContext
    {
        get
        {
            return _currentContext;
        }
        set
        {
            _currentContext = value;
        }
    }

    public virtual string RenderToString(HttpContext context)
    {
        CurrentContext = context;
        BindToContext();
        DataBind();

        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter tw = new HtmlTextWriter(sw);
        RenderControl(tw);

        return sb.ToString();
    }

}
