using System;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ProjectManager.Droid.code.controllers
{
    public class GofBaseAdapter : RecyclerView.ViewHolder
    {
        private View view;

        public GofBaseAdapter(View view) : base(view)
        {
            this.view = view;
        }

        public T Get<T>(int id) where T : View
        {
            SparseArray<View> viewHolder = (SparseArray<View>)view.Tag;
            if (viewHolder == null)
            {
                viewHolder = new SparseArray<View>();
                view.Tag = viewHolder;
            }
            View childView = viewHolder.Get(id);
            if (childView == null)
            {
                childView = view.FindViewById(id);
                viewHolder.Put(id, childView);
            }
            return (T)childView;
        }
       
    }
}
