using System;
using UnityEngine;

namespace ns0
{
	// Token: 0x020002A9 RID: 681
	public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
	{
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000EA6 RID: 3750 RVA: 0x0000CD65 File Offset: 0x0000AF65
		public static T Instance
		{
			get
			{
				return MonoSingleton<T>._instance;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000EA7 RID: 3751 RVA: 0x0000CD6C File Offset: 0x0000AF6C
		public static bool Boolean_0
		{
			get
			{
				return null != MonoSingleton<T>.Instance;
			}
		}

		// Token: 0x06000EA8 RID: 3752 RVA: 0x0000CD7E File Offset: 0x0000AF7E
		protected virtual void Awake()
		{
			if (MonoSingleton<T>._instance == null)
			{
				MonoSingleton<T>._instance = this as T;
			}
		}

		// Token: 0x06000EA9 RID: 3753 RVA: 0x0000CDA2 File Offset: 0x0000AFA2
		private void OnApplicationQuit()
		{
			if (!AppManager.s_allowQuit)
			{
				return;
			}
			MonoSingleton<T>._instance = (T)((object)null);
		}

		// Token: 0x04000D28 RID: 3368
		protected static T _instance;
	}
}
