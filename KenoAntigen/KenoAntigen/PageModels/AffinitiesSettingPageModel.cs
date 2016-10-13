using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KenoAntigen.Interfaces;
using KenoAntigen.Messages;

namespace KenoAntigen.PageModels
{
    public class AffinitiesSettingPageModel : BasePageModel
    {
        public AffinitiesSettingPageModel(ISocketService socketService) : base(socketService)
        {
        }

        protected override void HandleMessage(MessageReceivedMessage sender)
        {

        }
    }
}
