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
    /// Strongly-typed collection for the CustomerCustomerDemo class.
    /// </summary>
    [Serializable]
    public partial class CustomerCustomerDemoCollection : ActiveList<CustomerCustomerDemo> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public CustomerCustomerDemoCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public CustomerCustomerDemoCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public CustomerCustomerDemoCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public CustomerCustomerDemoCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public CustomerCustomerDemoCollection Where(string columnName, object value) 
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

    	
        public CustomerCustomerDemoCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public CustomerCustomerDemoCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public CustomerCustomerDemoCollection Load() 
        {
            Query qry = new Query(CustomerCustomerDemo.Schema);
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

        
        public CustomerCustomerDemoCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the CustomerCustomerDemo table.
    /// </summary>
    [Serializable]
    public partial class CustomerCustomerDemo : ActiveRecord<CustomerCustomerDemo>
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
				TableSchema.Table schema = new TableSchema.Table("CustomerCustomerDemo", TableType.Table, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarCustomerID = new TableSchema.TableColumn(schema);
                colvarCustomerID.ColumnName = "CustomerID";
                colvarCustomerID.DataType = DbType.String;
                colvarCustomerID.MaxLength = 5;
                colvarCustomerID.AutoIncrement = false;
                colvarCustomerID.IsNullable = false;
                colvarCustomerID.IsPrimaryKey = true;
                colvarCustomerID.IsForeignKey = true;
                colvarCustomerID.IsReadOnly = false;
                
                
				colvarCustomerID.ForeignKeyTableName = "Customers";
                
                schema.Columns.Add(colvarCustomerID);
                
                TableSchema.TableColumn colvarCustomerTypeID = new TableSchema.TableColumn(schema);
                colvarCustomerTypeID.ColumnName = "CustomerTypeID";
                colvarCustomerTypeID.DataType = DbType.String;
                colvarCustomerTypeID.MaxLength = 10;
                colvarCustomerTypeID.AutoIncrement = false;
                colvarCustomerTypeID.IsNullable = false;
                colvarCustomerTypeID.IsPrimaryKey = true;
                colvarCustomerTypeID.IsForeignKey = true;
                colvarCustomerTypeID.IsReadOnly = false;
                
                
				colvarCustomerTypeID.ForeignKeyTableName = "CustomerDemographics";
                
                schema.Columns.Add(colvarCustomerTypeID);
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("CustomerCustomerDemo",schema);
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
	    public CustomerCustomerDemo()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public CustomerCustomerDemo(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public CustomerCustomerDemo(string columnName, object columnValue)
        {
            SetSQLProps();
            SetDefaults();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("CustomerID")]
        public string CustomerID 
	    {
		    get { return GetColumnValue<string>("CustomerID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CustomerID", value);
            }

        }

	      
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

	    
	    #endregion
	    
	    
	 	
			
	    
	    
	    
	    #region ForeignKey Properties
	    
        /// <summary>
        /// Returns a CustomerDemographic ActiveRecord object related to this CustomerCustomerDemo
        /// </summary>
	    public Chapter08.NorthwindDAL.CustomerDemographic CustomerDemographic
        {
	        get { return Chapter08.NorthwindDAL.CustomerDemographic.FetchByID(this.CustomerTypeID); }

	        set
	        {
		        MarkDirty();
		        SetColumnValue("CustomerTypeID", value.CustomerTypeID);
	        }

        }

	    
	    
        /// <summary>
        /// Returns a Customer ActiveRecord object related to this CustomerCustomerDemo
        /// </summary>
	    public Chapter08.NorthwindDAL.Customer Customer
        {
	        get { return Chapter08.NorthwindDAL.Customer.FetchByID(this.CustomerID); }

	        set
	        {
		        MarkDirty();
		        SetColumnValue("CustomerID", value.CustomerID);
	        }

        }

	    
	    
	    #endregion
	    
	    
	    
	    //no ManyToMany tables defined (0)
	    
	    #region ObjectDataSource support
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(string varCustomerID,string varCustomerTypeID)
	    {
		    CustomerCustomerDemo item = new CustomerCustomerDemo();
		    
            item.CustomerID = varCustomerID;
            
            item.CustomerTypeID = varCustomerTypeID;
            
	    
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(string varCustomerID,string varCustomerTypeID)
	    {
		    CustomerCustomerDemo item = new CustomerCustomerDemo();
		    
                item.CustomerID = varCustomerID;
				
                item.CustomerTypeID = varCustomerTypeID;
				
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
		    
		    
            public static string CustomerID = @"CustomerID";
            
            public static string CustomerTypeID = @"CustomerTypeID";
            
	    }

	    #endregion
    }

}

