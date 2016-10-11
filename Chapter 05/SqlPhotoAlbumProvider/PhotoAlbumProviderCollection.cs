using System;
using System.Configuration.Provider;

namespace Chapter05.PhotoAlbumProvider
{
    public class PhotoAlbumProviderCollection : ProviderCollection
    {
        public new PhotoAlbumProvider this[string name]
        {
            get { return (PhotoAlbumProvider)base[name]; }
        }

        public override void Add(ProviderBase provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (!(provider is PhotoAlbumProvider))
                throw new ArgumentException
                    ("Invalid provider type", "provider");

            base.Add(provider);
        }

    }
}
