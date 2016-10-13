using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenoAntigen.Messages
{
    public class StartRegistrationMessage
    {
        public StartRegistrationMessage()
        {
            Xamarin.Forms.MessagingCenter.Send(this, nameof(StartRegistrationMessage));
        }
    }
}
