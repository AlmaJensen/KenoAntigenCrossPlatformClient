using FreshMvvm;
using KenoAntigen.Interfaces;
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
    public class RegistrationVerificationPageModel : BasePageModel
    {
        public RegistrationVerificationPageModel(ISocketService socketService) : base(socketService) 
        {
            
        }

        public string VerificationCode { get; set; }

        public Command SubmitCommand
        {
            get
            {
                return new Command(() => { Submit(); });
            }
        }


        protected override void HandleMessage(MessageReceivedMessage sender)
        {
            
        }

        private void Submit()
        {
            //var request = new Registration(EmpireName, EmailAddress);
            //if (!string.IsNullOrEmpty(socketService.ClientCode))
            //{
            //    request.clientCode = socketService.ClientCode;
            //    socketService.SendRequest(request);
            //}
        }
    }
}
