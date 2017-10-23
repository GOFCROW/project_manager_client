using System;
using System.Collections.Generic;
using Android.Content;
using Android.Support.V4.App;

namespace ProjectManager.Droid.code.controllers
{
    public class GenericTabAdapter : FragmentPagerAdapter
    {
        private Context context;
        private readonly String KEY = "TAG";
        private readonly String KEY_TAB_NAME = "TAB_NAME";
        private static List<Fragment> fragmentList = new List<Fragment>();

        public GenericTabAdapter(FragmentManager fragmentManager ,Context context) : base(fragmentManager)
        {
            this.context = context; 
        }

        public override int Count => fragmentList.Count;

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return fragmentList[position].Arguments.GetCharSequenceFormatted(KEY_TAB_NAME);
        }


        public void AddFragment(Fragment fragment)
        {
            if(!ContainsFragment(fragment))
            {
                fragmentList.Add(fragment);
            }
        }

        public override Fragment GetItem(int position)
        {
            return fragmentList[position];
        }

        private Boolean ContainsFragment(Fragment fragmentToAdd)
        {
            foreach (Fragment fragment in fragmentList)
            {
                if (fragment.Arguments.Get(KEY).Equals(fragmentToAdd.Arguments.GetString(KEY)))
                {
                    return true;
                }
            }
            return false;

        }
    }
}
