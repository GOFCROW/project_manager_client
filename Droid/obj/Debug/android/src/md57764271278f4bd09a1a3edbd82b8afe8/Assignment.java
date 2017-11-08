package md57764271278f4bd09a1a3edbd82b8afe8;


public class Assignment
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ProjectManager.Droid.code.entity.Assignment, ProjectManager.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Assignment.class, __md_methods);
	}


	public Assignment ()
	{
		super ();
		if (getClass () == Assignment.class)
			mono.android.TypeManager.Activate ("ProjectManager.Droid.code.entity.Assignment, ProjectManager.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public Assignment (int p0, int p1, int p2, int p3, md57764271278f4bd09a1a3edbd82b8afe8.Developer p4, md57764271278f4bd09a1a3edbd82b8afe8.RoleDev p5)
	{
		super ();
		if (getClass () == Assignment.class)
			mono.android.TypeManager.Activate ("ProjectManager.Droid.code.entity.Assignment, ProjectManager.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:ProjectManager.Droid.code.entity.Developer, ProjectManager.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:ProjectManager.Droid.code.entity.RoleDev, ProjectManager.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0, p1, p2, p3, p4, p5 });
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
