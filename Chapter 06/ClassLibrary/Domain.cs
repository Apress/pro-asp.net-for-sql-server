using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Caching;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Chapter05.ClassLibrary
{

    public enum CachingMode
    {
        Off,
        AbsoluteExpiration,
        Polling,
        Notification,
        SqlDependency
    }

    public enum CacheActivity
    {
        AlreadyExists,
        Expired,
        Underused,
        Removed,
        DependencyChanged
    }

    [DataObject()]
    public class Domain
    {
        public event EventHandler<DomainEventArgs> DomainItemChanged;

        private Database db;
        private string dbName = "aw";
        private CachingMode defaultCachingMode = CachingMode.Off;
        private int absoluteTimeout = 120;
        private IDictionary<int, DataSet> products = new Dictionary<int, DataSet>();

        public Domain()
        {
            db = DatabaseFactory.CreateDatabase(dbName);
        }

        #region "  Utility Methods  "

        protected void OnDomainItemChanged(CacheActivity cacheActivity)
        {
            DomainEventArgs args = new DomainEventArgs(cacheActivity);
            OnDomainItemChanged(args);
        }

        protected void OnDomainItemChanged(DomainEventArgs e)
        {
            if (DomainItemChanged != null)
            {
                DomainItemChanged(this, e);
            }
        }

        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
            }
        }

        public void PrepareCachingMode(CachingMode mode)
        {
            if (mode == CachingMode.Polling)
            {
                //SqlCacheDependencyAdmin.EnableNotifications(ConnectionString);
                //SqlCacheDependencyAdmin.EnableTableForNotifications(ConnectionString, "Production.Product");
            }
            else if (mode == CachingMode.Notification || mode == CachingMode.SqlDependency)
            {
                SqlDependency.Start(ConnectionString);
            }
        }

        public void CompleteCachingMode(CachingMode mode)
        {
            if (mode == CachingMode.Polling)
            {
                //SqlCacheDependencyAdmin.DisableTableForNotifications(ConnectionString, "Production.Product");
                //SqlCacheDependencyAdmin.DisableNotifications(ConnectionString);
            }
            else if (mode == CachingMode.Notification)
            {
                SqlDependency.Stop(ConnectionString);
            }
        }

        public void SetAbsoluteTimeout(int seconds)
        {
            absoluteTimeout = seconds;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void ClearCache()
        {
            Cache cache = HttpRuntime.Cache;
            List<string> keys = new List<string>();
            foreach (DictionaryEntry entry in cache)
            {
                keys.Add((string)entry.Key);
            }
            foreach (string key in keys)
            {
                cache.Remove(key);
            }
        }

        #endregion

        #region " Product Methods  "

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetAllProducts()
        {
            DataSet ds = new DataSet();

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt05_GetAllProducts"))
                {
                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }

            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetAllProductsWithPhotos()
        {
            DataSet ds = new DataSet();

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt05_GetAllProductsWithPhotos"))
                {
                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }

            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetProductPhotos(int productId)
        {
            DataSet ds = new DataSet();

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt05_GetProductPhotos"))
                {
                    db.AddInParameter(dbCmd, "@ProductID", DbType.Int16, productId);

                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }

            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable GetProductByID(DataSet productDs, int productId)
        {
            DataView dv = new DataView(productDs.Tables[0]);
            dv.RowFilter = "ProductID = " + productId;
            return dv.ToTable();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetProductByID(int productId)
        {
            return GetProductByID(productId, defaultCachingMode);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetProductByID(int productId, CachingMode mode)
        {
            if (mode == CachingMode.SqlDependency)
            {
                lock (this)
                {
                    if (products.ContainsKey(productId))
                    {
                        WriteMessage("Using cached copy");
                        OnDomainItemChanged(CacheActivity.AlreadyExists);
                        return products[productId];
                    }
                }
            }

            Cache cache = HttpRuntime.Cache;
            string cacheKey = "Product-" + productId;
            if (mode != CachingMode.Off)
            {
                lock (this)
                {
                    if (cache[cacheKey] != null)
                    {
                        WriteMessage("Using cached copy");
                        OnDomainItemChanged(CacheActivity.AlreadyExists);
                        return cache[cacheKey] as DataSet;
                    }
                }
            }

            DataSet ds = new DataSet();
            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("dbo.chpt05_GetProductByID"))
                {
                    db.AddInParameter(dbCmd, "@ProductID", DbType.Int16, productId);

                    CacheDependency cacheDependency = null;

                    if (mode == CachingMode.Polling)
                    {
                        // use Polling
                        WriteMessage("Using SqlCacheDependency (Polling)");
                        cacheDependency = new SqlCacheDependency("aw", "Production.Product");
                    }
                    else if (mode == CachingMode.Notification)
                    {
                        // use Notifications
                        WriteMessage("Using SqlCacheDependency (Notification)");
                        SqlCommand sqlCmd = dbCmd as SqlCommand;
                        if (sqlCmd != null)
                        {
                            cacheDependency = new SqlCacheDependency(sqlCmd);
                        }
                    }
                    else if (mode == CachingMode.SqlDependency)
                    {
                        SqlCommand sqlCmd = dbCmd as SqlCommand;
                        if (sqlCmd != null)
                        {
                            WriteMessage("Using SqlDependency");
                            SqlDependency sqlDependency = new SqlDependency(sqlCmd);
                            OnChangeEventHandler onChangeHandler =
                                delegate(object sender, SqlNotificationEventArgs e)
                                {
                                    WriteSqlDependencyChange(sqlDependency, e, productId);
                                    OnDomainItemChanged(CacheActivity.Removed);
                                    products.Remove(productId);
                                };
                            sqlDependency.OnChange += onChangeHandler;
                        }
                    }

                    // get the data
                    ds = db.ExecuteDataSet(dbCmd);

                    CacheItemRemovedCallback removedCallback = delegate(
                        string key, object value, CacheItemRemovedReason reason)
                           {
                               switch(reason)
                               {
                                   case CacheItemRemovedReason.Underused:
                                       OnDomainItemChanged(CacheActivity.Underused);
                                       break;
                                   case CacheItemRemovedReason.Removed:
                                       OnDomainItemChanged(CacheActivity.Removed);
                                       break;
                                   case CacheItemRemovedReason.Expired:
                                       OnDomainItemChanged(CacheActivity.Expired);
                                       break;
                                   case CacheItemRemovedReason.DependencyChanged:
                                       OnDomainItemChanged(CacheActivity.DependencyChanged);
                                       break;
                               }
                               WriteCacheItemRemoved(key, value, reason);
                           };
                    if (mode == CachingMode.SqlDependency)
                    {
                        products[productId] = ds;
                    }
                    else if (mode == CachingMode.Polling || mode == CachingMode.Notification)
                    {
                        cache.Insert(cacheKey, ds, cacheDependency,
                             DateTime.Now.AddSeconds(absoluteTimeout), Cache.NoSlidingExpiration,
                             CacheItemPriority.Normal, removedCallback);
                    }
                    else if (mode == CachingMode.AbsoluteExpiration)
                    {
                        // shorten the absolute timeout from the default in this mode
                        if (absoluteTimeout == 120)
                        {
                            absoluteTimeout = 10;
                        }
                        WriteMessage("Using AbsoluteExpiration (" + absoluteTimeout + " seconds)");
                        cache.Insert(cacheKey, ds, null,
                             DateTime.Now.AddSeconds(absoluteTimeout), Cache.NoSlidingExpiration,
                             CacheItemPriority.Normal, removedCallback);
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }
            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void SetListPrice(decimal listPrice, int productId)
        {
            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("dbo.chpt05_SetListPriceByID"))
                {
                    db.AddInParameter(dbCmd, "@ListPrice", DbType.Decimal, listPrice);
                    db.AddInParameter(dbCmd, "@ProductID", DbType.Int16, productId);

                    db.ExecuteNonQuery(dbCmd);
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }
        }

        #endregion

        #region " Session Methods  "

        public static void LoadSessionState()
        {
            HttpContext.Current.Session["Session Data"] = GetSessionData();
        }

        public static void ClearSessionState()
        {
            HttpContext.Current.Session.Remove("Session Data");
        }

        private static DataSet GetSessionData()
        {
            return null;
        }

        #endregion

        #region " Console Methods  "

        private void WriteMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t- " + message);
        }

        private void WriteCacheItemRemoved(string key, object value, CacheItemRemovedReason reason)
        {
            // colorize the reason for removal
            if (CacheItemRemovedReason.Underused == reason)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else if (CacheItemRemovedReason.Expired == reason)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else if (CacheItemRemovedReason.DependencyChanged == reason)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (CacheItemRemovedReason.Removed == reason)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine(String.Format(
                  " - {0}, {1}, {2}", key, value.GetType(), reason));
        }

        private void WriteSqlDependencyChange(
            SqlDependency sqlDependency, SqlNotificationEventArgs e, int productId)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("SqlDependency.OnChange:");
            Console.WriteLine(" Type:  " + e.Type);
            Console.WriteLine(" Source: " + e.Source);
            Console.WriteLine(" Info: " + e.Info);
            Console.WriteLine(" Id: " + sqlDependency.Id);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" - Removed data item (" + productId + ")");
        }

        #endregion

    }

    public class DomainEventArgs : EventArgs
    {
        public DomainEventArgs(CacheActivity cacheActivity)
        {
            CacheActivity = cacheActivity;
        }

        private CacheActivity _cacheActivity;

        public CacheActivity CacheActivity
        {
            get
            {
                return _cacheActivity;
            }
            set
            {
                _cacheActivity = value;
            }
        }
    }
}
