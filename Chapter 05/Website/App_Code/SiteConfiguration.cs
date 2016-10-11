using System;
using System.Configuration;

/// <summary>
/// Summary description for SiteConfiguration
/// </summary>
public class SiteConfiguration
{

    public static string FlickFeedUrlFormat
    {
        get
        {
            return GetSetting("FlickrFeedUrlFormat");
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
