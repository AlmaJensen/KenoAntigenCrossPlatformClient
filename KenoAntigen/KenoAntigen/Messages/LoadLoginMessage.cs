using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenoAntigen.Messages
{
    public class LoadLoginMessage
    {
        public LoadLoginMessage()
        {
            Xamarin.Forms.MessagingCenter.Send(this, nameof(LoadLoginMessage));
        }
    }
}
