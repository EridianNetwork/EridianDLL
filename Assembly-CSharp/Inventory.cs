using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Core;
using ns0;
using XsdSettings;

// Token: 0x02000397 RID: 919
public class Inventory
{
	// Token: 0x06001720 RID: 5920 RVA: 0x0007D57C File Offset: 0x0007B77C
	public Inventory()
	{
	}

	// Token: 0x06001721 RID: 5921 RVA: 0x0007D63C File Offset: 0x0007B83C
	public Inventory(Hashtable hashtable_0)
	{
		this.mCharacterId = (int)hashtable_0[0];
		this.mNumWeaponSlots = (byte)hashtable_0[1];
		this.mActiveWeapon = (byte)hashtable_0[2];
		Hashtable hashtable = (Hashtable)hashtable_0[3];
		for (int i = 0; i < 4; i++)
		{
			if (hashtable.ContainsKey(i) && hashtable[i] != null)
			{
				if (hashtable[i].GetType() == typeof(Hashtable))
				{
					this.mEquippedWeapons[i] = ItemDNA.smethod_12((Hashtable)hashtable[i]);
				}
				else
				{
					this.mEquippedWeapons[i] = (ItemDNA)hashtable[i];
				}
			}
		}
		Hashtable hashtable2 = (Hashtable)hashtable_0[4];
		this.mAmmoCounts[4] = (int)hashtable2[0];
		this.mMaxAmmoCounts[4] = (int)hashtable2[1];
		Hashtable hashtable3 = (Hashtable)hashtable_0[5];
		this.mAmmoCounts[0] = (int)hashtable3[0];
		this.mMaxAmmoCounts[0] = (int)hashtable3[1];
		Hashtable hashtable4 = (Hashtable)hashtable_0[6];
		this.mAmmoCounts[3] = (int)hashtable4[0];
		this.mMaxAmmoCounts[3] = (int)hashtable4[1];
		Hashtable hashtable5 = (Hashtable)hashtable_0[7];
		this.mAmmoCounts[1] = (int)hashtable5[0];
		this.mMaxAmmoCounts[1] = (int)hashtable5[1];
		Hashtable hashtable6 = (Hashtable)hashtable_0[8];
		this.mAmmoCounts[2] = (int)hashtable6[0];
		this.mMaxAmmoCounts[2] = (int)hashtable6[1];
		Hashtable hashtable7 = (Hashtable)hashtable_0[12];
		this.mAmmoCounts[5] = (int)hashtable7[0];
		this.mMaxAmmoCounts[5] = (int)hashtable7[1];
		this.mMaxSlots = (int)hashtable_0[9];
		Hashtable hashtable8 = (Hashtable)hashtable_0[10];
		foreach (object obj in hashtable8)
		{
			DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
			int num = (int)dictionaryEntry.Key;
			Hashtable hashtable9 = (Hashtable)dictionaryEntry.Value;
			if (hashtable9 != null)
			{
				this.mItems[num] = new InventoryItem(hashtable9);
			}
		}
		if (hashtable_0[11] != null)
		{
			this.mShield = ItemDNA.smethod_12((Hashtable)hashtable_0[11]);
		}
		if (hashtable_0[13] != null)
		{
			this.mClassMod = ItemDNA.smethod_12((Hashtable)hashtable_0[13]);
		}
		if (hashtable_0[14] == null)
		{
		}
		for (AvatarSubPart avatarSubPart = AvatarSubPart.HAIR; avatarSubPart < AvatarSubPart.TOTAL; avatarSubPart++)
		{
			this.mEquippedOutfit[avatarSubPart] = ((hashtable_0[(int)(15 + avatarSubPart)] != null) ? ItemDNA.smethod_12((Hashtable)hashtable_0[(int)(15 + avatarSubPart)]) : null);
		}
		OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.Prop_0.imethod_6(new InventoryCallback(this.OnNewInventory));
	}

	// Token: 0x06001722 RID: 5922 RVA: 0x000111BF File Offset: 0x0000F3BF
	public ItemDNA method_0(int int_0)
	{
		if (this.mItems.ContainsKey(int_0))
		{
			return this.mItems[int_0].mItem;
		}
		return null;
	}

	// Token: 0x06001723 RID: 5923 RVA: 0x000111E2 File Offset: 0x0000F3E2
	public ItemDNA method_1(byte byte_0)
	{
		if (byte_0 < this.mNumWeaponSlots)
		{
			return this.mEquippedWeapons[(int)byte_0];
		}
		return null;
	}

	// Token: 0x06001724 RID: 5924 RVA: 0x000111F7 File Offset: 0x0000F3F7
	public ItemDNA method_2()
	{
		return this.mEquippedWeapons[(int)this.mActiveWeapon];
	}

	// Token: 0x06001725 RID: 5925 RVA: 0x00011206 File Offset: 0x0000F406
	public byte method_3()
	{
		return this.mActiveWeapon;
	}

	// Token: 0x06001726 RID: 5926 RVA: 0x0001120E File Offset: 0x0000F40E
	public int method_4(AmmoType ammoType_0)
	{
		if (this.mAmmoCounts != null && this.mAmmoCounts.ContainsKey((int)ammoType_0))
		{
			return this.mAmmoCounts[(int)ammoType_0];
		}
		return 0;
	}

	// Token: 0x06001727 RID: 5927 RVA: 0x00011234 File Offset: 0x0000F434
	public int method_5(AmmoType ammoType_0)
	{
		if (this.mMaxAmmoCounts != null && this.mMaxAmmoCounts.ContainsKey((int)ammoType_0))
		{
			return this.mMaxAmmoCounts[(int)ammoType_0];
		}
		return 0;
	}

	// Token: 0x06001728 RID: 5928 RVA: 0x0007DB28 File Offset: 0x0007BD28
	public void method_6(byte byte_0, byte byte_1)
	{
		if (byte_0 == byte_1)
		{
			return;
		}
		InventoryItem inventoryItem;
		this.mItems.TryGetValue((int)byte_0, out inventoryItem);
		InventoryItem inventoryItem2;
		this.mItems.TryGetValue((int)byte_1, out inventoryItem2);
		if (inventoryItem != null)
		{
			this.mItems[(int)byte_1] = inventoryItem;
		}
		else
		{
			this.mItems.Remove((int)byte_1);
		}
		if (inventoryItem2 != null)
		{
			this.mItems[(int)byte_0] = inventoryItem2;
		}
		else
		{
			this.mItems.Remove((int)byte_0);
		}
		PhotonNetwork.onlinePeer.method_3(195, new object[] { byte_0, byte_1 });
		this.method_34(InventoryAction.SwapItems, byte_0, byte_1);
	}

	// Token: 0x06001729 RID: 5929 RVA: 0x0007DBC8 File Offset: 0x0007BDC8
	public void method_7(byte byte_0, byte byte_1)
	{
		if (byte_0 == byte_1)
		{
			return;
		}
		ItemDNA itemDNA = this.mEquippedWeapons[(int)byte_0];
		ItemDNA itemDNA2 = this.mEquippedWeapons[(int)byte_1];
		this.mEquippedWeapons[(int)byte_0] = itemDNA2;
		this.mEquippedWeapons[(int)byte_1] = itemDNA;
		PhotonNetwork.onlinePeer.method_3(166, new object[] { byte_0, byte_1 });
		this.method_34(InventoryAction.SwapWeapons, byte_0, byte_1);
	}

	// Token: 0x0600172A RID: 5930 RVA: 0x0001125A File Offset: 0x0000F45A
	public void method_8(byte byte_0)
	{
		this.mItems.Remove((int)byte_0);
		PhotonNetwork.onlinePeer.method_3(193, new object[] { byte_0 });
		this.method_34(InventoryAction.DropItem, byte_0, 0);
	}

	// Token: 0x0600172B RID: 5931 RVA: 0x0007DC30 File Offset: 0x0007BE30
	public void method_9(byte byte_0, byte byte_1)
	{
		if ((int)byte_0 < this.mMaxSlots && byte_1 < this.mNumWeaponSlots)
		{
			ItemDNA itemDNA = this.method_0((int)byte_0);
			if (this.mEquippedWeapons[(int)byte_1] == null)
			{
				this.mItems.Remove((int)byte_0);
			}
			else
			{
				this.mItems[(int)byte_0] = new InventoryItem
				{
					mItem = this.mEquippedWeapons[(int)byte_1]
				};
			}
			this.mEquippedWeapons[(int)byte_1] = itemDNA;
			PhotonNetwork.onlinePeer.method_3(192, new object[] { byte_0, byte_1 });
			this.method_34(InventoryAction.EquipWeapon, byte_0, byte_1);
			return;
		}
	}

	// Token: 0x0600172C RID: 5932 RVA: 0x0007DCD0 File Offset: 0x0007BED0
	public void method_10(byte byte_0, byte byte_1)
	{
		if (byte_0 != this.mActiveWeapon && byte_0 < this.mNumWeaponSlots && (int)byte_1 < this.mMaxSlots)
		{
			if (this.mEquippedWeapons[(int)byte_0] != null)
			{
				this.mItems[(int)byte_1] = new InventoryItem
				{
					mItem = this.mEquippedWeapons[(int)byte_0]
				};
				this.mEquippedWeapons[(int)byte_0] = null;
				PhotonNetwork.onlinePeer.method_3(191, new object[] { byte_0, byte_1 });
			}
			this.method_34(InventoryAction.UnequipWeapon, byte_0, 0);
			return;
		}
	}

	// Token: 0x0600172D RID: 5933 RVA: 0x0007DD60 File Offset: 0x0007BF60
	public void method_11(byte byte_0)
	{
		if (byte_0 != this.mActiveWeapon && byte_0 < this.mNumWeaponSlots)
		{
			for (int i = 0; i < this.mMaxSlots; i++)
			{
				if (!this.mItems.ContainsKey(i))
				{
					this.method_10(byte_0, (byte)i);
				}
			}
			return;
		}
	}

	// Token: 0x0600172E RID: 5934 RVA: 0x0007DDA8 File Offset: 0x0007BFA8
	public void method_12(byte byte_0)
	{
		if (byte_0 >= this.mNumWeaponSlots)
		{
			DebugUtils.LogError(LogCategory.Default, string.Format("Set Active Weapon {0} - Invalid index", byte_0));
			return;
		}
		if (this.mEquippedWeapons[(int)byte_0] == null)
		{
			DebugUtils.LogError(LogCategory.Default, string.Format("Set Active Weapon {0} - No weapon in slot", byte_0));
			return;
		}
		this.mActiveWeapon = byte_0;
		this.method_34(InventoryAction.SetActiveWeapon, byte_0, 0);
		PhotonNetwork.onlinePeer.method_3(190, new object[] { byte_0 });
	}

	// Token: 0x0600172F RID: 5935 RVA: 0x0007DE28 File Offset: 0x0007C028
	private void OnNewInventory(Inventory inventory)
	{
		if (inventory.mCharacterId == this.mCharacterId)
		{
			this.mItems = inventory.mItems;
			this.mEquippedWeapons = inventory.mEquippedWeapons;
			this.mShield = inventory.mShield;
			this.mClassMod = inventory.mClassMod;
			this.mActiveWeapon = inventory.mActiveWeapon;
			this.mNumWeaponSlots = inventory.mNumWeaponSlots;
			this.mEquippedOutfit = inventory.mEquippedOutfit;
			this.mAmmoCounts = inventory.mAmmoCounts;
			this.mMaxAmmoCounts = inventory.mMaxAmmoCounts;
			this.mMaxSlots = inventory.mMaxSlots;
		}
	}

	// Token: 0x06001730 RID: 5936 RVA: 0x0007DEBC File Offset: 0x0007C0BC
	public void method_13(int int_0, ItemDNA itemDNA_0, int int_1 = 1)
	{
		if (!this.mItems.ContainsKey(int_0))
		{
			this.mItems[int_0] = new InventoryItem
			{
				mItem = itemDNA_0
			};
		}
		else
		{
			if (itemDNA_0.m_type == ItemType.Weapon)
			{
				throw new Exception(string.Format("Can't add {0} items to slot {1} - already has item.", int_1, int_0));
			}
			if (itemDNA_0.m_type != ItemType.Material)
			{
				throw new Exception(string.Format("Unsupported item type ({0}).", itemDNA_0.m_type));
			}
			if (this.mItems[int_0].mItem.m_materialType != itemDNA_0.m_materialType)
			{
				throw new Exception(string.Format("Can't stack {0} items in slot {1} - types do not match.", int_1, int_0));
			}
			if (this.mItems[int_0].Int32_0 + int_1 > 99)
			{
				throw new Exception(string.Format("Can't add {0} items to slot {1} [{2}]- stack is full.", int_1, int_0, this.mItems[int_0].Int32_0));
			}
			this.mItems[int_0].Int32_0 += int_1;
		}
	}

	// Token: 0x06001731 RID: 5937 RVA: 0x00011291 File Offset: 0x0000F491
	public void method_14(ItemDNA itemDNA_0, byte byte_0)
	{
		this.mEquippedWeapons[(int)byte_0] = itemDNA_0;
	}

	// Token: 0x06001732 RID: 5938 RVA: 0x0001129C File Offset: 0x0000F49C
	public void method_15(Dictionary<int, int> dictionary_0)
	{
		this.mAmmoCounts = dictionary_0;
	}

	// Token: 0x06001733 RID: 5939 RVA: 0x000112A5 File Offset: 0x0000F4A5
	public ItemDNA method_16()
	{
		return this.mClassMod;
	}

	// Token: 0x06001734 RID: 5940 RVA: 0x000112AD File Offset: 0x0000F4AD
	public void method_17(ItemDNA itemDNA_0)
	{
		this.mClassMod = itemDNA_0;
	}

	// Token: 0x06001735 RID: 5941 RVA: 0x000112B6 File Offset: 0x0000F4B6
	public ItemDNA method_18()
	{
		return this.mShield;
	}

	// Token: 0x06001736 RID: 5942 RVA: 0x000112BE File Offset: 0x0000F4BE
	public void method_19(ItemDNA itemDNA_0)
	{
		this.mShield = itemDNA_0;
	}

	// Token: 0x06001737 RID: 5943 RVA: 0x0007DFE0 File Offset: 0x0007C1E0
	public void method_20(byte byte_0)
	{
		if ((int)byte_0 >= this.mMaxSlots)
		{
			return;
		}
		ItemDNA itemDNA = this.method_0((int)byte_0);
		if (this.mShield == null)
		{
			this.mItems.Remove((int)byte_0);
		}
		else
		{
			this.mItems[(int)byte_0] = new InventoryItem
			{
				mItem = this.mShield
			};
		}
		this.mShield = itemDNA;
		PhotonNetwork.onlinePeer.method_3(135, new object[] { byte_0 });
		this.method_34(InventoryAction.EquipShield, byte_0, 0);
	}

	// Token: 0x06001738 RID: 5944 RVA: 0x000112C7 File Offset: 0x0000F4C7
	public void method_21(byte byte_0)
	{
		this.method_23(byte_0);
	}

	// Token: 0x06001739 RID: 5945 RVA: 0x0007E064 File Offset: 0x0007C264
	public void method_22()
	{
		for (int i = 0; i < this.mMaxSlots; i++)
		{
			if (!this.mItems.ContainsKey(i))
			{
				this.method_21((byte)i);
			}
		}
	}

	// Token: 0x0600173A RID: 5946 RVA: 0x0007E098 File Offset: 0x0007C298
	public void method_23(byte byte_0)
	{
		if ((int)byte_0 >= this.mMaxSlots)
		{
			return;
		}
		ItemDNA itemDNA = this.method_0((int)byte_0);
		if (this.mClassMod == null)
		{
			this.mItems.Remove((int)byte_0);
		}
		else
		{
			this.mItems[(int)byte_0] = new InventoryItem
			{
				mItem = this.mClassMod
			};
		}
		this.mClassMod = itemDNA;
		PhotonNetwork.onlinePeer.method_3(86, new object[] { byte_0 });
		this.method_34(InventoryAction.EquipClassMod, byte_0, 0);
	}

	// Token: 0x0600173B RID: 5947 RVA: 0x0007E11C File Offset: 0x0007C31C
	public void method_24(int int_0, int int_1, int int_2)
	{
		if (!this.mItems.ContainsKey(int_0))
		{
			return;
		}
		if (this.mItems.ContainsKey(int_1))
		{
			return;
		}
		if (this.mItems[int_0].mItem.m_type != ItemType.Material)
		{
			return;
		}
		if (this.mItems[int_0].Int32_0 <= int_2)
		{
			return;
		}
		this.mItems[int_0].Int32_0 -= int_2;
		this.mItems[int_1] = new InventoryItem
		{
			mItem = ItemDNA.smethod_3(this.mItems[int_0].mItem.m_materialType, int_2)
		};
		PhotonNetwork.onlinePeer.method_3(90, new object[] { int_0, int_1, int_2 });
	}

	// Token: 0x0600173C RID: 5948 RVA: 0x0007E1F4 File Offset: 0x0007C3F4
	public void method_25(int int_0, int int_1)
	{
		if (!this.mItems.ContainsKey(int_0))
		{
			return;
		}
		if (!this.mItems.ContainsKey(int_1))
		{
			return;
		}
		if (this.mItems[int_0].mItem.m_type != ItemType.Material)
		{
			return;
		}
		if (this.mItems[int_1].mItem.m_type != ItemType.Material)
		{
			return;
		}
		if (this.mItems[int_0].mItem.m_materialType != this.mItems[int_1].mItem.m_materialType)
		{
			return;
		}
		int num = this.mItems[int_0].Int32_0 + this.mItems[int_1].Int32_0;
		if (num > 99)
		{
			this.mItems[int_1] = new InventoryItem
			{
				mItem = ItemDNA.smethod_3(this.mItems[int_0].mItem.m_materialType, 99)
			};
			this.mItems[int_0] = new InventoryItem
			{
				mItem = ItemDNA.smethod_3(this.mItems[int_0].mItem.m_materialType, num - 99)
			};
		}
		else
		{
			this.mItems[int_1] = new InventoryItem
			{
				mItem = ItemDNA.smethod_3(this.mItems[int_0].mItem.m_materialType, 99)
			};
			this.mItems.Remove(int_0);
		}
		PhotonNetwork.onlinePeer.method_3(89, new object[] { int_0, int_1 });
	}

	// Token: 0x0600173D RID: 5949 RVA: 0x0007E384 File Offset: 0x0007C584
	public void method_26()
	{
		int[] array = new int[13];
		for (MaterialType materialType = MaterialType.MT_Titanium; materialType < MaterialType.TOTAL; materialType++)
		{
			array[(int)materialType] = this.method_27(materialType);
		}
		List<InventoryItem> list = new List<InventoryItem>(this.mItems.Values);
		list.RemoveAll((InventoryItem i) => i == null || i.mItem == null);
		list.RemoveAll(new Predicate<InventoryItem>(Inventory.smethod_1));
		for (MaterialType materialType2 = MaterialType.MT_Titanium; materialType2 < MaterialType.TOTAL; materialType2++)
		{
			int k = array[(int)materialType2];
			if (k > 0)
			{
				while (k > 99)
				{
					list.Add(new InventoryItem
					{
						mItem = ItemDNA.smethod_3(materialType2, 99)
					});
					k -= 99;
				}
				list.Add(new InventoryItem
				{
					mItem = ItemDNA.smethod_3(materialType2, k)
				});
			}
		}
		list = list.OrderByDescending<InventoryItem, int>(new Func<InventoryItem, int>(Inventory.smethod_2)).ToList<InventoryItem>();
		Dictionary<int, InventoryItem> dictionary = new Dictionary<int, InventoryItem>();
		for (int j = 0; j < list.Count; j++)
		{
			dictionary[j] = list[j];
		}
		this.mItems = dictionary;
		PhotonNetwork.onlinePeer.method_3(88, new object[0]);
	}

	// Token: 0x0600173E RID: 5950 RVA: 0x0007E4B8 File Offset: 0x0007C6B8
	private int method_27(MaterialType materialType_0)
	{
		int num = 0;
		foreach (InventoryItem inventoryItem in this.mItems.Values)
		{
			if (inventoryItem != null && inventoryItem.mItem != null && inventoryItem.mItem.m_type == ItemType.Material && inventoryItem.mItem.m_materialType == materialType_0)
			{
				num += inventoryItem.Int32_0;
			}
		}
		return num;
	}

	// Token: 0x0600173F RID: 5951 RVA: 0x0007E53C File Offset: 0x0007C73C
	private int method_28(ItemType itemType_0)
	{
		switch (itemType_0)
		{
		case ItemType.Weapon:
			return 0;
		case ItemType.Shield:
			return 1;
		}
		if (itemType_0 != ItemType.ClassMode)
		{
			return 99;
		}
		return 2;
	}

	// Token: 0x06001740 RID: 5952 RVA: 0x0007E574 File Offset: 0x0007C774
	public static int smethod_0(ItemDNA itemDNA_0)
	{
		int num = 0;
		switch (itemDNA_0.m_type)
		{
		case ItemType.Weapon:
			num = 5;
			break;
		case ItemType.Shield:
			num = 4;
			break;
		case ItemType.Material:
			num = 1;
			break;
		case ItemType.ClassMode:
			num = 3;
			break;
		case ItemType.Outfit:
			num = 2;
			break;
		}
		int itemRarity_ = (int)itemDNA_0.ItemRarity_0;
		int num2 = itemDNA_0.method_0();
		int num3 = 0;
		if (itemDNA_0.m_type == ItemType.Material)
		{
			MaterialType materialType = itemDNA_0.m_materialType;
			if (materialType != MaterialType.MT_Diamond_Shell)
			{
				if (materialType != MaterialType.MT_Purple_Crystal)
				{
					num3 = 0;
				}
				else
				{
					num3 = 2;
				}
			}
			else
			{
				num3 = 1;
			}
		}
		else if (itemDNA_0.m_type == ItemType.Weapon)
		{
			if (itemDNA_0.method_6() != null)
			{
				switch (itemDNA_0.method_6().method_1())
				{
				case WeaponType.SMG:
					num3 = 5;
					break;
				case WeaponType.SniperRifle:
					num3 = 4;
					break;
				case WeaponType.ShotGun:
					num3 = 3;
					break;
				case WeaponType.RepeaterPistol:
					num3 = 2;
					break;
				case WeaponType.CombatRifle:
					num3 = 1;
					break;
				default:
					num3 = 0;
					break;
				}
			}
		}
		else if (itemDNA_0.m_type == ItemType.Outfit && itemDNA_0.method_9() != null)
		{
			switch (itemDNA_0.method_9().m_avatarSubpart)
			{
			case AvatarSubPart.HAIR:
				num3 = 5;
				goto IL_0139;
			case AvatarSubPart.MASK:
				num3 = 4;
				goto IL_0139;
			case AvatarSubPart.BODY:
				num3 = 3;
				goto IL_0139;
			case AvatarSubPart.PANTS:
				num3 = 2;
				goto IL_0139;
			case AvatarSubPart.SHOE:
				num3 = 1;
				goto IL_0139;
			}
			num3 = 0;
		}
		IL_0139:
		return num * 1000000 + itemRarity_ * 10000 + num2 * 100 + num3;
	}

	// Token: 0x06001741 RID: 5953 RVA: 0x000112D0 File Offset: 0x0000F4D0
	public void method_29(byte byte_0)
	{
		this.method_20(byte_0);
	}

	// Token: 0x06001742 RID: 5954 RVA: 0x0007E6D0 File Offset: 0x0007C8D0
	public void method_30()
	{
		for (int i = 0; i < this.mMaxSlots; i++)
		{
			if (!this.mItems.ContainsKey(i))
			{
				this.method_29((byte)i);
			}
		}
	}

	// Token: 0x06001743 RID: 5955 RVA: 0x000112D9 File Offset: 0x0000F4D9
	public ItemDNA method_31(AvatarSubPart avatarSubPart_0)
	{
		return this.mEquippedOutfit[avatarSubPart_0];
	}

	// Token: 0x06001744 RID: 5956 RVA: 0x0007E704 File Offset: 0x0007C904
	public void method_32(int int_0)
	{
		if (int_0 < 0 || int_0 >= this.mMaxSlots)
		{
			throw new Exception(string.Format("Backpack slot {0} is out of range (backpack size = {1}).", int_0, this.mMaxSlots));
		}
		if (!this.mItems.ContainsKey(int_0))
		{
			throw new Exception(string.Format("No item in backpack slot {0}.", int_0));
		}
		InventoryItem inventoryItem = this.mItems[int_0];
		if (inventoryItem.mItem.m_type != ItemType.Outfit)
		{
			throw new Exception(string.Format("Backpack slot {0} is not an outfit part.", int_0));
		}
		this.mItems.Remove(int_0);
		OutfitDNA outfitDNA = inventoryItem.mItem.method_9();
		ItemDNA itemDNA = this.mEquippedOutfit[outfitDNA.m_avatarSubpart];
		this.mEquippedOutfit[outfitDNA.m_avatarSubpart] = inventoryItem.mItem;
		if (itemDNA != null)
		{
			for (int i = 0; i < this.mMaxSlots; i++)
			{
				if (!this.mItems.ContainsKey(i))
				{
					this.method_13(i, itemDNA, 1);
					break;
				}
			}
		}
		PhotonNetwork.onlinePeer.method_3(51, new object[] { int_0 });
	}

	// Token: 0x06001745 RID: 5957 RVA: 0x0007E828 File Offset: 0x0007CA28
	public void method_33(AvatarSubPart avatarSubPart_0)
	{
		if (mItems.Count >= mMaxSlots)
		{
			throw new Exception("Not enough room in backpack to unequip outfit.");
		}
		ItemDNA itemDNA = mEquippedOutfit[avatarSubPart_0];
		if (itemDNA == null)
		{
			throw new Exception($"No outfit equipped on {avatarSubPart_0}.");
		}
		mEquippedOutfit[avatarSubPart_0] = null;
		for (int i = 0; i < mMaxSlots; i++)
		{
			if (!mItems.ContainsKey(i))
			{
				method_13(i, itemDNA);
				break;
			}
		}
		PhotonNetwork.onlinePeer.method_3(50, (int)avatarSubPart_0);
	}
	// Token: 0x06001746 RID: 5958 RVA: 0x000112E7 File Offset: 0x0000F4E7
	public void method_34(InventoryAction inventoryAction_0, byte byte_0, byte byte_1 = 0)
	{
		if (null == MonoSingleton<AppManager>.Instance)
		{
			return;
		}
		if (MonoSingleton<AppManager>.Instance.m_offlineMode)
		{
			(OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.Prop_0 as InventoryServiceOffline).OnInventoryModification(this);
		}
	}

	// Token: 0x06001747 RID: 5959 RVA: 0x0007E8CC File Offset: 0x0007CACC
	public Hashtable method_35()
	{
		Hashtable hashtable = new Hashtable();
		foreach (KeyValuePair<int, InventoryItem> keyValuePair in this.mItems)
		{
			if (keyValuePair.Value != null)
			{
				Hashtable hashtable2 = keyValuePair.Value.mItem.method_10();
				hashtable[keyValuePair.Key] = hashtable2;
			}
		}
		Hashtable hashtable3 = new Hashtable();
		for (int i = 0; i < 4; i++)
		{
			if (this.mEquippedWeapons[i] == null)
			{
				hashtable3[i] = null;
			}
			else
			{
				hashtable3[i] = this.mEquippedWeapons[i].method_10();
			}
		}
		object obj = null;
		if (this.mShield != null)
		{
			obj = this.mShield.method_10();
		}
		object obj2 = null;
		if (this.mClassMod != null)
		{
			obj2 = this.mClassMod.method_10();
		}
		Hashtable hashtable4 = new Hashtable
		{
			{ 0, this.mCharacterId },
			{ 1, this.mNumWeaponSlots },
			{ 2, this.mActiveWeapon },
			{ 3, hashtable3 },
			{
				4,
				new Hashtable
				{
					{
						0,
						this.mAmmoCounts[4]
					},
					{
						1,
						this.mMaxAmmoCounts[4]
					}
				}
			},
			{
				5,
				new Hashtable
				{
					{
						0,
						this.mAmmoCounts[0]
					},
					{
						1,
						this.mMaxAmmoCounts[0]
					}
				}
			},
			{
				6,
				new Hashtable
				{
					{
						0,
						this.mAmmoCounts[3]
					},
					{
						1,
						this.mMaxAmmoCounts[3]
					}
				}
			},
			{
				7,
				new Hashtable
				{
					{
						0,
						this.mAmmoCounts[1]
					},
					{
						1,
						this.mMaxAmmoCounts[1]
					}
				}
			},
			{
				8,
				new Hashtable
				{
					{
						0,
						this.mAmmoCounts[2]
					},
					{
						1,
						this.mMaxAmmoCounts[2]
					}
				}
			},
			{
				12,
				new Hashtable
				{
					{
						0,
						this.mAmmoCounts[5]
					},
					{
						1,
						this.mMaxAmmoCounts[5]
					}
				}
			},
			{ 9, this.mMaxSlots },
			{ 10, hashtable },
			{ 11, obj },
			{ 13, obj2 },
			{ 14, null }
		};
		for (AvatarSubPart avatarSubPart = AvatarSubPart.HAIR; avatarSubPart < AvatarSubPart.TOTAL; avatarSubPart++)
		{
			hashtable4[(int)(15 + avatarSubPart)] = ((this.mEquippedOutfit[avatarSubPart] != null) ? this.mEquippedOutfit[avatarSubPart].method_10() : null);
		}
		return hashtable4;
	}

	// Token: 0x06001748 RID: 5960 RVA: 0x0007ECB8 File Offset: 0x0007CEB8
	public bool method_36()
	{
		bool flag = true;
		for (int i = 0; i < this.mMaxSlots; i++)
		{
			if (!this.mItems.ContainsKey(i))
			{
				flag = false;
				return flag;
			}
		}
		return flag;
	}

	// Token: 0x06001749 RID: 5961 RVA: 0x00011313 File Offset: 0x0000F513
	public int method_37()
	{
		return this.mMaxSlots;
	}

	// Token: 0x17000134 RID: 308
	// (get) Token: 0x0600174A RID: 5962 RVA: 0x0001131B File Offset: 0x0000F51B
	public int Int32_0
	{
		get
		{
			return this.mItems.Count;
		}
	}

	// Token: 0x0600174B RID: 5963 RVA: 0x00011328 File Offset: 0x0000F528
	[CompilerGenerated]
	private static bool smethod_1(InventoryItem inventoryItem_0)
	{
		return inventoryItem_0.mItem.m_type == ItemType.Material;
	}

	// Token: 0x0600174C RID: 5964 RVA: 0x00011338 File Offset: 0x0000F538
	[CompilerGenerated]
	private static int smethod_2(InventoryItem inventoryItem_0)
	{
		return Inventory.smethod_0(inventoryItem_0.mItem);
	}

	// Token: 0x0600174D RID: 5965 RVA: 0x00007599 File Offset: 0x00005799
	[CompilerGenerated]
	private static InventoryItem smethod_3(InventoryItem inventoryItem_0)
	{
		return inventoryItem_0;
	}

	// Token: 0x04000FC1 RID: 4033
	public const int MAX_MATERIAL_STACK = 99;

	// Token: 0x04000FC2 RID: 4034
	private Dictionary<int, InventoryItem> mItems = new Dictionary<int, InventoryItem>();

	// Token: 0x04000FC3 RID: 4035
	private Dictionary<int, int> mAmmoCounts = new Dictionary<int, int>
	{
		{ 0, 0 },
		{ 1, 0 },
		{ 2, 0 },
		{ 3, 0 },
		{ 4, 0 },
		{ 5, 0 }
	};

	// Token: 0x04000FC4 RID: 4036
	private Dictionary<int, int> mMaxAmmoCounts = new Dictionary<int, int>
	{
		{ 0, 0 },
		{ 1, 0 },
		{ 2, 0 },
		{ 3, 0 },
		{ 4, 0 },
		{ 5, 0 }
	};

	// Token: 0x04000FC5 RID: 4037
	private ItemDNA[] mEquippedWeapons = new ItemDNA[4];

	// Token: 0x04000FC6 RID: 4038
	private ItemDNA mShield;

	// Token: 0x04000FC7 RID: 4039
	private ItemDNA mClassMod;

	// Token: 0x04000FC8 RID: 4040
	private ItemDNA mGrenadeMod;

	// Token: 0x04000FC9 RID: 4041
	private byte mActiveWeapon;

	// Token: 0x04000FCA RID: 4042
	private byte mNumWeaponSlots = 4;

	// Token: 0x04000FCB RID: 4043
	private int mCharacterId;

	// Token: 0x04000FCC RID: 4044
	private int mMaxSlots = 42;

	// Token: 0x04000FCD RID: 4045
	private Dictionary<AvatarSubPart, ItemDNA> mEquippedOutfit = new Dictionary<AvatarSubPart, ItemDNA>();
}
