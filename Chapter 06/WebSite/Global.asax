<%@ Import namespace="System.Diagnostics"%>
<%@ Import namespace="System.Data"%>
<%@ Import namespace="Chapter05.ClassLibrary"%>
<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        HttpContext.Current.Application["ApplicationState"] = GetApplicationState();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //HttpContext.Current.Application["ApplicationState"] = null;
    }

    public DataSet GetApplicationState()
    {
        return null;
    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        Exception lastError = Server.GetLastError();
        Utility.LogMessage("Global error caught", lastError, EventLogEntryType.Error);
    }

    void Session_Start(object sender, EventArgs e) 
    {
    }

    void Session_End(object sender, EventArgs e) 
    {
    }
       
</script>
