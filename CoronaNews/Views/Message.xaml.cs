using CoronaNews.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoronaNews
{
    public enum MessageType
    {
        Info,
        Warning,
        Error
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Message : ContentPage
    {
        public EventHandler OnClose;

        public Message(MessageType messageType, string message, string buttontext)
        {
            InitializeComponent();
            switch (messageType)
            {
                case MessageType.Info:
                    imgTitle.Source = "alert_info.png";
                    lblTitle.TextColor = (Color)Application.Current.Resources["BlackColor"];
                    lblTitle.Text = AppResources.Message_TitleInfo;
                    break;
                case MessageType.Warning:
                    imgTitle.Source = "alert_alert.png";
                    lblTitle.TextColor = (Color)Application.Current.Resources["BlackColor"];
                    lblTitle.Text = AppResources.Message_TitleWarning;
                    break;
                case MessageType.Error:
                    imgTitle.Source = "alert_error.png";
                    lblTitle.TextColor = (Color)Application.Current.Resources["BlackColor"];
                    lblTitle.Text = AppResources.Message_TitleError;
                    break;
            }

            lblMessage.Text = message;
            btnHome.Text = buttontext;
        }

        private void btnHome_OnClicked(object sender, EventArgs e)
        {
            OnClose?.Invoke(this, EventArgs.Empty);
        }
    }
}