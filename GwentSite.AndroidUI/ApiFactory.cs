using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GwentSite.ApiWrapper;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ModernHttpClient;

namespace GwentSite.AndroidUI
{
    public class ApiFactory
    {
        private static Client _apiInstance;
        public static Client GetInstance()
        {
            if (_apiInstance == null)
            {
                _apiInstance = new Client();
            }
            return _apiInstance;
        }
    }
}