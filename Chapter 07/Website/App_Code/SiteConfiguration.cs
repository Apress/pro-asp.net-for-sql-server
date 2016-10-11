using System;
using System.Configuration;
using System.ServiceModel.Configuration;
using Chapter07.WCFService;

namespace Chapter07.Website
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

        public static string HomeUrl
        {
            get
            {
                if (Utility.IsUserAuthenticated)
                {
                    return Utility.GetSiteUrl("~/Home.aspx");
                }
                else
                {
                    return Utility.GetSiteUrl("~/");
                }
            }
        }

        public static string ToolsUrl
        {
            get
            {
                return Utility.GetSiteUrl("~/Tools.aspx");
            }
        }

        public static string ErrorUrl
        {
            get
            {
                return Utility.GetSiteUrl("~/Error.aspx");
            }
        }

        public static string LoginUrl
        {
            get
            {
                return Utility.GetSiteUrl("~/Login.aspx");
            }
        }

        public static bool IsSelfHosting
        {
            get
            {
                return GetIsSelfHosting(typeof(IFavoriteLinkService));
            }
        }

        public static bool GetIsSelfHosting(Type contractType)
        {
            bool isSelfHosting = false;
            ServicesSection config = ConfigurationManager.GetSection("system.serviceModel/services") as ServicesSection;
            if (config != null)
            {
                foreach (ServiceElement service in config.Services)
                {
                    foreach (ServiceEndpointElement endpoint in service.Endpoints)
                    {
                        if (endpoint.Contract.Equals(contractType.FullName))
                        {
                            isSelfHosting = true;
                            break;
                        }
                    }
                }
            }
            return isSelfHosting;
        }

        public static string DataServiceUri
        {
            get
            {
                return GetSetting("DataServiceUri");
            }
        }

        public static string GetSetting(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch
            {
                throw new Exception("No " + key + " setting in the web.config.");
            }
        }

    }
}