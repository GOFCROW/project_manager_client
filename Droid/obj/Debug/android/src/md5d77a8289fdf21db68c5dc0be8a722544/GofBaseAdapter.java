package md5d77a8289fdf21db68c5dc0be8a722544;


public class GofBaseAdapter
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ProjectManager.Droid.code.controllers.GofBaseAdapter, ProjectManager.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", GofBaseAdapter.class, __md_methods);
	}


	public GofBaseAdapter (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == GofBaseAdapter.class)
			mono.android.TypeManager.Activate ("ProjectManager.Droid.code.controllers.GofBaseAdapter, ProjectManager.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
