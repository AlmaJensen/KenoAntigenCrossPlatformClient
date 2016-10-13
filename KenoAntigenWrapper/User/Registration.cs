using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenoAntigenWrapper.User
{
    public class Registration : BaseRequest
    {
        public Registration(string username, string email, int messageId = 0)
        {
            route = "/user/register";
            msgId = messageId;
            content = new RegisterContent
            {
                username = username,
                email = email,
            };
        }
        public RegisterContent content { get; set; }
    }
    
    public class RegisterContent
    {
        public string username { get; set; }
        public string email { get; set; }
    }
}
