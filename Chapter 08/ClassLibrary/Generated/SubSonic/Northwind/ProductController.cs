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


//Generated on 6/10/2007 10:07:10 PM by brennan

namespace Chapter08.NorthwindDAL
{
    /// <summary>
    /// Controller class for Products
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductController
    {
        // Preload our schema..
        Product thisSchemaLoad = new Product();
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
        public ProductCollection FetchAll()
        {
            ProductCollection coll = new ProductCollection();
            Query qry = new Query(Product.Schema);
            coll.Load(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductCollection FetchByID(object ProductID)
        {
            ProductCollection coll = new ProductCollection().Where("ProductID", ProductID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductCollection FetchByQuery(Query qry)
        {
            ProductCollection coll = new ProductCollection();
            coll.Load(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductID)
        {
            return (Product.Delete(ProductID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductID)
        {
            return (Product.Destroy(ProductID) == 1);
        }

       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string ProductName,int? SupplierID,int? CategoryID,string QuantityPerUnit,decimal? UnitPrice,short? UnitsInStock,short? UnitsOnOrder,short? ReorderLevel,bool Discontinued,string AttributeXML,DateTime? DateCreated,Guid? ProductGUID)
	    {
		    Product item = new Product();
		    
            item.ProductName = ProductName;
            
            item.SupplierID = SupplierID;
            
            item.CategoryID = CategoryID;
            
            item.QuantityPerUnit = QuantityPerUnit;
            
            item.UnitPrice = UnitPrice;
            
            item.UnitsInStock = UnitsInStock;
            
            item.UnitsOnOrder = UnitsOnOrder;
            
            item.ReorderLevel = ReorderLevel;
            
            item.Discontinued = Discontinued;
            
            item.AttributeXML = AttributeXML;
            
            item.DateCreated = DateCreated;
            
            item.ProductGUID = ProductGUID;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductID,string ProductName,int? SupplierID,int? CategoryID,string QuantityPerUnit,decimal? UnitPrice,short? UnitsInStock,short? UnitsOnOrder,short? ReorderLevel,bool Discontinued,string AttributeXML,DateTime? DateCreated,Guid? ProductGUID)
	    {
		    Product item = new Product();
		    
				item.ProductID = ProductID;
				
				item.ProductName = ProductName;
				
				item.SupplierID = SupplierID;
				
				item.CategoryID = CategoryID;
				
				item.QuantityPerUnit = QuantityPerUnit;
				
				item.UnitPrice = UnitPrice;
				
				item.UnitsInStock = UnitsInStock;
				
				item.UnitsOnOrder = UnitsOnOrder;
				
				item.ReorderLevel = ReorderLevel;
				
				item.Discontinued = Discontinued;
				
				item.AttributeXML = AttributeXML;
				
				item.DateCreated = DateCreated;
				
				item.ProductGUID = ProductGUID;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}
