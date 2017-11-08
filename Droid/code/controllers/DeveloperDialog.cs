using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ProjectManager.Droid.code.entity;
using Android.Support.V7.Widget;
using ProjectManager.Droid.Controllers;
using Newtonsoft.Json;

namespace ProjectManager.Droid.code.controllers
{
    class DeveloperDialog : Dialog
    {
        private ImageButton iv_cancel;
        private List<Developer> listDevelopers;
        private RecyclerView rv_developers;


        public OnDeveloperListener onDeveloperListener;
        private Context context;

        private readonly int NUM_COLUMNS = 1;

        public DeveloperDialog(Context context, OnDeveloperListener onDeveloperListener,List<Developer> listDevelopers ) : base(context)
        {
            this.context = context;
            this.onDeveloperListener = onDeveloperListener;
            this.listDevelopers = listDevelopers;
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature((int)WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.dialog_developer);
            initComponents();
        }

        private void initComponents()
        {

            this.iv_cancel = FindViewById<ImageButton>(Resource.Id.iv_cancel);
            this.rv_developers = FindViewById<RecyclerView>(Resource.Id.developer_recycler_view);

            if (listDevelopers != null && listDevelopers.Count != 0)
            {
                this.rv_developers.Visibility = ViewStates.Visible;          
                InitRecyclerView(this.listDevelopers);
            }



        }



        private void InitRecyclerView(List<Developer> listDevelopers)
        {
            DeveloperRecyclerViewAdapter projectRecyclerViewAdapter =
                 new DeveloperRecyclerViewAdapter(Resource.Layout.item_dialog, listDevelopers, onDeveloperListener, rv_developers);

            GridLayoutManager gridLayoutManager = new GridLayoutManager(Context, NUM_COLUMNS);
            this.rv_developers.SetLayoutManager(gridLayoutManager);
            this.rv_developers.SetAdapter(projectRecyclerViewAdapter);
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

        class DeveloperRecyclerViewAdapter : RecyclerView.Adapter
        {
            private readonly int itemLayout;
            private readonly List<Developer> listDevelopers;
            private OnDeveloperListener onDeveloperListener;
            private RecyclerView recyclerView;

            public DeveloperRecyclerViewAdapter(int itemLayout, List<Developer> listDevelopers, OnDeveloperListener onDeveloperListener, RecyclerView recyclerView)
            {
                this.itemLayout = itemLayout;
                this.listDevelopers = listDevelopers;
                this.onDeveloperListener = onDeveloperListener;
                this.recyclerView = recyclerView;

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
                myHolder.Get<TextView>(Resource.Id.name).Text = developer.first_name + " " + developer.last_name;
                myHolder.Get<TextView>(Resource.Id.ability).Text = developer.skills;
                myHolder.ItemView.Click += OnDeveloperSelected;



            }

            void OnDeveloperSelected(object sender, EventArgs e)
            {
                int position = recyclerView.GetChildAdapterPosition((View)sender);
                Developer dev = listDevelopers.ElementAt(position);
                onDeveloperListener.OnDeveloperSelected(dev);
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

        public interface OnDeveloperListener
        {
            void OnDeveloperSelected(Developer dev);

            void OnDismissed(Exception e);
        }

    }
}