package md57764271278f4bd09a1a3edbd82b8afe8;


public class RoleDev
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ProjectManager.Droid.code.entity.RoleDev, ProjectManager.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", RoleDev.class, __md_methods);
	}


	public RoleDev ()
	{
		super ();
		if (getClass () == RoleDev.class)
			mono.android.TypeManager.Activate ("ProjectManager.Droid.code.entity.RoleDev, ProjectManager.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public RoleDev (int p0, java.lang.String p1)
	{
		super ();
		if (getClass () == RoleDev.class)
			mono.android.TypeManager.Activate ("ProjectManager.Droid.code.entity.RoleDev, ProjectManager.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
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
