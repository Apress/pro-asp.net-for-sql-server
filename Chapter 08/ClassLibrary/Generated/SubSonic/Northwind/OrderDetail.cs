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


//Generated on 6/10/2007 10:06:55 PM by brennan

namespace Chapter08.NorthwindDAL{
    /// <summary>
    /// Strongly-typed collection for the OrderDetail class.
    /// </summary>
    [Serializable]
    public partial class OrderDetailCollection : ActiveList<OrderDetail> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public OrderDetailCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public OrderDetailCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public OrderDetailCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public OrderDetailCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public OrderDetailCollection Where(string columnName, object value) 
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

    	
        public OrderDetailCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public OrderDetailCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public OrderDetailCollection Load() 
        {
            Query qry = new Query(OrderDetail.Schema);
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

        
        public OrderDetailCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the Order Details table.
    /// </summary>
    [Serializable]
    public partial class OrderDetail : ActiveRecord<OrderDetail>
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
				TableSchema.Table schema = new TableSchema.Table("Order Details", TableType.Table, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarOrderID = new TableSchema.TableColumn(schema);
                colvarOrderID.ColumnName = "OrderID";
                colvarOrderID.DataType = DbType.Int32;
                colvarOrderID.MaxLength = 0;
                colvarOrderID.AutoIncrement = false;
                colvarOrderID.IsNullable = false;
                colvarOrderID.IsPrimaryKey = true;
                colvarOrderID.IsForeignKey = true;
                colvarOrderID.IsReadOnly = false;
                
                
				colvarOrderID.ForeignKeyTableName = "Orders";
                
                schema.Columns.Add(colvarOrderID);
                
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
                
                TableSchema.TableColumn colvarUnitPrice = new TableSchema.TableColumn(schema);
                colvarUnitPrice.ColumnName = "UnitPrice";
                colvarUnitPrice.DataType = DbType.Currency;
                colvarUnitPrice.MaxLength = 0;
                colvarUnitPrice.AutoIncrement = false;
                colvarUnitPrice.IsNullable = false;
                colvarUnitPrice.IsPrimaryKey = false;
                colvarUnitPrice.IsForeignKey = false;
                colvarUnitPrice.IsReadOnly = false;
                
						colvarUnitPrice.DefaultSetting = @"((0))";
				
                
                schema.Columns.Add(colvarUnitPrice);
                
                TableSchema.TableColumn colvarQuantity = new TableSchema.TableColumn(schema);
                colvarQuantity.ColumnName = "Quantity";
                colvarQuantity.DataType = DbType.Int16;
                colvarQuantity.MaxLength = 0;
                colvarQuantity.AutoIncrement = false;
                colvarQuantity.IsNullable = false;
                colvarQuantity.IsPrimaryKey = false;
                colvarQuantity.IsForeignKey = false;
                colvarQuantity.IsReadOnly = false;
                
						colvarQuantity.DefaultSetting = @"((1))";
				
                
                schema.Columns.Add(colvarQuantity);
                
                TableSchema.TableColumn colvarDiscount = new TableSchema.TableColumn(schema);
                colvarDiscount.ColumnName = "Discount";
                colvarDiscount.DataType = DbType.Decimal;
                colvarDiscount.MaxLength = 0;
                colvarDiscount.AutoIncrement = false;
                colvarDiscount.IsNullable = false;
                colvarDiscount.IsPrimaryKey = false;
                colvarDiscount.IsForeignKey = false;
                colvarDiscount.IsReadOnly = false;
                
						colvarDiscount.DefaultSetting = @"((0))";
				
                
                schema.Columns.Add(colvarDiscount);
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Order Details",schema);
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
	    public OrderDetail()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public OrderDetail(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public OrderDetail(string columnName, object columnValue)
        {
            SetSQLProps();
            SetDefaults();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("OrderID")]
        public int OrderID 
	    {
		    get { return GetColumnValue<int>("OrderID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("OrderID", value);
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

	      
        [XmlAttribute("UnitPrice")]
        public decimal UnitPrice 
	    {
		    get { return GetColumnValue<decimal>("UnitPrice"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("UnitPrice", value);
            }

        }

	      
        [XmlAttribute("Quantity")]
        public short Quantity 
	    {
		    get { return GetColumnValue<short>("Quantity"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Quantity", value);
            }

        }

	      
        [XmlAttribute("Discount")]
        public decimal Discount 
	    {
		    get { return GetColumnValue<decimal>("Discount"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Discount", value);
            }

        }

	    
	    #endregion
	    
	    
	 	
			
	    
	    
	    
	    #region ForeignKey Properties
	    
        /// <summary>
        /// Returns a Order ActiveRecord object related to this OrderDetail
        /// </summary>
	    public Chapter08.NorthwindDAL.Order Order
        {
	        get { return Chapter08.NorthwindDAL.Order.FetchByID(this.OrderID); }

	        set
	        {
		        MarkDirty();
		        SetColumnValue("OrderID", value.OrderID);
	        }

        }

	    
	    
        /// <summary>
        /// Returns a Product ActiveRecord object related to this OrderDetail
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
	    public static void Insert(int varOrderID,int varProductID,decimal varUnitPrice,short varQuantity,decimal varDiscount)
	    {
		    OrderDetail item = new OrderDetail();
		    
            item.OrderID = varOrderID;
            
            item.ProductID = varProductID;
            
            item.UnitPrice = varUnitPrice;
            
            item.Quantity = varQuantity;
            
            item.Discount = varDiscount;
            
	    
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(int varOrderID,int varProductID,decimal varUnitPrice,short varQuantity,decimal varDiscount)
	    {
		    OrderDetail item = new OrderDetail();
		    
                item.OrderID = varOrderID;
				
                item.ProductID = varProductID;
				
                item.UnitPrice = varUnitPrice;
				
                item.Quantity = varQuantity;
				
                item.Discount = varDiscount;
				
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
		    
		    
            public static string OrderID = @"OrderID";
            
            public static string ProductID = @"ProductID";
            
            public static string UnitPrice = @"UnitPrice";
            
            public static string Quantity = @"Quantity";
            
            public static string Discount = @"Discount";
            
	    }

	    #endregion
    }

}

