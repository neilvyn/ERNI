using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ERNITech.Services.Network
{
    public class NetworkHelper : INetworkHelper
    {
        public bool HasInternet()
        {
            var current = Connectivity.NetworkAccess;
            return (current == NetworkAccess.Internet);
        }
    }
}
