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
    public abstract class BasePageModel : FreshBasePageModel
    {
        ISocketService socketService;

        public  BasePageModel(ISocketService socketService)
        {
            this.socketService = socketService;
            Subscribe();
        }
        private void Subscribe()
        {
            MessagingCenter.Subscribe<MessageReceivedMessage>(this, nameof(MessageReceivedMessage), (sender) => { HandleMessage(sender); });
        }

        protected abstract void HandleMessage(MessageReceivedMessage sender);
        
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
        }
    }
}
