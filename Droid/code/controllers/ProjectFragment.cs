using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using ProjectManager.Droid.code.entity;
using ProjectManager.Droid.Controllers;

namespace ProjectManager.Droid.code.controllers
{

        public class ProjectFragment : Android.Support.V4.App.Fragment
        {
            private RecyclerView rvDevelopers;
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
                View view = inflater.Inflate(Resource.Layout.fragment_developer, container, false);
                InitComponents(view);
                return base.OnCreateView(inflater, container, savedInstanceState);
            }



            private void InitComponents(View view)
            {
                this.rvDevelopers = view.FindViewById<RecyclerView>(Resource.Id.project_recycler_view);
                this.listProjects = (System.Collections.Generic.List<ProjectManager.Droid.code.entity.Project>)
                ((Activity)this.Context).Intent.Extras.GetSerializable(MenuActivity.KEY_EXTRA_PROJECTS);
                if(this.listProjects != null && this.listProjects.Count != 0)
                {
                    InitRecyclerView(this.listProjects);
                }
            }


            private void InitRecyclerView(List<Project> listProjects)
            {
            ProjectRecyclerViewAdapter projectRecyclerViewAdapter =
                new ProjectRecyclerViewAdapter(Resource.Layout.card_project, listProjects);
            this.rvDevelopers.SetAdapter(projectRecyclerViewAdapter);
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
