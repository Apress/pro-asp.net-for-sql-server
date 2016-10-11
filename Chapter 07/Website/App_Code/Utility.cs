using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Chapter07.Domain;
//using SmallSharpTools;
//using SmallSharpTools.Logging;

namespace Chapter07.Website
{
    /// <summary>
    /// Summary description for Utility
    /// </summary>
    public class Utility
    {

        public static string GetUserName()
        {
            if (IsUserAuthenticated)
            {
                return HttpContext.Current.User.Identity.Name;
            }
            return String.Empty;
        }

        public static bool IsUserAuthenticated
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        public static bool IsAdminUser
        {
            get
            {
                return HttpContext.Current.User.IsInRole("Admin");
            }
        }

        public static Guid UserID
        {
            get
            {
                if (IsUserAuthenticated)
                {
                    return (Guid)Membership.GetUser().ProviderUserKey;
                }
                else
                {
                    Guid userId = new Guid(HttpContext.Current.Request.AnonymousID.Substring(0, 36));
                    return userId;
                }
            }
        }

        public static Profile GetProfile()
        {
            Profile profile = new Profile(UserID);
            return profile;
        }

        public static Profile GetProfile(string userIdStr)
        {
            try
            {
                Guid userId = new Guid(userIdStr);
                Profile profile = new Profile(userId);
                return profile;
            }
            catch (Exception ex)
            {
                FavoriteLinkWebsiteException ex2 = 
                    new FavoriteLinkWebsiteException("Invalid value for userId: " + userIdStr, ex);
                throw ex2;
            }
        }

        private static FavoriteLinkDomain _domain = null;
        public static FavoriteLinkDomain Domain
        {
            get
            {
                if (_domain == null)
                {
                    _domain = new FavoriteLinkDomain();
                }
                return _domain;
            }
        }

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

        /// <summary>
        /// Given a FileUpload control named FileUpload1, pass the following
        /// parameter: FileUpload1.FileBytes.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static bool ImportOpml(byte[] bytes)
        {
            bool isSuccessful = true;

            try
            {
                long profileId = GetProfile().ProfileID;
                MemoryStream stream = new MemoryStream(bytes);
                XmlDocument document = new XmlDocument();
                document.Load(stream);

                XmlNode rootOutlineNode = document.SelectSingleNode("/opml/body/outline");
                if (rootOutlineNode != null)
                {
                    XmlNodeList outlineNodes = rootOutlineNode.SelectNodes("outline");
                    foreach (XmlNode outlineNode in outlineNodes)
                    {
                        XmlNode typeNode = outlineNode.SelectSingleNode("@type");
                        if ("html".Equals(typeNode.Value))
                        {
                            XmlNode titleNode = outlineNode.SelectSingleNode("@title");
                            XmlNode htmlUrlNode = outlineNode.SelectSingleNode("@htmlUrl");
                            XmlNode tagsNode = outlineNode.SelectSingleNode("@tags");
                            XmlNode ratingNode = outlineNode.SelectSingleNode("@rating");
                            XmlNode creationNode = outlineNode.SelectSingleNode("@Creation");
                            XmlNode modifiedNode = outlineNode.SelectSingleNode("@Modified");
                            bool keeper = true;
                            int rating;
                            int.TryParse(ratingNode.Value, out rating);
                            DateTime creation;
                            DateTime modified;
                            DateTime.TryParse(creationNode.Value, out creation);
                            DateTime.TryParse(modifiedNode.Value, out modified);
                            Domain.SaveFavoriteLink(profileId, htmlUrlNode.Value, 
                                titleNode.Value, keeper, rating, String.Empty, tagsNode.Value,
                                creation, modified, -1);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex.Message);
                isSuccessful = false;
            }
            return isSuccessful;
        }

        /// <summary>
        /// Given a FileUpload control named FileUpload1, pass the following
        /// parameters: FileUpload1.FileName, FileUpload1.FileBytes.
        /// </summary>
        /// <param name="filename">name of file</param>
        /// <param name="bytes">file contents</param>
        /// <returns>filename for saved file</returns>
        public static string SaveUploadFile(String filename, byte[] bytes)
        {
            String outfilename = String.Empty;
            try
            {
                outfilename = "C:Temp" + Path.DirectorySeparatorChar + filename;
                if (File.Exists(outfilename))
                {
                    File.Delete(outfilename);
                }
                File.WriteAllBytes(outfilename, bytes);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return outfilename;
        }

        //public static ILogger GetLogger(Type type)
        //{
        //    return LoggingProvider.Instance.GetLogger(type);
        //}

    }
}
