using System;
using System.Diagnostics;
using System.ServiceModel;
using Chapter07.WCFService;

public class DataServiceHost
{
    private static DataServiceHost _instance = null;
    private static Object _lock = new Object();

    private ServiceHost dataHost;

    private DataServiceHost()
    {
    }

    public static DataServiceHost Instance
    {
        get
        {
            lock (_lock)
            {
                _instance = new DataServiceHost();
            }
            return _instance;
        }
    }

    public void StartDataService()
    {
        Trace.WriteLine("Self Hosting: StartDataService");
        dataHost = new ServiceHost(typeof(FavoriteLinkService));
        dataHost.Open();
    }

    public void StopDataService()
    {
        Trace.WriteLine("Self Hosting: StopDataService");
        if (dataHost != null)
        {
            dataHost.Close();
        }
    }

}
