
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using GoogleGson;
using Newtonsoft.Json;
using ProjectManager.Droid.code.entity;
using ProjectManager.Droid.Controllers;

namespace ProjectManager.Droid.code.controllers
{

        public class ProjectFragment : Android.Support.V4.App.Fragment
        {
            private RecyclerView rvProjects;
            private ImageView ivNoProjects;
            private FloatingActionButton btn_add_project;
            private readonly int NUM_COLUMNS = 1;
            private readonly String TAG = nameof(ProjectFragment);
            private List<Project> listProjects;

            private ProjectFragment projectsFragment;


            public static ProjectFragment newInstance()
            {
                ProjectFragment projectsFragment = new ProjectFragment();
                Bundle bundle = new Bundle();
                bundle.PutString("TAG", "ProjectsFragment");
                bundle.PutString("TAB_NAME", "Projects");
                projectsFragment.Arguments = bundle;
                return projectsFragment;
            }


            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                View view = inflater.Inflate(Resource.Layout.fragment_project, container, false);
                InitComponents(view);
                return view;
            }



            private void InitComponents(View view)
            {
                this.rvProjects = view.FindViewById<RecyclerView>(Resource.Id.project_recycler_view);
                this.ivNoProjects = view.FindViewById<ImageView>(Resource.Id.iv_no_projects);
                this.btn_add_project = view.FindViewById<FloatingActionButton>(Resource.Id.btn_add_project);
           
                Java.Util.ArrayList arrayListProjects = (Java.Util.ArrayList)
                ((Activity)this.Context).Intent.Extras.GetSerializable(MenuActivity.KEY_EXTRA_PROJECTS);

                Java.Util.ArrayList arrayListDevelopers = (Java.Util.ArrayList)
                ((Activity)this.Context).Intent.Extras.GetSerializable(MenuActivity.KEY_EXTRA_DEVELOPERS);
            
                List<Developer> listDevelopers = ConvertJavaListToCSharpList2(arrayListDevelopers);

                String developerJson = JsonConvert.SerializeObject(listDevelopers);

                this.btn_add_project.Click += (sender, e) => {
                Intent intent = new Intent(Context, typeof(ProjectActivity));
                intent.PutExtra(MenuActivity.KEY_EXTRA_DEVELOPERS_OBJECT, developerJson);
                StartActivity(intent);
                };

                if(arrayListProjects != null && !arrayListProjects.IsEmpty)
                {
                    this.ivNoProjects.Visibility = ViewStates.Gone;
                    this.rvProjects.Visibility = ViewStates.Visible;
                    this.listProjects = ConvertJavaListToCSharpList(arrayListProjects);
                    InitRecyclerView(this.listProjects);
                }
            }


        private List<Project> ConvertJavaListToCSharpList(Java.Util.ArrayList arrayListProjects)
        {
            List<Project> lstProjects = new List<Project>();
            for (int i = 0; i < arrayListProjects.Size(); i++)
            {
                lstProjects.Add((ProjectManager.Droid.code.entity.Project)arrayListProjects.Get(i));
            }
            return lstProjects;
        }


        private List<Developer> ConvertJavaListToCSharpList2(Java.Util.ArrayList arrayListDevelopers)
        {
            List<Developer> lstDevelopers = new List<Developer>();
            for (int i = 0; i < arrayListDevelopers.Size(); i++)
            {
                lstDevelopers.Add((ProjectManager.Droid.code.entity.Developer)arrayListDevelopers.Get(i));
            }
            return lstDevelopers;
        }


            private void InitRecyclerView(List<Project> listProjects)
            {
            ProjectRecyclerViewAdapter projectRecyclerViewAdapter =
                new ProjectRecyclerViewAdapter(Resource.Layout.card_project, listProjects);
            GridLayoutManager gridLayoutManager = new GridLayoutManager(Context, NUM_COLUMNS);
            this.rvProjects.SetLayoutManager(gridLayoutManager);
            this.rvProjects.SetAdapter(projectRecyclerViewAdapter);
            }
          
            class ProjectRecyclerViewAdapter : RecyclerView.Adapter
            {
                private readonly int itemLayout;
                private readonly List<Project> listProjects;

                public ProjectRecyclerViewAdapter(int itemLayout, List<Project> listProjects)
                {
                    this.itemLayout = itemLayout;
                    this.listProjects = listProjects;
                }

            public override int ItemCount => listProjects.Count;

                public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
                {
                    View view = LayoutInflater.From(parent.Context).Inflate(itemLayout, parent, false);
                    return new GofBaseAdapter(view);
                }

                public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
                {
                    GofBaseAdapter myHolder = holder as GofBaseAdapter;
                    Project project = this.listProjects[position];
                    myHolder.Get<TextView>(Resource.Id.title).Text = project.name;
                    myHolder.Get<TextView>(Resource.Id.description).Text = project.description;
                }

                public override long GetItemId(int position)
                {
                    return base.GetItemId(position);
                }

                public override int GetItemViewType(int position)
                {
                    return base.GetItemViewType(position);
                }

            }
        }
}
