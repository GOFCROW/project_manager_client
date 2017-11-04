
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
using ProjectManager.Droid.code.entity;

namespace ProjectManager.Droid.code.controllers
{
    [Activity(Label = "ProjectActivity", Theme = "@style/MyTheme", Icon = "@drawable/icon")]
    public class ProjectActivity : AppCompatActivity,DeveloperDialog.OnDeveloperListener
    {
        private EditText et_title;
        private EditText et_description;

        private Spinner sp_type;
        private Spinner sp_number;

        private LinearLayout ly_developers;

        private List<Developer> lstDevelopers;
        private List<Assignment> lstAssignments;

        private String textNumber;
        private String textType;

        private Button btn_project;

        private ImageView iv_add_dev;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_project);
            InitComponents();
            InitSpinners();
        }

        private void InitComponents()
        {
            this.et_title = FindViewById<EditText>(Resource.Id.et_title);
            this.et_description = FindViewById<EditText>(Resource.Id.et_description);

            this.sp_number = FindViewById<Spinner>(Resource.Id.sp_number);
            this.sp_type = FindViewById<Spinner>(Resource.Id.sp_type);

            this.ly_developers = FindViewById<LinearLayout>(Resource.Id.ly_developers);

            this.btn_project = FindViewById<Button>(Resource.Id.btn_project);
            this.btn_project.Click += BtnSaveProject;
            this.iv_add_dev = FindViewById<ImageView>(Resource.Id.iv_add_dev);
            this.iv_add_dev.Click += BtnAddDeveloper;

            this.lstAssignments = new List<Assignment>();
            this.lstDevelopers = new List<Developer>();

            
        }

        private void InitSpinners()
        {
            this.sp_number.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerNumberSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                this, Resource.Array.number_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            this.sp_number.Adapter = adapter;


            this.sp_type.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerTypeSelected);
            var adapter2 = ArrayAdapter.CreateFromResource(
                this, Resource.Array.type_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            this.sp_type.Adapter = adapter2;
        }


        private void BtnAddDeveloper(object sender, EventArgs e)
        {
            Project project = new Project();
            project.id = 0;
            project.name = this.et_title.Text;
            project.description = this.et_description.Text;
            project.estimated_hours = textNumber + " " + textType;
                
        }

        private void BtnSaveProject(object sender, EventArgs e)
        {
            Project project = new Project();
            project.id = 0;
            project.name = this.et_title.Text;
            project.description = this.et_description.Text;
            project.estimated_hours = textNumber + " " + textType;
        }


        private void spinnerNumberSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            textNumber = (string)spinner.GetItemAtPosition(e.Position);
        }

        private void spinnerTypeSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            textType = (string)spinner.GetItemAtPosition(e.Position);
        }

        public void OnItemSelected(Developer dev)
        {
            throw new NotImplementedException();
        }

        public void OnDismissed(Exception e)
        {
            throw new NotImplementedException();
        }
    }
}
