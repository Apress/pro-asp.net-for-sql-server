using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Caching;

namespace Chapter05.ClassLibrary
{
    [DataObject()]
    public class BasicDomain
    {
        private string dbName = "aw";

        public void PrepareCachingMode(CachingMode mode)
        {
            if (mode == CachingMode.Polling)
            {
                SqlCacheDependencyAdmin.EnableNotifications(ConnectionString);
                SqlCacheDependencyAdmin.EnableTableForNotifications(ConnectionString, "Production.Product");
            }
            else if (mode == CachingMode.Notification)
            {
                SqlDependency.Start(ConnectionString);
            }
        }

        public void CompleteCachingMode(CachingMode mode)
        {
            if (mode == CachingMode.Polling)
            {
                SqlCacheDependencyAdmin.DisableNotifications(ConnectionString);
            }
            else if (mode == CachingMode.Notification)
            {
                SqlDependency.Stop(ConnectionString);
            }
        }

        public DataSet GetProductByID(int productId, CachingMode mode)
        {
            Cache cache = HttpRuntime.Cache;
            string cacheKey = "Product-" + productId;
            if (mode != CachingMode.Off)
            {
                if (cache[cacheKey] != null)
                {
                    return cache[cacheKey] as DataSet;
                }
            }

            DataSet ds = null;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                // Construct the command to get any new ProductReview rows from the database along with
                // the corresponding product name from the Product table.
                SqlCommand cmd = new SqlCommand("SELECT ProductID, [Name], ListPrice " +
                    "FROM dbo.SimpleProduct WHERE ProductID = @ProductID", conn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int);
                cmd.Parameters[0].Value = productId;
 
                //Note: We do not need to close the reader as the "using" statement 
                // will dispose of the connection.

                CacheDependency cacheDependency = null;
                if (mode == CachingMode.Polling)
                {
                    // use Polling
                    cacheDependency = new SqlCacheDependency("aw", "dbo.SimpleProduct");
                }
                else if (mode == CachingMode.Notification)
                {
                    // use Notifications
                    Console.WriteLine("Adding SqlCacheDependency");
                    //cacheDependency = new SqlCacheDependency(cmd);

                    //Console.WriteLine("Adding SqlDependency");
                    // Create a dependency on this query
                    //dependency = new SqlDependency(cmd);

                    // Register the event handler
                    //dependency.OnChange += new OnChangeEventHandler(Dependency_OnChange);
                    
                }

                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // Get any new rows
                ds = new DataSet();
                adapter.Fill(ds);

                if (cacheDependency == null)
                {
                    Console.WriteLine("-- using absolute timeout");
                    cache.Insert(cacheKey, ds, null,
                         DateTime.Now.AddSeconds(120), Cache.NoSlidingExpiration,
                         CacheItemPriority.Normal, RemovedCallback);
                }
                else
                {
                    Console.WriteLine("-- using cacheDependency");
                    // just rely on the cacheDependency
                    cache.Insert(cacheKey, ds, cacheDependency,
                         Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration,
                         CacheItemPriority.Normal, RemovedCallback);
                }
            }
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void SetListPrice(decimal listPrice, int productId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE dbo.SimpleProduct SET ListPrice = " +
                        "@ListPrice WHERE ProductID = @ProductID", conn);

                    cmd.Parameters.Add("@ListPrice", SqlDbType.Decimal);
                    cmd.Parameters[0].Value = listPrice;
                    cmd.Parameters.Add("@ProductID", SqlDbType.Int);
                    cmd.Parameters[1].Value = productId;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
        }

        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
            }
        }

        void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency sqlDependency = (SqlDependency) sender;
            // use sqlDependency.Id?
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Dependency_OnChange: " + e);
            Console.WriteLine("\t" + e.Type);
            Console.WriteLine("\t" + e.Source);
            Console.WriteLine("\t" + e.Info);

            string cacheKey = "Product-1";
            Cache cache = HttpRuntime.Cache;
            Console.WriteLine("Removing cached item: " + cacheKey);
            cache.Remove(cacheKey);
        }

        private void RemovedCallback(string key, object value,
            CacheItemRemovedReason reason)
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
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else if (CacheItemRemovedReason.Removed == reason)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine(String.Format(
                " - {0}, {1}, {2}",
                key, value.GetType(), reason));

        }

    }
}
