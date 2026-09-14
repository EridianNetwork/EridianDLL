using System;
using ns0;

// Token: 0x02000AAC RID: 2732
public class BadAssNetworkView : PhotonView
{
	// Token: 0x06004A22 RID: 18978 RVA: 0x000308CE File Offset: 0x0002EACE
	private new void Awake()
	{
		base.Awake();
	}

	// Token: 0x06004A23 RID: 18979 RVA: 0x00133428 File Offset: 0x00131628
	private void Start()
	{
		InstantiateManager component = MonoSingleton<AppManager>.Instance.GetComponent<InstantiateManager>();
		if (component != null)
		{
			component.method_1(base.gameObject);
		}
		NetworkManager component2 = MonoSingleton<AppManager>.Instance.GetComponent<NetworkManager>();
		if (component2 != null)
		{
			component2.method_4(this);
		}
	}

	// Token: 0x06004A24 RID: 18980 RVA: 0x00133470 File Offset: 0x00131670
	private new void OnDestroy()
	{
		AppManager prop_ = MonoSingleton<AppManager>.Instance;
		if (prop_ != null)
		{
			InstantiateManager component = prop_.GetComponent<InstantiateManager>();
			if (component != null)
			{
				component.method_2(base.gameObject);
			}
			NetworkManager component2 = prop_.GetComponent<NetworkManager>();
			if (component2 != null)
			{
				component2.method_5(this);
			}
		}
	}

	// Token: 0x06004A25 RID: 18981 RVA: 0x000308D6 File Offset: 0x0002EAD6
	public int method_19()
	{
		return base.Int32_1;
	}

	// Token: 0x06004A26 RID: 18982 RVA: 0x001334C0 File Offset: 0x001316C0
	public static BadAssNetworkView smethod_3(int int_0)
	{
		int count = MonoSingleton<AppManager>.Instance.GetComponent<NetworkManager>().List_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (MonoSingleton<AppManager>.Instance.GetComponent<NetworkManager>().List_0[i].method_19() == int_0)
			{
				return MonoSingleton<AppManager>.Instance.GetComponent<NetworkManager>().List_0[i];
			}
		}
		return null;
	}

	// Token: 0x06004A27 RID: 18983 RVA: 0x00133524 File Offset: 0x00131724
	public static Entity smethod_4(int int_0)
	{
		Entity entity = null;
		BadAssNetworkView badAssNetworkView = BadAssNetworkView.smethod_3(int_0);
		if (badAssNetworkView != null)
		{
			entity = (Entity)badAssNetworkView.GetComponent(typeof(Entity));
		}
		return entity;
	}
}
