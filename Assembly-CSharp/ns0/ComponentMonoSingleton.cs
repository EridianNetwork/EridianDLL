using System;

namespace ns0
{
	// Token: 0x020002AE RID: 686
	public abstract class ComponentMonoSingleton<T> where T : class, new()
	{
		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000EB7 RID: 3767 RVA: 0x0000CE7F File Offset: 0x0000B07F
		public static T Instance
		{
			get
			{
				return ComponentMonoSingleton<T>.gparam_0;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000EB8 RID: 3768 RVA: 0x0000CE86 File Offset: 0x0000B086
		public static bool Boolean_0
		{
			get
			{
				return null != ComponentMonoSingleton<T>.gparam_0;
			}
		}

		// Token: 0x06000EB9 RID: 3769 RVA: 0x0000CE98 File Offset: 0x0000B098
		public static T smethod_0()
		{
			ComponentMonoSingleton<T>.bool_0 = true;
			ComponentMonoSingleton<T>.gparam_0 = new T();
			ComponentMonoSingleton<T>.bool_0 = false;
			return ComponentMonoSingleton<T>.gparam_0;
		}

		// Token: 0x04000D33 RID: 3379
		protected static T gparam_0;

		// Token: 0x04000D34 RID: 3380
		protected static bool bool_0;
	}
}
