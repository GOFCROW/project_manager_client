
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using ProjectManager.Droid.code.entity;
using ProjectManager.Droid.Controllers;

namespace ProjectManager.Droid.code.controllers
{
    public class DeveloperFragment : Android.Support.V4.App.Fragment
    {

        private RecyclerView rvDevelopers;
        private readonly int NUM_COLUMNS = 1;
        private readonly String TAG = nameof(DeveloperFragment);
        private List<Developer> listDevelopers;

        private DeveloperFragment developerFragment;


        public static DeveloperFragment newInstance()
        {
            DeveloperFragment developerFragment = new DeveloperFragment();
            Bundle bundle = new Bundle();
            bundle.PutString("TAG", "DeveloperFragment");
            bundle.PutString("TAB_NAME", "Developers");
            developerFragment.Arguments = bundle;
            return developerFragment;
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
            this.listDevelopers = (System.Collections.Generic.List<ProjectManager.Droid.code.entity.Developer>)
            ((Activity)this.Context).Intent.Extras.GetSerializable(MenuActivity.KEY_EXTRA_DEVELOPERS);
            if (this.listDevelopers != null && this.listDevelopers.Count != 0)
            {
                InitRecyclerView(this.listDevelopers);
            }
        }


        private void InitRecyclerView(List<Developer> listDevelopers)
        {
            DeveloperRecyclerViewAdapter projectRecyclerViewAdapter =
                new DeveloperRecyclerViewAdapter(Resource.Layout.card_developer, listDevelopers);
            this.rvDevelopers.SetAdapter(projectRecyclerViewAdapter);
        }


        class DeveloperRecyclerViewAdapter : RecyclerView.Adapter
        {
            private readonly int itemLayout;
            private readonly List<Developer> listDevelopers;

            public DeveloperRecyclerViewAdapter(int itemLayout,List<Developer> listDevelopers)
            {
                this.itemLayout = itemLayout;
                this.listDevelopers = listDevelopers;
            }

            public override int ItemCount => listDevelopers.Count();

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
