using System;
using System.Data.Common;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Chapter05.CustomSiteMapProvider
{
    public class SqlSiteMapHelper
    {
        public const string CACHE_KEY = "SqlSiteMapNodes";

        private Database db;

        public SqlSiteMapHelper(string connStringName)
        {
            db = DatabaseFactory.CreateDatabase(connStringName);
        }

        public void RepopulateSiteMapNodes()
        {
            try
            {
                using (DbCommand dbCmd = 
                  db.GetStoredProcCommand("sm_RepopulateSiteMapNodes"))
                {
                  db.ExecuteNonQuery(dbCmd);
                  InvalidateSiteMapCache();
                }
            }
            catch (Exception ex)
            {
              HandleError("Exception with RepopulateSiteMapNodes", ex);
            }
        }

        internal void InvalidateSiteMapCache()
        {
            HttpRuntime.Cache.Remove(CACHE_KEY);
        }

        private void HandleError(string message, Exception ex)
        {
          //TODO log error
          throw new ApplicationException(message, ex);
        }
    }
}
