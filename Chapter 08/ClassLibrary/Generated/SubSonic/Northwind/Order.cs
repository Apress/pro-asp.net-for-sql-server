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


//Generated on 6/10/2007 10:06:56 PM by brennan

namespace Chapter08.NorthwindDAL{
    /// <summary>
    /// Strongly-typed collection for the Order class.
    /// </summary>
    [Serializable]
    public partial class OrderCollection : ActiveList<Order> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public OrderCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public OrderCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public OrderCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public OrderCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public OrderCollection Where(string columnName, object value) 
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

    	
        public OrderCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public OrderCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public OrderCollection Load() 
        {
            Query qry = new Query(Order.Schema);
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

        
        public OrderCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the Orders table.
    /// </summary>
    [Serializable]
    public partial class Order : ActiveRecord<Order>
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
				TableSchema.Table schema = new TableSchema.Table("Orders", TableType.Table, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarOrderID = new TableSchema.TableColumn(schema);
                colvarOrderID.ColumnName = "OrderID";
                colvarOrderID.DataType = DbType.Int32;
                colvarOrderID.MaxLength = 0;
                colvarOrderID.AutoIncrement = true;
                colvarOrderID.IsNullable = false;
                colvarOrderID.IsPrimaryKey = true;
                colvarOrderID.IsForeignKey = false;
                colvarOrderID.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarOrderID);
                
                TableSchema.TableColumn colvarCustomerID = new TableSchema.TableColumn(schema);
                colvarCustomerID.ColumnName = "CustomerID";
                colvarCustomerID.DataType = DbType.String;
                colvarCustomerID.MaxLength = 5;
                colvarCustomerID.AutoIncrement = false;
                colvarCustomerID.IsNullable = true;
                colvarCustomerID.IsPrimaryKey = false;
                colvarCustomerID.IsForeignKey = true;
                colvarCustomerID.IsReadOnly = false;
                
                
				colvarCustomerID.ForeignKeyTableName = "Customers";
                
                schema.Columns.Add(colvarCustomerID);
                
                TableSchema.TableColumn colvarEmployeeID = new TableSchema.TableColumn(schema);
                colvarEmployeeID.ColumnName = "EmployeeID";
                colvarEmployeeID.DataType = DbType.Int32;
                colvarEmployeeID.MaxLength = 0;
                colvarEmployeeID.AutoIncrement = false;
                colvarEmployeeID.IsNullable = true;
                colvarEmployeeID.IsPrimaryKey = false;
                colvarEmployeeID.IsForeignKey = true;
                colvarEmployeeID.IsReadOnly = false;
                
                
				colvarEmployeeID.ForeignKeyTableName = "Employees";
                
                schema.Columns.Add(colvarEmployeeID);
                
                TableSchema.TableColumn colvarOrderDate = new TableSchema.TableColumn(schema);
                colvarOrderDate.ColumnName = "OrderDate";
                colvarOrderDate.DataType = DbType.DateTime;
                colvarOrderDate.MaxLength = 0;
                colvarOrderDate.AutoIncrement = false;
                colvarOrderDate.IsNullable = true;
                colvarOrderDate.IsPrimaryKey = false;
                colvarOrderDate.IsForeignKey = false;
                colvarOrderDate.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarOrderDate);
                
                TableSchema.TableColumn colvarRequiredDate = new TableSchema.TableColumn(schema);
                colvarRequiredDate.ColumnName = "RequiredDate";
                colvarRequiredDate.DataType = DbType.DateTime;
                colvarRequiredDate.MaxLength = 0;
                colvarRequiredDate.AutoIncrement = false;
                colvarRequiredDate.IsNullable = true;
                colvarRequiredDate.IsPrimaryKey = false;
                colvarRequiredDate.IsForeignKey = false;
                colvarRequiredDate.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarRequiredDate);
                
                TableSchema.TableColumn colvarShippedDate = new TableSchema.TableColumn(schema);
                colvarShippedDate.ColumnName = "ShippedDate";
                colvarShippedDate.DataType = DbType.DateTime;
                colvarShippedDate.MaxLength = 0;
                colvarShippedDate.AutoIncrement = false;
                colvarShippedDate.IsNullable = true;
                colvarShippedDate.IsPrimaryKey = false;
                colvarShippedDate.IsForeignKey = false;
                colvarShippedDate.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarShippedDate);
                
                TableSchema.TableColumn colvarShipVia = new TableSchema.TableColumn(schema);
                colvarShipVia.ColumnName = "ShipVia";
                colvarShipVia.DataType = DbType.Int32;
                colvarShipVia.MaxLength = 0;
                colvarShipVia.AutoIncrement = false;
                colvarShipVia.IsNullable = true;
                colvarShipVia.IsPrimaryKey = false;
                colvarShipVia.IsForeignKey = true;
                colvarShipVia.IsReadOnly = false;
                
                
				colvarShipVia.ForeignKeyTableName = "Shippers";
                
                schema.Columns.Add(colvarShipVia);
                
                TableSchema.TableColumn colvarFreight = new TableSchema.TableColumn(schema);
                colvarFreight.ColumnName = "Freight";
                colvarFreight.DataType = DbType.Currency;
                colvarFreight.MaxLength = 0;
                colvarFreight.AutoIncrement = false;
                colvarFreight.IsNullable = true;
                colvarFreight.IsPrimaryKey = false;
                colvarFreight.IsForeignKey = false;
                colvarFreight.IsReadOnly = false;
                
						colvarFreight.DefaultSetting = @"((0))";
				
                
                schema.Columns.Add(colvarFreight);
                
                TableSchema.TableColumn colvarShipName = new TableSchema.TableColumn(schema);
                colvarShipName.ColumnName = "ShipName";
                colvarShipName.DataType = DbType.String;
                colvarShipName.MaxLength = 40;
                colvarShipName.AutoIncrement = false;
                colvarShipName.IsNullable = true;
                colvarShipName.IsPrimaryKey = false;
                colvarShipName.IsForeignKey = false;
                colvarShipName.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarShipName);
                
                TableSchema.TableColumn colvarShipAddress = new TableSchema.TableColumn(schema);
                colvarShipAddress.ColumnName = "ShipAddress";
                colvarShipAddress.DataType = DbType.String;
                colvarShipAddress.MaxLength = 60;
                colvarShipAddress.AutoIncrement = false;
                colvarShipAddress.IsNullable = true;
                colvarShipAddress.IsPrimaryKey = false;
                colvarShipAddress.IsForeignKey = false;
                colvarShipAddress.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarShipAddress);
                
                TableSchema.TableColumn colvarShipCity = new TableSchema.TableColumn(schema);
                colvarShipCity.ColumnName = "ShipCity";
                colvarShipCity.DataType = DbType.String;
                colvarShipCity.MaxLength = 15;
                colvarShipCity.AutoIncrement = false;
                colvarShipCity.IsNullable = true;
                colvarShipCity.IsPrimaryKey = false;
                colvarShipCity.IsForeignKey = false;
                colvarShipCity.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarShipCity);
                
                TableSchema.TableColumn colvarShipRegion = new TableSchema.TableColumn(schema);
                colvarShipRegion.ColumnName = "ShipRegion";
                colvarShipRegion.DataType = DbType.String;
                colvarShipRegion.MaxLength = 15;
                colvarShipRegion.AutoIncrement = false;
                colvarShipRegion.IsNullable = true;
                colvarShipRegion.IsPrimaryKey = false;
                colvarShipRegion.IsForeignKey = false;
                colvarShipRegion.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarShipRegion);
                
                TableSchema.TableColumn colvarShipPostalCode = new TableSchema.TableColumn(schema);
                colvarShipPostalCode.ColumnName = "ShipPostalCode";
                colvarShipPostalCode.DataType = DbType.String;
                colvarShipPostalCode.MaxLength = 10;
                colvarShipPostalCode.AutoIncrement = false;
                colvarShipPostalCode.IsNullable = true;
                colvarShipPostalCode.IsPrimaryKey = false;
                colvarShipPostalCode.IsForeignKey = false;
                colvarShipPostalCode.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarShipPostalCode);
                
                TableSchema.TableColumn colvarShipCountry = new TableSchema.TableColumn(schema);
                colvarShipCountry.ColumnName = "ShipCountry";
                colvarShipCountry.DataType = DbType.String;
                colvarShipCountry.MaxLength = 15;
                colvarShipCountry.AutoIncrement = false;
                colvarShipCountry.IsNullable = true;
                colvarShipCountry.IsPrimaryKey = false;
                colvarShipCountry.IsForeignKey = false;
                colvarShipCountry.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarShipCountry);
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Orders",schema);
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
	    public Order()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public Order(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public Order(string columnName, object columnValue)
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

	      
        [XmlAttribute("EmployeeID")]
        public int? EmployeeID 
	    {
		    get { return GetColumnValue<int?>("EmployeeID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("EmployeeID", value);
            }

        }

	      
        [XmlAttribute("OrderDate")]
        public DateTime? OrderDate 
	    {
		    get { return GetColumnValue<DateTime?>("OrderDate"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("OrderDate", value);
            }

        }

	      
        [XmlAttribute("RequiredDate")]
        public DateTime? RequiredDate 
	    {
		    get { return GetColumnValue<DateTime?>("RequiredDate"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("RequiredDate", value);
            }

        }

	      
        [XmlAttribute("ShippedDate")]
        public DateTime? ShippedDate 
	    {
		    get { return GetColumnValue<DateTime?>("ShippedDate"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShippedDate", value);
            }

        }

	      
        [XmlAttribute("ShipVia")]
        public int? ShipVia 
	    {
		    get { return GetColumnValue<int?>("ShipVia"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShipVia", value);
            }

        }

	      
        [XmlAttribute("Freight")]
        public decimal? Freight 
	    {
		    get { return GetColumnValue<decimal?>("Freight"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Freight", value);
            }

        }

	      
        [XmlAttribute("ShipName")]
        public string ShipName 
	    {
		    get { return GetColumnValue<string>("ShipName"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShipName", value);
            }

        }

	      
        [XmlAttribute("ShipAddress")]
        public string ShipAddress 
	    {
		    get { return GetColumnValue<string>("ShipAddress"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShipAddress", value);
            }

        }

	      
        [XmlAttribute("ShipCity")]
        public string ShipCity 
	    {
		    get { return GetColumnValue<string>("ShipCity"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShipCity", value);
            }

        }

	      
        [XmlAttribute("ShipRegion")]
        public string ShipRegion 
	    {
		    get { return GetColumnValue<string>("ShipRegion"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShipRegion", value);
            }

        }

	      
        [XmlAttribute("ShipPostalCode")]
        public string ShipPostalCode 
	    {
		    get { return GetColumnValue<string>("ShipPostalCode"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShipPostalCode", value);
            }

        }

	      
        [XmlAttribute("ShipCountry")]
        public string ShipCountry 
	    {
		    get { return GetColumnValue<string>("ShipCountry"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShipCountry", value);
            }

        }

	    
	    #endregion
	    
	    
	    #region PrimaryKey Methods
	    
		public Chapter08.NorthwindDAL.OrderDetailCollection OrderDetails()
		{
			return new Chapter08.NorthwindDAL.OrderDetailCollection().Where(OrderDetail.Columns.OrderID, OrderID).Load();
		}

		#endregion
		
	 	
			
	    
	    
	    
	    #region ForeignKey Properties
	    
        /// <summary>
        /// Returns a Customer ActiveRecord object related to this Order
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

	    
	    
        /// <summary>
        /// Returns a Employee ActiveRecord object related to this Order
        /// </summary>
	    public Chapter08.NorthwindDAL.Employee Employee
        {
	        get { return Chapter08.NorthwindDAL.Employee.FetchByID(this.EmployeeID); }

	        set
	        {
		        MarkDirty();
		        SetColumnValue("EmployeeID", value.EmployeeID);
	        }

        }

	    
	    
        /// <summary>
        /// Returns a Shipper ActiveRecord object related to this Order
        /// </summary>
	    public Chapter08.NorthwindDAL.Shipper Shipper
        {
	        get { return Chapter08.NorthwindDAL.Shipper.FetchByID(this.ShipVia); }

	        set
	        {
		        MarkDirty();
		        SetColumnValue("ShipVia", value.ShipperID);
	        }

        }

	    
	    
	    #endregion
	    
	    
	    
	    #region Many To Many Helpers
	    
	     
        public Chapter08.NorthwindDAL.ProductCollection GetProductCollection() {
            return Order.GetProductCollection(this.OrderID);
        }

        public static Chapter08.NorthwindDAL.ProductCollection GetProductCollection(int varOrderID) {
            SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
                "SELECT * FROM Products INNER JOIN Order Details ON "+
                "Products.ProductID=Order Details.ProductID WHERE Order Details.OrderID=@OrderID", Order.Schema.Provider.Name);
            
            cmd.AddParameter("@OrderID", varOrderID);
            
            IDataReader rdr = SubSonic.DataService.GetReader(cmd);
            ProductCollection coll = new ProductCollection();
            coll.LoadAndCloseReader(rdr);
            return coll;
        }

        public static void SaveProductMap(int varOrderID, ProductCollection items) {
            
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
            QueryCommand cmdDel = new QueryCommand("DELETE FROM Order Details WHERE OrderID=@OrderID", Order.Schema.Provider.Name);
            cmdDel.AddParameter("@OrderID", varOrderID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (Product item in items)
            {
				OrderDetail varOrderDetail = new OrderDetail();
				varOrderDetail.SetColumnValue("OrderID", varOrderID);
				varOrderDetail.SetColumnValue("ProductID", item.GetPrimaryKeyValue());
				varOrderDetail.Save();
            }

        }

        public static void SaveProductMap(int varOrderID, System.Web.UI.WebControls.ListItemCollection itemList) 
        {
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
             QueryCommand cmdDel = new QueryCommand("DELETE FROM Order Details WHERE OrderID=@OrderID", Order.Schema.Provider.Name);
            cmdDel.AddParameter("@OrderID", varOrderID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (System.Web.UI.WebControls.ListItem l in itemList) 
            {
                if (l.Selected) 
                {
					OrderDetail varOrderDetail = new OrderDetail();
					varOrderDetail.SetColumnValue("OrderID", varOrderID);
					varOrderDetail.SetColumnValue("ProductID", l.Value);
					varOrderDetail.Save();
                }

            }

        }

        public static void SaveProductMap(int varOrderID , int[] itemList) 
        {
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
             QueryCommand cmdDel = new QueryCommand("DELETE FROM Order Details WHERE OrderID=@OrderID", Order.Schema.Provider.Name);
            cmdDel.AddParameter("@OrderID", varOrderID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (int item in itemList) 
            {
            	OrderDetail varOrderDetail = new OrderDetail();
				varOrderDetail.SetColumnValue("OrderID", varOrderID);
				varOrderDetail.SetColumnValue("ProductID", item);
				varOrderDetail.Save();
            }

        }

        
        public static void DeleteProductMap(int varOrderID) 
        {
            QueryCommand cmdDel = new QueryCommand("DELETE FROM Order Details WHERE OrderID=@OrderID", Order.Schema.Provider.Name);
            cmdDel.AddParameter("@OrderID", varOrderID);
            DataService.ExecuteQuery(cmdDel);
		}

	    
	    #endregion
	    
	    #region ObjectDataSource support
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(string varCustomerID,int? varEmployeeID,DateTime? varOrderDate,DateTime? varRequiredDate,DateTime? varShippedDate,int? varShipVia,decimal? varFreight,string varShipName,string varShipAddress,string varShipCity,string varShipRegion,string varShipPostalCode,string varShipCountry)
	    {
		    Order item = new Order();
		    
            item.CustomerID = varCustomerID;
            
            item.EmployeeID = varEmployeeID;
            
            item.OrderDate = varOrderDate;
            
            item.RequiredDate = varRequiredDate;
            
            item.ShippedDate = varShippedDate;
            
            item.ShipVia = varShipVia;
            
            item.Freight = varFreight;
            
            item.ShipName = varShipName;
            
            item.ShipAddress = varShipAddress;
            
            item.ShipCity = varShipCity;
            
            item.ShipRegion = varShipRegion;
            
            item.ShipPostalCode = varShipPostalCode;
            
            item.ShipCountry = varShipCountry;
            
	    
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(int varOrderID,string varCustomerID,int? varEmployeeID,DateTime? varOrderDate,DateTime? varRequiredDate,DateTime? varShippedDate,int? varShipVia,decimal? varFreight,string varShipName,string varShipAddress,string varShipCity,string varShipRegion,string varShipPostalCode,string varShipCountry)
	    {
		    Order item = new Order();
		    
                item.OrderID = varOrderID;
				
                item.CustomerID = varCustomerID;
				
                item.EmployeeID = varEmployeeID;
				
                item.OrderDate = varOrderDate;
				
                item.RequiredDate = varRequiredDate;
				
                item.ShippedDate = varShippedDate;
				
                item.ShipVia = varShipVia;
				
                item.Freight = varFreight;
				
                item.ShipName = varShipName;
				
                item.ShipAddress = varShipAddress;
				
                item.ShipCity = varShipCity;
				
                item.ShipRegion = varShipRegion;
				
                item.ShipPostalCode = varShipPostalCode;
				
                item.ShipCountry = varShipCountry;
				
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
            
            public static string CustomerID = @"CustomerID";
            
            public static string EmployeeID = @"EmployeeID";
            
            public static string OrderDate = @"OrderDate";
            
            public static string RequiredDate = @"RequiredDate";
            
            public static string ShippedDate = @"ShippedDate";
            
            public static string ShipVia = @"ShipVia";
            
            public static string Freight = @"Freight";
            
            public static string ShipName = @"ShipName";
            
            public static string ShipAddress = @"ShipAddress";
            
            public static string ShipCity = @"ShipCity";
            
            public static string ShipRegion = @"ShipRegion";
            
            public static string ShipPostalCode = @"ShipPostalCode";
            
            public static string ShipCountry = @"ShipCountry";
            
	    }

	    #endregion
    }

}

