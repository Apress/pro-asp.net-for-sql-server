using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apress.Chapter04
{
    /// <summary>
    /// Summary description for Utility
    /// </summary>
    public class Utility
    {

        public static string GetSiteUrl(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                return GetSiteRoot() + "/";
            }
            if (url.StartsWith("~/"))
            {
                url = url.Substring(1, url.Length - 1);
            }
            return GetSiteRoot() + url;
        }

        public static string GetUrlPath(string url)
        {
            return HttpContext.Current.Request.MapPath(url);
        }

        public static string GetRelativeSiteUrl(string url)
        {
            if (!String.IsNullOrEmpty(url))
            {
                if (url.StartsWith("~/"))
                {
                    url = url.Substring(1, url.Length - 1);
                }
                return GetRelativeSiteRoot() + url;
            }
            return GetRelativeSiteRoot() + "/";
        }

        public static string GetSiteRoot()
        {
            string Port = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            if (Port == null || Port == "80" || Port == "443")
                Port = "";
            else
                Port = ":" + Port;

            string Protocol = HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
            if (Protocol == null || Protocol == "0")
                Protocol = "http://";
            else
                Protocol = "https://";
            string sOut;
            if ("/".Equals(HttpContext.Current.Request.ApplicationPath))
            {
                sOut = Protocol + HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + Port;
            }
            else
            {
                sOut = Protocol + HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + Port + HttpContext.Current.Request.ApplicationPath;
            }
            return sOut;
        }

        public static string GetRelativeSiteRoot()
        {
            if ("/".Equals(HttpContext.Current.Request.ApplicationPath))
            {
                return String.Empty;
            }
            return HttpContext.Current.Request.ApplicationPath;
        }

        public static List<BaseValidator> GetValidators(ControlCollection controls)
        {
            List<BaseValidator> validators = new List<BaseValidator>();
            foreach (Control control in controls)
            {
                if (control is IValidator)
                {
                    validators.Add(control as BaseValidator);
                }
                else if (control.Controls.Count > 0)
                {
                    // start recursion
                    List<BaseValidator> subValidators = GetValidators(control.Controls);
                    foreach (BaseValidator subValidator in subValidators)
                    {
                        validators.Add(subValidator);
                    }
                }
            }
            return validators;
        }

    }
}
