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
using ProjectManager.Droid.code.logic.tasks;
using ProjectManager.Droid.code.logic.listeners;
using ProjectManager.Droid.Controllers;
using Newtonsoft.Json;

namespace ProjectManager.Droid.code.controllers
{
    [Activity(Label = "ProjectActivity", Theme = "@style/MyTheme", Icon = "@drawable/icon")]
    public class ProjectActivity : GofCompatActivity, DeveloperDialog.OnDeveloperListener, CompleteAsyncTask
    {
        private EditText et_title;
        private EditText et_description;
        private EditText et_estimated_hours;


        private LinearLayout ly_developers;

        private List<Developer> lstDevelopers;
        private List<Assignment> lstAssignments;

        private String textNumber;
        private String textType;

        private Button btn_project;

        private ImageView iv_add_dev;
        private ImageView iv_no_team;

        private DeveloperDialog developerDialog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_project);
            InitToolbarComponents(Resource.Id.toolbar, "Gestión de proyectos", true);
            InitComponents();
        }

        private void InitComponents()
        {
            this.et_title = FindViewById<EditText>(Resource.Id.et_title);
            this.et_description = FindViewById<EditText>(Resource.Id.et_description);
            this.et_estimated_hours = FindViewById<EditText>(Resource.Id.et_estimated_hours);


            this.ly_developers = FindViewById<LinearLayout>(Resource.Id.ly_developers);

            this.btn_project = FindViewById<Button>(Resource.Id.btn_project);
            this.btn_project.Click += BtnSaveProject;
            this.iv_add_dev = FindViewById<ImageView>(Resource.Id.iv_add_dev);
            this.iv_add_dev.Click += BtnAddDeveloper;

            this.iv_no_team = FindViewById<ImageView>(Resource.Id.iv_no_team);

            this.lstAssignments = new List<Assignment>();
            this.lstDevelopers = new List<Developer>();


        }

        private void BtnAddDeveloper(object sender, EventArgs e)
        {

            string developersJson = Intent.Extras.GetString(MenuActivity.KEY_EXTRA_DEVELOPERS_OBJECT);
            List<Developer> listDevelopers = JsonConvert.DeserializeObject<List<Developer>>(developersJson);
            developerDialog = new DeveloperDialog(this, this, listDevelopers);
            developerDialog.Show();

        }


        private void BtnSaveProject(object sender, EventArgs e)
        {
            if (!ValidateComponents())
            {
                Toast.MakeText(this, "Por favor, revise sus campos", ToastLength.Short).Show();
                return;
            }
            Project project = new Project();
            project.id = 0;
            project.name = this.et_title.Text;
            project.description = this.et_description.Text;
            project.estimated_hours = Convert.ToInt16(this.et_estimated_hours.Text);
            project.enabled = "True";
            //prepare assignemtes
            project.assignment = lstAssignments;
            SaveProjectTask saveProjectTask = new SaveProjectTask(this, this, project);
            saveProjectTask.Execute();
        }


        private Boolean ValidateComponents()
        {
            if (this.et_title.Text.Equals("") || this.et_title.Text.Count() == 0 || this.et_title.Text.Equals(" "))
            {
                this.et_title.Error = "Debe introducir un título";
                return false;
            }

            if (this.et_description.Text.Equals("") || this.et_description.Text.Count() == 0 || this.et_title.Text.Equals(" "))
            {
                this.et_description.Error = "Debe introducir una descripción";
                return false;
            }

            if (this.et_estimated_hours.Text.Equals("") || this.et_estimated_hours.Text.Count() == 0 || this.et_title.Text.Equals(" "))
            {
                this.et_estimated_hours.Error = "Debe introducir un estimado de horas";
                return false;
            }
            return true;
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


        private void LoadDeveloperLinearLayout(List<Developer> lstAssignments)
        {
            ly_developers.RemoveAllViews();

            foreach (Developer assignment in lstAssignments)
            {
                var inflater = Application.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                View view = inflater.Inflate(Resource.Layout.item_developer, null, true);
                ((TextView)view.FindViewById(Resource.Id.name)).Text = assignment.first_name + " " + assignment.last_name;
                ((ImageView)view.FindViewById(Resource.Id.iv_delete)).Tag = ly_developers.ChildCount;
                ((ImageView)view.FindViewById(Resource.Id.iv_delete)).Click += OnClickRemoveDeveloper;
                ly_developers.AddView(view);
            }

        }

        private void OnClickRemoveDeveloper(object sender, EventArgs e)
        {
            var button = (ImageView)sender;
            int posToRemove = (int)button.Tag;

            lstAssignments.RemoveAt(posToRemove);
            lstDevelopers.RemoveAt(posToRemove);
            ly_developers.RemoveViewAt(posToRemove);
        }
        public void OnDeveloperSelected(Developer dev)
        {
            developerDialog.Dismiss();
            Assignment assignment = new Assignment();

            if (lstDevelopers.Count() == 0)
            {
                lstDevelopers.Add(dev);
                assignment.fk_dev = dev.id;
                assignment.hours_worked = 10;
                lstAssignments.Add(assignment);
                this.iv_no_team.Visibility = ViewStates.Gone;
                LoadDeveloperLinearLayout(lstDevelopers);
            }

            if (!lstDevelopers.Contains(dev))
            {
                lstDevelopers.Add(dev);
                assignment.fk_dev = dev.id;
                assignment.hours_worked = 10;
                lstAssignments.Add(assignment);
                this.iv_no_team.Visibility = ViewStates.Gone;
                LoadDeveloperLinearLayout(lstDevelopers);
            }
        }

        public void OnDismissed(Exception e)
        {
            //canceled
            throw new NotImplementedException();
        }

        public void OnResponse(object result)
        {
            Toast.MakeText(this, "Proyecto guardado correctamente", ToastLength.Short).Show();
            Finish();
        }

        public void OnError(string message)
        {
            Toast.MakeText(this, "Error al guardar Proyecto", ToastLength.Short).Show();
        }
    }
}