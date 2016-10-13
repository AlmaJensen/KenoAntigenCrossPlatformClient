using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenoAntigen.Utils
{
    public class ConsoleDebugWriter
    {
        public static void OutputObjectToConsole(object obj, string message = "")
        {
            System.Diagnostics.Debug.WriteLine(message);
            var json = JsonConvert.SerializeObject(obj);
            System.Diagnostics.Debug.WriteLine(json);
        }
    }
}
