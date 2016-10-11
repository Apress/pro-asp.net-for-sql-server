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


//Generated on 6/10/2007 10:07:03 PM by brennan

namespace Chapter08.NorthwindDAL
{
    /// <summary>
    /// Controller class for CustomerCustomerDemo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CustomerCustomerDemoController
    {
        // Preload our schema..
        CustomerCustomerDemo thisSchemaLoad = new CustomerCustomerDemo();
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
        public CustomerCustomerDemoCollection FetchAll()
        {
            CustomerCustomerDemoCollection coll = new CustomerCustomerDemoCollection();
            Query qry = new Query(CustomerCustomerDemo.Schema);
            coll.Load(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CustomerCustomerDemoCollection FetchByID(object CustomerID)
        {
            CustomerCustomerDemoCollection coll = new CustomerCustomerDemoCollection().Where("CustomerID", CustomerID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CustomerCustomerDemoCollection FetchByQuery(Query qry)
        {
            CustomerCustomerDemoCollection coll = new CustomerCustomerDemoCollection();
            coll.Load(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CustomerID)
        {
            return (CustomerCustomerDemo.Delete(CustomerID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CustomerID)
        {
            return (CustomerCustomerDemo.Destroy(CustomerID) == 1);
        }

       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string CustomerID,string CustomerTypeID)
	    {
		    CustomerCustomerDemo item = new CustomerCustomerDemo();
		    
            item.CustomerID = CustomerID;
            
            item.CustomerTypeID = CustomerTypeID;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string CustomerID,string CustomerTypeID)
	    {
		    CustomerCustomerDemo item = new CustomerCustomerDemo();
		    
				item.CustomerID = CustomerID;
				
				item.CustomerTypeID = CustomerTypeID;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}
