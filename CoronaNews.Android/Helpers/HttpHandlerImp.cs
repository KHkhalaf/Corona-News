using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CoronaNews.Droid.Helpers;
using CoronaNews.CustomControl;
using Xamarin.Android.Net;
using Xamarin.Forms;

[assembly: Dependency(typeof(HttpHandlerImp))]
namespace CoronaNews.Droid.Helpers
{
    public class HttpHandlerImp : IHttpHandler
    {
        public object GetHttpHandler()
        {
            var handler = new AndroidClientHandler();
            return handler;
        }
    }
}