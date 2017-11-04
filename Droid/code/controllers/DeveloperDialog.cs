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

namespace ProjectManager.Droid.code.controllers
{
    class DeveloperDialog : DialogFragment
    {
        private ImageButton iv_cancel;
        private List<Developer> listDevelopers;
        private RecyclerView rv_developers;


        private OnDeveloperListener  onDeveloperListener;
        private Context context;

        private readonly int NUM_COLUMNS = 1;


        public static DeveloperDialog NewInstace(Bundle bundle)
        {
            var fragment = new DeveloperDialog();
            fragment.Arguments = bundle;
            return fragment;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.dialog_developer, container, false);
            this.iv_cancel = view.FindViewById<ImageButton>(Resource.Id.iv_cancel);
            this.rv_developers = view.FindViewById<RecyclerView>(Resource.Id.developer_recycler_view);
            Java.Util.ArrayList arrayListDevelopers = (Java.Util.ArrayList)
                 ((Activity)this.Context).Intent.Extras.GetSerializable(MenuActivity.KEY_EXTRA_DEVELOPERS);
            if (arrayListDevelopers != null && !arrayListDevelopers.IsEmpty)
            {
                this.rv_developers.Visibility = ViewStates.Visible;
                this.listDevelopers = ConvertJavaListToCSharpList(arrayListDevelopers);
                InitRecyclerView(this.listDevelopers);
            }
            
            return view;
        }
      

        private void InitRecyclerView(List<Developer> listDevelopers)
        {
            DeveloperRecyclerViewAdapter projectRecyclerViewAdapter =
                 new DeveloperRecyclerViewAdapter(Resource.Layout.item_dialog, listDevelopers);

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

            public DeveloperRecyclerViewAdapter(int itemLayout, List<Developer> listDevelopers)
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
                myHolder.Get<TextView>(Resource.Id.name).Text = developer.first_name + " " + developer.last_name;
                myHolder.Get<TextView>(Resource.Id.ability).Text = developer.skills;
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
            void OnItemSelected(Developer dev);

            void OnDismissed(Exception e);
        }

    }
}