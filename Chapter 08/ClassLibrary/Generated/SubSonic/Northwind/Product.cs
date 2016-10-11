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
    /// Strongly-typed collection for the Product class.
    /// </summary>
    [Serializable]
    public partial class ProductCollection : ActiveList<Product> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public ProductCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public ProductCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public ProductCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public ProductCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public ProductCollection Where(string columnName, object value) 
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

    	
        public ProductCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public ProductCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public ProductCollection Load() 
        {
            Query qry = new Query(Product.Schema);
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

        
        public ProductCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the Products table.
    /// </summary>
    [Serializable]
    public partial class Product : ActiveRecord<Product>
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
				TableSchema.Table schema = new TableSchema.Table("Products", TableType.Table, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarProductID = new TableSchema.TableColumn(schema);
                colvarProductID.ColumnName = "ProductID";
                colvarProductID.DataType = DbType.Int32;
                colvarProductID.MaxLength = 0;
                colvarProductID.AutoIncrement = true;
                colvarProductID.IsNullable = false;
                colvarProductID.IsPrimaryKey = true;
                colvarProductID.IsForeignKey = false;
                colvarProductID.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarProductID);
                
                TableSchema.TableColumn colvarProductName = new TableSchema.TableColumn(schema);
                colvarProductName.ColumnName = "ProductName";
                colvarProductName.DataType = DbType.String;
                colvarProductName.MaxLength = 40;
                colvarProductName.AutoIncrement = false;
                colvarProductName.IsNullable = false;
                colvarProductName.IsPrimaryKey = false;
                colvarProductName.IsForeignKey = false;
                colvarProductName.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarProductName);
                
                TableSchema.TableColumn colvarSupplierID = new TableSchema.TableColumn(schema);
                colvarSupplierID.ColumnName = "SupplierID";
                colvarSupplierID.DataType = DbType.Int32;
                colvarSupplierID.MaxLength = 0;
                colvarSupplierID.AutoIncrement = false;
                colvarSupplierID.IsNullable = true;
                colvarSupplierID.IsPrimaryKey = false;
                colvarSupplierID.IsForeignKey = true;
                colvarSupplierID.IsReadOnly = false;
                
                
				colvarSupplierID.ForeignKeyTableName = "Suppliers";
                
                schema.Columns.Add(colvarSupplierID);
                
                TableSchema.TableColumn colvarCategoryID = new TableSchema.TableColumn(schema);
                colvarCategoryID.ColumnName = "CategoryID";
                colvarCategoryID.DataType = DbType.Int32;
                colvarCategoryID.MaxLength = 0;
                colvarCategoryID.AutoIncrement = false;
                colvarCategoryID.IsNullable = true;
                colvarCategoryID.IsPrimaryKey = false;
                colvarCategoryID.IsForeignKey = true;
                colvarCategoryID.IsReadOnly = false;
                
                
				colvarCategoryID.ForeignKeyTableName = "Categories";
                
                schema.Columns.Add(colvarCategoryID);
                
                TableSchema.TableColumn colvarQuantityPerUnit = new TableSchema.TableColumn(schema);
                colvarQuantityPerUnit.ColumnName = "QuantityPerUnit";
                colvarQuantityPerUnit.DataType = DbType.String;
                colvarQuantityPerUnit.MaxLength = 20;
                colvarQuantityPerUnit.AutoIncrement = false;
                colvarQuantityPerUnit.IsNullable = true;
                colvarQuantityPerUnit.IsPrimaryKey = false;
                colvarQuantityPerUnit.IsForeignKey = false;
                colvarQuantityPerUnit.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarQuantityPerUnit);
                
                TableSchema.TableColumn colvarUnitPrice = new TableSchema.TableColumn(schema);
                colvarUnitPrice.ColumnName = "UnitPrice";
                colvarUnitPrice.DataType = DbType.Currency;
                colvarUnitPrice.MaxLength = 0;
                colvarUnitPrice.AutoIncrement = false;
                colvarUnitPrice.IsNullable = true;
                colvarUnitPrice.IsPrimaryKey = false;
                colvarUnitPrice.IsForeignKey = false;
                colvarUnitPrice.IsReadOnly = false;
                
						colvarUnitPrice.DefaultSetting = @"((0))";
				
                
                schema.Columns.Add(colvarUnitPrice);
                
                TableSchema.TableColumn colvarUnitsInStock = new TableSchema.TableColumn(schema);
                colvarUnitsInStock.ColumnName = "UnitsInStock";
                colvarUnitsInStock.DataType = DbType.Int16;
                colvarUnitsInStock.MaxLength = 0;
                colvarUnitsInStock.AutoIncrement = false;
                colvarUnitsInStock.IsNullable = true;
                colvarUnitsInStock.IsPrimaryKey = false;
                colvarUnitsInStock.IsForeignKey = false;
                colvarUnitsInStock.IsReadOnly = false;
                
						colvarUnitsInStock.DefaultSetting = @"((0))";
				
                
                schema.Columns.Add(colvarUnitsInStock);
                
                TableSchema.TableColumn colvarUnitsOnOrder = new TableSchema.TableColumn(schema);
                colvarUnitsOnOrder.ColumnName = "UnitsOnOrder";
                colvarUnitsOnOrder.DataType = DbType.Int16;
                colvarUnitsOnOrder.MaxLength = 0;
                colvarUnitsOnOrder.AutoIncrement = false;
                colvarUnitsOnOrder.IsNullable = true;
                colvarUnitsOnOrder.IsPrimaryKey = false;
                colvarUnitsOnOrder.IsForeignKey = false;
                colvarUnitsOnOrder.IsReadOnly = false;
                
						colvarUnitsOnOrder.DefaultSetting = @"((0))";
				
                
                schema.Columns.Add(colvarUnitsOnOrder);
                
                TableSchema.TableColumn colvarReorderLevel = new TableSchema.TableColumn(schema);
                colvarReorderLevel.ColumnName = "ReorderLevel";
                colvarReorderLevel.DataType = DbType.Int16;
                colvarReorderLevel.MaxLength = 0;
                colvarReorderLevel.AutoIncrement = false;
                colvarReorderLevel.IsNullable = true;
                colvarReorderLevel.IsPrimaryKey = false;
                colvarReorderLevel.IsForeignKey = false;
                colvarReorderLevel.IsReadOnly = false;
                
						colvarReorderLevel.DefaultSetting = @"((0))";
				
                
                schema.Columns.Add(colvarReorderLevel);
                
                TableSchema.TableColumn colvarDiscontinued = new TableSchema.TableColumn(schema);
                colvarDiscontinued.ColumnName = "Discontinued";
                colvarDiscontinued.DataType = DbType.Boolean;
                colvarDiscontinued.MaxLength = 0;
                colvarDiscontinued.AutoIncrement = false;
                colvarDiscontinued.IsNullable = false;
                colvarDiscontinued.IsPrimaryKey = false;
                colvarDiscontinued.IsForeignKey = false;
                colvarDiscontinued.IsReadOnly = false;
                
						colvarDiscontinued.DefaultSetting = @"((0))";
				
                
                schema.Columns.Add(colvarDiscontinued);
                
                TableSchema.TableColumn colvarAttributeXML = new TableSchema.TableColumn(schema);
                colvarAttributeXML.ColumnName = "AttributeXML";
                colvarAttributeXML.DataType = DbType.String;
                colvarAttributeXML.MaxLength = -1;
                colvarAttributeXML.AutoIncrement = false;
                colvarAttributeXML.IsNullable = true;
                colvarAttributeXML.IsPrimaryKey = false;
                colvarAttributeXML.IsForeignKey = false;
                colvarAttributeXML.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarAttributeXML);
                
                TableSchema.TableColumn colvarDateCreated = new TableSchema.TableColumn(schema);
                colvarDateCreated.ColumnName = "DateCreated";
                colvarDateCreated.DataType = DbType.DateTime;
                colvarDateCreated.MaxLength = 0;
                colvarDateCreated.AutoIncrement = false;
                colvarDateCreated.IsNullable = true;
                colvarDateCreated.IsPrimaryKey = false;
                colvarDateCreated.IsForeignKey = false;
                colvarDateCreated.IsReadOnly = false;
                
						colvarDateCreated.DefaultSetting = @"(getdate())";
				
                
                schema.Columns.Add(colvarDateCreated);
                
                TableSchema.TableColumn colvarProductGUID = new TableSchema.TableColumn(schema);
                colvarProductGUID.ColumnName = "ProductGUID";
                colvarProductGUID.DataType = DbType.Guid;
                colvarProductGUID.MaxLength = 0;
                colvarProductGUID.AutoIncrement = false;
                colvarProductGUID.IsNullable = true;
                colvarProductGUID.IsPrimaryKey = false;
                colvarProductGUID.IsForeignKey = false;
                colvarProductGUID.IsReadOnly = false;
                
						colvarProductGUID.DefaultSetting = @"(newid())";
				
                
                schema.Columns.Add(colvarProductGUID);
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Products",schema);
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
	    public Product()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public Product(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public Product(string columnName, object columnValue)
        {
            SetSQLProps();
            SetDefaults();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
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

	      
        [XmlAttribute("ProductName")]
        public string ProductName 
	    {
		    get { return GetColumnValue<string>("ProductName"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ProductName", value);
            }

        }

	      
        [XmlAttribute("SupplierID")]
        public int? SupplierID 
	    {
		    get { return GetColumnValue<int?>("SupplierID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("SupplierID", value);
            }

        }

	      
        [XmlAttribute("CategoryID")]
        public int? CategoryID 
	    {
		    get { return GetColumnValue<int?>("CategoryID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CategoryID", value);
            }

        }

	      
        [XmlAttribute("QuantityPerUnit")]
        public string QuantityPerUnit 
	    {
		    get { return GetColumnValue<string>("QuantityPerUnit"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("QuantityPerUnit", value);
            }

        }

	      
        [XmlAttribute("UnitPrice")]
        public decimal? UnitPrice 
	    {
		    get { return GetColumnValue<decimal?>("UnitPrice"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("UnitPrice", value);
            }

        }

	      
        [XmlAttribute("UnitsInStock")]
        public short? UnitsInStock 
	    {
		    get { return GetColumnValue<short?>("UnitsInStock"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("UnitsInStock", value);
            }

        }

	      
        [XmlAttribute("UnitsOnOrder")]
        public short? UnitsOnOrder 
	    {
		    get { return GetColumnValue<short?>("UnitsOnOrder"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("UnitsOnOrder", value);
            }

        }

	      
        [XmlAttribute("ReorderLevel")]
        public short? ReorderLevel 
	    {
		    get { return GetColumnValue<short?>("ReorderLevel"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ReorderLevel", value);
            }

        }

	      
        [XmlAttribute("Discontinued")]
        public bool Discontinued 
	    {
		    get { return GetColumnValue<bool>("Discontinued"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Discontinued", value);
            }

        }

	      
        [XmlAttribute("AttributeXML")]
        public string AttributeXML 
	    {
		    get { return GetColumnValue<string>("AttributeXML"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("AttributeXML", value);
            }

        }

	      
        [XmlAttribute("DateCreated")]
        public DateTime? DateCreated 
	    {
		    get { return GetColumnValue<DateTime?>("DateCreated"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("DateCreated", value);
            }

        }

	      
        [XmlAttribute("ProductGUID")]
        public Guid? ProductGUID 
	    {
		    get { return GetColumnValue<Guid?>("ProductGUID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ProductGUID", value);
            }

        }

	    
	    #endregion
	    
	    
	    #region PrimaryKey Methods
	    
		public Chapter08.NorthwindDAL.OrderDetailCollection OrderDetails()
		{
			return new Chapter08.NorthwindDAL.OrderDetailCollection().Where(OrderDetail.Columns.ProductID, ProductID).Load();
		}

		public Chapter08.NorthwindDAL.ProductCategoryMapCollection ProductCategoryMapRecords()
		{
			return new Chapter08.NorthwindDAL.ProductCategoryMapCollection().Where(ProductCategoryMap.Columns.ProductID, ProductID).Load();
		}

		#endregion
		
	 	
			
	    
	    
	    
	    #region ForeignKey Properties
	    
        /// <summary>
        /// Returns a Category ActiveRecord object related to this Product
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
        /// Returns a Supplier ActiveRecord object related to this Product
        /// </summary>
	    public Chapter08.NorthwindDAL.Supplier Supplier
        {
	        get { return Chapter08.NorthwindDAL.Supplier.FetchByID(this.SupplierID); }

	        set
	        {
		        MarkDirty();
		        SetColumnValue("SupplierID", value.SupplierID);
	        }

        }

	    
	    
	    #endregion
	    
	    
	    
	    #region Many To Many Helpers
	    
	     
        public Chapter08.NorthwindDAL.OrderCollection GetOrderCollection() {
            return Product.GetOrderCollection(this.ProductID);
        }

        public static Chapter08.NorthwindDAL.OrderCollection GetOrderCollection(int varProductID) {
            SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
                "SELECT * FROM Orders INNER JOIN Order Details ON "+
                "Orders.OrderID=Order Details.OrderID WHERE Order Details.ProductID=@ProductID", Product.Schema.Provider.Name);
            
            cmd.AddParameter("@ProductID", varProductID);
            
            IDataReader rdr = SubSonic.DataService.GetReader(cmd);
            OrderCollection coll = new OrderCollection();
            coll.LoadAndCloseReader(rdr);
            return coll;
        }

        public static void SaveOrderMap(int varProductID, OrderCollection items) {
            
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
            QueryCommand cmdDel = new QueryCommand("DELETE FROM Order Details WHERE ProductID=@ProductID", Product.Schema.Provider.Name);
            cmdDel.AddParameter("@ProductID", varProductID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (Order item in items)
            {
				OrderDetail varOrderDetail = new OrderDetail();
				varOrderDetail.SetColumnValue("ProductID", varProductID);
				varOrderDetail.SetColumnValue("OrderID", item.GetPrimaryKeyValue());
				varOrderDetail.Save();
            }

        }

        public static void SaveOrderMap(int varProductID, System.Web.UI.WebControls.ListItemCollection itemList) 
        {
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
             QueryCommand cmdDel = new QueryCommand("DELETE FROM Order Details WHERE ProductID=@ProductID", Product.Schema.Provider.Name);
            cmdDel.AddParameter("@ProductID", varProductID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (System.Web.UI.WebControls.ListItem l in itemList) 
            {
                if (l.Selected) 
                {
					OrderDetail varOrderDetail = new OrderDetail();
					varOrderDetail.SetColumnValue("ProductID", varProductID);
					varOrderDetail.SetColumnValue("OrderID", l.Value);
					varOrderDetail.Save();
                }

            }

        }

        public static void SaveOrderMap(int varProductID , int[] itemList) 
        {
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
             QueryCommand cmdDel = new QueryCommand("DELETE FROM Order Details WHERE ProductID=@ProductID", Product.Schema.Provider.Name);
            cmdDel.AddParameter("@ProductID", varProductID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (int item in itemList) 
            {
            	OrderDetail varOrderDetail = new OrderDetail();
				varOrderDetail.SetColumnValue("ProductID", varProductID);
				varOrderDetail.SetColumnValue("OrderID", item);
				varOrderDetail.Save();
            }

        }

        
        public static void DeleteOrderMap(int varProductID) 
        {
            QueryCommand cmdDel = new QueryCommand("DELETE FROM Order Details WHERE ProductID=@ProductID", Product.Schema.Provider.Name);
            cmdDel.AddParameter("@ProductID", varProductID);
            DataService.ExecuteQuery(cmdDel);
		}

	    
	     
        public Chapter08.NorthwindDAL.CategoryCollection GetCategoryCollection() {
            return Product.GetCategoryCollection(this.ProductID);
        }

        public static Chapter08.NorthwindDAL.CategoryCollection GetCategoryCollection(int varProductID) {
            SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
                "SELECT * FROM Categories INNER JOIN Product_Category_Map ON "+
                "Categories.CategoryID=Product_Category_Map.CategoryID WHERE Product_Category_Map.ProductID=@ProductID", Product.Schema.Provider.Name);
            
            cmd.AddParameter("@ProductID", varProductID);
            
            IDataReader rdr = SubSonic.DataService.GetReader(cmd);
            CategoryCollection coll = new CategoryCollection();
            coll.LoadAndCloseReader(rdr);
            return coll;
        }

        public static void SaveCategoryMap(int varProductID, CategoryCollection items) {
            
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
            QueryCommand cmdDel = new QueryCommand("DELETE FROM Product_Category_Map WHERE ProductID=@ProductID", Product.Schema.Provider.Name);
            cmdDel.AddParameter("@ProductID", varProductID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (Category item in items)
            {
				ProductCategoryMap varProductCategoryMap = new ProductCategoryMap();
				varProductCategoryMap.SetColumnValue("ProductID", varProductID);
				varProductCategoryMap.SetColumnValue("CategoryID", item.GetPrimaryKeyValue());
				varProductCategoryMap.Save();
            }

        }

        public static void SaveCategoryMap(int varProductID, System.Web.UI.WebControls.ListItemCollection itemList) 
        {
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
             QueryCommand cmdDel = new QueryCommand("DELETE FROM Product_Category_Map WHERE ProductID=@ProductID", Product.Schema.Provider.Name);
            cmdDel.AddParameter("@ProductID", varProductID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (System.Web.UI.WebControls.ListItem l in itemList) 
            {
                if (l.Selected) 
                {
					ProductCategoryMap varProductCategoryMap = new ProductCategoryMap();
					varProductCategoryMap.SetColumnValue("ProductID", varProductID);
					varProductCategoryMap.SetColumnValue("CategoryID", l.Value);
					varProductCategoryMap.Save();
                }

            }

        }

        public static void SaveCategoryMap(int varProductID , int[] itemList) 
        {
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
             QueryCommand cmdDel = new QueryCommand("DELETE FROM Product_Category_Map WHERE ProductID=@ProductID", Product.Schema.Provider.Name);
            cmdDel.AddParameter("@ProductID", varProductID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (int item in itemList) 
            {
            	ProductCategoryMap varProductCategoryMap = new ProductCategoryMap();
				varProductCategoryMap.SetColumnValue("ProductID", varProductID);
				varProductCategoryMap.SetColumnValue("CategoryID", item);
				varProductCategoryMap.Save();
            }

        }

        
        public static void DeleteCategoryMap(int varProductID) 
        {
            QueryCommand cmdDel = new QueryCommand("DELETE FROM Product_Category_Map WHERE ProductID=@ProductID", Product.Schema.Provider.Name);
            cmdDel.AddParameter("@ProductID", varProductID);
            DataService.ExecuteQuery(cmdDel);
		}

	    
	    #endregion
	    
	    #region ObjectDataSource support
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(string varProductName,int? varSupplierID,int? varCategoryID,string varQuantityPerUnit,decimal? varUnitPrice,short? varUnitsInStock,short? varUnitsOnOrder,short? varReorderLevel,bool varDiscontinued,string varAttributeXML,DateTime? varDateCreated,Guid? varProductGUID)
	    {
		    Product item = new Product();
		    
            item.ProductName = varProductName;
            
            item.SupplierID = varSupplierID;
            
            item.CategoryID = varCategoryID;
            
            item.QuantityPerUnit = varQuantityPerUnit;
            
            item.UnitPrice = varUnitPrice;
            
            item.UnitsInStock = varUnitsInStock;
            
            item.UnitsOnOrder = varUnitsOnOrder;
            
            item.ReorderLevel = varReorderLevel;
            
            item.Discontinued = varDiscontinued;
            
            item.AttributeXML = varAttributeXML;
            
            item.DateCreated = varDateCreated;
            
            item.ProductGUID = varProductGUID;
            
	    
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(int varProductID,string varProductName,int? varSupplierID,int? varCategoryID,string varQuantityPerUnit,decimal? varUnitPrice,short? varUnitsInStock,short? varUnitsOnOrder,short? varReorderLevel,bool varDiscontinued,string varAttributeXML,DateTime? varDateCreated,Guid? varProductGUID)
	    {
		    Product item = new Product();
		    
                item.ProductID = varProductID;
				
                item.ProductName = varProductName;
				
                item.SupplierID = varSupplierID;
				
                item.CategoryID = varCategoryID;
				
                item.QuantityPerUnit = varQuantityPerUnit;
				
                item.UnitPrice = varUnitPrice;
				
                item.UnitsInStock = varUnitsInStock;
				
                item.UnitsOnOrder = varUnitsOnOrder;
				
                item.ReorderLevel = varReorderLevel;
				
                item.Discontinued = varDiscontinued;
				
                item.AttributeXML = varAttributeXML;
				
                item.DateCreated = varDateCreated;
				
                item.ProductGUID = varProductGUID;
				
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
		    
		    
            public static string ProductID = @"ProductID";
            
            public static string ProductName = @"ProductName";
            
            public static string SupplierID = @"SupplierID";
            
            public static string CategoryID = @"CategoryID";
            
            public static string QuantityPerUnit = @"QuantityPerUnit";
            
            public static string UnitPrice = @"UnitPrice";
            
            public static string UnitsInStock = @"UnitsInStock";
            
            public static string UnitsOnOrder = @"UnitsOnOrder";
            
            public static string ReorderLevel = @"ReorderLevel";
            
            public static string Discontinued = @"Discontinued";
            
            public static string AttributeXML = @"AttributeXML";
            
            public static string DateCreated = @"DateCreated";
            
            public static string ProductGUID = @"ProductGUID";
            
	    }

	    #endregion
    }

}

