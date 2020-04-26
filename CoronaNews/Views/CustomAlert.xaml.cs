using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoronaNews.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomAlert : PopupPage
    {
        public enum AlertType
        {
            Success,
            Info,
            Warning,
            Error
        }
        private readonly AlertType _aType;
        private readonly int _milisecond = 6000;
        public CustomAlert(AlertType aType, string message)
        {
            InitializeComponent();

            _aType = aType;

            lblMessage.Text = message;
            SetAlert();
        }

        public CustomAlert(AlertType aType, string message, int milisecond)
        {
            InitializeComponent();

            _aType = aType;
            _milisecond = milisecond;

            lblMessage.Text = message;
            SetAlert();
        }

        private void SetAlert()
        {
            switch (_aType)
            {
                case AlertType.Success:
                    imgAlert.Source = "succ.png";
                    break;
                case AlertType.Info:
                    imgAlert.Source = "alert_info.png";
                    break;
                case AlertType.Warning:
                    imgAlert.Source = "alert_alert.png";
                    break;
                case AlertType.Error:
                    imgAlert.Source = "alert_error.png";
                    break;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_milisecond > 0) HidePopup();
        }
        private async void HidePopup()
        {
            await Task.Delay(_milisecond);
            App.Instance.ClosePopup(this);
        }
    }
}