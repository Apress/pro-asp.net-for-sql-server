// Derived from the PlainTextSiteMapProvider example on MSDN
// http://msdn2.microsoft.com/en-us/library/system.web.sitemapprovider.aspx

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Security.Permissions;
using System.Web;
using System.Web.Caching;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Chapter05.CustomSiteMapProvider
{

    /// <summary>
    /// Summary description for SqlSiteMapProvider
    /// </summary>
    [AspNetHostingPermission(SecurityAction.Demand, Level = 
    AspNetHostingPermissionLevel.Minimal)]
    public class SqlSiteMapProvider : SiteMapProvider
    {

        #region "  Variables  "

        private string connStringName;
        private Database db;

        private SiteMapProvider _parentSiteMapProvider = null;
        private SiteMapNode rootNode = null;
        private List<DictionaryEntry> siteMapNodes = null;
        private List<DictionaryEntry> childParentRelationship = null;

        #endregion

        #region "  Implementation Methods  "

        public override SiteMapNode CurrentNode
        {
          get
          {
            EnsureSiteMapLoaded();
            string currentUrl = FindCurrentUrl();
            // Find the SiteMapNode that represents the current page.
            SiteMapNode currentNode = FindSiteMapNode(currentUrl);
            return currentNode;
          }
        }

        public override SiteMapNode RootNode
        {
          get
          {
            EnsureSiteMapLoaded();
            return rootNode;
          }
        }

        public override SiteMapProvider ParentProvider
        {
          get
          {
            return _parentSiteMapProvider;
          }
          set
          {
            _parentSiteMapProvider = value;
          }
        }

        public override SiteMapProvider RootProvider
        {
          get
          {
            // If the current instance belongs to a provider hierarchy, it
            // cannot be the RootProvider. Rely on the ParentProvider.
            if (ParentProvider != null)
            {
              return ParentProvider.RootProvider;
            }
            // If the current instance does not have a ParentProvider, 
            // it is not a child in a hierarchy, and can be the 
            // RootProvider.
            else
            {
              return this;
            }
          }
        }

        public override SiteMapNode FindSiteMapNode(string rawUrl)
        {
          EnsureSiteMapLoaded();

          // Does the root node match the URL?
          if (RootNode.Url == rawUrl)
          {
            return RootNode;
          }
          else
          {
            SiteMapNode candidate;
            // Retrieve the SiteMapNode that matches the URL.
            lock (this)
            {
              candidate = GetNode(siteMapNodes, rawUrl);
            }
            return candidate;
          }
        }

        public override SiteMapNodeCollection GetChildNodes(SiteMapNode node)
        {
          EnsureSiteMapLoaded();

          SiteMapNodeCollection children = new SiteMapNodeCollection();
          // Iterate through the ArrayList and find all nodes that have the 
          // specified node as a parent.
          lock (this)
          {
            for (int i = 0; i < childParentRelationship.Count; i++)
            {
              string nodeUrl = childParentRelationship[i].Key as string;

              SiteMapNode parent = GetNode(childParentRelationship, nodeUrl);

              if (parent != null && node.Url == parent.Url)
              {
                // The SiteMapNode with the Url that corresponds to
                // nodeUrl is a child of the specified node. Get the
                // SiteMapNode for the nodeUrl.
                SiteMapNode child = FindSiteMapNode(nodeUrl);
                if (child != null)
                {
                  children.Add(child);
                }
                else
                {
                  throw new Exception("ArrayLists not in sync.");
                }
              }
            }
          }
          return children;
        }

        protected override SiteMapNode GetRootNodeCore()
        {
          EnsureSiteMapLoaded();
          return RootNode;
        }

        public override SiteMapNode GetParentNode(SiteMapNode node)
        {
            // Check the childParentRelationship table and find the parent
            // of the current node. If there is no parent, the current node 
            // is the RootNode.
            SiteMapNode parent;
            lock (this)
            {
              // Get the Value of the node in childParentRelationship
              EnsureSiteMapLoaded();
              parent = GetNode(childParentRelationship, node.Url);
            }
            return parent;
        }

        public override void Initialize(string name, NameValueCollection attributes)
        {
            lock (this)
            {
              base.Initialize(name, attributes);

              connStringName = attributes["connectionStringName"].ToString();
              //SqlCacheDependencyAdmin.EnableNotifications(connString);
              db = DatabaseFactory.CreateDatabase(connStringName);
              siteMapNodes = new List<DictionaryEntry>();
              childParentRelationship = new List<DictionaryEntry>();
              EnsureSiteMapLoaded();
            }
        }

        #endregion

        #region "  Private helper methods  "

        private SiteMapNode GetNode(List<DictionaryEntry> list, string url)
        {
            for (int i = 0; i < list.Count; i++)
            {
              DictionaryEntry item = list[i];
              if ( ((string)item.Key).ToLower().Equals(url.ToLower()))
                return item.Value as SiteMapNode;
            }
            return null;
        }

        private string FindCurrentUrl()
        {
            try
            {
              // The current HttpContext.
              HttpContext currentContext = HttpContext.Current;
              if (currentContext != null)
              {
                return currentContext.Request.RawUrl;
              }
              else
              {
                throw new Exception("HttpContext.Current is Invalid");
              }
            }
            catch (Exception e)
            {
              throw new NotSupportedException(
                "This provider requires a valid context.", e);
            }
        }

        private void EnsureSiteMapLoaded()
        {
            if (rootNode == null)
            {
              // Build the site map in memory.
              LoadSiteMapFromDatabase();
            }
        }

        protected virtual void LoadSiteMapFromDatabase()
        {
          lock (this)
          {
            // If a root node exists, LoadSiteMapFromDatabase has already
            // been called, and the method can return.
            if (rootNode != null)
            {
              return;
            }
            else
            {
              // Clear the state of the collections and rootNode
              Clear();
              SiteMapNode temp = null;

              DataSet nodes = LoadSiteMapNodes();
              if (nodes != null && nodes.Tables.Count > 0)
              {
                string baseUrl = HttpRuntime.AppDomainAppVirtualPath + "/";
                foreach (DataRow node in nodes.Tables[0].Rows)
                {
                  long parentNodeId = node["ParentID"] is long ? 
                    (long)node["ParentID"] : 0L;
                  String url = node["Url"] as String;
                  String parentUrl = node["ParentUrl"] as String;
                  String title = node["Title"] as String;

                  temp = new SiteMapNode(this, baseUrl + url, 
                    baseUrl + url, title);

                   // Is this a root node yet?
                  if (null == rootNode && parentNodeId < 0)
                  {
                      rootNode = temp;
                  }
                  // If not the root node, add the node to the 
                  // various collections.
                  else if (parentUrl != null)
                  {
                    siteMapNodes.Add(
                      new DictionaryEntry(temp.Url, temp));
                    // The parent node has already been added 
                    // to the collection.
                    SiteMapNode parentNode = FindSiteMapNode(
                      baseUrl + parentUrl);
                    if (parentNode != null)
                    {
                      childParentRelationship.Add(
                        new DictionaryEntry(temp.Url, parentNode));
                    }
                    else
                    {
                      throw new Exception(
                        "Parent node not found for current node.");
                    }
                  }
                }
              }
            }
          }
          return;
        }

        private void Clear()
        {
          rootNode = null;
          siteMapNodes.Clear();
          childParentRelationship.Clear();
        }

        /// <summary>
        /// Get SiteMap Nodes from the database
        /// </summary>
        /// <returns></returns>
        internal DataSet LoadSiteMapNodes()
        {
          String cacheKey = SqlSiteMapHelper.CACHE_KEY;
          object obj = HttpRuntime.Cache.Get(cacheKey);
          if (obj != null)
          {
            return obj as DataSet;
          }
          DataSet ds = null;

          try
          {
              using (DbCommand dbCmd = 
                db.GetStoredProcCommand("sm_GetSiteMapNodes"))
              {
                ds = db.ExecuteDataSet(dbCmd);
              }
          }
          catch (Exception ex)
          {
            HandleError("Exception with LoadSiteMapNodes", ex);
          }

          //SqlCacheDependency tableDependency = 
          // new SqlCacheDependency(connStringName, "sm_SiteMapNodes");
          HttpRuntime.Cache.Insert(cacheKey, ds, null, DateTime.Now.AddHours(1), 
            TimeSpan.Zero, CacheItemPriority.NotRemovable, OnRemoveCallback);

          //return the results
          return ds;
        }

        private void OnRemoveCallback(string key, object value, 
          CacheItemRemovedReason reason)
        {
          if (CacheItemRemovedReason.DependencyChanged == reason ||
              CacheItemRemovedReason.Removed == reason)
          {
            Clear();
            LoadSiteMapFromDatabase();
          }
          else
          {
            Clear();
          }
        }

        private void HandleError(string message, Exception ex)
        {
          //TODO log error
          throw new ApplicationException(message, ex);
        }
    
        #endregion

    }

}
