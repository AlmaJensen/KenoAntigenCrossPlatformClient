using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenoAntigen.Messages
{
    public class LoginSuccessMessage
    {
        public LoginSuccessMessage()
        {
            Xamarin.Forms.MessagingCenter.Send(this, nameof(LoginSuccessMessage));
        }
    }
}
