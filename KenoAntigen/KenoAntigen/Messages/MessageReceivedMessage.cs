using KenoAntigenWrapper.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenoAntigen.Messages
{
    public class MessageReceivedMessage
    {
        public BaseResponse Value { get; private set; }
        public MessageReceivedMessage(BaseResponse data)
        {
            Value = data;
            Xamarin.Forms.MessagingCenter.Send(this, nameof(MessageReceivedMessage));
        }
    }
}
