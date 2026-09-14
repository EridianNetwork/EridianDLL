using System;

// Token: 0x020008D0 RID: 2256
public class WeaponExtraAttributeStore : ExtraAttributeStore
{
	// Token: 0x17000351 RID: 849
	// (get) Token: 0x06003E55 RID: 15957 RVA: 0x0002A15A File Offset: 0x0002835A
	// (set) Token: 0x06003E56 RID: 15958 RVA: 0x0002A16D File Offset: 0x0002836D
	public static WeaponExtraAttributeStore WeaponExtraAttributeStore_0
	{
		get
		{
			if (WeaponExtraAttributeStore.s_extraAttributeStore == null)
			{
				WeaponExtraAttributeStore.smethod_4();
			}
			return WeaponExtraAttributeStore.s_extraAttributeStore;
		}
		protected set
		{
			WeaponExtraAttributeStore.s_extraAttributeStore = value;
		}
	}

	// Token: 0x06003E57 RID: 15959 RVA: 0x0002A175 File Offset: 0x00028375
	private static void smethod_4()
	{
		WeaponExtraAttributeStore.s_extraAttributeStore = new WeaponExtraAttributeStore();
		ExtraAttributeStore.smethod_3("Weapon", WeaponExtraAttributeStore.s_extraAttributeStore);
	}

	// Token: 0x04002BD5 RID: 11221
	private static WeaponExtraAttributeStore s_extraAttributeStore;
}
