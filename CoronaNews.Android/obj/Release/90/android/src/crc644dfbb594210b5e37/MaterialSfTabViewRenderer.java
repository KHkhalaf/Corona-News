package crc644dfbb594210b5e37;


public class MaterialSfTabViewRenderer
	extends crc644dfbb594210b5e37.SfTabViewRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Syncfusion.XForms.Android.TabView.MaterialSfTabViewRenderer, Syncfusion.SfTabView.XForms.Android", MaterialSfTabViewRenderer.class, __md_methods);
	}


	public MaterialSfTabViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == MaterialSfTabViewRenderer.class)
			mono.android.TypeManager.Activate ("Syncfusion.XForms.Android.TabView.MaterialSfTabViewRenderer, Syncfusion.SfTabView.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public MaterialSfTabViewRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == MaterialSfTabViewRenderer.class)
			mono.android.TypeManager.Activate ("Syncfusion.XForms.Android.TabView.MaterialSfTabViewRenderer, Syncfusion.SfTabView.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public MaterialSfTabViewRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MaterialSfTabViewRenderer.class)
			mono.android.TypeManager.Activate ("Syncfusion.XForms.Android.TabView.MaterialSfTabViewRenderer, Syncfusion.SfTabView.XForms.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
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
