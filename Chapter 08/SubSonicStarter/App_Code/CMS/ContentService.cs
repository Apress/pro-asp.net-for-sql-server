using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections.Generic;
using System.Collections;

namespace CMS {

    public enum SupportedLocales {
        en_US
    }


    /// <summary>
    /// Summary description for ContentService
    /// </summary>
    public class ContentService {

        #region Page Methods

        /// <summary>
        /// Gets a CMS Page by URL
        /// </summary>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        public static Page GetPage(string pageUrl) {

            //take the page URL, which should be something like "this-is-the-page-name.aspx"
            //and query on it
            Page p = new Page("pageUrl", pageUrl);
            if (!p.IsLoaded) {
                throw new Exception("There is no page corresponding to " + pageUrl);
            }

            return p;
        }

        /// <summary>
        /// Gets a CMS page by ID
        /// </summary>
        /// <param name="pageID"></param>
        /// <returns></returns>
        public static Page GetPage(int pageID) {

            //take the page URL, which should be something like "this-is-the-page-name.aspx"
            //and query on it
            Page p = new Page(pageID);
            if (!p.IsLoaded) {
                throw new Exception("There is no page corresponding to " + pageID.ToString());
            }

            return p;
        }

        /// <summary>
        /// Gets a paragraph (CMS_Content) from by name
        /// </summary>
        /// <param name="contentName"></param>
        /// <returns></returns>
        public static Content GetContent(string contentName){
            return new Content("contentName", contentName);
        }

        /// <summary>
        /// Utility function for removing things that aren't letters
        /// </summary>
        /// <param name="sIn"></param>
        /// <returns></returns>
        static string StripNonAlphaNumeric(string sIn) {
            //remove whitespace
            //sIn = sIn.Replace(" ", "");
            ////char[] chars = sIn.ToCharArray();
            //string result = "";
            StringBuilder sb = new StringBuilder(sIn);
            char c = " ".ToCharArray()[0];
            //these are illegal characters - remove zem
            string stripList = ".'?\\/><$!@%^*&+,;:\"{}[]|#";

            for (int i = 0; i < stripList.Length; i++) {
                sb.Replace(stripList[i], c);
            }
            sb.Replace(" ", String.Empty);
            return sb.ToString();
        }
        
        /// <summary>
        /// Method for creating the title for the dynamic page
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        static string TransformTitleToUrl(string title) {
            string result = title;

            //first, reset all spaces to dashes
            result = result.Replace(" ", "-");

            //strip out all punctuation and non-numbers
            result=StripNonAlphaNumeric(result);

            //finally, set it to lower
            result = result.ToLower();

            if (!result.EndsWith(".aspx"))
                result += ".aspx";

            return result;
        }

        /// <summary>
        /// Saves the page to the DB
        /// </summary>
        /// <param name="p"></param>
        public static void SavePage(CMS.Page p) {

            if (p.PageID==0) {
                //this is an insert
                p.PageGuid = System.Guid.NewGuid();
                
                //configure the URL from the title
                p.PageUrl = TransformTitleToUrl(p.Title);

            }

            //gotta make sure the URL's not already in there
            //the SiteMapProvider doesn't like it
            CMS.Page pCheck = new Page("PageURL", p.PageUrl);
            int existingUrls = new SubSonic.Query(Page.Schema).WHERE(Page.Columns.PageUrl, p.PageUrl).GetRecordCount();
            if (existingUrls>0) {
                existingUrls++;
                p.PageUrl = p.PageUrl.Replace(".aspx", "_" + existingUrls.ToString() + ".aspx");
            }

            //save it
            p.Save(System.Web.HttpContext.Current.User.Identity.Name);

        }

        /// <summary>
        /// Deletes the page from the DB. This is permanent
        /// </summary>
        /// <param name="pageID"></param>
        public static void DeletePage(int pageID) {

            //can't delete if this page has children
            if (PageHasChildren(pageID)) {
                throw new Exception("Can't delete this page - it has child pages. Please move these prior to deleting");
            } else {
                CMS.Page.Delete(pageID);
            }
        }
        static bool PageHasChildren(int pageID) {
            CMS.PageCollection collCheck = GetHierarchicalPageCollection(pageID);
            return collCheck.Count > 0;
            
        }
        /// <summary>
        /// Resets the parent page of the supplied page
        /// </summary>
        /// <param name="pageID"></param>
        /// <param name="newParentID"></param>
        public static void ChangeParent(int pageID, int? newParentID){

            //make sure that we're not resetting to a child's ID
            if (!PageHasChildren(pageID)) {
                throw new Exception("Cannot move this page to the new location as the new page is a child of this page. Move the target page to a higher level first");
            } else {
                CMS.Page p = new Page(pageID);
                p.ParentID = newParentID;
                //save it
                p.Save(System.Web.HttpContext.Current.User.Identity.Name);

            }
        }

        static CMS.PageCollection sortedPages;
        static CMS.PageCollection unSortedPages;
        static CMS.Page LoadChildItem(CMS.Page parentItem) {
            CMS.Page result = null;
            foreach (CMS.Page item in unSortedPages) {
                result = null;
                if (item.ParentID == parentItem.PageID) {
                    result = item;
                    item.Level = parentItem.Level+1;
                    sortedPages.Add(result);
                    LoadChildItem(result);
                }
            }

            return result;

        }
        public static CMS.PageCollection GetHierarchicalPageCollection() {
            
            sortedPages = new PageCollection();
            unSortedPages = new PageCollection().Load();

            foreach (CMS.Page item in unSortedPages) {
                if (item.ParentID == null) {
                    item.Level = 0;
                    //check the role for validity
                    sortedPages.Add(item);
                    LoadChildItem(item);
                }
            }

            return sortedPages;
        }
        public static CMS.PageCollection GetHierarchicalPageCollection(int parentID) {

            sortedPages = new PageCollection();
            unSortedPages = new PageCollection().Load();

            foreach (CMS.Page item in unSortedPages) {
                if (item.ParentID == parentID) {
                    item.Level = 0;
                    //check the role for validity
                    sortedPages.Add(item);
                    LoadChildItem(item);
                }
            }

            return sortedPages;
        }

        //NOTE
        /*
         * If you want to put this into the DB, you can use this SP:
         * ALTER PROCEDURE CMS_GetPageHierarchy

            AS
            	
	            WITH PageCTE (parentID, pageID, title, pageUrl, menuTitle, theLevel,sortKey)
	            AS
	            (
	            -- Anchor member definition. These records are your "top level", or "anchor"
	            SELECT e.parentID, e.pageID, e.title, e.pageUrl, e.menuTitle,
	            0 AS theLevel,
		            --this is my sortkey- using VARBINARY
		            CAST (e.pageID AS VARBINARY(900))
	            FROM CMS_Page AS e
	            WHERE parentID IS NULL
	            --UNION the top level to the "child level"
		            UNION ALL
	            -- Recursive member definition
	            --ths is the same query as above, but we're going to join it now to the
		            --CTE itself
		            SELECT e.parentID, e.pageID, e.title, e.pageUrl, e.menuTitle, theLevel + 1,
	            --increment the sortkey
	            CAST (d.sortKey + CAST (e.pageID AS BINARY(4)) AS VARBINARY(900))
	            FROM CMS_Page AS e
	            INNER JOIN PageCTE AS d
	            ON e.parentID = d.pageID
	            )
	            -- Run a select from the CTE, and sort it by the sortKey
	            SELECT * FROM PageCTE
	            order by sortKey
            	
            	 
	            RETURN

        */
        #endregion

    }
}