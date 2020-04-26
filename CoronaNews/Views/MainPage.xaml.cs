using CoronaNews.CustomControl;
using CoronaNews.Model;
using CoronaNews.Resources;
using CoronaNews.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CoronaNews
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : BaseContentPage
    {
        private GetAllData data;
        private List<CountryModel> countryList = new List<CountryModel>();
        public MainPage()
        {
            InitializeComponent();
            Init();
        }
        async void Init()
        {

            if (!App.Instance.CheckInternet())
            {
                //App.Current.MainPage = new Message(MessageType.Error, AppResources.App_StopMessage, AppResources.App_StopButton);
                noInternetstack1.IsVisible = true;
                noInternetstack2.IsVisible = true;
            }
            else
                data = await Api.AllData();
            if (data != null)
            {
                noInternetstack1.IsVisible = false;
                noInternetstack2.IsVisible = false;
                lblCases.Text = data.cases.ToString("n0");
                lblDeath.Text = data.deaths.ToString("n0");
                lblRecovered.Text = data.recovered.ToString("n0");
                lblTodayCases.Text = data.todayCases.ToString("n0");
                lblTodayDeath.Text = data.todayDeaths.ToString("n0");
                lblActiveCases.Text = data.active.ToString("n0");
            }

            if (!App.Instance.CheckInternet())
            {
                //App.Current.MainPage = new Message(MessageType.Error, AppResources.App_StopMessage, AppResources.App_StopButton);
            }
            else
                countryList = await Api.GetCountryData();
            if (countryList != null)
            {
                foreach (CountryModel country in countryList)
                    country.InitStrings(country);
                try {
                    listView.ItemsSource = countryList.OrderByDescending(q => q.cases).Take(100);
                }
                catch(Exception ex)
                {
                  
                }
            }
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = entr_search.Text;
            if (countryList != null && countryList.Count > 0)
            {
                var lw = countryList.Where(w => w.country.ToLower().Contains(keyword.ToLower())).ToList();
                listView.ItemsSource = lw;

                if (String.IsNullOrEmpty(keyword))
                {
                    listView.ItemsSource = countryList.OrderByDescending(q => q.cases).Take(100);
                }
            }

        }

        private void listView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var Mdl = (CountryModel)e.ItemData;
            App.Instance.ShowPopup(new Detail(Mdl));
        }
        private void RefreshPressed(object sender, EventArgs e)
        {
            data = null;
            countryList = null;
            Init();
        }

        private async void ExitStack2_Tapped(object sender, EventArgs e)
        {
            _ = noInternetstack2.RotateXTo(90, 500, Easing.CubicOut);
            await Task.Delay(500);
            noInternetstack2.IsVisible = false;
            _ = noInternetstack2.RotateXTo(0, 5, Easing.CubicOut);
        }
    }
}
