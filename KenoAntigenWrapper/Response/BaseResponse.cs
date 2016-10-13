using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenoAntigenWrapper.Response
{
    public class BaseResponse
    {
        public string route { get; set; }
        public int status { get; set; }
        public int msgId { get; set; }
        public string room { get; set; }
        public Content content { get; set; }
        public string message { get; set; }
    }

    /*
     * Message from server
"{\"content\":{},\"route\":\"/welcome\",\"room\":\"main\"}"
'KenoAntigen.UWP.exe' (CoreCLR: CoreCLR_UWP_Domain): Loaded 'Anonymously Hosted DynamicMethods Assembly'. 
Message from server
"{\"room\":\"main\",\"status\":0,\"msgId\":123,\"route\":\"/user/clientCode\",\"content\":{\"clientCode\":\"3067e867-88c9-4ff1-8370-5352628cf95b-15202f\"},\"message\":\"OK\"}"
The thread 0x1d8c has exited with code 0 (0x0).

    Message from server
"{\"message\":\"OK\",\"status\":0,\"room\":\"main\",\"msgId\":123,\"route\":\"/user/register\",\"content\":{\"loginStage\":\"enterEmailCode\",\"username\":\"TestEmpire1\"}}"
Message from server
"{\"route\":\"/user/register\",\"content\":{\"data\":\"TestEmpire1\"},\"msgId\":123,\"status\":1001,\"room\":\"main\",\"message\":\"Username not available\"}"

     */
}
