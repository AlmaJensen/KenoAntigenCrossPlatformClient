using FreshMvvm;
using KenoAntigen.DataModels;
using KenoAntigen.Interfaces;
using KenoAntigen.Messages;
using KenoAntigenWrapper.User;
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
    public class CreateAccountPageModel : FreshBasePageModel
    {
        ISocketService socketService;
        ILoginCache loginCache;

        private int requestID = 1;

        private Task<EmpireCredentials> credentials;

        public CreateAccountPageModel(ISocketService socketService, ILoginCache loginCache)
        {
            this.socketService = socketService;
            this.loginCache = loginCache;

            credentials = LoadCredentials();
        }

        private async Task<EmpireCredentials> LoadCredentials()
        {
            return await loginCache.GetCachedCredentials();
        }

        public string EmailAddress { get; set; }
        public string EmpireName { get; set; }
        public Command SubmitCommand
        {
            get
            {
                return new Command(() => { Submit(); });
            }
        }

        private void Submit()
        {
            //new ConfirmRegistrationMessage();
            var request = new Registration(EmpireName, EmailAddress, requestID);
            if (!string.IsNullOrEmpty(socketService.ClientCode))
            {
                request.clientCode = socketService.ClientCode;
                socketService.SendRequest(request);
            }
        }

        private void Subscribe()
        {
            MessagingCenter.Subscribe<MessageReceivedMessage>(this, nameof(MessageReceivedMessage), async (sender) => { await HandleMessage(sender); });
        }

        private async Task HandleMessage(MessageReceivedMessage sender)
        {
            if (sender.Value.status == 0 && sender.Value.msgId == requestID)
            {
                var creds = await credentials;
                creds.Email = EmailAddress;
                creds.EmpireName = EmpireName;
                loginCache.UpdateCache(creds);

                Device.BeginInvokeOnMainThread(() => { new ConfirmRegistrationMessage(); });
            }
            else
                await CoreMethods.DisplayAlert("Error", sender.Value.message, "Ok");
        }

        private void Unsubscribe()
        {
            MessagingCenter.Unsubscribe<MessageReceivedMessage>(this, nameof(MessageReceivedMessage));
        }

        protected override void ViewIsDisappearing(object sender, System.EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
            Unsubscribe();
        }

        public override void ReverseInit(object value)
        {
            Subscribe();
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            Subscribe();
        }
    }
}
