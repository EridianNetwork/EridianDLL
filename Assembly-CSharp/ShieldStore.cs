using System;

// Token: 0x020008E8 RID: 2280
public class ShieldStore
{
	// Token: 0x17000359 RID: 857
	// (get) Token: 0x06003ECF RID: 16079 RVA: 0x0002A505 File Offset: 0x00028705
	// (set) Token: 0x06003ED0 RID: 16080 RVA: 0x0002A51D File Offset: 0x0002871D
	public static ShieldStore ShieldStore_0
	{
		get
		{
			if (ShieldStore.s_shieldStore == null)
			{
				ShieldStore.s_shieldStore = new ShieldStore();
			}
			return ShieldStore.s_shieldStore;
		}
		protected set
		{
			ShieldStore.s_shieldStore = value;
		}
	}

	// Token: 0x04002C30 RID: 11312
	public ShieldAttribute m_shieldAttr = new ShieldAttribute();

	// Token: 0x04002C31 RID: 11313
	private static ShieldStore s_shieldStore;
}
