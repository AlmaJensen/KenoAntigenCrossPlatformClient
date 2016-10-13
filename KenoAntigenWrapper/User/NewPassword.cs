using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenoAntigenWrapper.User
{
    public class NewPassword : BaseRequest
    {
        public NewPassword(string password, int messageId = 0)
        {
            route = "/user/enterNewPassword";
            msgId = messageId;
            content = new PasswordContent
            {
                password = password
            };
        }
        public PasswordContent content { get; set; }
    }

    public class PasswordContent
    {
        public string password { get; set; }
    }
}
