
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace ProjectManager.Droid.code.controllers
{
    [Activity(Label = "ProjectActivity", Theme = "@style/MyTheme", Icon = "@drawable/icon")]
    public class ProjectActivity : AppCompatActivity
    {
        private EditText et_title;
        private EditText et_lenght;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_project);
        }
    }
}
