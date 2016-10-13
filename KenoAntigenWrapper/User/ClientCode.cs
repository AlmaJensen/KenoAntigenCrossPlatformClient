using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenoAntigenWrapper.User
{
    public class ClientCode : BaseRequest
    {
        public ClientCode(string code = "")
        {
            route = "/user/clientCode";
            msgId = 123;
            clientCode = code;
        }
    }
}
