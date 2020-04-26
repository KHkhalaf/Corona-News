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
    public partial class BaseContentPage : ContentPage
    {
        private bool _isBusy;

        public new bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public class Busy : IDisposable
        {
            readonly object _sync = new object();
            readonly BaseContentPage _contentPage;

            public Busy(BaseContentPage contentPage)
            {
                _contentPage = contentPage;
                lock (_sync)
                {
                    _contentPage.IsBusy = true;
                }
            }

            public void Dispose()
            {
                lock (_sync)
                {
                    _contentPage.IsBusy = false;
                }
            }
        }

        public BaseContentPage()
        {
            //InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //this.BindingContext = App.logoSource
        }

        private void RefreshPressed(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            /*
            App.Instance.PageChange(
                p: this,
                isHome: GetType() == typeof(VoyageList)
            ); */
        }
    }
}
