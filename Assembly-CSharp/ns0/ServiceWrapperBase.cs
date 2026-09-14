using System;

namespace ns0
{
	// Token: 0x020002AD RID: 685
	public abstract class ServiceWrapperBase<T> where T : class, new()
	{
		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000EB4 RID: 3764 RVA: 0x0000CE44 File Offset: 0x0000B044
		public static T Instance
		{
			get
			{
				if (ServiceWrapperBase<T>._instance == null)
				{
					ServiceWrapperBase<T>._isInitializing = true;
					ServiceWrapperBase<T>._instance = new T();
					ServiceWrapperBase<T>._isInitializing = false;
				}
				return ServiceWrapperBase<T>._instance;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000EB5 RID: 3765 RVA: 0x0000CE6D File Offset: 0x0000B06D
		public static bool HasInstance
		{
			get
			{
				return null != ServiceWrapperBase<T>._instance;
			}
		}

		// Token: 0x04000D31 RID: 3377
		protected static T _instance;

		// Token: 0x04000D32 RID: 3378
		protected static bool _isInitializing;
	}
}
