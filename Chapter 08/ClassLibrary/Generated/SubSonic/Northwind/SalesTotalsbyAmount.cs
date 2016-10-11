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



namespace Chapter08.NorthwindDAL{
    /// <summary>
    /// Strongly-typed collection for the SalesTotalsbyAmount class.
    /// </summary>
    [Serializable]
    public partial class SalesTotalsbyAmountCollection : ReadOnlyList<SalesTotalsbyAmount>
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public SalesTotalsbyAmountCollection OrderByAsc(string columnName) 
        {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public SalesTotalsbyAmountCollection OrderByDesc(string columnName) 
        {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

        public SalesTotalsbyAmountCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
        {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public SalesTotalsbyAmountCollection Where(Where where) 
        {
            wheres.Add(where);
            return this;
        }

    	
        public SalesTotalsbyAmountCollection Where(string columnName, object value) 
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

    	
        public SalesTotalsbyAmountCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public SalesTotalsbyAmountCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public SalesTotalsbyAmountCollection Load() 
	    {
            Query qry = new Query(SalesTotalsbyAmount.Schema);
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

        
        public SalesTotalsbyAmountCollection() 
        {
            
        }

    }

    /// <summary>
    /// This is  Read-only wrapper class for the Sales Totals by Amount view.
    /// </summary>
    [Serializable]
    public partial class SalesTotalsbyAmount : ReadOnlyRecord<SalesTotalsbyAmount> 
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
                TableSchema.Table schema = new TableSchema.Table("Sales Totals by Amount", TableType.View, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarSaleAmount = new TableSchema.TableColumn(schema);
                colvarSaleAmount.ColumnName = "SaleAmount";
                colvarSaleAmount.DataType = DbType.Currency;
                colvarSaleAmount.MaxLength = 0;
                colvarSaleAmount.AutoIncrement = false;
                colvarSaleAmount.IsNullable = true;
                colvarSaleAmount.IsPrimaryKey = false;
                colvarSaleAmount.IsForeignKey = false;
                colvarSaleAmount.IsReadOnly = false;
                
                schema.Columns.Add(colvarSaleAmount);
                
                TableSchema.TableColumn colvarOrderID = new TableSchema.TableColumn(schema);
                colvarOrderID.ColumnName = "OrderID";
                colvarOrderID.DataType = DbType.Int32;
                colvarOrderID.MaxLength = 0;
                colvarOrderID.AutoIncrement = false;
                colvarOrderID.IsNullable = false;
                colvarOrderID.IsPrimaryKey = false;
                colvarOrderID.IsForeignKey = false;
                colvarOrderID.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrderID);
                
                TableSchema.TableColumn colvarCompanyName = new TableSchema.TableColumn(schema);
                colvarCompanyName.ColumnName = "CompanyName";
                colvarCompanyName.DataType = DbType.String;
                colvarCompanyName.MaxLength = 40;
                colvarCompanyName.AutoIncrement = false;
                colvarCompanyName.IsNullable = false;
                colvarCompanyName.IsPrimaryKey = false;
                colvarCompanyName.IsForeignKey = false;
                colvarCompanyName.IsReadOnly = false;
                
                schema.Columns.Add(colvarCompanyName);
                
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
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Sales Totals by Amount",schema);
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
	    public SalesTotalsbyAmount()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public SalesTotalsbyAmount(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public SalesTotalsbyAmount(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("SaleAmount")]
        public decimal? SaleAmount 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("SaleAmount");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("SaleAmount", value);
            }

        }

	      
        [XmlAttribute("OrderID")]
        public int OrderID 
	    {
		    get
		    {
			    return GetColumnValue<int>("OrderID");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("OrderID", value);
            }

        }

	      
        [XmlAttribute("CompanyName")]
        public string CompanyName 
	    {
		    get
		    {
			    return GetColumnValue<string>("CompanyName");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CompanyName", value);
            }

        }

	      
        [XmlAttribute("ShippedDate")]
        public DateTime? ShippedDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("ShippedDate");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShippedDate", value);
            }

        }

	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string SaleAmount  = @"SaleAmount";
            
            public static string OrderID  = @"OrderID";
            
            public static string CompanyName  = @"CompanyName";
            
            public static string ShippedDate  = @"ShippedDate";
            
	    }

	    #endregion
    }

}
