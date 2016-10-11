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


//Generated on 6/10/2007 10:06:51 PM by brennan

namespace Chapter08.NorthwindDAL{
    /// <summary>
    /// Strongly-typed collection for the CustomerDemographic class.
    /// </summary>
    [Serializable]
    public partial class CustomerDemographicCollection : ActiveList<CustomerDemographic> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public CustomerDemographicCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public CustomerDemographicCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public CustomerDemographicCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public CustomerDemographicCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public CustomerDemographicCollection Where(string columnName, object value) 
	    {
		    if(value != DBNull.Value && value != null)
		    {	
			    return Where(columnName, Comparison.Equals, value);
		    }

		    else
		    {
			    return Where(columnName, Comparison.Is, DBNull.Value);
		    }

        }

    	
        public CustomerDemographicCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public CustomerDemographicCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            BetweenAnd between = new BetweenAnd();
            between.ColumnName = columnName;
            between.StartDate = dateStart;
            between.EndDate = dateEnd;
            between.StartParameterName = "start" + columnName; 
            between.EndParameterName = "end" + columnName; 
            betweens.Add(between);
            return this;
        }

    	
        public CustomerDemographicCollection Load() 
        {
            Query qry = new Query(CustomerDemographic.Schema);
            CheckLogicalDelete(qry);
            foreach (Where where in wheres) 
            {
                qry.AddWhere(where);
            }

             
            foreach (BetweenAnd between in betweens)
            {
                qry.AddBetweenAnd(between);
            }

            if (orderBy != null)
            {
                qry.OrderBy = orderBy;
            }

            IDataReader rdr = qry.ExecuteReader();
            this.Load(rdr);
            rdr.Close();
            return this;
        }

        
        public CustomerDemographicCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the CustomerDemographics table.
    /// </summary>
    [Serializable]
    public partial class CustomerDemographic : ActiveRecord<CustomerDemographic>
    {
    
	    #region Default Settings
	    protected static void SetSQLProps() 
	    {
		    GetTableSchema();
	    }

	    #endregion
        #region Schema Accessor
	    public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }

                return BaseSchema;
            }

        }

    	
        private static void GetTableSchema() 
	    {
            if(!IsSchemaInitialized)
            {
                //Schema declaration
				TableSchema.Table schema = new TableSchema.Table("CustomerDemographics", TableType.Table, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarCustomerTypeID = new TableSchema.TableColumn(schema);
                colvarCustomerTypeID.ColumnName = "CustomerTypeID";
                colvarCustomerTypeID.DataType = DbType.String;
                colvarCustomerTypeID.MaxLength = 10;
                colvarCustomerTypeID.AutoIncrement = false;
                colvarCustomerTypeID.IsNullable = false;
                colvarCustomerTypeID.IsPrimaryKey = true;
                colvarCustomerTypeID.IsForeignKey = false;
                colvarCustomerTypeID.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarCustomerTypeID);
                
                TableSchema.TableColumn colvarCustomerDesc = new TableSchema.TableColumn(schema);
                colvarCustomerDesc.ColumnName = "CustomerDesc";
                colvarCustomerDesc.DataType = DbType.String;
                colvarCustomerDesc.MaxLength = 1073741823;
                colvarCustomerDesc.AutoIncrement = false;
                colvarCustomerDesc.IsNullable = true;
                colvarCustomerDesc.IsPrimaryKey = false;
                colvarCustomerDesc.IsForeignKey = false;
                colvarCustomerDesc.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarCustomerDesc);
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("CustomerDemographics",schema);
            }

        }

        #endregion
        
        #region Query Accessor
	    public static Query CreateQuery()
	    {
		    return new Query(Schema);
	    }

	    #endregion
	    
	    #region .ctors
	    public CustomerDemographic()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public CustomerDemographic(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public CustomerDemographic(string columnName, object columnValue)
        {
            SetSQLProps();
            SetDefaults();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("CustomerTypeID")]
        public string CustomerTypeID 
	    {
		    get { return GetColumnValue<string>("CustomerTypeID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CustomerTypeID", value);
            }

        }

	      
        [XmlAttribute("CustomerDesc")]
        public string CustomerDesc 
	    {
		    get { return GetColumnValue<string>("CustomerDesc"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CustomerDesc", value);
            }

        }

	    
	    #endregion
	    
	    
	    #region PrimaryKey Methods
	    
		public Chapter08.NorthwindDAL.CustomerCustomerDemoCollection CustomerCustomerDemoRecords()
		{
			return new Chapter08.NorthwindDAL.CustomerCustomerDemoCollection().Where(CustomerCustomerDemo.Columns.CustomerTypeID, CustomerTypeID).Load();
		}

		#endregion
		
	 	
			
	    
	    //no foreign key tables defined (0)
	    
	    
	    
	    #region Many To Many Helpers
	    
	     
        public Chapter08.NorthwindDAL.CustomerCollection GetCustomerCollection() {
            return CustomerDemographic.GetCustomerCollection(this.CustomerTypeID);
        }

        public static Chapter08.NorthwindDAL.CustomerCollection GetCustomerCollection(string varCustomerTypeID) {
            SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
                "SELECT * FROM Customers INNER JOIN CustomerCustomerDemo ON "+
                "Customers.CustomerID=CustomerCustomerDemo.CustomerID WHERE CustomerCustomerDemo.CustomerTypeID=@CustomerTypeID", CustomerDemographic.Schema.Provider.Name);
            
            cmd.AddParameter("@CustomerTypeID", varCustomerTypeID);
            
            IDataReader rdr = SubSonic.DataService.GetReader(cmd);
            CustomerCollection coll = new CustomerCollection();
            coll.LoadAndCloseReader(rdr);
            return coll;
        }

        public static void SaveCustomerMap(string varCustomerTypeID, CustomerCollection items) {
            
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
            QueryCommand cmdDel = new QueryCommand("DELETE FROM CustomerCustomerDemo WHERE CustomerTypeID=@CustomerTypeID", CustomerDemographic.Schema.Provider.Name);
            cmdDel.AddParameter("@CustomerTypeID", varCustomerTypeID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (Customer item in items)
            {
				CustomerCustomerDemo varCustomerCustomerDemo = new CustomerCustomerDemo();
				varCustomerCustomerDemo.SetColumnValue("CustomerTypeID", varCustomerTypeID);
				varCustomerCustomerDemo.SetColumnValue("CustomerID", item.GetPrimaryKeyValue());
				varCustomerCustomerDemo.Save();
            }

        }

        public static void SaveCustomerMap(string varCustomerTypeID, System.Web.UI.WebControls.ListItemCollection itemList) 
        {
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
             QueryCommand cmdDel = new QueryCommand("DELETE FROM CustomerCustomerDemo WHERE CustomerTypeID=@CustomerTypeID", CustomerDemographic.Schema.Provider.Name);
            cmdDel.AddParameter("@CustomerTypeID", varCustomerTypeID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (System.Web.UI.WebControls.ListItem l in itemList) 
            {
                if (l.Selected) 
                {
					CustomerCustomerDemo varCustomerCustomerDemo = new CustomerCustomerDemo();
					varCustomerCustomerDemo.SetColumnValue("CustomerTypeID", varCustomerTypeID);
					varCustomerCustomerDemo.SetColumnValue("CustomerID", l.Value);
					varCustomerCustomerDemo.Save();
                }

            }

        }

        public static void SaveCustomerMap(string varCustomerTypeID , string[] itemList) 
        {
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
             QueryCommand cmdDel = new QueryCommand("DELETE FROM CustomerCustomerDemo WHERE CustomerTypeID=@CustomerTypeID", CustomerDemographic.Schema.Provider.Name);
            cmdDel.AddParameter("@CustomerTypeID", varCustomerTypeID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (string item in itemList) 
            {
            	CustomerCustomerDemo varCustomerCustomerDemo = new CustomerCustomerDemo();
				varCustomerCustomerDemo.SetColumnValue("CustomerTypeID", varCustomerTypeID);
				varCustomerCustomerDemo.SetColumnValue("CustomerID", item);
				varCustomerCustomerDemo.Save();
            }

        }

        
        public static void DeleteCustomerMap(string varCustomerTypeID) 
        {
            QueryCommand cmdDel = new QueryCommand("DELETE FROM CustomerCustomerDemo WHERE CustomerTypeID=@CustomerTypeID", CustomerDemographic.Schema.Provider.Name);
            cmdDel.AddParameter("@CustomerTypeID", varCustomerTypeID);
            DataService.ExecuteQuery(cmdDel);
		}

	    
	    #endregion
	    
	    #region ObjectDataSource support
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(string varCustomerTypeID,string varCustomerDesc)
	    {
		    CustomerDemographic item = new CustomerDemographic();
		    
            item.CustomerTypeID = varCustomerTypeID;
            
            item.CustomerDesc = varCustomerDesc;
            
	    
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(string varCustomerTypeID,string varCustomerDesc)
	    {
		    CustomerDemographic item = new CustomerDemographic();
		    
                item.CustomerTypeID = varCustomerTypeID;
				
                item.CustomerDesc = varCustomerDesc;
				
		    item.IsNew = false;
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

	    #endregion
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string CustomerTypeID = @"CustomerTypeID";
            
            public static string CustomerDesc = @"CustomerDesc";
            
	    }

	    #endregion
    }

}

