using CoronaNews.CustomControl;
using CoronaNews.Resources;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoronaNews
{
    public partial class App : Application
    {

        private static App _instance;
        public static App Instance => _instance;
        public TimeSpan DefaultTaskDelay = TimeSpan.FromMilliseconds(500);
        public HttpMessageHandler HttpMessageHandler { get; set; }

        public App()
        {
            _instance = this;
            HttpMessageHandler = (System.Net.Http.HttpMessageHandler)DependencyService.Get<IHttpHandler>().GetHttpHandler();


            InitializeComponent();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjQ2NTMzQDMxMzgyZTMxMmUzMGdvMW9lTkpjTVpFU0JwZGNaK2xhWWhIQk5BQWx2NmxxMW9lQWxXOEgwakk9");


            MainPage = new MainPage();



            CrossMultilingual.Current.CurrentCultureInfo = CrossMultilingual.Current.DeviceCultureInfo;
            //Remember.LanguageCode == String.Empty ? CrossMultilingual.Current.DeviceCultureInfo : new CultureInfo(Remember.LanguageCode);




            if (Device.RuntimePlatform == Device.iOS)
            {
                DependencyService.Get<IFontLoader>().LoadFile("Oswald-Bold.ttf");
                DependencyService.Get<IFontLoader>().LoadFile("Oswald-BoldItalic.ttf");
                DependencyService.Get<IFontLoader>().LoadFile("Oswald-Demi-BoldItalic.ttf");
                DependencyService.Get<IFontLoader>().LoadFile("Oswald-Extra-LightItalic.ttf");
                DependencyService.Get<IFontLoader>().LoadFile("Oswald-ExtraLight.ttf");
                DependencyService.Get<IFontLoader>().LoadFile("Oswald-Heavy.ttf");
                DependencyService.Get<IFontLoader>().LoadFile("Oswald-HeavyItalic.ttf");
                DependencyService.Get<IFontLoader>().LoadFile("Oswald-Light.ttf");
                DependencyService.Get<IFontLoader>().LoadFile("Oswald-LightItalic.ttf");
                DependencyService.Get<IFontLoader>().LoadFile("Oswald-Medium.ttf");
                DependencyService.Get<IFontLoader>().LoadFile("Oswald-MediumItalic.ttf");
                DependencyService.Get<IFontLoader>().LoadFile("Oswald-Regular.ttf");
                DependencyService.Get<IFontLoader>().LoadFile("Oswald-RegularItalic.ttf");
                DependencyService.Get<IFontLoader>().LoadFile("Oswald-Stencil.ttf");
            }
        }




        public List<Language> GetLanguages()
        {
            return new List<Language>()
            {
                new Language()
                {
                    Name = AppResources.Lang_en,
                    code = "en-EN",
                },
                new Language()
                {
                    Name = AppResources.Lang_tr,
                    code = "tr-TR",
                },
                new Language()
                {
                    Name = AppResources.Lang_tr,
                    code = "ar-AR",
                }
            };
        }

        public bool CheckInternet()
        {
            bool c = true;
            if (!CrossConnectivity.Current.IsConnected)
            {
                Device.StartTimer(TimeSpan.FromSeconds(2), () =>
                {
                    var checkelse = CrossConnectivity.Current.IsConnected;

                    return !checkelse;
                });
                c = false;
            }
            return c;
        }

        public async void ShowPopup(Rg.Plugins.Popup.Pages.PopupPage p,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            try
            {
                await PopupNavigation.Instance.PushAsync(p, true);
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        public async void ClosePopup(Rg.Plugins.Popup.Pages.PopupPage p,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            try
            {
                Debug.WriteLine($"ClosePopup() <= {memberName} {sourceFilePath} ({sourceLineNumber})");
                await PopupNavigation.Instance.RemovePageAsync(p, true);
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        private class Busy : IDisposable
        {
            readonly object _sync = new object();
            readonly App _busyObject;

            public Busy(App busyObject)
            {
                _busyObject = busyObject;
                lock (_sync)
                {
                    _busyObject.IsBusy = true;
                }
            }

            public void Dispose()
            {
                lock (_sync)
                {
                    _busyObject.IsBusy = false;
                }
            }
        }

        private async void BackButtonPressed(object sender, EventArgs e)
        {
            using (new Busy(this))
            {
                try
                {

                }
                finally
                {
                    await Task.Delay(DefaultTaskDelay);
                }
            }
        }

    }

    public class Language
    {
        public string Name { get; set; }
        public string code { get; set; }
    }
}
