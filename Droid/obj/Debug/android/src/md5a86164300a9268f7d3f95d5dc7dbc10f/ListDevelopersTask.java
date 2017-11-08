package md5a86164300a9268f7d3f95d5dc7dbc10f;


public class ListDevelopersTask
	extends md5a86164300a9268f7d3f95d5dc7dbc10f.AsyncTaskGOF
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPreExecute:()V:GetOnPreExecuteHandler\n" +
			"n_doInBackground:([Ljava/lang/Object;)Ljava/lang/Object;:GetDoInBackground_arrayLjava_lang_Object_Handler\n" +
			"n_onPostExecute:(Ljava/lang/Object;)V:GetOnPostExecute_Ljava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("ProjectManager.Droid.code.logic.tasks.ListDevelopersTask, ProjectManager.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ListDevelopersTask.class, __md_methods);
	}


	public ListDevelopersTask ()
	{
		super ();
		if (getClass () == ListDevelopersTask.class)
			mono.android.TypeManager.Activate ("ProjectManager.Droid.code.logic.tasks.ListDevelopersTask, ProjectManager.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onPreExecute ()
	{
		n_onPreExecute ();
	}

	private native void n_onPreExecute ();


	public java.lang.Object doInBackground (java.lang.Object[] p0)
	{
		return n_doInBackground (p0);
	}

	private native java.lang.Object n_doInBackground (java.lang.Object[] p0);


	public void onPostExecute (java.lang.Object p0)
	{
		n_onPostExecute (p0);
	}

	private native void n_onPostExecute (java.lang.Object p0);

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
