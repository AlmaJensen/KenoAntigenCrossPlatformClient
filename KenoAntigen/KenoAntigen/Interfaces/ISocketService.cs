using KenoAntigenWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenoAntigen.Interfaces
{
    public interface ISocketService
    {
        bool IsConnected { get; set; }
        string ClientCode { get; set; }
        string DefaultConnectionString { get; set; }
        void SendRequest(BaseRequest request);
        void OpenConnection(string url);
    }
}
