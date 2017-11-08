using System.Collections.Generic;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using ProjectManager.Droid.code.controllers;
using ProjectManager.Droid.code.entity;
using ProjectManager.Droid.code.logic.business;
using ProjectManager.Droid.code.logic.listeners;

namespace ProjectManager.Droid.Controllers
{
    [Activity(Label = "MenuActivity", MainLauncher = true, Theme = "@style/MyTheme",
              Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MenuActivity : GofCompatActivity, NotifyController
    {
        private DevelopersBusiness developersBusiness;
        private ProjectBusiness projectBusiness;
        private ProgressDialog progressDialog;


        private ViewPager vpPrincipal;
        private TabLayout tlPrincipal;

        public static readonly string KEY_EXTRA_DEVELOPERS = "KEY_EXTRA_DEVELOPERS";
        public static readonly string KEY_EXTRA_DEVELOPERS_OBJECT = "KEY_EXTRA_DEVELOPERS_OBJECT";
        public static readonly string KEY_EXTRA_PROJECTS = "KEY_EXTRA_PROJECTS";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            base.SetContentView(Resource.Layout.activity_menu);
            InitToolbarComponents(Resource.Id.toolbar, "Administrador de proyectos", false);
            InitComponents();

        }


        protected override void OnResume()
        {
            base.OnResume();
            progressDialog.Show();
            developersBusiness = new DevelopersBusiness(this, this);
            projectBusiness = new ProjectBusiness(this, this);
            developersBusiness.GetListDevelopers();
        }


        private void InitComponents()
        {
            this.vpPrincipal = FindViewById<ViewPager>(Resource.Id.viewpager);
            this.tlPrincipal = FindViewById<TabLayout>(Resource.Id.tabLayout);

            this.tlPrincipal.TabSelected += (object sender, TabLayout.TabSelectedEventArgs e) => { };
            this.vpPrincipal.AddOnPageChangeListener(new TabLayout.TabLayoutOnPageChangeListener(tlPrincipal));
            this.tlPrincipal.SetupWithViewPager(this.vpPrincipal);

            progressDialog = new ProgressDialog(this);
            progressDialog.SetMessage("Espere un momento mientras cargamos sus proyectos");
            progressDialog.SetCancelable(false);
        }

        private void InitViewPager(ViewPager viewPager)
        {
            GenericTabAdapter genericTabAdapter = new GenericTabAdapter(SupportFragmentManager, this);
            genericTabAdapter.AddFragment(DeveloperFragment.newInstance());
            genericTabAdapter.AddFragment(ProjectFragment.newInstance());
            viewPager.Adapter = genericTabAdapter;
            viewPager.OffscreenPageLimit = genericTabAdapter.Count;
        }


        /*
        * notif
        */
        public void Notify(object obj, string type)
        {
            if (type.Equals(DevelopersBusiness.NOTIFY_KEY))
            {
                this.Intent.PutExtra(KEY_EXTRA_DEVELOPERS, new Java.Util.ArrayList((List<Developer>)obj));
                projectBusiness.GetListProjects();
            }
            else if (type.Equals(ProjectBusiness.NOTIFY_KEY))
            {
                this.Intent.PutExtra(KEY_EXTRA_PROJECTS, new Java.Util.ArrayList((List<Project>)obj));
                progressDialog.Dismiss();
                InitViewPager(this.vpPrincipal);
            }
            else
            {
                progressDialog.Dismiss();
                Toast.MakeText(this, obj.ToString(), ToastLength.Short).Show();
            }
        }

    }
}
