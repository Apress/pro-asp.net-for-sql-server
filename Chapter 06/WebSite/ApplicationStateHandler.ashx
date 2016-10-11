<%@ WebHandler Language="C#" Class="ApplicationStateHandler" %>

using System.Web;
using Chapter05.ClassLibrary;

public class ApplicationStateHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        string action = context.Request.QueryString["action"];

        if ("ReloadApplicationState".Equals(action))
        {
            context.Response.Write("Reloading Application State\n");
            //Domain.LoadApplicationState();
            context.Response.Write("Done.");
        }
        else
        {
            context.Response.Write("Action unknown: " + action);
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}