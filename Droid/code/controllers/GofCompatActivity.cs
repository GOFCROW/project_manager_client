using System;
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace ProjectManager.Droid.code.controllers
{
    public abstract class GofCompatActivity : AppCompatActivity
    {
       
        public void InitToolbarComponents(int viewId, string tittle, bool isDisplayHomeButton)
        {
            Toolbar toolbar = (Toolbar)FindViewById(viewId);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = tittle;
            if(isDisplayHomeButton)
            {
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetDisplayShowHomeEnabled(true);
                toolbar.NavigationClick += OnBackHomeClickListener;
            }
        }


        private void OnBackHomeClickListener(object sender, EventArgs e)
        {
            OnBackPressed();
        }

    }
}
