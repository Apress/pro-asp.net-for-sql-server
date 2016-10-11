using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using System.Xml;
using System.Xml.Serialization;
using SubSonic;
using SubSonic.Utilities;

namespace Chapter08.SubSonicDAL
{
    public partial class PersonController
    {
        
        public PersonCollection FetchByID(object ID, bool cached)
        {
            if (!cached) 
            {
                return FetchByID(ID);
            }
            string cacheKey = (typeof(Person)).ToString() + "-" + ID;
            Cache cache = HttpRuntime.Cache;
            if (cache[cacheKey] != null) {
                return cache[cacheKey] as PersonCollection;
            }

            PersonCollection coll = new PersonCollection().Where(Person.Columns.ID, ID).Load();
            
            cache.Insert(cacheKey, coll, null,
                DateTime.Now.AddMinutes(5), TimeSpan.Zero);
            return coll;
        }

        public PersonCollection FetchPersonsByLocationID(object LocationID)
        {
            return new PersonCollection().
                Where(Person.Columns.LocationID, LocationID).
                OrderByAsc(Person.Columns.LastName).Load();
        }

        public void ClearCachedItem(object ID)
        {
            string cacheKey = (typeof(Person)).ToString() + "-" + ID;
            Cache cache = HttpRuntime.Cache;
            cache.Remove(cacheKey);
        }
    }
}
