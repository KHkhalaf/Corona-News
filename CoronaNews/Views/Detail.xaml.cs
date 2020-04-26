using CoronaNews.Model;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
    public partial class Detail : PopupPage
    {
        public Detail(CountryModel countryModel)
        {
            InitializeComponent();
            this.BindingContext = countryModel;
        }

        private async void btnClose_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.RemovePageAsync(this, true);
        }
    }
}