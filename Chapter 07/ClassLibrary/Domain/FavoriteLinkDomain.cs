using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Web.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Chapter07.Domain
{
    [DataObject()]
    public class FavoriteLinkDomain
    {
        #region "  Variables  "

        private Database db;

        private readonly DateTime DefaultDate = new DateTime(1754, 1, 1, 1, 1, 1);

        #endregion

        #region "  Constructor  "

        public FavoriteLinkDomain()
        {
            //string connectionStringName = ConfigurationManager.AppSettings["FavoriteLinksDB"];
            //db = DatabaseFactory.CreateDatabase(connectionStringName);

            FavoriteLinkSection config = GetConfiguration();
            string connectionStringName = config.ConnectionStringName;

            // verify the required connection string is available
            if (ConfigurationManager.ConnectionStrings[connectionStringName] == null)
            {
                throw new DomainException("Missing connection string: " + 
                    connectionStringName);
            }

            db = DatabaseFactory.CreateDatabase(connectionStringName);
        }

        #endregion

        #region "  Configuration  "

        public FavoriteLinkSection GetConfiguration()
        {
            FavoriteLinkSection section = (FavoriteLinkSection)
                ConfigurationManager.GetSection("chapter07/favoriteLink");
            return section;
        }
        #endregion

        #region  " Get Methods  "

        [DataObjectMethod(DataObjectMethodType.Select)]
        public long GetFavoriteLinkProfileID(Guid userId)
        {
            long profileId;
            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt07_GetFavoriteLinkProfile"))
                {
                    db.AddInParameter(dbCmd, "@UserID", DbType.Guid, userId);
                    db.AddOutParameter(dbCmd, "@ProfileID", DbType.Int64, 0);

                    db.ExecuteNonQuery(dbCmd);
                    profileId = (long)db.GetParameterValue(dbCmd, "@ProfileID");
                }
            }
            catch (Exception ex)
            {
                throw GetException("Error in GetFavoriteLinkProfile", ex);
            }
            return profileId;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetFavoriteLinksByProfileID(long profileId)
        {
            DataSet ds;

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt07_GetFavoriteLinksByProfileID"))
                {
                    db.AddInParameter(dbCmd, "@ProfileID", DbType.Int64, profileId);
                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                throw GetException("Error in GetFavoriteLinksByProfileID", ex);
            }

            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetRecentFavoriteLinksByProfileID(
            long profileId, int startDaysBack, int endDaysBack)
        {
            DataSet ds;

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand(
                    "chpt07_GetRecentFavoriteLinksByProfileID"))
                {
                    db.AddInParameter(dbCmd, "@ProfileID", 
                        DbType.Int64, profileId);
                    db.AddInParameter(dbCmd, "@StartDaysBack", 
                        DbType.Int32, startDaysBack);
                    db.AddInParameter(dbCmd, "@EndDaysBack", 
                        DbType.Int32, endDaysBack);

                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                throw GetException(
                    "Error in GetRecentFavoriteLinksByProfileID", ex);
            }

            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetLatest20FavoriteLinksByProfileID(long profileId)
        {
            DataSet ds;

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt07_GetLatest20FavoriteLinksByProfileID"))
                {
                    db.AddInParameter(dbCmd, "@ProfileID", DbType.Int64, profileId);

                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                throw GetException("Error in GetLatest20FavoriteLinksByProfileID", ex);
            }

            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetFavoriteLinkByUrl(long profileId, string url)
        {
            DataSet ds;

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt07_GetFavoriteLinkByUrl"))
                {
                    db.AddInParameter(dbCmd, "@ProfileID", DbType.Int64, profileId);
                    db.AddInParameter(dbCmd, "@Url", DbType.String, url);

                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                throw GetException("Error in GetFavoriteLinkByUrl", ex);
            }

            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetFavoriteLinksByTag(long profileId, string token)
        {
            DataSet ds;

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt07_GetFavoriteLinksByTag"))
                {
                    db.AddInParameter(dbCmd, "@ProfileID", DbType.Int64, profileId);
                    db.AddInParameter(dbCmd, "@Token", DbType.String, token);

                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                throw GetException("Error in GetFavoriteLinksByTag", ex);
            }

            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetLinkTagsByProfileID(long profileId)
        {
            DataSet ds;

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt07_GetLinkTagsByProfileID"))
                {
                    db.AddInParameter(dbCmd, "@ProfileID", DbType.Int64, profileId);

                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                throw GetException("Error in GetLinkTagsByProfileID", ex);
            }

            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetLinkTagsWithCountByProfileID(long profileId)
        {
            DataSet ds;

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt07_GetLinkTagsWithCountByProfileID"))
                {
                    db.AddInParameter(dbCmd, "@ProfileID", DbType.Int64, profileId);
                    
                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                throw GetException("Error in GetLinkTagsWithCountByProfileID", ex);
            }

            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetLinkTagsByFavoriteLinkID(long favoriteLinkId)
        {
            DataSet ds;

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt07_GetLinkTagsByFavoriteLinkID"))
                {
                    db.AddInParameter(dbCmd, "@FavoriteLinkID", DbType.Int64, favoriteLinkId);

                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                throw GetException("Error in GetLinkTagsByFavoriteLinkID", ex);
            }

            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DateTime GetLatestFavoriteLinkDate(long profileId)
        {
            DateTime latestDate;
            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt07_GetLatestFavoriteLinkDate"))
                {
                    db.AddInParameter(dbCmd, "@ProfileID", DbType.Int64, profileId);
                    db.AddOutParameter(dbCmd, "@LatestDate", DbType.DateTime, 0);

                    db.ExecuteNonQuery(dbCmd);
                    latestDate = (DateTime)db.GetParameterValue(dbCmd, "@LatestDate");
                }
            }
            catch (Exception ex)
            {
                throw GetException("Error in GetLatestFavoriteLinkDate", ex);
            }
            return latestDate;
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public FavoriteLinkCollection GetFavoriteLinkCollection(long profileId)
        {
            DataSet ds = GetFavoriteLinksByProfileID(profileId);
            FavoriteLinkCollection collection = new FavoriteLinkCollection();
            AddToFavoriteLinkCollection(collection, ds);
            return collection;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public FavoriteLinkCollection GetFavoriteLinkCollection2(long profileId)
        {
            FavoriteLinkCollection collection = new FavoriteLinkCollection();

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt07_GetFavoriteLinksByProfileID"))
                {
                    db.AddInParameter(dbCmd, "@ProfileID", DbType.Int64, profileId);
                    IDataReader dr = db.ExecuteReader(dbCmd);
                    AddToFavoriteLinkCollection(collection, dr);
                }
            }
            catch (Exception ex)
            {
                throw GetException("Error in GetFavoriteLinksByProfileID", ex);
            }

            //return the results
            return collection;
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public FavoriteLinkCollection GetRecentFavoriteLinkCollection(
            long profileId, int startDaysBack, int endDaysBack)
        {
            DataSet ds = GetRecentFavoriteLinksByProfileID(profileId, startDaysBack, endDaysBack);
            FavoriteLinkCollection collection = new FavoriteLinkCollection();
            AddToFavoriteLinkCollection(collection, ds);
            return collection;
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public FavoriteLinkCollection GetLatest20FavoriteLinkCollection(long profileId)
        {
            DataSet ds = GetLatest20FavoriteLinksByProfileID(profileId);
            FavoriteLinkCollection collection = new FavoriteLinkCollection();
            AddToFavoriteLinkCollection(collection, ds);
            return collection;
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public FavoriteLinkCollection GetFavoriteLinkCollectionByTag(long profileId, string token)
        {
            DataSet ds = GetFavoriteLinksByTag(profileId, token);
            FavoriteLinkCollection collection = new FavoriteLinkCollection();
            AddToFavoriteLinkCollection(collection, ds);
            return collection;
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public FavoriteLinkCollection GetFavoriteLinkCollectionByUrl(long profileId, string url)
        {
            DataSet ds = GetFavoriteLinkByUrl(profileId, url);
            FavoriteLinkCollection collection = new FavoriteLinkCollection();
            AddToFavoriteLinkCollection(collection, ds);
            return collection;
        }



        public DataSet GetNullables()
        {
            DataSet ds = new DataSet();

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt07_GetNullables"))
                {
                    //db.AddInParameter(dbCmd, "@Parameter1", DbType.String, String.Empty);
                    //db.AddOutParameter(dbCmd, "@Parameter2", DbType.String, 0);

                    ds = db.ExecuteDataSet(dbCmd);
                    //Object outputParameter = db.GetParameterValue(dbCmd, "@OutputParameter");
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

        #endregion

        #region "  Save Methods  "

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public long SaveFavoriteLink(long profileId, string url, string title)
        {
            return SaveFavoriteLink(profileId, url, title, -1);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public long SaveFavoriteLink(long profileId, string url, string title, long oldFavoriteLinkId) 
        {
            // load existing FavoriteLink
            bool keeper = true;
            int rating = 1;
            string tags = String.Empty;
            string note = String.Empty;
            FavoriteLinkCollection lc = GetFavoriteLinkCollectionByUrl(profileId, url);
            if (lc.Count > 0)
            {
                FavoriteLink fl = lc[0];
                keeper = fl.Keeper;
                rating = fl.Rating;
                tags = fl.Tags;
                note = fl.Note;
            }

            return SaveFavoriteLink(profileId, url, title, keeper, rating, note,
                tags, DefaultDate, DefaultDate, oldFavoriteLinkId);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public long SaveFavoriteLink(
            long profileId, string url, string title, 
            bool keeper, int rating, string note, string tags,
            DateTime created, DateTime modified, long oldFavoriteLinkId)
        {
            long favoriteLinkId;

            try
            {
                using (DbCommand dbCmd = 
                    db.GetStoredProcCommand("chpt07_SaveFavoriteLink"))
                {
                    db.AddInParameter(dbCmd, "@ProfileID", 
                        DbType.Int64, profileId);
                    db.AddInParameter(dbCmd, "@Url", 
                        DbType.String, url);
                    db.AddInParameter(dbCmd, "@Title", 
                        DbType.String, title);
                    db.AddInParameter(dbCmd, "@Keeper", 
                        DbType.Boolean, keeper);
                    db.AddInParameter(dbCmd, "@Rating", 
                        DbType.Int16, rating);
                    db.AddInParameter(dbCmd, "@Note", 
                        DbType.String, note);
                    db.AddInParameter(dbCmd, "@Created", 
                        DbType.DateTime, created);
                    db.AddInParameter(dbCmd, "@Modified", 
                        DbType.DateTime, modified);
                    db.AddInParameter(dbCmd, "@OldFavoriteLinkID", 
                        DbType.Int64, oldFavoriteLinkId);
                    db.AddOutParameter(dbCmd, "@FavoriteLinkID", 
                        DbType.Int64, 0);

                    db.ExecuteNonQuery(dbCmd);
                    object obj = db.GetParameterValue(dbCmd, "@FavoriteLinkID");
                    favoriteLinkId = (long) obj;
                }
            }
            catch (Exception ex)
            {
                throw GetException("Error in SaveFavoriteLink", ex);
            }
            SaveLinkTags(favoriteLinkId, tags);
            return favoriteLinkId;
        }

        public long SaveFavoriteLink(long profileId, string url, string title,
                                  bool keeper, int rating, string note, 
                                  string tags, long oldFavoriteLinkId)
        {
            long favoriteLinkId = SaveFavoriteLink(profileId, url, title, keeper,
                rating, note, tags, DefaultDate, DefaultDate, oldFavoriteLinkId);
            return favoriteLinkId;
        }

        private void SaveLinkTags(long favoriteLinkId, string tags)
        {
            if (String.IsNullOrEmpty(tags))
            {
                tags = String.Empty;
            }

            List<String> newTokens = new List<String>();
            List<String> oldTokens = new List<String>();

            foreach (String newToken in tags.Trim().Split(" ".ToCharArray()[0]))
            {
                newTokens.Add(newToken);
            }

            DataSet tagsDs = GetLinkTagsByFavoriteLinkID(favoriteLinkId);
            if (tagsDs != null && tagsDs.Tables.Count > 0)
            {
                foreach (DataRow row in tagsDs.Tables[0].Rows)
                {
                    oldTokens.Add(row["Token"].ToString());
                }                    
            }

            // look for tags to delete
            foreach (String oldToken in oldTokens)
            {
                if (!newTokens.Contains(oldToken))
                {
                    // remove tag
                    RemoveLinkTag(favoriteLinkId, oldToken);
                }
            }

            foreach (string newTag in newTokens)
            {
                if (!oldTokens.Contains(newTag))
                {
                    SaveLinkTag(favoriteLinkId, newTag);
                }
            }
                    
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public long SaveLinkTag(long favoriteLinkId, string token)
        {
            if (String.Empty.Equals(token))
            {
                return 0;
            }
            long linkTagId;
            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt07_SaveLinkTag"))
                {
                    db.AddInParameter(dbCmd, "@FavoriteLinkID", DbType.String, favoriteLinkId);
                    db.AddInParameter(dbCmd, "@Token", DbType.String, token);
                    db.AddOutParameter(dbCmd, "@LinkTagID", DbType.Int64, 0);

                    db.ExecuteNonQuery(dbCmd);
                    linkTagId = (long) db.GetParameterValue(dbCmd, "@LinkTagID");
                }
            }
            catch (Exception ex)
            {
                throw GetException("Error in SaveLinkTag", ex);
            }
            return linkTagId;
        }

        #endregion

        #region "  Remove Methods  "

        public void RemoveLinkTag(long favoriteLinkId, string token)
        {
            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt07_RemoveLinkTag"))
                {
                    db.AddInParameter(dbCmd, "@FavoriteLinkID", DbType.Int64, favoriteLinkId);
                    db.AddInParameter(dbCmd, "@Token", DbType.String, token);

                    db.ExecuteNonQuery(dbCmd);
                }
            }
            catch (Exception ex)
            {
                throw GetException("Error in RemoveLinkTag", ex);
            }
        }

        #endregion

        #region "  Purge Methods  "

        public void PurgeProfile(long profileId)
        {
            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt07_PurgeProfile"))
                {
                    db.AddInParameter(dbCmd, "@ProfileID", DbType.Int64, profileId);

                    db.ExecuteNonQuery(dbCmd);
                }
            }
            catch (Exception ex)
            {
                throw GetException("Error in PurgeProfile", ex);
            }
        }

        #endregion

        #region "  Helper Methods  "

        private void AddToFavoriteLinkCollection(FavoriteLinkCollection collection, DataSet ds)
        {
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    FavoriteLink fl = new FavoriteLink(row);
                    collection.Add(fl);
                }
            }
        }

        private void AddToFavoriteLinkCollection(FavoriteLinkCollection collection, IDataReader dr)
        {
            while (dr.Read())
            {
                FavoriteLink fl = new FavoriteLink(dr);
                collection.Add(fl);
            }
        }

        public FavoriteLink Convert(DataRow row)
        {
            return new FavoriteLink(row);
        }

        private DomainException GetException(string message, Exception ex)
        {
            // TODO log the message and exception
            return new DomainException("Error in the domain layer");
        }

        #endregion

        #region "  X  "

        
        public delegate void SetPropertyValue(object obj, PropertyInfo pi, DataRow row, string name);

        public static List<SetPropertyValue> PrepareDataLoadActions(DataTable table)
        {
            return null;
        }

        public List<SetPropertyValue> dataLoadActions = new List<SetPropertyValue>();
        public void AddAction(SetPropertyValue dataLoadAction)
        {
            dataLoadActions.Add(dataLoadAction);
        }

        #endregion

        #region "  Inline SQL  "

        public DataSet GetProduct(int productId)
        {
            DataSet ds;
            try
            {
                String sql = "SELECT * FROM Production.Product " +
                    "WHERE ProductID = @ProductID";
                using (DbCommand dbCmd = db.GetSqlStringCommand(sql))
                {
                    db.AddInParameter(dbCmd, "@ProductID", 
                        DbType.Int32, productId);
                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                // handle exception
                throw;
            }
            return ds;
        }

        #endregion

    }
}
