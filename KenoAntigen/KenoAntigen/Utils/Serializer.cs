using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenoAntigen.Utils
{
    public static class Serializer
    {
        public static string SerializeObject(object obj) =>
            JsonConvert.SerializeObject(obj);
    }
}
