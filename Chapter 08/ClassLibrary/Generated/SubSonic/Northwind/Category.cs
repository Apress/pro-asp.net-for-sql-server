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


//Generated on 6/10/2007 10:06:50 PM by brennan

namespace Chapter08.NorthwindDAL{
    /// <summary>
    /// Strongly-typed collection for the Category class.
    /// </summary>
    [Serializable]
    public partial class CategoryCollection : ActiveList<Category> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public CategoryCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public CategoryCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public CategoryCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public CategoryCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public CategoryCollection Where(string columnName, object value) 
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

    	
        public CategoryCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public CategoryCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public CategoryCollection Load() 
        {
            Query qry = new Query(Category.Schema);
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

        
        public CategoryCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the Categories table.
    /// </summary>
    [Serializable]
    public partial class Category : ActiveRecord<Category>
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
				TableSchema.Table schema = new TableSchema.Table("Categories", TableType.Table, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarCategoryID = new TableSchema.TableColumn(schema);
                colvarCategoryID.ColumnName = "CategoryID";
                colvarCategoryID.DataType = DbType.Int32;
                colvarCategoryID.MaxLength = 0;
                colvarCategoryID.AutoIncrement = true;
                colvarCategoryID.IsNullable = false;
                colvarCategoryID.IsPrimaryKey = true;
                colvarCategoryID.IsForeignKey = false;
                colvarCategoryID.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarCategoryID);
                
                TableSchema.TableColumn colvarCategoryName = new TableSchema.TableColumn(schema);
                colvarCategoryName.ColumnName = "CategoryName";
                colvarCategoryName.DataType = DbType.String;
                colvarCategoryName.MaxLength = 15;
                colvarCategoryName.AutoIncrement = false;
                colvarCategoryName.IsNullable = false;
                colvarCategoryName.IsPrimaryKey = false;
                colvarCategoryName.IsForeignKey = false;
                colvarCategoryName.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarCategoryName);
                
                TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
                colvarDescription.ColumnName = "Description";
                colvarDescription.DataType = DbType.String;
                colvarDescription.MaxLength = 1073741823;
                colvarDescription.AutoIncrement = false;
                colvarDescription.IsNullable = true;
                colvarDescription.IsPrimaryKey = false;
                colvarDescription.IsForeignKey = false;
                colvarDescription.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarDescription);
                
                TableSchema.TableColumn colvarPicture = new TableSchema.TableColumn(schema);
                colvarPicture.ColumnName = "Picture";
                colvarPicture.DataType = DbType.Binary;
                colvarPicture.MaxLength = 2147483647;
                colvarPicture.AutoIncrement = false;
                colvarPicture.IsNullable = true;
                colvarPicture.IsPrimaryKey = false;
                colvarPicture.IsForeignKey = false;
                colvarPicture.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarPicture);
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Categories",schema);
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
	    public Category()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public Category(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public Category(string columnName, object columnValue)
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

	      
        [XmlAttribute("CategoryName")]
        public string CategoryName 
	    {
		    get { return GetColumnValue<string>("CategoryName"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CategoryName", value);
            }

        }

	      
        [XmlAttribute("Description")]
        public string Description 
	    {
		    get { return GetColumnValue<string>("Description"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Description", value);
            }

        }

	      
        [XmlAttribute("Picture")]
        public byte[] Picture 
	    {
		    get { return GetColumnValue<byte[]>("Picture"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Picture", value);
            }

        }

	    
	    #endregion
	    
	    
	    #region PrimaryKey Methods
	    
		public Chapter08.NorthwindDAL.ProductCategoryMapCollection ProductCategoryMapRecords()
		{
			return new Chapter08.NorthwindDAL.ProductCategoryMapCollection().Where(ProductCategoryMap.Columns.CategoryID, CategoryID).Load();
		}

		public Chapter08.NorthwindDAL.ProductCollection Products()
		{
			return new Chapter08.NorthwindDAL.ProductCollection().Where(Product.Columns.CategoryID, CategoryID).Load();
		}

		#endregion
		
	 	
			
	    
	    //no foreign key tables defined (0)
	    
	    
	    
	    #region Many To Many Helpers
	    
	     
        public Chapter08.NorthwindDAL.ProductCollection GetProductCollection() {
            return Category.GetProductCollection(this.CategoryID);
        }

        public static Chapter08.NorthwindDAL.ProductCollection GetProductCollection(int varCategoryID) {
            SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
                "SELECT * FROM Products INNER JOIN Product_Category_Map ON "+
                "Products.ProductID=Product_Category_Map.ProductID WHERE Product_Category_Map.CategoryID=@CategoryID", Category.Schema.Provider.Name);
            
            cmd.AddParameter("@CategoryID", varCategoryID);
            
            IDataReader rdr = SubSonic.DataService.GetReader(cmd);
            ProductCollection coll = new ProductCollection();
            coll.LoadAndCloseReader(rdr);
            return coll;
        }

        public static void SaveProductMap(int varCategoryID, ProductCollection items) {
            
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
            QueryCommand cmdDel = new QueryCommand("DELETE FROM Product_Category_Map WHERE CategoryID=@CategoryID", Category.Schema.Provider.Name);
            cmdDel.AddParameter("@CategoryID", varCategoryID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (Product item in items)
            {
				ProductCategoryMap varProductCategoryMap = new ProductCategoryMap();
				varProductCategoryMap.SetColumnValue("CategoryID", varCategoryID);
				varProductCategoryMap.SetColumnValue("ProductID", item.GetPrimaryKeyValue());
				varProductCategoryMap.Save();
            }

        }

        public static void SaveProductMap(int varCategoryID, System.Web.UI.WebControls.ListItemCollection itemList) 
        {
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
             QueryCommand cmdDel = new QueryCommand("DELETE FROM Product_Category_Map WHERE CategoryID=@CategoryID", Category.Schema.Provider.Name);
            cmdDel.AddParameter("@CategoryID", varCategoryID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (System.Web.UI.WebControls.ListItem l in itemList) 
            {
                if (l.Selected) 
                {
					ProductCategoryMap varProductCategoryMap = new ProductCategoryMap();
					varProductCategoryMap.SetColumnValue("CategoryID", varCategoryID);
					varProductCategoryMap.SetColumnValue("ProductID", l.Value);
					varProductCategoryMap.Save();
                }

            }

        }

        public static void SaveProductMap(int varCategoryID , int[] itemList) 
        {
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
             QueryCommand cmdDel = new QueryCommand("DELETE FROM Product_Category_Map WHERE CategoryID=@CategoryID", Category.Schema.Provider.Name);
            cmdDel.AddParameter("@CategoryID", varCategoryID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (int item in itemList) 
            {
            	ProductCategoryMap varProductCategoryMap = new ProductCategoryMap();
				varProductCategoryMap.SetColumnValue("CategoryID", varCategoryID);
				varProductCategoryMap.SetColumnValue("ProductID", item);
				varProductCategoryMap.Save();
            }

        }

        
        public static void DeleteProductMap(int varCategoryID) 
        {
            QueryCommand cmdDel = new QueryCommand("DELETE FROM Product_Category_Map WHERE CategoryID=@CategoryID", Category.Schema.Provider.Name);
            cmdDel.AddParameter("@CategoryID", varCategoryID);
            DataService.ExecuteQuery(cmdDel);
		}

	    
	    #endregion
	    
	    #region ObjectDataSource support
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(string varCategoryName,string varDescription,byte[] varPicture)
	    {
		    Category item = new Category();
		    
            item.CategoryName = varCategoryName;
            
            item.Description = varDescription;
            
            item.Picture = varPicture;
            
	    
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(int varCategoryID,string varCategoryName,string varDescription,byte[] varPicture)
	    {
		    Category item = new Category();
		    
                item.CategoryID = varCategoryID;
				
                item.CategoryName = varCategoryName;
				
                item.Description = varDescription;
				
                item.Picture = varPicture;
				
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
            
            public static string CategoryName = @"CategoryName";
            
            public static string Description = @"Description";
            
            public static string Picture = @"Picture";
            
	    }

	    #endregion
    }

}

