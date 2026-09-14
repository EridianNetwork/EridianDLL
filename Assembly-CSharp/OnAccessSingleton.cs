using System;
using ns0;

// Token: 0x020003C2 RID: 962
public abstract class OnAccessSingleton<Interface, OnlineImpl, OfflineImpl> where OnlineImpl : Interface, new() where OfflineImpl : Interface, new()
{
	// Token: 0x17000147 RID: 327
	// (get) Token: 0x06001864 RID: 6244 RVA: 0x00081708 File Offset: 0x0007F908
	public static Interface Prop_0
	{
		get
		{
			if (OnAccessSingleton<Interface, OnlineImpl, OfflineImpl>.gInstance == null)
			{
				if (!MonoSingleton<AppManager>.Instance.m_offlineMode)
				{
					OnAccessSingleton<Interface, OnlineImpl, OfflineImpl>.gInstance = (Interface)((object)((default(OnlineImpl) == null) ? new OnlineImpl() : default(OnlineImpl)));
				}
				else
				{
					OnAccessSingleton<Interface, OnlineImpl, OfflineImpl>.gInstance = (Interface)((object)((default(OfflineImpl) == null) ? new OfflineImpl() : default(OfflineImpl)));
				}
			}
			return OnAccessSingleton<Interface, OnlineImpl, OfflineImpl>.gInstance;
		}
	}

	// Token: 0x04001076 RID: 4214
	private static Interface gInstance;
}
