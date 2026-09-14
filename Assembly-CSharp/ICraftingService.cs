using System;
using XsdSettings;

// Token: 0x020002ED RID: 749
internal interface ICraftingService
{
	// Token: 0x0600110F RID: 4367
	void imethod_0(OnSmeltWeapon onSmeltWeapon_0, int int_0);

	// Token: 0x06001110 RID: 4368
	void imethod_1(OnCraftWeapon onCraftWeapon_0, WeaponType weaponType_0);

	// Token: 0x06001111 RID: 4369
	void imethod_2(OnGetMyCraftedWeapons onGetMyCraftedWeapons_0);

	// Token: 0x06001112 RID: 4370
	void imethod_3(OnUpgradeStarExperience onUpgradeStarExperience_0, int int_0);

	// Token: 0x06001113 RID: 4371
	void imethod_4(OnUpgradeStarLevel onUpgradeStarLevel_0, int int_0);
}
