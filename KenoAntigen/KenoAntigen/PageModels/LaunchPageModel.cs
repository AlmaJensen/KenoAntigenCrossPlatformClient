using FreshMvvm;
using KenoAntigen.Messages;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KenoAntigen.PageModels
{
    [ImplementPropertyChanged]
    public class LaunchPageModel : FreshBasePageModel
    {        
        public Command LoginCommand
        {
            get
            {
                return new Command(() => { new LoadLoginMessage(); });
            }
        }
        public Command RegisterCommand
        {
            get
            {
                return new Command(() => { new StartRegistrationMessage() ; });
            }
        }
    }
}
