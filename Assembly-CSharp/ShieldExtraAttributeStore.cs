using System;

// Token: 0x020008D1 RID: 2257
public class ShieldExtraAttributeStore : ExtraAttributeStore
{
	// Token: 0x17000352 RID: 850
	// (get) Token: 0x06003E59 RID: 15961 RVA: 0x0002A190 File Offset: 0x00028390
	// (set) Token: 0x06003E5A RID: 15962 RVA: 0x0002A1A3 File Offset: 0x000283A3
	public static ShieldExtraAttributeStore ShieldExtraAttributeStore_0
	{
		get
		{
			if (ShieldExtraAttributeStore.s_extraAttributeStore == null)
			{
				ShieldExtraAttributeStore.smethod_4();
			}
			return ShieldExtraAttributeStore.s_extraAttributeStore;
		}
		protected set
		{
			ShieldExtraAttributeStore.s_extraAttributeStore = value;
		}
	}

	// Token: 0x06003E5B RID: 15963 RVA: 0x0002A1AB File Offset: 0x000283AB
	private static void smethod_4()
	{
		ShieldExtraAttributeStore.s_extraAttributeStore = new ShieldExtraAttributeStore();
		ExtraAttributeStore.smethod_3("Shield", ShieldExtraAttributeStore.s_extraAttributeStore);
	}

	// Token: 0x04002BD6 RID: 11222
	private static ShieldExtraAttributeStore s_extraAttributeStore;
}
