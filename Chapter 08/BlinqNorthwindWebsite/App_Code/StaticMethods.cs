using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.DLinq;
using System.Query;
using System.Web.Configuration;
using Microsoft.Web.Blinq.Utils;

namespace Chapter08.BlinqNorthwindDAL {

  public partial class Northwind : DataContext {
    public static Northwind CreateDataContext() {
      ConnectionUtil connectionUtil = new ConnectionUtil();
      ConnectionStringSettings connectionStringSettings = WebConfigurationManager.ConnectionStrings["NorthwindConnectionString"];
      return new Northwind(connectionUtil.CreateConnection(connectionStringSettings));
    }
  }

  public partial class Shipper {
    // This method retrieves all Shippers.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Shipper> GetAllShippers() {
      Northwind db = Northwind.CreateDataContext();
      return db.Shippers;
    }
    // This method gets record counts of all Shippers.
    // Do not change this method.
    public static int GetAllShippersCount() {
      return GetAllShippers().Count();
    }
    // This method retrieves a single Shipper.
    // Change this method to alter how that record is received.
    public static Shipper GetShipper(Int32 ShipperID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Shippers.Where(x=>x.ShipperID == ShipperID).FirstOrDefault();
    }
    // This method pages and sorts over all Shippers.
    // Do not change this method.
    public static IQueryable<Shipper> GetAllShippers(string sortExpression, int startRowIndex, int maximumRows) {
      return GetAllShippers().SortAndPage(sortExpression, startRowIndex, maximumRows, "ShipperID");
    }
    // This method deletes a record in the table.
    // Change this method to alter how records are deleted.
    public static int Delete(Shipper x) {
      Northwind db = Northwind.CreateDataContext();
      db.Shippers.Remove(x);
      db.SubmitChanges();
      return 1;
    }
    // This method inserts a new record in the table.
    // Change this method to alter how records are inserted.
    public static int Insert(Shipper x) {
      Northwind db = Northwind.CreateDataContext();
      db.Shippers.Add(x);
      db.SubmitChanges();
      return 1;
    }
    // This method updates a record in the table.
    // Change this method to alter how records are updated.
    public static int Update(Shipper original_x, Shipper x) {
      Northwind db = Northwind.CreateDataContext();
      db.Shippers.Attach(original_x);
      original_x.CompanyName = x.CompanyName;
      original_x.Phone = x.Phone;
      db.SubmitChanges();
      return 1;
    }
  }

  public partial class Order {
    // This method retrieves all Orders.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Order> GetAllOrders() {
      Northwind db = Northwind.CreateDataContext();
      return db.Orders;
    }
    // This method gets record counts of all Orders.
    // Do not change this method.
    public static int GetAllOrdersCount() {
      return GetAllOrders().Count();
    }
    // This method retrieves a single Order.
    // Change this method to alter how that record is received.
    public static Order GetOrder(Int32 OrderID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Orders.Where(x=>x.OrderID == OrderID).FirstOrDefault();
    }
    // This method retrieves Orders by Shipper.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Order> GetOrdersByShipper(Int32 ShipperID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Shippers.Where(x=>x.ShipperID == ShipperID).SelectMany(x=>x.Orders);
    }
    // This method retrieves Orders by Employee.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Order> GetOrdersByEmployee(Int32 EmployeeID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Employees.Where(x=>x.EmployeeID == EmployeeID).SelectMany(x=>x.Orders);
    }
    // This method retrieves Orders by Customer.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Order> GetOrdersByCustomer(String CustomerID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Customers.Where(x=>x.CustomerID == CustomerID).SelectMany(x=>x.Orders);
    }
    // This method gets sorted and paged records of all Orders filtered by a specified field.
    // Do not change this method.
    public static IQueryable<Order> GetOrders(string tableName, Int32 Orders_ShipperID, Int32 Orders_EmployeeID, String Orders_CustomerID, string sortExpression, int startRowIndex, int maximumRows) {
      IQueryable<Order> x = GetFilteredOrders(tableName, Orders_ShipperID, Orders_EmployeeID, Orders_CustomerID);
      return x.SortAndPage(sortExpression, startRowIndex, maximumRows, "OrderID");
    }
    // This method routes a request for filtering by a field value to another method.
    // Do not change this method.
    private static IQueryable<Order> GetFilteredOrders(string tableName, Int32 Orders_ShipperID, Int32 Orders_EmployeeID, String Orders_CustomerID) {
      switch (tableName) {
        case "Shipper_Orders":
          return GetOrdersByShipper(Orders_ShipperID);
        case "Employee_Orders":
          return GetOrdersByEmployee(Orders_EmployeeID);
        case "Customer_Orders":
          return GetOrdersByCustomer(Orders_CustomerID);
        default:
          return GetAllOrders();
      }
    }
    // This method gets records counts of all Orders filtered by a specified field.
    // Do not change this method.
    public static int GetOrdersCount(string tableName, Int32 Orders_ShipperID, Int32 Orders_EmployeeID, String Orders_CustomerID) {
      IQueryable<Order> x = GetFilteredOrders(tableName, Orders_ShipperID, Orders_EmployeeID, Orders_CustomerID);
      return x.Count();
    }
    // This method deletes a record in the table.
    // Change this method to alter how records are deleted.
    public static int Delete(Order x) {
      Northwind db = Northwind.CreateDataContext();
      db.Orders.Remove(x);
      db.SubmitChanges();
      return 1;
    }
    // This method inserts a new record in the table.
    // Change this method to alter how records are inserted.
    public static int Insert(Order x) {
      Northwind db = Northwind.CreateDataContext();
      db.Orders.Add(x);
      db.SubmitChanges();
      return 1;
    }
    // This method updates a record in the table.
    // Change this method to alter how records are updated.
    public static int Update(Order original_x, Order x) {
      Northwind db = Northwind.CreateDataContext();
      db.Orders.Attach(original_x);
      original_x.CustomerID = x.CustomerID;
      original_x.EmployeeID = x.EmployeeID;
      original_x.OrderDate = x.OrderDate;
      original_x.RequiredDate = x.RequiredDate;
      original_x.ShippedDate = x.ShippedDate;
      original_x.ShipVia = x.ShipVia;
      original_x.Freight = x.Freight;
      original_x.ShipName = x.ShipName;
      original_x.ShipAddress = x.ShipAddress;
      original_x.ShipCity = x.ShipCity;
      original_x.ShipRegion = x.ShipRegion;
      original_x.ShipPostalCode = x.ShipPostalCode;
      original_x.ShipCountry = x.ShipCountry;
      db.SubmitChanges();
      return 1;
    }
  }

  public partial class OrderDetail {
    // This method retrieves all OrderDetails.
    // Change this method to alter how records are retrieved.
    public static IQueryable<OrderDetail> GetAllOrderDetails() {
      Northwind db = Northwind.CreateDataContext();
      return db.OrderDetails;
    }
    // This method gets record counts of all OrderDetails.
    // Do not change this method.
    public static int GetAllOrderDetailsCount() {
      return GetAllOrderDetails().Count();
    }
    // This method retrieves a single OrderDetail.
    // Change this method to alter how that record is received.
    public static OrderDetail GetOrderDetail(Int32 OrderID, Int32 ProductID) {
      Northwind db = Northwind.CreateDataContext();
      return db.OrderDetails.Where(x=>x.OrderID == OrderID && x.ProductID == ProductID).FirstOrDefault();
    }
    // This method retrieves OrderDetails by Order.
    // Change this method to alter how records are retrieved.
    public static IQueryable<OrderDetail> GetOrderDetailsByOrder(Int32 OrderID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Orders.Where(x=>x.OrderID == OrderID).SelectMany(x=>x.OrderDetails);
    }
    // This method retrieves OrderDetails by Product.
    // Change this method to alter how records are retrieved.
    public static IQueryable<OrderDetail> GetOrderDetailsByProduct(Int32 ProductID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Products.Where(x=>x.ProductID == ProductID).SelectMany(x=>x.OrderDetails);
    }
    // This method gets sorted and paged records of all OrderDetails filtered by a specified field.
    // Do not change this method.
    public static IQueryable<OrderDetail> GetOrderDetails(string tableName, Int32 OrderDetails_OrderID, Int32 OrderDetails_ProductID, string sortExpression, int startRowIndex, int maximumRows) {
      IQueryable<OrderDetail> x = GetFilteredOrderDetails(tableName, OrderDetails_OrderID, OrderDetails_ProductID);
      return x.SortAndPage(sortExpression, startRowIndex, maximumRows, "OrderID");
    }
    // This method routes a request for filtering by a field value to another method.
    // Do not change this method.
    private static IQueryable<OrderDetail> GetFilteredOrderDetails(string tableName, Int32 OrderDetails_OrderID, Int32 OrderDetails_ProductID) {
      switch (tableName) {
        case "Order_OrderDetails":
          return GetOrderDetailsByOrder(OrderDetails_OrderID);
        case "Product_OrderDetails":
          return GetOrderDetailsByProduct(OrderDetails_ProductID);
        default:
          return GetAllOrderDetails();
      }
    }
    // This method gets records counts of all OrderDetails filtered by a specified field.
    // Do not change this method.
    public static int GetOrderDetailsCount(string tableName, Int32 OrderDetails_OrderID, Int32 OrderDetails_ProductID) {
      IQueryable<OrderDetail> x = GetFilteredOrderDetails(tableName, OrderDetails_OrderID, OrderDetails_ProductID);
      return x.Count();
    }
    // This method deletes a record in the table.
    // Change this method to alter how records are deleted.
    public static int Delete(OrderDetail x) {
      Northwind db = Northwind.CreateDataContext();
      db.OrderDetails.Remove(x);
      db.SubmitChanges();
      return 1;
    }
    // This method inserts a new record in the table.
    // Change this method to alter how records are inserted.
    public static int Insert(OrderDetail x) {
      Northwind db = Northwind.CreateDataContext();
      db.OrderDetails.Add(x);
      db.SubmitChanges();
      return 1;
    }
    // This method updates a record in the table.
    // Change this method to alter how records are updated.
    public static int Update(OrderDetail original_x, OrderDetail x) {
      Northwind db = Northwind.CreateDataContext();
      db.OrderDetails.Attach(original_x);
      original_x.UnitPrice = x.UnitPrice;
      original_x.Quantity = x.Quantity;
      original_x.Discount = x.Discount;
      db.SubmitChanges();
      return 1;
    }
  }

  public partial class CustomerDemographic {
    // This method retrieves all CustomerDemographics.
    // Change this method to alter how records are retrieved.
    public static IQueryable<CustomerDemographic> GetAllCustomerDemographics() {
      Northwind db = Northwind.CreateDataContext();
      return db.CustomerDemographics;
    }
    // This method gets record counts of all CustomerDemographics.
    // Do not change this method.
    public static int GetAllCustomerDemographicsCount() {
      return GetAllCustomerDemographics().Count();
    }
    // This method retrieves a single CustomerDemographic.
    // Change this method to alter how that record is received.
    public static CustomerDemographic GetCustomerDemographic(String CustomerTypeID) {
      Northwind db = Northwind.CreateDataContext();
      return db.CustomerDemographics.Where(x=>x.CustomerTypeID == CustomerTypeID).FirstOrDefault();
    }
    // This method pages and sorts over all CustomerDemographics.
    // Do not change this method.
    public static IQueryable<CustomerDemographic> GetAllCustomerDemographics(string sortExpression, int startRowIndex, int maximumRows) {
      return GetAllCustomerDemographics().SortAndPage(sortExpression, startRowIndex, maximumRows, "CustomerTypeID");
    }
    // This method deletes a record in the table.
    // Change this method to alter how records are deleted.
    public static int Delete(CustomerDemographic x) {
      Northwind db = Northwind.CreateDataContext();
      db.CustomerDemographics.Remove(x);
      db.SubmitChanges();
      return 1;
    }
    // This method inserts a new record in the table.
    // Change this method to alter how records are inserted.
    public static int Insert(CustomerDemographic x) {
      Northwind db = Northwind.CreateDataContext();
      db.CustomerDemographics.Add(x);
      db.SubmitChanges();
      return 1;
    }
    // This method updates a record in the table.
    // Change this method to alter how records are updated.
    public static int Update(CustomerDemographic original_x, CustomerDemographic x) {
      Northwind db = Northwind.CreateDataContext();
      db.CustomerDemographics.Attach(original_x);
      original_x.CustomerDesc = x.CustomerDesc;
      db.SubmitChanges();
      return 1;
    }
  }

  public partial class Region {
    // This method retrieves all Regions.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Region> GetAllRegions() {
      Northwind db = Northwind.CreateDataContext();
      return db.Regions;
    }
    // This method gets record counts of all Regions.
    // Do not change this method.
    public static int GetAllRegionsCount() {
      return GetAllRegions().Count();
    }
    // This method retrieves a single Region.
    // Change this method to alter how that record is received.
    public static Region GetRegion(Int32 RegionID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Regions.Where(x=>x.RegionID == RegionID).FirstOrDefault();
    }
    // This method pages and sorts over all Regions.
    // Do not change this method.
    public static IQueryable<Region> GetAllRegions(string sortExpression, int startRowIndex, int maximumRows) {
      return GetAllRegions().SortAndPage(sortExpression, startRowIndex, maximumRows, "RegionID");
    }
    // This method deletes a record in the table.
    // Change this method to alter how records are deleted.
    public static int Delete(Region x) {
      Northwind db = Northwind.CreateDataContext();
      db.Regions.Remove(x);
      db.SubmitChanges();
      return 1;
    }
    // This method inserts a new record in the table.
    // Change this method to alter how records are inserted.
    public static int Insert(Region x) {
      Northwind db = Northwind.CreateDataContext();
      db.Regions.Add(x);
      db.SubmitChanges();
      return 1;
    }
    // This method updates a record in the table.
    // Change this method to alter how records are updated.
    public static int Update(Region original_x, Region x) {
      Northwind db = Northwind.CreateDataContext();
      db.Regions.Attach(original_x);
      original_x.RegionDescription = x.RegionDescription;
      db.SubmitChanges();
      return 1;
    }
  }

  public partial class TextEntry {
    // This method retrieves all TextEntries.
    // Change this method to alter how records are retrieved.
    public static IQueryable<TextEntry> GetAllTextEntries() {
      Northwind db = Northwind.CreateDataContext();
      return db.TextEntries;
    }
    // This method gets record counts of all TextEntries.
    // Do not change this method.
    public static int GetAllTextEntriesCount() {
      return GetAllTextEntries().Count();
    }
    // This method retrieves a single TextEntry.
    // Change this method to alter how that record is received.
    public static TextEntry GetTextEntry(Int32 ContentID) {
      Northwind db = Northwind.CreateDataContext();
      return db.TextEntries.Where(x=>x.ContentID == ContentID).FirstOrDefault();
    }
    // This method pages and sorts over all TextEntries.
    // Do not change this method.
    public static IQueryable<TextEntry> GetAllTextEntries(string sortExpression, int startRowIndex, int maximumRows) {
      return GetAllTextEntries().SortAndPage(sortExpression, startRowIndex, maximumRows, "ContentID");
    }
    // This method deletes a record in the table.
    // Change this method to alter how records are deleted.
    public static int Delete(TextEntry x) {
      Northwind db = Northwind.CreateDataContext();
      db.TextEntries.Remove(x);
      db.SubmitChanges();
      return 1;
    }
    // This method inserts a new record in the table.
    // Change this method to alter how records are inserted.
    public static int Insert(TextEntry x) {
      Northwind db = Northwind.CreateDataContext();
      db.TextEntries.Add(x);
      db.SubmitChanges();
      return 1;
    }
    // This method updates a record in the table.
    // Change this method to alter how records are updated.
    public static int Update(TextEntry original_x, TextEntry x) {
      Northwind db = Northwind.CreateDataContext();
      db.TextEntries.Attach(original_x);
      original_x.ContentGUID = x.ContentGUID;
      original_x.Title = x.Title;
      original_x.ContentName = x.ContentName;
      original_x.Content = x.Content;
      original_x.IconPath = x.IconPath;
      original_x.DateExpires = x.DateExpires;
      original_x.LastEditedBy = x.LastEditedBy;
      original_x.ExternalLink = x.ExternalLink;
      original_x.Status = x.Status;
      original_x.ListOrder = x.ListOrder;
      original_x.CallOut = x.CallOut;
      original_x.CreatedOn = x.CreatedOn;
      original_x.CreatedBy = x.CreatedBy;
      original_x.ModifiedOn = x.ModifiedOn;
      original_x.ModifiedBy = x.ModifiedBy;
      db.SubmitChanges();
      return 1;
    }
  }

  public partial class Employee {
    // This method retrieves all Employees.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Employee> GetAllEmployees() {
      Northwind db = Northwind.CreateDataContext();
      return db.Employees;
    }
    // This method gets record counts of all Employees.
    // Do not change this method.
    public static int GetAllEmployeesCount() {
      return GetAllEmployees().Count();
    }
    // This method retrieves a single Employee.
    // Change this method to alter how that record is received.
    public static Employee GetEmployee(Int32 EmployeeID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Employees.Where(x=>x.EmployeeID == EmployeeID).FirstOrDefault();
    }
    // This method retrieves Employees by Employee.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Employee> GetEmployeesByEmployee(Int32 EmployeeID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Employees.Where(x=>x.EmployeeID == EmployeeID).SelectMany(x=>x.Employees);
    }
    // This method gets sorted and paged records of all Employees filtered by a specified field.
    // Do not change this method.
    public static IQueryable<Employee> GetEmployees(string tableName, Int32 Employees_EmployeeID, string sortExpression, int startRowIndex, int maximumRows) {
      IQueryable<Employee> x = GetFilteredEmployees(tableName, Employees_EmployeeID);
      return x.SortAndPage(sortExpression, startRowIndex, maximumRows, "EmployeeID");
    }
    // This method routes a request for filtering by a field value to another method.
    // Do not change this method.
    private static IQueryable<Employee> GetFilteredEmployees(string tableName, Int32 Employees_EmployeeID) {
      switch (tableName) {
        case "Employee_Employees":
          return GetEmployeesByEmployee(Employees_EmployeeID);
        default:
          return GetAllEmployees();
      }
    }
    // This method gets records counts of all Employees filtered by a specified field.
    // Do not change this method.
    public static int GetEmployeesCount(string tableName, Int32 Employees_EmployeeID) {
      IQueryable<Employee> x = GetFilteredEmployees(tableName, Employees_EmployeeID);
      return x.Count();
    }
    // This method deletes a record in the table.
    // Change this method to alter how records are deleted.
    public static int Delete(Employee x) {
      Northwind db = Northwind.CreateDataContext();
      db.Employees.Remove(x);
      db.SubmitChanges();
      return 1;
    }
    // This method inserts a new record in the table.
    // Change this method to alter how records are inserted.
    public static int Insert(Employee x) {
      Northwind db = Northwind.CreateDataContext();
      db.Employees.Add(x);
      db.SubmitChanges();
      return 1;
    }
    // This method updates a record in the table.
    // Change this method to alter how records are updated.
    public static int Update(Employee original_x, Employee x) {
      Northwind db = Northwind.CreateDataContext();
      db.Employees.Attach(original_x);
      original_x.LastName = x.LastName;
      original_x.FirstName = x.FirstName;
      original_x.Title = x.Title;
      original_x.TitleOfCourtesy = x.TitleOfCourtesy;
      original_x.BirthDate = x.BirthDate;
      original_x.HireDate = x.HireDate;
      original_x.Address = x.Address;
      original_x.City = x.City;
      original_x.Region = x.Region;
      original_x.PostalCode = x.PostalCode;
      original_x.Country = x.Country;
      original_x.HomePhone = x.HomePhone;
      original_x.Extension = x.Extension;
      original_x.Notes = x.Notes;
      original_x.ReportsTo = x.ReportsTo;
      original_x.PhotoPath = x.PhotoPath;
      original_x.Deleted = x.Deleted;
      db.SubmitChanges();
      return 1;
    }
  }

  public partial class Category {
    // This method retrieves all Categories.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Category> GetAllCategories() {
      Northwind db = Northwind.CreateDataContext();
      return db.Categories;
    }
    // This method gets record counts of all Categories.
    // Do not change this method.
    public static int GetAllCategoriesCount() {
      return GetAllCategories().Count();
    }
    // This method retrieves a single Category.
    // Change this method to alter how that record is received.
    public static Category GetCategory(Int32 CategoryID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Categories.Where(x=>x.CategoryID == CategoryID).FirstOrDefault();
    }
    // This method pages and sorts over all Categories.
    // Do not change this method.
    public static IQueryable<Category> GetAllCategories(string sortExpression, int startRowIndex, int maximumRows) {
      return GetAllCategories().SortAndPage(sortExpression, startRowIndex, maximumRows, "CategoryID");
    }
    // This method deletes a record in the table.
    // Change this method to alter how records are deleted.
    public static int Delete(Category x) {
      Northwind db = Northwind.CreateDataContext();
      db.Categories.Remove(x);
      db.SubmitChanges();
      return 1;
    }
    // This method inserts a new record in the table.
    // Change this method to alter how records are inserted.
    public static int Insert(Category x) {
      Northwind db = Northwind.CreateDataContext();
      db.Categories.Add(x);
      db.SubmitChanges();
      return 1;
    }
    // This method updates a record in the table.
    // Change this method to alter how records are updated.
    public static int Update(Category original_x, Category x) {
      Northwind db = Northwind.CreateDataContext();
      db.Categories.Attach(original_x);
      original_x.CategoryName = x.CategoryName;
      original_x.Description = x.Description;
      db.SubmitChanges();
      return 1;
    }
  }

  public partial class Customer {
    // This method retrieves all Customers.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Customer> GetAllCustomers() {
      Northwind db = Northwind.CreateDataContext();
      return db.Customers;
    }
    // This method gets record counts of all Customers.
    // Do not change this method.
    public static int GetAllCustomersCount() {
      return GetAllCustomers().Count();
    }
    // This method retrieves a single Customer.
    // Change this method to alter how that record is received.
    public static Customer GetCustomer(String CustomerID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Customers.Where(x=>x.CustomerID == CustomerID).FirstOrDefault();
    }
    // This method pages and sorts over all Customers.
    // Do not change this method.
    public static IQueryable<Customer> GetAllCustomers(string sortExpression, int startRowIndex, int maximumRows) {
      return GetAllCustomers().SortAndPage(sortExpression, startRowIndex, maximumRows, "CustomerID");
    }
    // This method deletes a record in the table.
    // Change this method to alter how records are deleted.
    public static int Delete(Customer x) {
      Northwind db = Northwind.CreateDataContext();
      db.Customers.Remove(x);
      db.SubmitChanges();
      return 1;
    }
    // This method inserts a new record in the table.
    // Change this method to alter how records are inserted.
    public static int Insert(Customer x) {
      Northwind db = Northwind.CreateDataContext();
      db.Customers.Add(x);
      db.SubmitChanges();
      return 1;
    }
    // This method updates a record in the table.
    // Change this method to alter how records are updated.
    public static int Update(Customer original_x, Customer x) {
      Northwind db = Northwind.CreateDataContext();
      db.Customers.Attach(original_x);
      original_x.CompanyName = x.CompanyName;
      original_x.ContactName = x.ContactName;
      original_x.ContactTitle = x.ContactTitle;
      original_x.Address = x.Address;
      original_x.City = x.City;
      original_x.Region = x.Region;
      original_x.PostalCode = x.PostalCode;
      original_x.Country = x.Country;
      original_x.Phone = x.Phone;
      original_x.Fax = x.Fax;
      db.SubmitChanges();
      return 1;
    }
  }

  public partial class Supplier {
    // This method retrieves all Suppliers.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Supplier> GetAllSuppliers() {
      Northwind db = Northwind.CreateDataContext();
      return db.Suppliers;
    }
    // This method gets record counts of all Suppliers.
    // Do not change this method.
    public static int GetAllSuppliersCount() {
      return GetAllSuppliers().Count();
    }
    // This method retrieves a single Supplier.
    // Change this method to alter how that record is received.
    public static Supplier GetSupplier(Int32 SupplierID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Suppliers.Where(x=>x.SupplierID == SupplierID).FirstOrDefault();
    }
    // This method pages and sorts over all Suppliers.
    // Do not change this method.
    public static IQueryable<Supplier> GetAllSuppliers(string sortExpression, int startRowIndex, int maximumRows) {
      return GetAllSuppliers().SortAndPage(sortExpression, startRowIndex, maximumRows, "SupplierID");
    }
    // This method deletes a record in the table.
    // Change this method to alter how records are deleted.
    public static int Delete(Supplier x) {
      Northwind db = Northwind.CreateDataContext();
      db.Suppliers.Remove(x);
      db.SubmitChanges();
      return 1;
    }
    // This method inserts a new record in the table.
    // Change this method to alter how records are inserted.
    public static int Insert(Supplier x) {
      Northwind db = Northwind.CreateDataContext();
      db.Suppliers.Add(x);
      db.SubmitChanges();
      return 1;
    }
    // This method updates a record in the table.
    // Change this method to alter how records are updated.
    public static int Update(Supplier original_x, Supplier x) {
      Northwind db = Northwind.CreateDataContext();
      db.Suppliers.Attach(original_x);
      original_x.CompanyName = x.CompanyName;
      original_x.ContactName = x.ContactName;
      original_x.ContactTitle = x.ContactTitle;
      original_x.Address = x.Address;
      original_x.City = x.City;
      original_x.Region = x.Region;
      original_x.PostalCode = x.PostalCode;
      original_x.Country = x.Country;
      original_x.Phone = x.Phone;
      original_x.Fax = x.Fax;
      original_x.HomePage = x.HomePage;
      db.SubmitChanges();
      return 1;
    }
  }

  public partial class ProductCategoryMap {
    // This method retrieves all ProductCategoryMaps.
    // Change this method to alter how records are retrieved.
    public static IQueryable<ProductCategoryMap> GetAllProductCategoryMaps() {
      Northwind db = Northwind.CreateDataContext();
      return db.ProductCategoryMaps;
    }
    // This method gets record counts of all ProductCategoryMaps.
    // Do not change this method.
    public static int GetAllProductCategoryMapsCount() {
      return GetAllProductCategoryMaps().Count();
    }
    // This method retrieves a single ProductCategoryMap.
    // Change this method to alter how that record is received.
    public static ProductCategoryMap GetProductCategoryMap(Int32 CategoryID, Int32 ProductID) {
      Northwind db = Northwind.CreateDataContext();
      return db.ProductCategoryMaps.Where(x=>x.CategoryID == CategoryID && x.ProductID == ProductID).FirstOrDefault();
    }
    // This method retrieves ProductCategoryMaps by Category.
    // Change this method to alter how records are retrieved.
    public static IQueryable<ProductCategoryMap> GetProductCategoryMapsByCategory(Int32 CategoryID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Categories.Where(x=>x.CategoryID == CategoryID).SelectMany(x=>x.ProductCategoryMaps);
    }
    // This method retrieves ProductCategoryMaps by Product.
    // Change this method to alter how records are retrieved.
    public static IQueryable<ProductCategoryMap> GetProductCategoryMapsByProduct(Int32 ProductID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Products.Where(x=>x.ProductID == ProductID).SelectMany(x=>x.ProductCategoryMaps);
    }
    // This method gets sorted and paged records of all ProductCategoryMaps filtered by a specified field.
    // Do not change this method.
    public static IQueryable<ProductCategoryMap> GetProductCategoryMaps(string tableName, Int32 ProductCategoryMaps_CategoryID, Int32 ProductCategoryMaps_ProductID, string sortExpression, int startRowIndex, int maximumRows) {
      IQueryable<ProductCategoryMap> x = GetFilteredProductCategoryMaps(tableName, ProductCategoryMaps_CategoryID, ProductCategoryMaps_ProductID);
      return x.SortAndPage(sortExpression, startRowIndex, maximumRows, "CategoryID");
    }
    // This method routes a request for filtering by a field value to another method.
    // Do not change this method.
    private static IQueryable<ProductCategoryMap> GetFilteredProductCategoryMaps(string tableName, Int32 ProductCategoryMaps_CategoryID, Int32 ProductCategoryMaps_ProductID) {
      switch (tableName) {
        case "Category_ProductCategoryMaps":
          return GetProductCategoryMapsByCategory(ProductCategoryMaps_CategoryID);
        case "Product_ProductCategoryMaps":
          return GetProductCategoryMapsByProduct(ProductCategoryMaps_ProductID);
        default:
          return GetAllProductCategoryMaps();
      }
    }
    // This method gets records counts of all ProductCategoryMaps filtered by a specified field.
    // Do not change this method.
    public static int GetProductCategoryMapsCount(string tableName, Int32 ProductCategoryMaps_CategoryID, Int32 ProductCategoryMaps_ProductID) {
      IQueryable<ProductCategoryMap> x = GetFilteredProductCategoryMaps(tableName, ProductCategoryMaps_CategoryID, ProductCategoryMaps_ProductID);
      return x.Count();
    }
    // This method deletes a record in the table.
    // Change this method to alter how records are deleted.
    public static int Delete(ProductCategoryMap x) {
      Northwind db = Northwind.CreateDataContext();
      db.ProductCategoryMaps.Remove(x);
      db.SubmitChanges();
      return 1;
    }
    // This method inserts a new record in the table.
    // Change this method to alter how records are inserted.
    public static int Insert(ProductCategoryMap x) {
      Northwind db = Northwind.CreateDataContext();
      db.ProductCategoryMaps.Add(x);
      db.SubmitChanges();
      return 1;
    }
    // This method updates a record in the table.
    // Change this method to alter how records are updated.
    public static int Update(ProductCategoryMap original_x, ProductCategoryMap x) {
      Northwind db = Northwind.CreateDataContext();
      db.ProductCategoryMaps.Attach(original_x);
      db.SubmitChanges();
      return 1;
    }
  }

  public partial class CustomerCustomerDemo {
    // This method retrieves all CustomerCustomerDemos.
    // Change this method to alter how records are retrieved.
    public static IQueryable<CustomerCustomerDemo> GetAllCustomerCustomerDemos() {
      Northwind db = Northwind.CreateDataContext();
      return db.CustomerCustomerDemos;
    }
    // This method gets record counts of all CustomerCustomerDemos.
    // Do not change this method.
    public static int GetAllCustomerCustomerDemosCount() {
      return GetAllCustomerCustomerDemos().Count();
    }
    // This method retrieves a single CustomerCustomerDemo.
    // Change this method to alter how that record is received.
    public static CustomerCustomerDemo GetCustomerCustomerDemo(String CustomerID, String CustomerTypeID) {
      Northwind db = Northwind.CreateDataContext();
      return db.CustomerCustomerDemos.Where(x=>x.CustomerID == CustomerID && x.CustomerTypeID == CustomerTypeID).FirstOrDefault();
    }
    // This method retrieves CustomerCustomerDemos by CustomerDemographic.
    // Change this method to alter how records are retrieved.
    public static IQueryable<CustomerCustomerDemo> GetCustomerCustomerDemosByCustomerDemographic(String CustomerTypeID) {
      Northwind db = Northwind.CreateDataContext();
      return db.CustomerDemographics.Where(x=>x.CustomerTypeID == CustomerTypeID).SelectMany(x=>x.CustomerCustomerDemos);
    }
    // This method retrieves CustomerCustomerDemos by Customer.
    // Change this method to alter how records are retrieved.
    public static IQueryable<CustomerCustomerDemo> GetCustomerCustomerDemosByCustomer(String CustomerID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Customers.Where(x=>x.CustomerID == CustomerID).SelectMany(x=>x.CustomerCustomerDemos);
    }
    // This method gets sorted and paged records of all CustomerCustomerDemos filtered by a specified field.
    // Do not change this method.
    public static IQueryable<CustomerCustomerDemo> GetCustomerCustomerDemos(string tableName, String CustomerCustomerDemos_CustomerTypeID, String CustomerCustomerDemos_CustomerID, string sortExpression, int startRowIndex, int maximumRows) {
      IQueryable<CustomerCustomerDemo> x = GetFilteredCustomerCustomerDemos(tableName, CustomerCustomerDemos_CustomerTypeID, CustomerCustomerDemos_CustomerID);
      return x.SortAndPage(sortExpression, startRowIndex, maximumRows, "CustomerID");
    }
    // This method routes a request for filtering by a field value to another method.
    // Do not change this method.
    private static IQueryable<CustomerCustomerDemo> GetFilteredCustomerCustomerDemos(string tableName, String CustomerCustomerDemos_CustomerTypeID, String CustomerCustomerDemos_CustomerID) {
      switch (tableName) {
        case "CustomerDemographic_CustomerCustomerDemos":
          return GetCustomerCustomerDemosByCustomerDemographic(CustomerCustomerDemos_CustomerTypeID);
        case "Customer_CustomerCustomerDemos":
          return GetCustomerCustomerDemosByCustomer(CustomerCustomerDemos_CustomerID);
        default:
          return GetAllCustomerCustomerDemos();
      }
    }
    // This method gets records counts of all CustomerCustomerDemos filtered by a specified field.
    // Do not change this method.
    public static int GetCustomerCustomerDemosCount(string tableName, String CustomerCustomerDemos_CustomerTypeID, String CustomerCustomerDemos_CustomerID) {
      IQueryable<CustomerCustomerDemo> x = GetFilteredCustomerCustomerDemos(tableName, CustomerCustomerDemos_CustomerTypeID, CustomerCustomerDemos_CustomerID);
      return x.Count();
    }
    // This method deletes a record in the table.
    // Change this method to alter how records are deleted.
    public static int Delete(CustomerCustomerDemo x) {
      Northwind db = Northwind.CreateDataContext();
      db.CustomerCustomerDemos.Remove(x);
      db.SubmitChanges();
      return 1;
    }
    // This method inserts a new record in the table.
    // Change this method to alter how records are inserted.
    public static int Insert(CustomerCustomerDemo x) {
      Northwind db = Northwind.CreateDataContext();
      db.CustomerCustomerDemos.Add(x);
      db.SubmitChanges();
      return 1;
    }
    // This method updates a record in the table.
    // Change this method to alter how records are updated.
    public static int Update(CustomerCustomerDemo original_x, CustomerCustomerDemo x) {
      Northwind db = Northwind.CreateDataContext();
      db.CustomerCustomerDemos.Attach(original_x);
      db.SubmitChanges();
      return 1;
    }
  }

  public partial class Territory {
    // This method retrieves all Territories.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Territory> GetAllTerritories() {
      Northwind db = Northwind.CreateDataContext();
      return db.Territories;
    }
    // This method gets record counts of all Territories.
    // Do not change this method.
    public static int GetAllTerritoriesCount() {
      return GetAllTerritories().Count();
    }
    // This method retrieves a single Territory.
    // Change this method to alter how that record is received.
    public static Territory GetTerritory(String TerritoryID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Territories.Where(x=>x.TerritoryID == TerritoryID).FirstOrDefault();
    }
    // This method retrieves Territories by Region.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Territory> GetTerritoriesByRegion(Int32 RegionID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Regions.Where(x=>x.RegionID == RegionID).SelectMany(x=>x.Territories);
    }
    // This method gets sorted and paged records of all Territories filtered by a specified field.
    // Do not change this method.
    public static IQueryable<Territory> GetTerritories(string tableName, Int32 Territories_RegionID, string sortExpression, int startRowIndex, int maximumRows) {
      IQueryable<Territory> x = GetFilteredTerritories(tableName, Territories_RegionID);
      return x.SortAndPage(sortExpression, startRowIndex, maximumRows, "TerritoryID");
    }
    // This method routes a request for filtering by a field value to another method.
    // Do not change this method.
    private static IQueryable<Territory> GetFilteredTerritories(string tableName, Int32 Territories_RegionID) {
      switch (tableName) {
        case "Region_Territories":
          return GetTerritoriesByRegion(Territories_RegionID);
        default:
          return GetAllTerritories();
      }
    }
    // This method gets records counts of all Territories filtered by a specified field.
    // Do not change this method.
    public static int GetTerritoriesCount(string tableName, Int32 Territories_RegionID) {
      IQueryable<Territory> x = GetFilteredTerritories(tableName, Territories_RegionID);
      return x.Count();
    }
    // This method deletes a record in the table.
    // Change this method to alter how records are deleted.
    public static int Delete(Territory x) {
      Northwind db = Northwind.CreateDataContext();
      db.Territories.Remove(x);
      db.SubmitChanges();
      return 1;
    }
    // This method inserts a new record in the table.
    // Change this method to alter how records are inserted.
    public static int Insert(Territory x) {
      Northwind db = Northwind.CreateDataContext();
      db.Territories.Add(x);
      db.SubmitChanges();
      return 1;
    }
    // This method updates a record in the table.
    // Change this method to alter how records are updated.
    public static int Update(Territory original_x, Territory x) {
      Northwind db = Northwind.CreateDataContext();
      db.Territories.Attach(original_x);
      original_x.TerritoryDescription = x.TerritoryDescription;
      original_x.RegionID = x.RegionID;
      db.SubmitChanges();
      return 1;
    }
  }

  public partial class EmployeeTerritory {
    // This method retrieves all EmployeeTerritories.
    // Change this method to alter how records are retrieved.
    public static IQueryable<EmployeeTerritory> GetAllEmployeeTerritories() {
      Northwind db = Northwind.CreateDataContext();
      return db.EmployeeTerritories;
    }
    // This method gets record counts of all EmployeeTerritories.
    // Do not change this method.
    public static int GetAllEmployeeTerritoriesCount() {
      return GetAllEmployeeTerritories().Count();
    }
    // This method retrieves a single EmployeeTerritory.
    // Change this method to alter how that record is received.
    public static EmployeeTerritory GetEmployeeTerritory(Int32 EmployeeID, String TerritoryID) {
      Northwind db = Northwind.CreateDataContext();
      return db.EmployeeTerritories.Where(x=>x.EmployeeID == EmployeeID && x.TerritoryID == TerritoryID).FirstOrDefault();
    }
    // This method retrieves EmployeeTerritories by Employee.
    // Change this method to alter how records are retrieved.
    public static IQueryable<EmployeeTerritory> GetEmployeeTerritoriesByEmployee(Int32 EmployeeID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Employees.Where(x=>x.EmployeeID == EmployeeID).SelectMany(x=>x.EmployeeTerritories);
    }
    // This method retrieves EmployeeTerritories by Territory.
    // Change this method to alter how records are retrieved.
    public static IQueryable<EmployeeTerritory> GetEmployeeTerritoriesByTerritory(String TerritoryID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Territories.Where(x=>x.TerritoryID == TerritoryID).SelectMany(x=>x.EmployeeTerritories);
    }
    // This method gets sorted and paged records of all EmployeeTerritories filtered by a specified field.
    // Do not change this method.
    public static IQueryable<EmployeeTerritory> GetEmployeeTerritories(string tableName, Int32 EmployeeTerritories_EmployeeID, String EmployeeTerritories_TerritoryID, string sortExpression, int startRowIndex, int maximumRows) {
      IQueryable<EmployeeTerritory> x = GetFilteredEmployeeTerritories(tableName, EmployeeTerritories_EmployeeID, EmployeeTerritories_TerritoryID);
      return x.SortAndPage(sortExpression, startRowIndex, maximumRows, "EmployeeID");
    }
    // This method routes a request for filtering by a field value to another method.
    // Do not change this method.
    private static IQueryable<EmployeeTerritory> GetFilteredEmployeeTerritories(string tableName, Int32 EmployeeTerritories_EmployeeID, String EmployeeTerritories_TerritoryID) {
      switch (tableName) {
        case "Employee_EmployeeTerritories":
          return GetEmployeeTerritoriesByEmployee(EmployeeTerritories_EmployeeID);
        case "Territory_EmployeeTerritories":
          return GetEmployeeTerritoriesByTerritory(EmployeeTerritories_TerritoryID);
        default:
          return GetAllEmployeeTerritories();
      }
    }
    // This method gets records counts of all EmployeeTerritories filtered by a specified field.
    // Do not change this method.
    public static int GetEmployeeTerritoriesCount(string tableName, Int32 EmployeeTerritories_EmployeeID, String EmployeeTerritories_TerritoryID) {
      IQueryable<EmployeeTerritory> x = GetFilteredEmployeeTerritories(tableName, EmployeeTerritories_EmployeeID, EmployeeTerritories_TerritoryID);
      return x.Count();
    }
    // This method deletes a record in the table.
    // Change this method to alter how records are deleted.
    public static int Delete(EmployeeTerritory x) {
      Northwind db = Northwind.CreateDataContext();
      db.EmployeeTerritories.Remove(x);
      db.SubmitChanges();
      return 1;
    }
    // This method inserts a new record in the table.
    // Change this method to alter how records are inserted.
    public static int Insert(EmployeeTerritory x) {
      Northwind db = Northwind.CreateDataContext();
      db.EmployeeTerritories.Add(x);
      db.SubmitChanges();
      return 1;
    }
    // This method updates a record in the table.
    // Change this method to alter how records are updated.
    public static int Update(EmployeeTerritory original_x, EmployeeTerritory x) {
      Northwind db = Northwind.CreateDataContext();
      db.EmployeeTerritories.Attach(original_x);
      db.SubmitChanges();
      return 1;
    }
  }

  public partial class Product {
    // This method retrieves all Products.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Product> GetAllProducts() {
      Northwind db = Northwind.CreateDataContext();
      return db.Products;
    }
    // This method gets record counts of all Products.
    // Do not change this method.
    public static int GetAllProductsCount() {
      return GetAllProducts().Count();
    }
    // This method retrieves a single Product.
    // Change this method to alter how that record is received.
    public static Product GetProduct(Int32 ProductID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Products.Where(x=>x.ProductID == ProductID).FirstOrDefault();
    }
    // This method retrieves Products by Category.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Product> GetProductsByCategory(Int32 CategoryID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Categories.Where(x=>x.CategoryID == CategoryID).SelectMany(x=>x.Products);
    }
    // This method retrieves Products by Supplier.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Product> GetProductsBySupplier(Int32 SupplierID) {
      Northwind db = Northwind.CreateDataContext();
      return db.Suppliers.Where(x=>x.SupplierID == SupplierID).SelectMany(x=>x.Products);
    }
    // This method gets sorted and paged records of all Products filtered by a specified field.
    // Do not change this method.
    public static IQueryable<Product> GetProducts(string tableName, Int32 Products_CategoryID, Int32 Products_SupplierID, string sortExpression, int startRowIndex, int maximumRows) {
      IQueryable<Product> x = GetFilteredProducts(tableName, Products_CategoryID, Products_SupplierID);
      return x.SortAndPage(sortExpression, startRowIndex, maximumRows, "ProductID");
    }
    // This method routes a request for filtering by a field value to another method.
    // Do not change this method.
    private static IQueryable<Product> GetFilteredProducts(string tableName, Int32 Products_CategoryID, Int32 Products_SupplierID) {
      switch (tableName) {
        case "Category_Products":
          return GetProductsByCategory(Products_CategoryID);
        case "Supplier_Products":
          return GetProductsBySupplier(Products_SupplierID);
        default:
          return GetAllProducts();
      }
    }
    // This method gets records counts of all Products filtered by a specified field.
    // Do not change this method.
    public static int GetProductsCount(string tableName, Int32 Products_CategoryID, Int32 Products_SupplierID) {
      IQueryable<Product> x = GetFilteredProducts(tableName, Products_CategoryID, Products_SupplierID);
      return x.Count();
    }
    // This method deletes a record in the table.
    // Change this method to alter how records are deleted.
    public static int Delete(Product x) {
      Northwind db = Northwind.CreateDataContext();
      db.Products.Remove(x);
      db.SubmitChanges();
      return 1;
    }
    // This method inserts a new record in the table.
    // Change this method to alter how records are inserted.
    public static int Insert(Product x) {
      Northwind db = Northwind.CreateDataContext();
      db.Products.Add(x);
      db.SubmitChanges();
      return 1;
    }
    // This method updates a record in the table.
    // Change this method to alter how records are updated.
    public static int Update(Product original_x, Product x) {
      Northwind db = Northwind.CreateDataContext();
      db.Products.Attach(original_x);
      original_x.ProductName = x.ProductName;
      original_x.SupplierID = x.SupplierID;
      original_x.CategoryID = x.CategoryID;
      original_x.QuantityPerUnit = x.QuantityPerUnit;
      original_x.UnitPrice = x.UnitPrice;
      original_x.UnitsInStock = x.UnitsInStock;
      original_x.UnitsOnOrder = x.UnitsOnOrder;
      original_x.ReorderLevel = x.ReorderLevel;
      original_x.Discontinued = x.Discontinued;
      original_x.AttributeXML = x.AttributeXML;
      original_x.DateCreated = x.DateCreated;
      original_x.ProductGUID = x.ProductGUID;
      db.SubmitChanges();
      return 1;
    }
  }
}
