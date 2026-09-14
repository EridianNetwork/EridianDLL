using System;
using System.Collections.Generic;
using XsdSettings;

// Token: 0x0200031E RID: 798
internal class CraftingServiceOffline : ICraftingService
{
	// Token: 0x06001366 RID: 4966 RVA: 0x0000EF48 File Offset: 0x0000D148
	public void imethod_0(OnSmeltWeapon onSmeltWeapon_0, int int_0)
	{
		if (onSmeltWeapon_0 != null)
		{
			onSmeltWeapon_0(SmeltResult.Unknown, new Dictionary<MaterialType, int>());
		}
	}

	// Token: 0x06001367 RID: 4967 RVA: 0x0000EF59 File Offset: 0x0000D159
	public void imethod_1(OnCraftWeapon onCraftWeapon_0, WeaponType weaponType_0)
	{
		if (onCraftWeapon_0 != null)
		{
			onCraftWeapon_0(false, -1, null);
		}
	}

	// Token: 0x06001368 RID: 4968 RVA: 0x0000EF67 File Offset: 0x0000D167
	public void imethod_2(OnGetMyCraftedWeapons onGetMyCraftedWeapons_0)
	{
		if (onGetMyCraftedWeapons_0 != null)
		{
			onGetMyCraftedWeapons_0(null);
		}
	}

	// Token: 0x06001369 RID: 4969 RVA: 0x0000EF73 File Offset: 0x0000D173
	public void imethod_3(OnUpgradeStarExperience onUpgradeStarExperience_0, int int_0)
	{
		if (onUpgradeStarExperience_0 != null)
		{
			onUpgradeStarExperience_0(null);
		}
	}

	// Token: 0x0600136A RID: 4970 RVA: 0x0000EF7F File Offset: 0x0000D17F
	public void imethod_4(OnUpgradeStarLevel onUpgradeStarLevel_0, int int_0)
	{
		if (onUpgradeStarLevel_0 != null)
		{
			onUpgradeStarLevel_0(false, null);
		}
	}
}
