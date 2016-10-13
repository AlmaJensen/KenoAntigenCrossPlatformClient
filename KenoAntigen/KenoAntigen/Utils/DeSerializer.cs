using KenoAntigenWrapper.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenoAntigen.Utils
{
    public class DeSerializer
    {
        public static BaseResponse DeSerialize(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<BaseResponse>(json);
            }
            catch
            {
                return new BaseResponse();
            }
        }
    }
}
