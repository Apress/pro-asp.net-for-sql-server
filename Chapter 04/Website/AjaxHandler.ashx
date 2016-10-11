<%@ WebHandler Language="C#" Class="AjaxHandler" %>

using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;

public class AjaxHandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        StringBuilder sb = new StringBuilder();

        // set the token in the current context
        if (String.IsNullOrEmpty(HttpContext.Current.Items["token"] as String))
        {
            string token = context.Request.QueryString["token"];
            HttpContext.Current.Items["token"] = token;
        }

        Control ctrl = new Page().LoadControl("~/Controls/PredictiveFetchControl.ascx");
        if (ctrl != null)
        {
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter tw = new HtmlTextWriter(sw);
            ctrl.DataBind();
            ctrl.RenderControl(tw);
        }
        else
        {
            sb.Append("Unable to load control: control is null");
        }

        context.Response.Write(sb.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}