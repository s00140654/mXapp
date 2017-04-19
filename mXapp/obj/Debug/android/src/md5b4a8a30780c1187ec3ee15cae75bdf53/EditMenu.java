package md5b4a8a30780c1187ec3ee15cae75bdf53;


public class EditMenu
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("mXapp.Resources.layout.EditMenu, mXapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", EditMenu.class, __md_methods);
	}


	public EditMenu () throws java.lang.Throwable
	{
		super ();
		if (getClass () == EditMenu.class)
			mono.android.TypeManager.Activate ("mXapp.Resources.layout.EditMenu, mXapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
