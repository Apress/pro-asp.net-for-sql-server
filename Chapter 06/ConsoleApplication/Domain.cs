using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using Chapter05.ClassLibrary;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Chapter05.ConsoleApplication
{

    public enum CachingModeX
    {
        Off,
        AbsoluteExpiration,
        Polling,
        Notification,
        SqlDependency
    }

    [DataObject()]
    public class DomainX
    {

        private Database db;
        private string dbName = "aw";
        private IDictionary<int, DataSet> dataItems = new Dictionary<int, DataSet>();

        public DomainX()
        {
            db = DatabaseFactory.CreateDatabase(dbName);
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

        //public void EnableNotifications()
        //{
        //    SqlCacheDependencyAdmin.EnableNotifications(ConnectionString);
        //}

        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
            }
        }

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
        public DataSet GetProductByID(int productId, CachingMode mode)
        {
            if (mode == CachingMode.SqlDependency)
            {
                if (dataItems.ContainsKey(productId))
                {
                    WriteMessage("Using cached copy");
                    return dataItems[productId];
                }
            }

            Cache cache = HttpRuntime.Cache;
            string cacheKey = "Product-" + productId;
            if (mode != CachingMode.Off)
            {
                if (cache[cacheKey] != null)
                {
                    WriteMessage("Using cached copy");
                    return cache[cacheKey] as DataSet;
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
                                    dataItems.Remove(productId);
                                };
                            sqlDependency.OnChange += onChangeHandler;
                        }
                    }

                    // get the data
                    ds = db.ExecuteDataSet(dbCmd);

                    CacheItemRemovedCallback removedCallback = delegate(
                        string key, object value, CacheItemRemovedReason reason)
                           {
                               WriteCacheItemRemoved(key, value, reason);
                           };
                    if (mode == CachingMode.SqlDependency)
                    {
                        dataItems[productId] = ds;
                    }
                    else if (mode == CachingMode.Polling || mode == CachingMode.Notification)
                    {
                        cache.Insert(cacheKey, ds, cacheDependency,
                             DateTime.Now.AddSeconds(120), Cache.NoSlidingExpiration,
                             CacheItemPriority.Normal, removedCallback);
                    }
                    else if (mode == CachingMode.AbsoluteExpiration)
                    {
                        WriteMessage("Using AbsoluteExpiration (10 seconds)");
                        cache.Insert(cacheKey, ds, null,
                             DateTime.Now.AddSeconds(10), Cache.NoSlidingExpiration,
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
                Console.ForegroundColor = ConsoleColor.Red;
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
    }
}
