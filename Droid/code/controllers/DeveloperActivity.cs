
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
    public class DeveloperActivity : GofCompatActivity, CompleteAsyncTask
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
            InitToolbarComponents(Resource.Id.toolbar, "Gestión de developers", true);
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
                this, Resource.Array.skills_array, Resource.Layout.custom_spinner_item);


            adapter.SetDropDownViewResource(Resource.Layout.custom_spinner_item);
            this.sp_area.Adapter = adapter;


            this.sp_experience.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerExpSelected);

            var adapter2 = ArrayAdapter.CreateFromResource(
                this, Resource.Array.exp_array, Resource.Layout.custom_spinner_item);

            adapter2.SetDropDownViewResource(Resource.Layout.custom_spinner_item);
            this.sp_experience.Adapter = adapter2;
        }


        void BtnSaveDeveloper(object sender, EventArgs e)
        {
            if (!ValidateComponents())
            {
                Toast.MakeText(this, "Por favor, revise sus campos", ToastLength.Short).Show();
                return;
            }
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

        private Boolean ValidateComponents()
        {
            if (this.et_name.Text.Equals("") || this.et_name.Text.Count() == 0 || this.et_name.Text.Equals(" "))
            {
                this.et_name.Error = "Debe introducir el nombre";
                return false;
            }

            if (this.et_last_name.Text.Equals("") || this.et_last_name.Text.Count() == 0 || this.et_last_name.Text.Equals(" "))
            {
                this.et_last_name.Error = "Debe introducir el apellido";
                return false;
            }

            if (this.et_mail.Text.Equals("") || this.et_mail.Text.Count() == 0 || this.et_mail.Text.Equals(" "))
            {
                this.et_mail.Error = "Debe introducir un correo";
                return false;
            }

            if (this.et_phone_number.Text.Equals("") || this.et_phone_number.Text.Count() == 0 || this.et_phone_number.Text.Equals(" "))
            {
                this.et_phone_number.Error = "Debe introducir un teléfono";
                return false;
            }
            return true;
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
