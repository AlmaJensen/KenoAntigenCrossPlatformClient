using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KenoAntigenWrapper
{
    public abstract class BaseRequest
    {
        public string route { get; set; }
        public int msgId { get; set; }
        public string clientCode { get; set; }
    }
}
