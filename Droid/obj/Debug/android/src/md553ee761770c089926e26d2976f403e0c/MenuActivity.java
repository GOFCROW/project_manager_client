package md553ee761770c089926e26d2976f403e0c;


public class MenuActivity
	extends md5d77a8289fdf21db68c5dc0be8a722544.GofCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"";
		mono.android.Runtime.register ("ProjectManager.Droid.Controllers.MenuActivity, ProjectManager.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MenuActivity.class, __md_methods);
	}


	public MenuActivity ()
	{
		super ();
		if (getClass () == MenuActivity.class)
			mono.android.TypeManager.Activate ("ProjectManager.Droid.Controllers.MenuActivity, ProjectManager.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();

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
