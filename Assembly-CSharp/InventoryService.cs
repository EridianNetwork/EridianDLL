using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Core;
using XsdSettings;

// Token: 0x0200039B RID: 923
public class InventoryService : OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>, IInventoryService
{
	// Token: 0x06001753 RID: 5971 RVA: 0x0007ECEC File Offset: 0x0007CEEC
	public InventoryService()
	{
		PhotonNetwork.onlinePeer.method_5(196, new OperationResponseCallback(this.OnNewInventory));
		PhotonNetwork.onlinePeer.method_5(88, new OperationResponseCallback(this.OnNewInventory));
		PhotonNetwork.onlinePeer.method_5(89, new OperationResponseCallback(this.OnNewInventory));
		PhotonNetwork.onlinePeer.method_7(222, new EventCallback(this.OnServerInventoryUpdate));
		PhotonNetwork.onlinePeer.method_5(99, new OperationResponseCallback(this.OnNewWarehouse));
		PhotonNetwork.onlinePeer.method_7(168, new EventCallback(this.OnServerWarehouseUpdate));
		PhotonNetwork.networkingPeer.method_77(222, new EventCallback(this.OnInventoryUpdated));
		PhotonNetwork.networkingPeer.method_77(221, new EventCallback(this.OnInventoryAction));
		PhotonNetwork.onlinePeer.method_5(59, new OperationResponseCallback(this.OnGetBackpackProgressionResponse));
		PhotonNetwork.onlinePeer.method_5(58, new OperationResponseCallback(this.OnPurchaseBackpackSizeResponse));
		this.mInventories = new Dictionary<int, Inventory>();
		this.mInventoryCallbacks = new List<InventoryCallback>();
	}

	// Token: 0x06001754 RID: 5972 RVA: 0x0001136F File Offset: 0x0000F56F
	public void imethod_2(int int_0)
	{
		this.mInventories.Remove(int_0);
	}

	// Token: 0x06001755 RID: 5973 RVA: 0x0007EE54 File Offset: 0x0007D054
	public Inventory imethod_0(int int_0, GetInventoryCallback getInventoryCallback_0 = null)
	{
		if (!this.mInventories.ContainsKey(int_0))
		{
			if (getInventoryCallback_0 != null)
			{
				this.mGetInventoryCallbacks.Add(getInventoryCallback_0);
			}
			this.imethod_1(int_0);
			return null;
		}
		Inventory inventory = this.mInventories[int_0];
		if (getInventoryCallback_0 != null)
		{
			getInventoryCallback_0(int_0, inventory);
		}
		return inventory;
	}

	// Token: 0x06001756 RID: 5974 RVA: 0x0001137E File Offset: 0x0000F57E
	public void imethod_1(int int_0)
	{
		PhotonNetwork.onlinePeer.method_3(196, new object[] { int_0 });
	}

	// Token: 0x06001757 RID: 5975 RVA: 0x0001139F File Offset: 0x0000F59F
	public void imethod_6(InventoryCallback inventoryCallback_0)
	{
		this.mInventoryCallbacks.Add(inventoryCallback_0);
	}

	// Token: 0x06001758 RID: 5976 RVA: 0x000113AD File Offset: 0x0000F5AD
	public void imethod_7(InventoryCallback inventoryCallback_0)
	{
		this.mInventoryCallbacks.Remove(inventoryCallback_0);
	}

	// Token: 0x06001759 RID: 5977 RVA: 0x000113BC File Offset: 0x0000F5BC
	private void OnNewInventory(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			this.method_5((Hashtable)parameters[0]);
		}
	}

	// Token: 0x0600175A RID: 5978 RVA: 0x000113D3 File Offset: 0x0000F5D3
	private void method_0(int int_0, ItemType itemType_0, int int_1, int int_2 = 1)
	{
		PhotonNetwork.onlinePeer.method_3(194, new object[]
		{
			int_0,
			(int)itemType_0,
			int_1,
			int_2
		});
	}

	// Token: 0x0600175B RID: 5979 RVA: 0x0007EEA0 File Offset: 0x0007D0A0
	public void method_1(int int_0, ItemDNA itemDNA_0, byte byte_0)
	{
		Inventory inventory = this.imethod_0(int_0, null);
		if (inventory != null)
		{
			inventory.method_14(itemDNA_0, byte_0);
			this.method_4(int_0, InventoryService.UpdateEventType.EquipNewWeapon, new Hashtable { 
			{
				byte_0,
				itemDNA_0.method_10()
			} });
		}
	}

	// Token: 0x0600175C RID: 5980 RVA: 0x0007EEE4 File Offset: 0x0007D0E4
	public void method_2(int int_0, Dictionary<int, int> dictionary_0)
	{
		Inventory inventory = this.imethod_0(int_0, null);
		if (inventory != null)
		{
			inventory.method_15(dictionary_0);
			this.method_4(int_0, InventoryService.UpdateEventType.UpdateAmmo, dictionary_0);
		}
	}

	// Token: 0x0600175D RID: 5981 RVA: 0x0007EF10 File Offset: 0x0007D110
	public void method_3(int int_0)
	{
		try
		{
			Inventory inventory = this.imethod_0(int_0, null);
			if (inventory != null)
			{
				PhotonNetwork.onlinePeer.method_3(177, new object[] { inventory.method_35() });
			}
		}
		catch (Exception ex)
		{
			DebugUtils.LogError(LogCategory.Network, string.Format("Failed to update inventory for character {0} with error {1}", int_0, ex.Message));
		}
	}

	// Token: 0x0600175E RID: 5982 RVA: 0x0007EF7C File Offset: 0x0007D17C
	public void method_4(int int_0, InventoryService.UpdateEventType updateEventType_0, object object_0)
	{
		if (PhotonNetwork.networkingPeer != null)
		{
			Hashtable hashtable = new Hashtable
			{
				{ 0, int_0 },
				{
					1,
					(byte)updateEventType_0
				},
				{ 2, object_0 }
			};
			PhotonNetwork.networkingPeer.vmethod_10(222, hashtable, true, 0);
		}
	}

	// Token: 0x0600175F RID: 5983 RVA: 0x0007EFE0 File Offset: 0x0007D1E0
	public void OnInventoryUpdated(Dictionary<byte, object> parameters)
	{
		if (!parameters.ContainsKey(245))
		{
			if (parameters.ContainsKey(0))
			{
				this.method_5((Hashtable)parameters[0]);
			}
			return;
		}
		Hashtable hashtable = (Hashtable)parameters[245];
		int key = (int)hashtable[0];
		if (!mInventories.ContainsKey(key))
		{
			return;
		}
		Inventory inventory = mInventories[key];
		switch ((UpdateEventType)(byte)hashtable[1])
		{
		case UpdateEventType.AddItemsToInventory:
		{
			Hashtable hashtable3 = (Hashtable)hashtable[2];
			{
				foreach (DictionaryEntry item in hashtable3)
				{
					int int_ = (int)item.Key;
					Hashtable hashtable_ = (Hashtable)item.Value;
					ItemDNA itemDNA_ = ItemDNA.smethod_12(hashtable_);
					inventory.method_13(int_, itemDNA_);
				}
				break;
			}
		}
		case UpdateEventType.EquipNewWeapon:
		{
			Hashtable hashtable2 = (Hashtable)hashtable[2];
			{
				foreach (DictionaryEntry item2 in hashtable2)
				{
					inventory.method_14(ItemDNA.smethod_12((Hashtable)item2.Value), (byte)item2.Key);
				}
				break;
			}
		}
		case UpdateEventType.UpdateAmmo:
		{
			Dictionary<int, int> dictionary_ = (Dictionary<int, int>)hashtable[2];
			inventory.method_15(dictionary_);
			break;
		}
		}
	}
	// Token: 0x06001760 RID: 5984 RVA: 0x0007F184 File Offset: 0x0007D384
	public void OnInventoryAction(Dictionary<byte, object> parameters)
	{
		Hashtable hashtable = null;
		int num = 255;
		Inventory inventory = null;
		InventoryAction inventoryAction = InventoryAction.Invalid;
		byte b = byte.MaxValue;
		byte b2 = byte.MaxValue;
		try
		{
			hashtable = (Hashtable)parameters[245];
			num = (int)hashtable[0];
			if (this.mInventories.ContainsKey(num))
			{
				inventory = this.mInventories[num];
				inventoryAction = (InventoryAction)((byte)hashtable[1]);
				b = (byte)hashtable[2];
				b2 = (byte)hashtable[3];
				switch (inventoryAction)
				{
				case InventoryAction.SwapItems:
					inventory.method_6(b, b2);
					break;
				case InventoryAction.DropItem:
					inventory.method_8(b);
					break;
				case InventoryAction.EquipWeapon:
					inventory.method_9(b, b2);
					break;
				case InventoryAction.UnequipWeapon:
					inventory.method_10(b, b2);
					break;
				case InventoryAction.SetActiveWeapon:
					inventory.method_12(b);
					break;
				case InventoryAction.SwapWeapons:
					inventory.method_7(b, b2);
					break;
				case InventoryAction.EquipShield:
					inventory.method_20(b);
					break;
				case InventoryAction.EquipClassMod:
					inventory.method_23(b);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			string text = string.Format("On Inventory Action failed with error {0}\r\n\t\t\t\tEvent Data Size: {1}\r\n\t\t\t\tCharacter ID: {2}\r\n\t\t\t\tInventory Found?  {3}\r\n\t\t\t\tAction:  {4}\r\n\t\t\t\tFrom {5} To {6}", new object[]
			{
				ex.Message,
				(hashtable != null) ? hashtable.Count : (-1),
				num,
				inventory != null,
				inventoryAction,
				b,
				b2
			});
			DebugUtils.LogError(LogCategory.Network, text);
			throw new Exception(text, ex);
		}
	}

	// Token: 0x06001761 RID: 5985 RVA: 0x0007F334 File Offset: 0x0007D534
	private void OnCompleteInstance(int characterId, int instanceId)
	{
		switch (instanceId)
		{
		case 1:
			method_0(characterId, ItemType.Weapon, 15);
			mItemRewardCallbacks.ForEach(delegate(ItemRewardCallback itemRewardCallback_0)
			{
				itemRewardCallback_0(characterId, instanceId, 15);
			});
			break;
		case 2:
			method_0(characterId, ItemType.Weapon, 16);
			mItemRewardCallbacks.ForEach(delegate(ItemRewardCallback itemRewardCallback_0)
			{
				itemRewardCallback_0(characterId, instanceId, 16);
			});
			break;
		case 3:
			method_0(characterId, ItemType.Weapon, 17);
			mItemRewardCallbacks.ForEach(delegate(ItemRewardCallback itemRewardCallback_0)
			{
				itemRewardCallback_0(characterId, instanceId, 17);
			});
			break;
		case 4:
			method_0(characterId, ItemType.Weapon, 18);
			method_0(characterId, ItemType.Weapon, 19);
			mItemRewardCallbacks.ForEach(delegate(ItemRewardCallback itemRewardCallback_0)
			{
				itemRewardCallback_0(characterId, instanceId, 18, 19);
			});
			break;
		case 5:
			method_0(characterId, ItemType.Weapon, 20);
			method_0(characterId, ItemType.Weapon, 21);
			mItemRewardCallbacks.ForEach(delegate(ItemRewardCallback itemRewardCallback_0)
			{
				itemRewardCallback_0(characterId, instanceId, 20, 21);
			});
			break;
		case 6:
			method_0(characterId, ItemType.Weapon, 22);
			method_0(characterId, ItemType.Weapon, 23);
			mItemRewardCallbacks.ForEach(delegate(ItemRewardCallback itemRewardCallback_0)
			{
				itemRewardCallback_0(characterId, instanceId, 22, 23);
			});
			break;
		case 7:
			method_0(characterId, ItemType.Weapon, 24);
			method_0(characterId, ItemType.Weapon, 25);
			mItemRewardCallbacks.ForEach(delegate(ItemRewardCallback itemRewardCallback_0)
			{
				itemRewardCallback_0(characterId, instanceId, 24, 25);
			});
			break;
		}
	}
	// Token: 0x06001762 RID: 5986 RVA: 0x00011410 File Offset: 0x0000F610
	public void imethod_8(ItemRewardCallback itemRewardCallback_0)
	{
		this.mItemRewardCallbacks.Add(itemRewardCallback_0);
	}

	// Token: 0x06001763 RID: 5987 RVA: 0x0001141E File Offset: 0x0000F61E
	public void imethod_9(ItemRewardCallback itemRewardCallback_0)
	{
		this.mItemRewardCallbacks.Remove(itemRewardCallback_0);
	}

	// Token: 0x06001764 RID: 5988 RVA: 0x0001142D File Offset: 0x0000F62D
	public void OnServerInventoryUpdate(Dictionary<byte, object> parameters)
	{
		this.method_5((Hashtable)parameters[0]);
	}

	// Token: 0x06001765 RID: 5989 RVA: 0x0007F4F0 File Offset: 0x0007D6F0
	private void method_5(Hashtable hashtable_0)
	{
		int num = (int)hashtable_0[0];
		Inventory inventory = new Inventory(hashtable_0);
		if (!mInventories.ContainsKey(num))
		{
			mInventories[num] = inventory;
		}
		mInventoryCallbacks.ForEach(delegate(InventoryCallback inventoryCallback_0)
		{
			inventoryCallback_0(inventory);
		});
		for (int i = 0; i < mGetInventoryCallbacks.Count; i++)
		{
			mGetInventoryCallbacks[i](num, inventory);
		}
	}
	// Token: 0x06001766 RID: 5990 RVA: 0x00011441 File Offset: 0x0000F641
	public void OnNewWarehouse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			this.method_6((Hashtable)parameters[0]);
		}
	}

	// Token: 0x06001767 RID: 5991 RVA: 0x00011458 File Offset: 0x0000F658
	public void OnServerWarehouseUpdate(Dictionary<byte, object> parameters)
	{
		this.method_6((Hashtable)parameters[0]);
	}

	// Token: 0x06001768 RID: 5992 RVA: 0x0001146C File Offset: 0x0000F66C
	private void method_6(Hashtable hashtable_0)
	{
		this.mWarehouse = new Warehouse(hashtable_0);
		this.mWarehouseCallbacks.ForEach(new Action<WarehouseCallback>(this.method_7));
	}

	// Token: 0x06001769 RID: 5993 RVA: 0x00011491 File Offset: 0x0000F691
	public void imethod_10(WarehouseCallback warehouseCallback_0)
	{
		this.mWarehouseCallbacks.Add(warehouseCallback_0);
	}

	// Token: 0x0600176A RID: 5994 RVA: 0x0001149F File Offset: 0x0000F69F
	public void imethod_11(WarehouseCallback warehouseCallback_0)
	{
		this.mWarehouseCallbacks.Remove(warehouseCallback_0);
	}

	// Token: 0x0600176B RID: 5995 RVA: 0x000114AE File Offset: 0x0000F6AE
	public void imethod_5()
	{
		PhotonNetwork.onlinePeer.method_3(99, new object[0]);
	}

	// Token: 0x0600176C RID: 5996 RVA: 0x000114C3 File Offset: 0x0000F6C3
	public void imethod_3(BackpackProgressionCallback backpackProgressionCallback_0)
	{
		if (backpackProgressionCallback_0 != null)
		{
			this.mBackpackProgressionCallback.Add(backpackProgressionCallback_0);
		}
		PhotonNetwork.onlinePeer.method_3(59, new object[0]);
	}

	// Token: 0x0600176D RID: 5997 RVA: 0x0007F588 File Offset: 0x0007D788
	private void OnGetBackpackProgressionResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			InventoryBackpackProgression progression = new InventoryBackpackProgression((Hashtable)parameters[0]);
			mBackpackProgressionCallback.ForEach(delegate(BackpackProgressionCallback backpackProgressionCallback_0)
			{
				backpackProgressionCallback_0(progression);
			});
		}
		else
		{
			mBackpackProgressionCallback.ForEach(delegate(BackpackProgressionCallback backpackProgressionCallback_0)
			{
				backpackProgressionCallback_0(null);
			});
		}
		mBackpackProgressionCallback.Clear();
	}
	// Token: 0x0600176E RID: 5998 RVA: 0x000114E7 File Offset: 0x0000F6E7
	public void imethod_4(PurchaseBackpackSizeCallback purchaseBackpackSizeCallback_0, int int_0)
	{
		if (purchaseBackpackSizeCallback_0 != null)
		{
			this.mPurchaseBackpackSizeCallback.Add(purchaseBackpackSizeCallback_0);
		}
		PhotonNetwork.onlinePeer.method_3(58, new object[] { int_0 });
	}

	// Token: 0x0600176F RID: 5999 RVA: 0x0007F604 File Offset: 0x0007D804
	private void OnPurchaseBackpackSizeResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			int newSize = (int)parameters[0];
			mPurchaseBackpackSizeCallback.ForEach(delegate(PurchaseBackpackSizeCallback purchaseBackpackSizeCallback_0)
			{
				purchaseBackpackSizeCallback_0(newSize);
			});
		}
		else
		{
			mPurchaseBackpackSizeCallback.ForEach(delegate(PurchaseBackpackSizeCallback purchaseBackpackSizeCallback_0)
			{
				purchaseBackpackSizeCallback_0(0);
			});
		}
		mPurchaseBackpackSizeCallback.Clear();
	}
	// Token: 0x06001770 RID: 6000 RVA: 0x00011514 File Offset: 0x0000F714
	[CompilerGenerated]
	private void method_7(WarehouseCallback warehouseCallback_0)
	{
		warehouseCallback_0(this.mWarehouse);
	}

	// Token: 0x06001771 RID: 6001 RVA: 0x00011522 File Offset: 0x0000F722
	[CompilerGenerated]
	private static void smethod_0(BackpackProgressionCallback backpackProgressionCallback_0)
	{
		backpackProgressionCallback_0(null);
	}

	// Token: 0x06001772 RID: 6002 RVA: 0x0001152B File Offset: 0x0000F72B
	[CompilerGenerated]
	private static void smethod_1(PurchaseBackpackSizeCallback purchaseBackpackSizeCallback_0)
	{
		purchaseBackpackSizeCallback_0(0);
	}

	// Token: 0x04000FDE RID: 4062
	private List<ItemRewardCallback> mItemRewardCallbacks = new List<ItemRewardCallback>();

	// Token: 0x04000FDF RID: 4063
	private List<InventoryCallback> mInventoryCallbacks;

	// Token: 0x04000FE0 RID: 4064
	private Dictionary<int, Inventory> mInventories;

	// Token: 0x04000FE1 RID: 4065
	private List<GetInventoryCallback> mGetInventoryCallbacks = new List<GetInventoryCallback>();

	// Token: 0x04000FE2 RID: 4066
	private List<BackpackProgressionCallback> mBackpackProgressionCallback = new List<BackpackProgressionCallback>();

	// Token: 0x04000FE3 RID: 4067
	private List<PurchaseBackpackSizeCallback> mPurchaseBackpackSizeCallback = new List<PurchaseBackpackSizeCallback>();

	// Token: 0x04000FE4 RID: 4068
	private List<WarehouseCallback> mWarehouseCallbacks = new List<WarehouseCallback>();

	// Token: 0x04000FE5 RID: 4069
	private Warehouse mWarehouse;

	// Token: 0x0200039C RID: 924
	public enum UpdateEventType
	{
		// Token: 0x04000FE9 RID: 4073
		AddItemsToInventory,
		// Token: 0x04000FEA RID: 4074
		EquipNewWeapon,
		// Token: 0x04000FEB RID: 4075
		UpdateAmmo
	}
}
