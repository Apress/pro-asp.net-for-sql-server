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
    /// Strongly-typed collection for the SummaryofSalesbyYear class.
    /// </summary>
    [Serializable]
    public partial class SummaryofSalesbyYearCollection : ReadOnlyList<SummaryofSalesbyYear>
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public SummaryofSalesbyYearCollection OrderByAsc(string columnName) 
        {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public SummaryofSalesbyYearCollection OrderByDesc(string columnName) 
        {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

        public SummaryofSalesbyYearCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
        {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public SummaryofSalesbyYearCollection Where(Where where) 
        {
            wheres.Add(where);
            return this;
        }

    	
        public SummaryofSalesbyYearCollection Where(string columnName, object value) 
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

    	
        public SummaryofSalesbyYearCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public SummaryofSalesbyYearCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public SummaryofSalesbyYearCollection Load() 
	    {
            Query qry = new Query(SummaryofSalesbyYear.Schema);
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

        
        public SummaryofSalesbyYearCollection() 
        {
            
        }

    }

    /// <summary>
    /// This is  Read-only wrapper class for the Summary of Sales by Year view.
    /// </summary>
    [Serializable]
    public partial class SummaryofSalesbyYear : ReadOnlyRecord<SummaryofSalesbyYear> 
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
                TableSchema.Table schema = new TableSchema.Table("Summary of Sales by Year", TableType.View, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
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
                
                TableSchema.TableColumn colvarSubtotal = new TableSchema.TableColumn(schema);
                colvarSubtotal.ColumnName = "Subtotal";
                colvarSubtotal.DataType = DbType.Currency;
                colvarSubtotal.MaxLength = 0;
                colvarSubtotal.AutoIncrement = false;
                colvarSubtotal.IsNullable = true;
                colvarSubtotal.IsPrimaryKey = false;
                colvarSubtotal.IsForeignKey = false;
                colvarSubtotal.IsReadOnly = false;
                
                schema.Columns.Add(colvarSubtotal);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Summary of Sales by Year",schema);
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
	    public SummaryofSalesbyYear()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public SummaryofSalesbyYear(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public SummaryofSalesbyYear(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
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

	      
        [XmlAttribute("Subtotal")]
        public decimal? Subtotal 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("Subtotal");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Subtotal", value);
            }

        }

	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string ShippedDate  = @"ShippedDate";
            
            public static string OrderID  = @"OrderID";
            
            public static string Subtotal  = @"Subtotal";
            
	    }

	    #endregion
    }

}
