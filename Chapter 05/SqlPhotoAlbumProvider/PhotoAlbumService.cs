using System.Configuration.Provider;
using System.Web.Configuration;

namespace Chapter05.PhotoAlbumProvider
{
    public class PhotoAlbumService
    {
        private static PhotoAlbumProvider _defaultProvider = null;
        private static PhotoAlbumProviderCollection _providers = null;
        private static object _lock = new object();

        private PhotoAlbumService() {}

        public PhotoAlbumProvider DefaultProvider
        {
            get { return _defaultProvider; }
        }

        public PhotoAlbumProvider GetProvider(string name)
        {
            return _providers[name];
        }

        public static PhotoAlbumProvider Instance
        {
            get
            {
                LoadProviders();
                return _defaultProvider;
            }
        }

        private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_defaultProvider == null)
            {
                lock (_lock)
                {
                    // Do this again to make sure _defaultProvider is still null
                    if (_defaultProvider == null)
                    {
                        PhotoAlbumSection section = (PhotoAlbumSection)
                            WebConfigurationManager.GetSection
                            ("photoAlbumService");

                        // Only want one provider here
                        //_defaultProvider = (PhotoAlbumProvider)
                        //    ProvidersHelper.InstantiateProvider
                        //    (section.Providers[0], typeof(PhotoAlbumProvider));

                        _providers = new PhotoAlbumProviderCollection();

                        ProvidersHelper.InstantiateProviders(
                            section.Providers, _providers, 
                            typeof(PhotoAlbumProvider));

                        _defaultProvider = _providers[section.DefaultProvider];

                        if (_defaultProvider == null)
                            throw new ProviderException
                                ("Unable to load default PhotoAlbumProvider");
                    }
                }
            }
        }

    }
}
