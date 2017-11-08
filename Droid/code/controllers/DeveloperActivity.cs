
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using ProjectManager.Droid.code.entity;
using ProjectManager.Droid.code.logic.listeners;
using ProjectManager.Droid.code.logic.tasks;

namespace ProjectManager.Droid.code.controllers
{
    [Activity(Label = "DeveloperActivity", Theme = "@style/MyTheme", Icon = "@drawable/icon",
              ScreenOrientation = ScreenOrientation.Portrait)]
    public class DeveloperActivity : AppCompatActivity, CompleteAsyncTask
    {
        EditText et_name;
        EditText et_last_name;
        EditText et_mail;
        EditText et_phone_number;

        Spinner sp_area;
        Spinner sp_experience;

        Button btn_developer;

        String textArea, textExperience;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_developer);
            InitComponents();
            InitSpinners();
        }

        private void InitComponents()
        {
            this.et_name = FindViewById<EditText>(Resource.Id.et_name);
            this.et_last_name = FindViewById<EditText>(Resource.Id.et_last_name);
            this.et_mail = FindViewById<EditText>(Resource.Id.et_mail);
            this.et_phone_number = FindViewById<EditText>(Resource.Id.et_phone_number);

            this.sp_area = FindViewById<Spinner>(Resource.Id.sp_area);
            this.sp_experience = FindViewById<Spinner>(Resource.Id.sp_experience);

            this.btn_developer = FindViewById<Button>(Resource.Id.btn_developer);
            this.btn_developer.Click += BtnSaveDeveloper;
        }

        private void InitSpinners(){
            this.sp_area.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerAreaSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                this, Resource.Array.skills_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            this.sp_area.Adapter = adapter;


            this.sp_experience.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerExpSelected);
            var adapter2 = ArrayAdapter.CreateFromResource(
                this, Resource.Array.exp_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            this.sp_experience.Adapter = adapter2;
        }


        void BtnSaveDeveloper(object sender, EventArgs e)
        {
            Developer developer = new Developer();
            developer.id = 0;
            developer.first_name = this.et_name.Text;
            developer.last_name = this.et_last_name.Text;
            developer.email = this.et_mail.Text;
            developer.phone_number = this.et_phone_number.Text;
            developer.experience = textExperience;
            developer.skills = textArea;

            SaveDeveloperTask saveDeveloperTask = new SaveDeveloperTask(this,this,developer);
            saveDeveloperTask.Execute();
        }

        private void spinnerAreaSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            textArea = (string) spinner.GetItemAtPosition(e.Position);
        }

        private void spinnerExpSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            textExperience = (string)spinner.GetItemAtPosition(e.Position);
        }





        public void OnResponse(object result)
        {
            Toast.MakeText(this, "Desarrollador guardado correctamente", ToastLength.Short).Show();
            Finish();
        }

        public void OnError(string message)
        {
            Toast.MakeText(this,"Error al guardar Developer",ToastLength.Short).Show();
        }
    }
}
