using System;
using System.Configuration;

namespace Apress.Chapter04
{
    /// <summary>
    /// Summary description for SiteConfiguration
    /// </summary>
    public class SiteConfiguration
    {

        public static string RootUrl
        {
            get
            {
                return Utility.GetSiteUrl("~/");
            }
        }

        public static string ErrorUrl
        {
            get
            {
                return Utility.GetSiteUrl("~/Error.aspx");
            }
        }

        public static string GetSetting(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
                //return System.Configuration.ConfigurationSettings.AppSettings[key].ToString();
            }
            catch
            {
                throw new Exception("No " + key + " setting in the web.config.");
            }
        }

    }
}