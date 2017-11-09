
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
using ProjectManager.Droid.code.entity;
using ProjectManager.Droid.Controllers;

namespace ProjectManager.Droid.code.controllers
{
    public class DeveloperFragment : Android.Support.V4.App.Fragment
    {

        private RecyclerView rvDevelopers;
        private ImageView ivNoDevelopers;
        private FloatingActionButton btn_add_dev;
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
            return view;
        }


        private void InitComponents(View view)
        {
            this.rvDevelopers = view.FindViewById<RecyclerView>(Resource.Id.developer_recycler_view);
            this.ivNoDevelopers = view.FindViewById<ImageView>(Resource.Id.iv_no_developers);
            Java.Util.ArrayList arrayListDevelopers = (Java.Util.ArrayList)
                ((Activity)this.Context).Intent.Extras.GetSerializable(MenuActivity.KEY_EXTRA_DEVELOPERS);

            this.btn_add_dev = view.FindViewById<FloatingActionButton>(Resource.Id.btn_add_dev);
            this.btn_add_dev.Click += (sender, e) => {
                StartActivity(new Intent(Context, typeof(DeveloperActivity)));
            };

            
            if (arrayListDevelopers != null && !arrayListDevelopers.IsEmpty)
            {
                this.ivNoDevelopers.Visibility = ViewStates.Gone;
                this.rvDevelopers.Visibility = ViewStates.Visible;
                this.listDevelopers = ConvertJavaListToCSharpList(arrayListDevelopers);
                InitRecyclerView(this.listDevelopers); 
            }
        }


        private List<Developer> ConvertJavaListToCSharpList(Java.Util.ArrayList arrayListDevelopers)
        {
            List<Developer> lstDevelopers = new List<Developer>();
            for (int i = 0; i < arrayListDevelopers.Size(); i++)
            {
                lstDevelopers.Add((ProjectManager.Droid.code.entity.Developer)arrayListDevelopers.Get(i));
            }
            return lstDevelopers;
        }

        private void InitRecyclerView(List<Developer> listDevelopers)
        {
            DeveloperRecyclerViewAdapter projectRecyclerViewAdapter =
                new DeveloperRecyclerViewAdapter(Resource.Layout.card_developer, listDevelopers);

            GridLayoutManager gridLayoutManager = new GridLayoutManager(Context, NUM_COLUMNS);
            this.rvDevelopers.SetLayoutManager(gridLayoutManager);
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
                Developer developer = this.listDevelopers[position];
                myHolder.Get<TextView>(Resource.Id.full_name).Text = developer.first_name + " " + developer.last_name;
                myHolder.Get<TextView>(Resource.Id.abilities).Text = developer.skills;
                myHolder.Get<TextView>(Resource.Id.projects).Text = "Experiencia " + developer.experience ;
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
