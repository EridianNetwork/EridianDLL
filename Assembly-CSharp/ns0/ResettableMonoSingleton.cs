using System;

namespace ns0
{
	// Token: 0x020002AA RID: 682
	public abstract class ResettableMonoSingleton<T> : MonoSingleton<T> where T : MonoSingleton<T>
	{
		// Token: 0x06000EAB RID: 3755 RVA: 0x0000CDBF File Offset: 0x0000AFBF
		protected override void Awake()
		{
			base.Awake();
		}

		// Token: 0x06000EAC RID: 3756 RVA: 0x0000CDC7 File Offset: 0x0000AFC7
		public virtual void vmethod_0()
		{
			MonoSingleton<T>._instance = (T)((object)null);
		}

		// Token: 0x06000EAD RID: 3757 RVA: 0x0000CDD4 File Offset: 0x0000AFD4
		protected virtual void OnDestroy()
		{
			if (this == MonoSingleton<T>.Instance)
			{
				this.vmethod_0();
			}
		}
	}
}
