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


//Generated on 6/10/2007 10:06:57 PM by brennan

namespace Chapter08.NorthwindDAL{
    /// <summary>
    /// Strongly-typed collection for the ProductCategoryMap class.
    /// </summary>
    [Serializable]
    public partial class ProductCategoryMapCollection : ActiveList<ProductCategoryMap> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public ProductCategoryMapCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public ProductCategoryMapCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public ProductCategoryMapCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public ProductCategoryMapCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public ProductCategoryMapCollection Where(string columnName, object value) 
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

    	
        public ProductCategoryMapCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public ProductCategoryMapCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public ProductCategoryMapCollection Load() 
        {
            Query qry = new Query(ProductCategoryMap.Schema);
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

        
        public ProductCategoryMapCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the Product_Category_Map table.
    /// </summary>
    [Serializable]
    public partial class ProductCategoryMap : ActiveRecord<ProductCategoryMap>
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
				TableSchema.Table schema = new TableSchema.Table("Product_Category_Map", TableType.Table, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarCategoryID = new TableSchema.TableColumn(schema);
                colvarCategoryID.ColumnName = "CategoryID";
                colvarCategoryID.DataType = DbType.Int32;
                colvarCategoryID.MaxLength = 0;
                colvarCategoryID.AutoIncrement = false;
                colvarCategoryID.IsNullable = false;
                colvarCategoryID.IsPrimaryKey = true;
                colvarCategoryID.IsForeignKey = true;
                colvarCategoryID.IsReadOnly = false;
                
                
				colvarCategoryID.ForeignKeyTableName = "Categories";
                
                schema.Columns.Add(colvarCategoryID);
                
                TableSchema.TableColumn colvarProductID = new TableSchema.TableColumn(schema);
                colvarProductID.ColumnName = "ProductID";
                colvarProductID.DataType = DbType.Int32;
                colvarProductID.MaxLength = 0;
                colvarProductID.AutoIncrement = false;
                colvarProductID.IsNullable = false;
                colvarProductID.IsPrimaryKey = true;
                colvarProductID.IsForeignKey = true;
                colvarProductID.IsReadOnly = false;
                
                
				colvarProductID.ForeignKeyTableName = "Products";
                
                schema.Columns.Add(colvarProductID);
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Product_Category_Map",schema);
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
	    public ProductCategoryMap()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public ProductCategoryMap(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public ProductCategoryMap(string columnName, object columnValue)
        {
            SetSQLProps();
            SetDefaults();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("CategoryID")]
        public int CategoryID 
	    {
		    get { return GetColumnValue<int>("CategoryID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CategoryID", value);
            }

        }

	      
        [XmlAttribute("ProductID")]
        public int ProductID 
	    {
		    get { return GetColumnValue<int>("ProductID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ProductID", value);
            }

        }

	    
	    #endregion
	    
	    
	 	
			
	    
	    
	    
	    #region ForeignKey Properties
	    
        /// <summary>
        /// Returns a Category ActiveRecord object related to this ProductCategoryMap
        /// </summary>
	    public Chapter08.NorthwindDAL.Category Category
        {
	        get { return Chapter08.NorthwindDAL.Category.FetchByID(this.CategoryID); }

	        set
	        {
		        MarkDirty();
		        SetColumnValue("CategoryID", value.CategoryID);
	        }

        }

	    
	    
        /// <summary>
        /// Returns a Product ActiveRecord object related to this ProductCategoryMap
        /// </summary>
	    public Chapter08.NorthwindDAL.Product Product
        {
	        get { return Chapter08.NorthwindDAL.Product.FetchByID(this.ProductID); }

	        set
	        {
		        MarkDirty();
		        SetColumnValue("ProductID", value.ProductID);
	        }

        }

	    
	    
	    #endregion
	    
	    
	    
	    //no ManyToMany tables defined (0)
	    
	    #region ObjectDataSource support
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(int varCategoryID,int varProductID)
	    {
		    ProductCategoryMap item = new ProductCategoryMap();
		    
            item.CategoryID = varCategoryID;
            
            item.ProductID = varProductID;
            
	    
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(int varCategoryID,int varProductID)
	    {
		    ProductCategoryMap item = new ProductCategoryMap();
		    
                item.CategoryID = varCategoryID;
				
                item.ProductID = varProductID;
				
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
		    
		    
            public static string CategoryID = @"CategoryID";
            
            public static string ProductID = @"ProductID";
            
	    }

	    #endregion
    }

}

