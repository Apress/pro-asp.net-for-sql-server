using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using Chapter05.ClassLibrary;

/// <summary>
/// Summary description for Utility
/// </summary>
public class Utility
{

    public static DataSet GetApplicationState()
    {
        return HttpContext.Current.Application["Global Data"] as DataSet;
    }

    public static DataSet GetSessionState()
    {
        return HttpContext.Current.Application["Global Data"] as DataSet;
    }

    public static Product GetProduct(HttpContext context)
    {
        if (context == null)
        {
            return null;
        }

        Product product = context.Items["CurrentProduct"] as Product;
        if (product == null)
        {
            // use the context.Request to load the Product
            string productIdStr = context.Request.QueryString["ProductID"];
            int productId = -1;
            int.TryParse(productIdStr, out productId);
            Domain domain = new Domain();
            DataSet productDs = domain.GetProductByID(productId);
            if (productDs != null && productDs.Tables.Count > 0 &&
                productDs.Tables[0].Rows.Count > 0)
            {
                DataRow row = productDs.Tables[0].Rows[0];
                product = new Product((int) row["ProductID"]);
                product.Name = (string) row["Name"];
                product.ProductNumber = (string) row["ProductNumber"];
                product.Price = (decimal)row["ListPrice"];
                product.Availability = (string) row["Availability"];
                product.Data = row;
            }
            context.Items["CurrentProduct"] = product;
        }
        return product;
    }

    public static void AddToCache(string key, Object value)
    {
        HttpRuntime.Cache.Add(key, value, null, DateTime.Now.AddSeconds(5),
            TimeSpan.Zero, CacheItemPriority.Normal, RemovedCallback);
    }

    private static void RemovedCallback(string key, object value, CacheItemRemovedReason reason)
    {
        LogMessage(String.Format(
            "Item removed from cache: {0}, {1}, {2}", key, value, reason), 
            null, EventLogEntryType.Information);
    }

    private static object GetCachedItems()
    {
        Cache cache = HttpRuntime.Cache;
        ArrayList items = new ArrayList();
        foreach (DictionaryEntry entry in cache)
        {
            string itemType = string.Empty;
            string itemValue = string.Empty;
            if (entry.Value != null)
            {
                Type type = entry.Value.GetType();
                itemType = type.FullName;
                if (entry.Value is string)
                {
                    itemValue = (string)entry.Value;
                }
                else if (entry.Value is ValueType)
                {
                    itemValue = entry.Value.ToString();
                }
                else
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(type);
                    if ((converter != null) && converter.CanConvertTo(typeof(string)))
                    {
                        itemValue = converter.ConvertToInvariantString(entry.Value);
                    }
                }
            }
            items.Add(new Triplet(entry.Key, itemType, itemValue));
        }
        return items;
    }

    private static int PurgeCacheItemsByType(Type type)
    {
        Cache cache = HttpRuntime.Cache;
        List<String> keys = new List<string>();
        foreach (DictionaryEntry entry in cache)
        {
            if (entry.Value != null && 
                entry.Value.GetType().Equals(type))
            {
                keys.Add((string)entry.Key);
            }
        }
        foreach (string key in keys)
        {
            cache.Remove(key);
        }
        return keys.Count;
    }

    public static void LogMessage(string message, Exception exception, EventLogEntryType entryType)
    {
        string eventSource = "Application";
        if (!EventLog.SourceExists(eventSource))
        {
            EventLog.CreateEventSource(eventSource, "Chapter 5 Website");
        }
        if (exception == null)
        {
            EventLog.WriteEntry(eventSource, message, entryType);
        }
        else
        {
            EventLog.WriteEntry(eventSource, GetFullMessage(message, exception), entryType);
        }
    }

    private static string GetFullMessage(string message, Exception exception)
    {
        return message + "\n\n" + exception.Message + "\n\n" + exception.StackTrace;
    }

}
