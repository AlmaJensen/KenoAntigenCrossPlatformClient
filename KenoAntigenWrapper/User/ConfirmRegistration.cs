using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenoAntigenWrapper.User
{
    public class ConfirmRegistration : BaseRequest
    {
        public ConfirmRegistration(string verificationCode, int messageId = 0)
        {
            route = "/user/loginWithEmailCode";
            msgId = messageId;
            content = new VerificationContent
            {
                emailCode = verificationCode
            };
        }
        public VerificationContent content { get; set; }
    }

    public class VerificationContent
    {
        public string emailCode { get; set; }
    }
}
