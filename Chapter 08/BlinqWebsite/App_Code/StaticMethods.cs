using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.DLinq;
using System.Query;
using System.Web.Configuration;
using Microsoft.Web.Blinq.Utils;

namespace Chapter08.BlinqDAL {

  public partial class Chapter08 : DataContext {
    public static Chapter08 CreateDataContext() {
      ConnectionUtil connectionUtil = new ConnectionUtil();
      ConnectionStringSettings connectionStringSettings = WebConfigurationManager.ConnectionStrings["Chapter08ConnectionString"];
      return new Chapter08(connectionUtil.CreateConnection(connectionStringSettings));
    }
  }

  public partial class Location {
    // This method retrieves all Locations.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Location> GetAllLocations() {
      Chapter08 db = Chapter08.CreateDataContext();
      return db.Locations;
    }
    // This method gets record counts of all Locations.
    // Do not change this method.
    public static int GetAllLocationsCount() {
      return GetAllLocations().Count();
    }
    // This method retrieves a single Location.
    // Change this method to alter how that record is received.
    public static Location GetLocation(Int64 ID) {
      Chapter08 db = Chapter08.CreateDataContext();
      return db.Locations.Where(x=>x.ID == ID).FirstOrDefault();
    }
    // This method pages and sorts over all Locations.
    // Do not change this method.
    public static IQueryable<Location> GetAllLocations(string sortExpression, int startRowIndex, int maximumRows) {
      return GetAllLocations().SortAndPage(sortExpression, startRowIndex, maximumRows, "ID");
    }
    // This method deletes a record in the table.
    // Change this method to alter how records are deleted.
    public static int Delete(Location x) {
      Chapter08 db = Chapter08.CreateDataContext();
      db.Locations.Remove(x);
      db.SubmitChanges();
      return 1;
    }
    // This method inserts a new record in the table.
    // Change this method to alter how records are inserted.
    public static int Insert(Location x) {
      Chapter08 db = Chapter08.CreateDataContext();
      db.Locations.Add(x);
      db.SubmitChanges();
      return 1;
    }
    // This method updates a record in the table.
    // Change this method to alter how records are updated.
    public static int Update(Location original_x, Location x) {
      Chapter08 db = Chapter08.CreateDataContext();
      db.Locations.Attach(original_x);
      original_x.City = x.City;
      original_x.State = x.State;
      original_x.Creation = x.Creation;
      original_x.Modified = x.Modified;
      db.SubmitChanges();
      return 1;
    }
  }

  public partial class Person {
    // This method retrieves all Persons.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Person> GetAllPersons() {
      Chapter08 db = Chapter08.CreateDataContext();
      return db.Persons;
    }
    // This method gets record counts of all Persons.
    // Do not change this method.
    public static int GetAllPersonsCount() {
      return GetAllPersons().Count();
    }
    // This method retrieves a single Person.
    // Change this method to alter how that record is received.
    public static Person GetPerson(Int64 ID) {
      Chapter08 db = Chapter08.CreateDataContext();
      return db.Persons.Where(x=>x.ID == ID).FirstOrDefault();
    }
    // This method retrieves Persons by Location.
    // Change this method to alter how records are retrieved.
    public static IQueryable<Person> GetPersonsByLocation(Int64 ID) {
      Chapter08 db = Chapter08.CreateDataContext();
      return db.Locations.Where(x=>x.ID == ID).SelectMany(x=>x.Persons);
    }
    // This method gets sorted and paged records of all Persons filtered by a specified field.
    // Do not change this method.
    public static IQueryable<Person> GetPersons(string tableName, Int64 Persons_ID, string sortExpression, int startRowIndex, int maximumRows) {
      IQueryable<Person> x = GetFilteredPersons(tableName, Persons_ID);
      return x.SortAndPage(sortExpression, startRowIndex, maximumRows, "ID");
    }
    // This method routes a request for filtering by a field value to another method.
    // Do not change this method.
    private static IQueryable<Person> GetFilteredPersons(string tableName, Int64 Persons_ID) {
      switch (tableName) {
        case "Location_Persons":
          return GetPersonsByLocation(Persons_ID);
        default:
          return GetAllPersons();
      }
    }
    // This method gets records counts of all Persons filtered by a specified field.
    // Do not change this method.
    public static int GetPersonsCount(string tableName, Int64 Persons_ID) {
      IQueryable<Person> x = GetFilteredPersons(tableName, Persons_ID);
      return x.Count();
    }
    // This method deletes a record in the table.
    // Change this method to alter how records are deleted.
    public static int Delete(Person x) {
      Chapter08 db = Chapter08.CreateDataContext();
      db.Persons.Remove(x);
      db.SubmitChanges();
      return 1;
    }
    // This method inserts a new record in the table.
    // Change this method to alter how records are inserted.
    public static int Insert(Person x) {
      Chapter08 db = Chapter08.CreateDataContext();
      db.Persons.Add(x);
      db.SubmitChanges();
      return 1;
    }
    // This method updates a record in the table.
    // Change this method to alter how records are updated.
    public static int Update(Person original_x, Person x) {
      Chapter08 db = Chapter08.CreateDataContext();
      db.Persons.Attach(original_x);
      original_x.FirstName = x.FirstName;
      original_x.LastName = x.LastName;
      original_x.LocationID = x.LocationID;
      original_x.Creation = x.Creation;
      original_x.Modified = x.Modified;
      db.SubmitChanges();
      return 1;
    }
  }
}
