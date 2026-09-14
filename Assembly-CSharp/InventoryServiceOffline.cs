using System;
using System.Collections.Generic;
using ns0;

// Token: 0x02000324 RID: 804
public class InventoryServiceOffline : IInventoryService
{
	// Token: 0x060013D6 RID: 5078 RVA: 0x00077474 File Offset: 0x00075674
	public Inventory imethod_0(int int_0, GetInventoryCallback getInventoryCallback_0 = null)
	{
		if (MonoSingleton<AppManager>.Instance == null)
		{
			return null;
		}
		WeaponGeneratorService component = MonoSingleton<AppManager>.Instance.GetComponent<WeaponGeneratorService>();
		if (component == null)
		{
			return null;
		}
		return this.mInventories[int_0];
	}

	// Token: 0x060013D7 RID: 5079 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_1(int int_0)
	{
	}

	// Token: 0x060013D8 RID: 5080 RVA: 0x0000F17D File Offset: 0x0000D37D
	public void imethod_2(int int_0)
	{
		this.mInventories.Remove(int_0);
	}

	// Token: 0x060013D9 RID: 5081 RVA: 0x0000F18C File Offset: 0x0000D38C
	public void imethod_3(BackpackProgressionCallback backpackProgressionCallback_0)
	{
		if (backpackProgressionCallback_0 != null)
		{
			backpackProgressionCallback_0(null);
		}
	}

	// Token: 0x060013DA RID: 5082 RVA: 0x0000F198 File Offset: 0x0000D398
	public void imethod_4(PurchaseBackpackSizeCallback purchaseBackpackSizeCallback_0, int int_0)
	{
		if (purchaseBackpackSizeCallback_0 != null)
		{
			purchaseBackpackSizeCallback_0(30);
		}
	}

	// Token: 0x060013DB RID: 5083 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_5()
	{
	}

	// Token: 0x060013DC RID: 5084 RVA: 0x0000F1A5 File Offset: 0x0000D3A5
	public void imethod_6(InventoryCallback inventoryCallback_0)
	{
		this.mInventoryCallbacks.Add(inventoryCallback_0);
	}

	// Token: 0x060013DD RID: 5085 RVA: 0x0000F1B3 File Offset: 0x0000D3B3
	public void imethod_7(InventoryCallback inventoryCallback_0)
	{
		this.mInventoryCallbacks.Remove(inventoryCallback_0);
	}

	// Token: 0x060013DE RID: 5086 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_8(ItemRewardCallback itemRewardCallback_0)
	{
	}

	// Token: 0x060013DF RID: 5087 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_9(ItemRewardCallback itemRewardCallback_0)
	{
	}

	// Token: 0x060013E0 RID: 5088 RVA: 0x0000F1C2 File Offset: 0x0000D3C2
	public void method_0(int int_0, ItemDNA itemDNA_0, byte byte_0)
	{
		if (int_0 == OnlineService.s_characterId)
		{
			this.imethod_0(int_0, null).method_14(itemDNA_0, byte_0);
		}
	}

	// Token: 0x060013E1 RID: 5089 RVA: 0x0000F1DB File Offset: 0x0000D3DB
	public void method_1(int int_0, Dictionary<int, int> dictionary_0)
	{
		if (int_0 == OnlineService.s_characterId)
		{
			this.imethod_0(int_0, null).method_15(dictionary_0);
		}
	}

	// Token: 0x060013E2 RID: 5090 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_2(int int_0)
	{
	}

	// Token: 0x060013E3 RID: 5091 RVA: 0x000774B4 File Offset: 0x000756B4
	public void OnInventoryModification(Inventory inventory)
	{
		mInventoryCallbacks.ForEach(delegate(InventoryCallback inventoryCallback_0)
		{
			inventoryCallback_0(inventory);
		});
	}
	// Token: 0x060013E4 RID: 5092 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_10(WarehouseCallback warehouseCallback_0)
	{
	}

	// Token: 0x060013E5 RID: 5093 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_11(WarehouseCallback warehouseCallback_0)
	{
	}

	// Token: 0x04000E54 RID: 3668
	private Dictionary<int, Inventory> mInventories = new Dictionary<int, Inventory>();

	// Token: 0x04000E55 RID: 3669
	private List<InventoryCallback> mInventoryCallbacks = new List<InventoryCallback>();
}
