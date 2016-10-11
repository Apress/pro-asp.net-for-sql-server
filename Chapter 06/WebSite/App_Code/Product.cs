using System;
using System.Data;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{

    public Product(int productId)
    {
        ProductID = productId;
    }

    private int _productId = 2;
    public int ProductID
    {
        get
        {
            return _productId;
        }
        set
        {
            _productId = value;
        }
    }

    private String _name = String.Empty;
    public String Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    private String _productNumber = String.Empty;
    public String ProductNumber
    {
        get
        {
            return _productNumber;
        }
        set
        {
            _productNumber = value;
        }
    }

    private decimal _price = 0;
    public decimal Price
    {
        get
        {
            return _price;
        }
        set
        {
            _price = value;
        }
    }

    private string _availability = "Unknown";
    public string Availability
    {
        get
        {
            return _availability;
        }
        set
        {
            _availability = value;
        }
    }

    private DataRow _data = null;
    public DataRow Data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value;
        }
    }

}
