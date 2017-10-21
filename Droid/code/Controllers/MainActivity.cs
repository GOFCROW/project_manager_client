
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
using ProjectManager.Droid.code.logic.business;
using ProjectManager.Droid.code.logic.listeners;

namespace ProjectManager.Droid.Controllers
{
    [Activity(Label = "MainActivity", MainLauncher = true, Theme = "@style/MyTheme", Icon = "@drawable/icon")]
    public class MainActivity : Activity, NotifyController
    {
        private DevelopersBusiness developersBusiness;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            base.SetContentView(Resource.Layout.activity_menu);
            developersBusiness = new DevelopersBusiness(this.BaseContext, this);
            //developerBusiness = new DevelopersBusiness(MainActivity.cont,MainActivity.this);
            developersBusiness.GetListDevelopers();
        }

        public void Notify(object obj, string type)
        {
           
        }

    }
}
