package md57764271278f4bd09a1a3edbd82b8afe8;


public class Project
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		java.io.Serializable
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ProjectManager.Droid.code.entity.Project, ProjectManager.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Project.class, __md_methods);
	}


	public Project ()
	{
		super ();
		if (getClass () == Project.class)
			mono.android.TypeManager.Activate ("ProjectManager.Droid.code.entity.Project, ProjectManager.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
