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
    /// Controller class for Person
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PersonController
    {
        // Preload our schema..
        Person thisSchemaLoad = new Person();
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
        public PersonCollection FetchAll()
        {
            PersonCollection coll = new PersonCollection();
            Query qry = new Query(Person.Schema);
            coll.Load(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PersonCollection FetchByID(object ID)
        {
            PersonCollection coll = new PersonCollection().Where("ID", ID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PersonCollection FetchByQuery(Query qry)
        {
            PersonCollection coll = new PersonCollection();
            coll.Load(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ID)
        {
            return (Person.Delete(ID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ID)
        {
            return (Person.Destroy(ID) == 1);
        }

       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string FirstName,string LastName,long LocationID,DateTime Creation,DateTime Modified)
	    {
		    Person item = new Person();
		    
            item.FirstName = FirstName;
            
            item.LastName = LastName;
            
            item.LocationID = LocationID;
            
            item.Creation = Creation;
            
            item.Modified = Modified;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(long ID,string FirstName,string LastName,long LocationID,DateTime Creation,DateTime Modified)
	    {
		    Person item = new Person();
		    
				item.ID = ID;
				
				item.FirstName = FirstName;
				
				item.LastName = LastName;
				
				item.LocationID = LocationID;
				
				item.Creation = Creation;
				
				item.Modified = Modified;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}
