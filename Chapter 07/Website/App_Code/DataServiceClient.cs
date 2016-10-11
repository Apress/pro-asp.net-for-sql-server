using System;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using Chapter07.WCFService;

namespace Chapter07.Website
{

    [DataObject()]
    public class DataServiceClient
    {

        [DataObjectMethod(DataObjectMethodType.Select)]
        public FavoriteLinkDataContract[] GetRecentFavoriteLinkCollection(
            long profileId, int startDaysBack, int endDaysBack)
        {
            Trace.WriteLine("DataServiceClient: GetRecentFavoriteLinkCollection");
            FavoriteLinkDataContract[] links = null;
            try
            {
                links = Proxy.GetRecentFavoriteLinkCollection(profileId, startDaysBack, endDaysBack);
            }
            catch (Exception ex)
            {
                LogError(ex);
                ResetProxy();
            }
            return links;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public FavoriteLinkDataContract[] GetLatest20FavoriteLinkCollection(long profileId)
        {
            Trace.WriteLine("DataServiceClient: GetLatest20FavoriteLinkCollection");
            FavoriteLinkDataContract[] links = null;
            try
            {
                links = Proxy.GetLatest20FavoriteLinkCollection(profileId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                ResetProxy();
            }
            return links;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public FavoriteLinkDataContract[] GetFavoriteLinkCollectionByTag(long profileId, string token)
        {
            Trace.WriteLine("DataServiceClient: GetFavoriteLinkCollectionByTag");
            FavoriteLinkDataContract[] links = null;
            try
            {
                links = Proxy.GetFavoriteLinkCollectionByTag(profileId, token);
            }
            catch (Exception ex)
            {
                LogError(ex);
                ResetProxy();
            }
            return links;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public FavoriteLinkDataContract[] GetFavoriteLinkCollectionByUrl(long profileId, string url)
        {
            Trace.WriteLine("DataServiceClient: GetFavoriteLinkCollectionByUrl");
            FavoriteLinkDataContract[] links = null;
            try
            {
                links = Proxy.GetFavoriteLinkCollectionByUrl(profileId, url);
            }
            catch (Exception ex)
            {
                LogError(ex);
                ResetProxy();
            }
            return links;
        }

        private IFavoriteLinkService _proxy = null;

        public IFavoriteLinkService Proxy
        {
            get
            {
                if (_proxy == null)
                {
                    _proxy = GetProxy();
                }
                return _proxy;
            }
        }

        public IFavoriteLinkService GetProxy()
        {
            Trace.WriteLine("DataServiceClient: GetProxy");
            ChannelFactory<IFavoriteLinkService> factory = 
                new ChannelFactory<IFavoriteLinkService>(String.Empty);

            IFavoriteLinkService proxy = factory.CreateChannel();
            return proxy;
        }

        public void ResetProxy()
        {
            _proxy = null;
        }

        private void LogError(Exception ex)
        {
            Trace.WriteLine("Error: " + ex.Message);
            throw new ApplicationException("Error while communicating with Data Service");
        }

    }
}
