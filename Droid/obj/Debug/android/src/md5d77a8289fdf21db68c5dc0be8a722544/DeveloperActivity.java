package md5d77a8289fdf21db68c5dc0be8a722544;


public class DeveloperActivity
	extends md5d77a8289fdf21db68c5dc0be8a722544.GofCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("ProjectManager.Droid.code.controllers.DeveloperActivity, ProjectManager.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DeveloperActivity.class, __md_methods);
	}


	public DeveloperActivity ()
	{
		super ();
		if (getClass () == DeveloperActivity.class)
			mono.android.TypeManager.Activate ("ProjectManager.Droid.code.controllers.DeveloperActivity, ProjectManager.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
