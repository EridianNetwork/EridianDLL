using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using XsdSettings;

// Token: 0x02000368 RID: 872
internal class CraftingService : OnAccessSingleton<ICraftingService, CraftingService, CraftingServiceOffline>, ICraftingService
{
	// Token: 0x060015F3 RID: 5619 RVA: 0x0007AE20 File Offset: 0x00079020
	public CraftingService()
	{
		this.mOnUpgradeStarExperience = new List<OnUpgradeStarExperience>();
		this.mOnUpgradeStarLevel = new List<OnUpgradeStarLevel>();
		PhotonNetwork.onlinePeer.method_5(154, new OperationResponseCallback(this.OnWeaponSmelted));
		PhotonNetwork.onlinePeer.method_5(153, new OperationResponseCallback(this.OnWeaponCrafted));
		PhotonNetwork.onlinePeer.method_5(143, new OperationResponseCallback(this.OnGetMyCraftedWeaponsResponse));
		PhotonNetwork.onlinePeer.method_5(69, new OperationResponseCallback(this.OnUpgradeStarExperienceResponse));
		PhotonNetwork.onlinePeer.method_5(68, new OperationResponseCallback(this.OnUpgradeStarLevelResponse));
	}

	// Token: 0x060015F4 RID: 5620 RVA: 0x00010099 File Offset: 0x0000E299
	public void imethod_0(OnSmeltWeapon onSmeltWeapon_0, int int_0)
	{
		this.mOnSmeltWeapon = onSmeltWeapon_0;
		PhotonNetwork.onlinePeer.method_3(154, new object[] { int_0 });
	}

	// Token: 0x060015F5 RID: 5621 RVA: 0x0007AED0 File Offset: 0x000790D0
	private void OnWeaponSmelted(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnSmeltWeapon != null)
		{
			Hashtable hashtable = (Hashtable)parameters[0];
			Dictionary<MaterialType, int> dictionary = new Dictionary<MaterialType, int>();
			foreach (object obj in hashtable)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				dictionary[(MaterialType)((int)dictionaryEntry.Key)] = (int)dictionaryEntry.Value;
			}
			switch (operationResponse)
			{
			case 32725:
				this.mOnSmeltWeapon(SmeltResult.NoItem, dictionary);
				goto IL_00E1;
			case 32726:
				this.mOnSmeltWeapon(SmeltResult.NotEnoughCurrency, dictionary);
				goto IL_00E1;
			case 32728:
				this.mOnSmeltWeapon(SmeltResult.ShopBought, dictionary);
				goto IL_00E1;
			}
			if (operationResponse != 0)
			{
				this.mOnSmeltWeapon(SmeltResult.Unknown, dictionary);
			}
			else
			{
				this.mOnSmeltWeapon(SmeltResult.Success, dictionary);
			}
			IL_00E1:
			this.mOnSmeltWeapon = null;
		}
	}

	// Token: 0x060015F6 RID: 5622 RVA: 0x000100C1 File Offset: 0x0000E2C1
	public void imethod_1(OnCraftWeapon onCraftWeapon_0, WeaponType weaponType_0)
	{
		this.mOnCraftWeapon = onCraftWeapon_0;
		PhotonNetwork.onlinePeer.method_3(153, new object[] { (int)weaponType_0 });
	}

	// Token: 0x060015F7 RID: 5623 RVA: 0x0007AFD8 File Offset: 0x000791D8
	private void OnWeaponCrafted(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnCraftWeapon != null)
		{
			if (operationResponse == 0)
			{
				this.mOnCraftWeapon(true, (int)parameters[1], ItemDNA.smethod_12((Hashtable)parameters[0]));
			}
			else
			{
				this.mOnCraftWeapon(false, -1, null);
			}
			this.mOnCraftWeapon = null;
		}
	}

	// Token: 0x060015F8 RID: 5624 RVA: 0x000100E9 File Offset: 0x0000E2E9
	public void imethod_3(OnUpgradeStarExperience onUpgradeStarExperience_0, int int_0)
	{
		if (onUpgradeStarExperience_0 != null)
		{
			this.mOnUpgradeStarExperience.Add(onUpgradeStarExperience_0);
		}
		PhotonNetwork.onlinePeer.method_3(69, new object[] { int_0 });
	}

	// Token: 0x060015F9 RID: 5625 RVA: 0x0007B030 File Offset: 0x00079230
	private void OnUpgradeStarExperienceResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			mOnUpgradeStarExperience.ForEach(delegate(OnUpgradeStarExperience onUpgradeStarExperience_0)
			{
				onUpgradeStarExperience_0(ItemDNA.smethod_12((Hashtable)parameters[0]));
			});
		}
		else
		{
			mOnUpgradeStarExperience.ForEach(delegate(OnUpgradeStarExperience onUpgradeStarExperience_0)
			{
				onUpgradeStarExperience_0(null);
			});
		}
		mOnUpgradeStarExperience.Clear();
	}
	// Token: 0x060015FA RID: 5626 RVA: 0x00010116 File Offset: 0x0000E316
	public void imethod_4(OnUpgradeStarLevel onUpgradeStarLevel_0, int int_0)
	{
		if (onUpgradeStarLevel_0 != null)
		{
			this.mOnUpgradeStarLevel.Add(onUpgradeStarLevel_0);
		}
		PhotonNetwork.onlinePeer.method_3(68, new object[] { int_0 });
	}

	// Token: 0x060015FB RID: 5627 RVA: 0x0007B09C File Offset: 0x0007929C
	private void OnUpgradeStarLevelResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			mOnUpgradeStarLevel.ForEach(delegate(OnUpgradeStarLevel onUpgradeStarLevel_0)
			{
				onUpgradeStarLevel_0((bool)parameters[0], ItemDNA.smethod_12((Hashtable)parameters[1]));
			});
		}
		else
		{
			mOnUpgradeStarLevel.ForEach(delegate(OnUpgradeStarLevel onUpgradeStarLevel_0)
			{
				onUpgradeStarLevel_0(success: false, null);
			});
		}
		mOnUpgradeStarLevel.Clear();
	}
	// Token: 0x060015FC RID: 5628 RVA: 0x00010143 File Offset: 0x0000E343
	public void imethod_2(OnGetMyCraftedWeapons onGetMyCraftedWeapons_0)
	{
		this.mOnGetMyCraftedWeapons = onGetMyCraftedWeapons_0;
		PhotonNetwork.onlinePeer.method_3(143, new object[0]);
	}

	// Token: 0x060015FD RID: 5629 RVA: 0x0007B108 File Offset: 0x00079308
	private void OnGetMyCraftedWeaponsResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGetMyCraftedWeapons != null)
		{
			if (operationResponse == 0 && parameters.Count > 0 && parameters[0] != null)
			{
				int[] array = (int[])parameters[0];
				this.mOnGetMyCraftedWeapons(array);
			}
			else
			{
				this.mOnGetMyCraftedWeapons(null);
			}
			this.mOnCraftWeapon = null;
		}
	}

	// Token: 0x060015FE RID: 5630 RVA: 0x00010162 File Offset: 0x0000E362
	[CompilerGenerated]
	private static void smethod_0(OnUpgradeStarExperience onUpgradeStarExperience_0)
	{
		onUpgradeStarExperience_0(null);
	}

	// Token: 0x060015FF RID: 5631 RVA: 0x0001016B File Offset: 0x0000E36B
	[CompilerGenerated]
	private static void smethod_1(OnUpgradeStarLevel onUpgradeStarLevel_0)
	{
		onUpgradeStarLevel_0(false, null);
	}

	// Token: 0x04000EE1 RID: 3809
	private List<OnUpgradeStarExperience> mOnUpgradeStarExperience;

	// Token: 0x04000EE2 RID: 3810
	private List<OnUpgradeStarLevel> mOnUpgradeStarLevel;

	// Token: 0x04000EE3 RID: 3811
	private OnSmeltWeapon mOnSmeltWeapon;

	// Token: 0x04000EE4 RID: 3812
	private OnCraftWeapon mOnCraftWeapon;

	// Token: 0x04000EE5 RID: 3813
	private OnGetMyCraftedWeapons mOnGetMyCraftedWeapons;
}
