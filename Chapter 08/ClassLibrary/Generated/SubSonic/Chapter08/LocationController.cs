using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using SubSonic;
using SubSonic.Utilities;


//Generated on 6/10/2007 10:07:13 PM by brennan

namespace Chapter08.SubSonicDAL
{
    /// <summary>
    /// Controller class for Location
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LocationController
    {
        // Preload our schema..
        Location thisSchemaLoad = new Location();
        private string userName = string.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}

					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}

				}

				return userName;
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public LocationCollection FetchAll()
        {
            LocationCollection coll = new LocationCollection();
            Query qry = new Query(Location.Schema);
            coll.Load(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LocationCollection FetchByID(object ID)
        {
            LocationCollection coll = new LocationCollection().Where("ID", ID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LocationCollection FetchByQuery(Query qry)
        {
            LocationCollection coll = new LocationCollection();
            coll.Load(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ID)
        {
            return (Location.Delete(ID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ID)
        {
            return (Location.Destroy(ID) == 1);
        }

       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string City,string State,DateTime Creation,DateTime Modified)
	    {
		    Location item = new Location();
		    
            item.City = City;
            
            item.State = State;
            
            item.Creation = Creation;
            
            item.Modified = Modified;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(long ID,string City,string State,DateTime Creation,DateTime Modified)
	    {
		    Location item = new Location();
		    
				item.ID = ID;
				
				item.City = City;
				
				item.State = State;
				
				item.Creation = Creation;
				
				item.Modified = Modified;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}
