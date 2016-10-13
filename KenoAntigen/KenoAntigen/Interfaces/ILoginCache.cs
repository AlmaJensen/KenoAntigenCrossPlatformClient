using KenoAntigen.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenoAntigen.Interfaces
{
    public interface ILoginCache
    {
        void UpdateCache(EmpireCredentials credentials);
        Task<EmpireCredentials> GetCachedCredentials();
    }
}
