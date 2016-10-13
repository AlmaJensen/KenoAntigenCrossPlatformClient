using KenoAntigen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KenoAntigen.DataModels;
using Akavache;
using System.Reactive.Linq;

namespace KenoAntigen.Services
{
    public class LoginCache : ILoginCache
    {
        private const string storageKey = "loginCreds";
        public async Task<EmpireCredentials> GetCachedCredentials()
        {
            try
            {
                var response = await BlobCache.Secure.GetObject<EmpireCredentials>(storageKey);
                return response;
            }
            catch (Exception ex)
            {
                //Insights.Report(ex);
                return new EmpireCredentials();
            }
        }

        public void UpdateCache(EmpireCredentials credentials)
        {
            BlobCache.Secure.Invalidate(storageKey);
            BlobCache.Secure.InsertObject(storageKey, credentials);
        }
    }
}
