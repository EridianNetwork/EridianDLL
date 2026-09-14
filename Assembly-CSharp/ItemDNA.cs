using System;
using System.Collections;
using Core;
using XsdSettings;

// Token: 0x020005EF RID: 1519
public class ItemDNA
{
	// Token: 0x06002654 RID: 9812 RVA: 0x000B9250 File Offset: 0x000B7450
	private ItemDNA()
	{
		this.m_itemId = -1;
		this.m_type = ItemType.TOTAL;
		this.m_weapon = null;
		this.m_value = 0;
		this.m_shiled = null;
		this.m_classMode = null;
		this.m_outfit = null;
		this.m_ownerID = 0;
		this.m_UID = Guid.NewGuid().ToString();
	}

	// Token: 0x170001DD RID: 477
	// (get) Token: 0x06002656 RID: 9814 RVA: 0x00019E58 File Offset: 0x00018058
	// (set) Token: 0x06002657 RID: 9815 RVA: 0x00019E60 File Offset: 0x00018060
	public int m_itemId { get; set; }

	// Token: 0x170001DE RID: 478
	// (get) Token: 0x06002658 RID: 9816 RVA: 0x00019E69 File Offset: 0x00018069
	// (set) Token: 0x06002659 RID: 9817 RVA: 0x00019E71 File Offset: 0x00018071
	public ItemType m_type { get; private set; }

	// Token: 0x170001DF RID: 479
	// (get) Token: 0x0600265A RID: 9818 RVA: 0x00019E7A File Offset: 0x0001807A
	// (set) Token: 0x0600265B RID: 9819 RVA: 0x00019E82 File Offset: 0x00018082
	public AmmoType m_ammoType { get; private set; }

	// Token: 0x170001E0 RID: 480
	// (get) Token: 0x0600265C RID: 9820 RVA: 0x00019E8B File Offset: 0x0001808B
	// (set) Token: 0x0600265D RID: 9821 RVA: 0x00019E93 File Offset: 0x00018093
	public MaterialType m_materialType { get; private set; }

	// Token: 0x170001E1 RID: 481
	// (get) Token: 0x0600265E RID: 9822 RVA: 0x00019E9C File Offset: 0x0001809C
	// (set) Token: 0x0600265F RID: 9823 RVA: 0x00019EA4 File Offset: 0x000180A4
	public ShieldDNA m_shiled { get; private set; }

	// Token: 0x170001E2 RID: 482
	// (get) Token: 0x06002660 RID: 9824 RVA: 0x00019EAD File Offset: 0x000180AD
	// (set) Token: 0x06002661 RID: 9825 RVA: 0x00019EB5 File Offset: 0x000180B5
	public ClassModeDNA m_classMode { get; private set; }

	// Token: 0x170001E3 RID: 483
	// (get) Token: 0x06002662 RID: 9826 RVA: 0x00019EBE File Offset: 0x000180BE
	// (set) Token: 0x06002663 RID: 9827 RVA: 0x00019EC6 File Offset: 0x000180C6
	public OutfitDNA m_outfit { get; private set; }

	// Token: 0x170001E4 RID: 484
	// (get) Token: 0x06002664 RID: 9828 RVA: 0x00019ECF File Offset: 0x000180CF
	// (set) Token: 0x06002665 RID: 9829 RVA: 0x00019ED7 File Offset: 0x000180D7
	public int m_value { get; set; }

	// Token: 0x170001E5 RID: 485
	// (get) Token: 0x06002666 RID: 9830 RVA: 0x00019EE0 File Offset: 0x000180E0
	// (set) Token: 0x06002667 RID: 9831 RVA: 0x00019EE8 File Offset: 0x000180E8
	public int m_price { get; private set; }

	// Token: 0x170001E6 RID: 486
	// (get) Token: 0x06002668 RID: 9832 RVA: 0x00019EF1 File Offset: 0x000180F1
	// (set) Token: 0x06002669 RID: 9833 RVA: 0x00019EF9 File Offset: 0x000180F9
	public int m_expiration { get; set; }

	// Token: 0x170001E7 RID: 487
	// (get) Token: 0x0600266A RID: 9834 RVA: 0x00019F02 File Offset: 0x00018102
	// (set) Token: 0x0600266B RID: 9835 RVA: 0x00019F0A File Offset: 0x0001810A
	public string m_UID { get; set; }

	// Token: 0x0600266C RID: 9836 RVA: 0x000B92B0 File Offset: 0x000B74B0
	public int method_0()
	{
		ItemType type = this.m_type;
		switch (type)
		{
		case ItemType.Weapon:
			return this.m_weapon.m_level;
		case ItemType.Shield:
			return this.m_shiled.m_level;
		}
		switch (type)
		{
		case ItemType.ClassMode:
			return this.m_classMode.m_level;
		case ItemType.Outfit:
			return this.m_outfit.m_level;
		}
		return 1;
	}

	// Token: 0x0600266D RID: 9837 RVA: 0x000B932C File Offset: 0x000B752C
	public AmmoType method_1()
	{
		if (!this.method_3(ItemType.Weapon))
		{
			return AmmoType.TOTAL;
		}
		switch (this.m_weapon.m_type)
		{
		case WeaponType.SMG:
			return AmmoType.SMG;
		case WeaponType.SniperRifle:
			return AmmoType.SniperRifle;
		case WeaponType.ShotGun:
			return AmmoType.ShotGun;
		case WeaponType.RepeaterPistol:
			return AmmoType.Pistol;
		case WeaponType.CombatRifle:
			return AmmoType.AssaultRifle;
		default:
			DebugUtils.LogError(LogCategory.Gamelogic, "Unknow weapon type" + this.m_weapon.m_type + " to ammo type ");
			return AmmoType.TOTAL;
		}
	}

	// Token: 0x170001E8 RID: 488
	// (get) Token: 0x0600266E RID: 9838 RVA: 0x000B939C File Offset: 0x000B759C
	public ItemRarity ItemRarity_0
	{
		get
		{
			switch (this.m_type)
			{
			case ItemType.Weapon:
				return (ItemRarity)this.m_weapon.m_rarity;
			case ItemType.Shield:
				return this.m_shiled.m_rarity;
			case ItemType.Material:
				return ItemRarity.Common;
			case ItemType.ClassMode:
				return this.m_classMode.m_rarity;
			case ItemType.Outfit:
				return this.m_outfit.m_rarity;
			}
			return ItemRarity.Common;
		}
	}

	// Token: 0x0600266F RID: 9839 RVA: 0x00019F13 File Offset: 0x00018113
	public void method_2(int int_0)
	{
		this.m_price = int_0;
	}

	// Token: 0x06002670 RID: 9840 RVA: 0x000B9418 File Offset: 0x000B7618
	public static ItemDNA smethod_0(int int_0)
	{
		return new ItemDNA
		{
			m_type = ItemType.HealthPack,
			m_value = int_0
		};
	}

	// Token: 0x06002671 RID: 9841 RVA: 0x000B943C File Offset: 0x000B763C
	public static ItemDNA smethod_1(int int_0)
	{
		return new ItemDNA
		{
			m_type = ItemType.AmmoPack,
			m_value = int_0
		};
	}

	// Token: 0x06002672 RID: 9842 RVA: 0x000B9460 File Offset: 0x000B7660
	public static ItemDNA smethod_2(WeaponDNA weaponDNA_0)
	{
		return new ItemDNA
		{
			m_type = ItemType.Weapon,
			m_weapon = weaponDNA_0,
			m_itemId = weaponDNA_0.m_id
		};
	}

	// Token: 0x06002673 RID: 9843 RVA: 0x000B9490 File Offset: 0x000B7690
	public static ItemDNA smethod_3(MaterialType materialType_0, int int_0)
	{
		return new ItemDNA
		{
			m_type = ItemType.Material,
			m_materialType = materialType_0,
			m_value = int_0
		};
	}

	// Token: 0x06002674 RID: 9844 RVA: 0x000B94BC File Offset: 0x000B76BC
	public static ItemDNA smethod_4(int int_0, AmmoType ammoType_0)
	{
		return new ItemDNA
		{
			m_type = ItemType.Ammo,
			m_ammoType = ammoType_0,
			m_value = int_0
		};
	}

	// Token: 0x06002675 RID: 9845 RVA: 0x000B94E8 File Offset: 0x000B76E8
	public static ItemDNA smethod_5(int int_0)
	{
		return new ItemDNA
		{
			m_type = ItemType.Money,
			m_value = int_0
		};
	}

	// Token: 0x06002676 RID: 9846 RVA: 0x000B950C File Offset: 0x000B770C
	public static ItemDNA smethod_6()
	{
		return new ItemDNA
		{
			m_type = ItemType.Shield
		};
	}

	// Token: 0x06002677 RID: 9847 RVA: 0x000B9528 File Offset: 0x000B7728
	public static ItemDNA smethod_7(ShieldDNA shieldDNA_0)
	{
		return new ItemDNA
		{
			m_type = ItemType.Shield,
			m_shiled = shieldDNA_0,
			m_itemId = shieldDNA_0.m_id
		};
	}

	// Token: 0x06002678 RID: 9848 RVA: 0x000B9558 File Offset: 0x000B7758
	public static ItemDNA smethod_8(ClassModeDNA classModeDNA_0)
	{
		return new ItemDNA
		{
			m_type = ItemType.ClassMode,
			m_classMode = classModeDNA_0,
			m_itemId = classModeDNA_0.m_id
		};
	}

	// Token: 0x06002679 RID: 9849 RVA: 0x000B9588 File Offset: 0x000B7788
	public static ItemDNA smethod_9(OutfitDNA outfitDNA_0)
	{
		return new ItemDNA
		{
			m_type = ItemType.Outfit,
			m_outfit = outfitDNA_0,
			m_itemId = outfitDNA_0.m_id
		};
	}

	// Token: 0x0600267A RID: 9850 RVA: 0x000B95B8 File Offset: 0x000B77B8
	public static ItemDNA smethod_10()
	{
		return new ItemDNA
		{
			m_type = ItemType.Claptrap
		};
	}

	// Token: 0x0600267B RID: 9851 RVA: 0x000B95D4 File Offset: 0x000B77D4
	public static string smethod_11(string string_0)
	{
		int num = string_0.IndexOf(" ");
		if (num <= 0)
		{
			return LocalizedString.smethod_0(new LocalizedString(string_0));
		}
		string[] array = string_0.Split(new char[] { ' ' });
		string text = null;
		for (int i = 0; i < array.Length; i++)
		{
			text += LocalizedString.smethod_0(new LocalizedString(array[i]));
			if (i != array.Length - 1)
			{
				text += " ";
			}
		}
		return text;
	}

	// Token: 0x0600267C RID: 9852 RVA: 0x00019F1C File Offset: 0x0001811C
	public bool method_3(ItemType itemType_0)
	{
		return this.m_type == itemType_0;
	}

	// Token: 0x0600267D RID: 9853 RVA: 0x000B9648 File Offset: 0x000B7848
	public bool method_4()
	{
		bool flag = false;
		if (this.m_type == ItemType.Weapon)
		{
			return this.ItemRarity_0 == ItemRarity.VeryRare || this.ItemRarity_0 == ItemRarity.Epic || this.ItemRarity_0 == ItemRarity.MetaEpic;
		}
		if (this.m_type == ItemType.Material)
		{
			return this.m_materialType == MaterialType.MT_Purple_Crystal;
		}
		return flag;
	}

	// Token: 0x0600267E RID: 9854 RVA: 0x000B9694 File Offset: 0x000B7894
	public bool method_5(EntityPlayer entityPlayer_0)
	{
		ItemType type = this.m_type;
		switch (type)
		{
		case ItemType.Weapon:
		{
			WeaponDNA weaponDNA = this.method_6();
			if (weaponDNA != null)
			{
				return entityPlayer_0.vmethod_3() >= weaponDNA.m_level;
			}
			DebugUtils.LogWarning(LogCategory.Gamelogic, "it should be a type of weapon, but it's dna is null");
			return false;
		}
		case ItemType.Shield:
		{
			ShieldDNA shieldDNA = this.method_7();
			if (shieldDNA != null)
			{
				return entityPlayer_0.vmethod_3() >= shieldDNA.m_level;
			}
			DebugUtils.LogWarning(LogCategory.Gamelogic, "it should be a type of Shield, but it's dna is null");
			return false;
		}
		}
		switch (type)
		{
		case ItemType.ClassMode:
		{
			ClassModeDNA classModeDNA = this.method_8();
			if (classModeDNA != null)
			{
				return entityPlayer_0.vmethod_3() >= classModeDNA.m_level && classModeDNA.method_3(classModeDNA.m_cmType) == entityPlayer_0.method_70();
			}
			DebugUtils.LogWarning(LogCategory.Gamelogic, "it should be a type of ClassMode, but it's dna is null");
			break;
		}
		case ItemType.Outfit:
		{
			OutfitDNA outfitDNA = this.method_9();
			if (outfitDNA != null)
			{
				return entityPlayer_0.vmethod_3() >= outfitDNA.m_level && outfitDNA.m_avatarType == entityPlayer_0.method_70();
			}
			DebugUtils.LogWarning(LogCategory.Gamelogic, "it should be a type of Outfit, but it's dna is null");
			break;
		}
		}
		return false;
	}

	// Token: 0x0600267F RID: 9855 RVA: 0x00019F27 File Offset: 0x00018127
	public WeaponDNA method_6()
	{
		return this.m_weapon;
	}

	// Token: 0x06002680 RID: 9856 RVA: 0x00019F2F File Offset: 0x0001812F
	public ShieldDNA method_7()
	{
		return this.m_shiled;
	}

	// Token: 0x06002681 RID: 9857 RVA: 0x00019F37 File Offset: 0x00018137
	public ClassModeDNA method_8()
	{
		return this.m_classMode;
	}

	// Token: 0x06002682 RID: 9858 RVA: 0x00019F3F File Offset: 0x0001813F
	public OutfitDNA method_9()
	{
		return this.m_outfit;
	}

	// Token: 0x06002683 RID: 9859 RVA: 0x000B97AC File Offset: 0x000B79AC
	public override string ToString()
	{
		if (this.m_type == ItemType.Weapon)
		{
			return this.m_type.ToString() + this.m_weapon.ToString();
		}
		if (this.m_type == ItemType.Ammo)
		{
			return this.m_type.ToString() + this.m_ammoType.ToString() + this.m_value;
		}
		return this.m_type.ToString() + this.m_value;
	}

	// Token: 0x06002684 RID: 9860 RVA: 0x000B9840 File Offset: 0x000B7A40
	public override bool Equals(object obj)
	{
		ItemDNA itemDNA = obj as ItemDNA;
		if (itemDNA != null && this.m_type == itemDNA.m_type)
		{
			if (this.m_type == ItemType.Weapon)
			{
				return this.m_weapon.Equals(itemDNA.m_weapon);
			}
			if (this.m_type != ItemType.Ammo)
			{
				return this.m_value == itemDNA.m_value;
			}
			if (this.m_ammoType == itemDNA.m_ammoType)
			{
				return this.m_value == itemDNA.m_value;
			}
		}
		return false;
	}

	// Token: 0x06002685 RID: 9861 RVA: 0x000B98B8 File Offset: 0x000B7AB8
	public override int GetHashCode()
	{
		if (this.m_type == ItemType.Weapon)
		{
			return this.m_weapon.GetHashCode();
		}
		if (this.m_type == ItemType.Shield && this.m_shiled != null)
		{
			return this.m_shiled.GetHashCode();
		}
		if (this.m_type == ItemType.ClassMode && this.m_classMode != null)
		{
			return this.m_classMode.GetHashCode();
		}
		if (this.m_type == ItemType.Outfit && this.m_outfit != null)
		{
			return this.m_outfit.GetHashCode();
		}
		return this.m_value.GetHashCode();
	}

	// Token: 0x06002686 RID: 9862 RVA: 0x000B9940 File Offset: 0x000B7B40
	public static ItemDNA smethod_12(Hashtable hashtable_0)
	{
		ItemType itemType = (ItemType)((int)hashtable_0[0]);
		ItemDNA itemDNA = null;
		int num = 8;
		switch (itemType)
		{
		case ItemType.Weapon:
		{
			WeaponDNA weaponDNA = WeaponDNA.smethod_0(hashtable_0, num);
			itemDNA = ItemDNA.smethod_2(weaponDNA);
			ItemDNA.smethod_13(ref itemDNA, hashtable_0, num + 14);
			goto IL_00FF;
		}
		case ItemType.Money:
		{
			int num2 = (int)hashtable_0[num + 1];
			itemDNA = ItemDNA.smethod_5(num2);
			goto IL_00FF;
		}
		case ItemType.Shield:
		{
			ShieldDNA shieldDNA = ShieldDNA.smethod_0(hashtable_0, num);
			itemDNA = ItemDNA.smethod_7(shieldDNA);
			ItemDNA.smethod_13(ref itemDNA, hashtable_0, 17);
			goto IL_00FF;
		}
		case ItemType.Material:
			itemDNA = ItemDNA.smethod_3((MaterialType)((int)hashtable_0[num + 1]), (int)hashtable_0[num + 2]);
			goto IL_00FF;
		case ItemType.ClassMode:
		{
			ClassModeDNA classModeDNA = ClassModeDNA.smethod_0(hashtable_0, num);
			itemDNA = ItemDNA.smethod_8(classModeDNA);
			goto IL_00FF;
		}
		case ItemType.Outfit:
		{
			OutfitDNA outfitDNA = OutfitDNA.smethod_0(hashtable_0, num);
			itemDNA = ItemDNA.smethod_9(outfitDNA);
			goto IL_00FF;
		}
		}
		return null;
		IL_00FF:
		itemDNA.m_price = (int)hashtable_0[5];
		itemDNA.m_expiration = (int)hashtable_0[6];
		itemDNA.m_ownerID = (int)hashtable_0[7];
		itemDNA.m_UID = (string)hashtable_0[8];
		return itemDNA;
	}

	// Token: 0x06002687 RID: 9863 RVA: 0x000B9AAC File Offset: 0x000B7CAC
	public Hashtable method_10()
	{
		switch (this.m_type)
		{
		case ItemType.Weapon:
		{
			Hashtable hashtable = new Hashtable
			{
				{
					0,
					(int)this.m_type
				},
				{
					1,
					this.m_weapon.m_level
				},
				{
					2,
					(int)this.m_weapon.m_rarity
				},
				{
					3,
					(int)this.m_weapon.m_generationSource
				},
				{
					4,
					this.m_weapon.m_id
				},
				{ 5, this.m_price },
				{ 6, this.m_expiration },
				{ 7, this.m_ownerID },
				{ 8, this.m_UID }
			};
			int count = hashtable.Count;
			hashtable[count++] = this.m_weapon.m_name;
			hashtable[count++] = (int)this.m_weapon.m_type;
			foreach (int num in this.m_weapon.m_subPartsCode)
			{
				SubPartWpn subPartWpn = SubPartWeaponStore.SubPartWeaponStore_0.method_1(num);
				if (subPartWpn != null)
				{
					hashtable[count++] = subPartWpn.m_Index;
				}
				else
				{
					hashtable[count++] = -1;
				}
			}
			hashtable[count++] = this.m_weapon.m_starLevel;
			hashtable[count++] = this.m_weapon.m_starExperience;
			this.method_11(ref hashtable);
			return hashtable;
		}
		case ItemType.Shield:
		{
			Hashtable hashtable = new Hashtable
			{
				{
					0,
					(int)this.m_type
				},
				{
					1,
					this.m_shiled.m_level
				},
				{
					2,
					(int)this.m_shiled.m_rarity
				},
				{
					3,
					(int)this.m_shiled.m_generationSource
				},
				{
					4,
					this.m_shiled.m_id
				},
				{ 5, this.m_price },
				{ 6, this.m_expiration },
				{ 7, this.m_ownerID },
				{ 8, this.m_UID }
			};
			int count2 = hashtable.Count;
			hashtable[count2++] = this.m_shiled.m_name;
			hashtable[count2++] = 0;
			hashtable[count2++] = (int)this.m_shiled.m_shieldManufacturer;
			hashtable[count2++] = this.m_shiled.m_bodyIdx;
			hashtable[count2++] = this.m_shiled.m_batteryIdx;
			hashtable[count2++] = this.m_shiled.m_capacitorIdx;
			hashtable[count2++] = this.m_shiled.m_accessoryIdx;
			hashtable[count2++] = this.m_shiled.m_materialIdx;
			this.method_11(ref hashtable);
			return hashtable;
		}
		case ItemType.Material:
			return new Hashtable
			{
				{
					0,
					(int)this.m_type
				},
				{ 1, 1 },
				{ 2, 0 },
				{ 3, 0 },
				{ 4, 0 },
				{ 5, this.m_price },
				{ 6, this.m_expiration },
				{ 7, this.m_ownerID },
				{ 8, this.m_UID },
				{ 9, this.m_materialType },
				{ 10, this.m_value }
			};
		case ItemType.ClassMode:
		{
			Hashtable hashtable = new Hashtable
			{
				{
					0,
					(int)this.m_type
				},
				{
					1,
					this.m_classMode.m_level
				},
				{
					2,
					(int)this.m_classMode.m_rarity
				},
				{
					3,
					(int)this.m_classMode.m_generationSource
				},
				{
					4,
					this.m_classMode.m_id
				},
				{ 5, this.m_price },
				{ 6, this.m_expiration },
				{ 7, this.m_ownerID },
				{ 8, this.m_UID }
			};
			int count3 = hashtable.Count;
			hashtable[count3++] = this.m_classMode.m_name;
			hashtable[count3++] = (int)this.m_classMode.m_cmType;
			hashtable[count3++] = this.m_classMode.m_adapterIdx;
			hashtable[count3++] = this.m_classMode.m_bodyIdx;
			hashtable[count3++] = this.m_classMode.m_chassisIdx;
			hashtable[count3++] = this.m_classMode.m_drumIdx;
			hashtable[count3++] = this.m_classMode.m_materialIdx;
			return hashtable;
		}
		case ItemType.Outfit:
		{
			Hashtable hashtable = new Hashtable
			{
				{
					0,
					(int)this.m_type
				},
				{
					1,
					this.m_outfit.m_level
				},
				{
					2,
					(int)this.m_outfit.m_rarity
				},
				{ 3, 0 },
				{
					4,
					this.m_outfit.m_id
				},
				{ 5, this.m_price },
				{ 6, this.m_expiration },
				{ 7, this.m_ownerID },
				{ 8, this.m_UID }
			};
			int count4 = hashtable.Count;
			hashtable[count4++] = this.m_outfit.m_name;
			hashtable[count4++] = this.m_outfit.m_itemDescription;
			hashtable[count4++] = this.m_outfit.m_avatarType;
			hashtable[count4++] = this.m_outfit.m_avatarSubpart;
			hashtable[count4++] = this.m_outfit.m_index;
			return hashtable;
		}
		}
		return null;
	}

	// Token: 0x06002688 RID: 9864 RVA: 0x000BA354 File Offset: 0x000B8554
	private void method_11(ref Hashtable hashtable_0)
	{
		int count = hashtable_0.Count;
		if (this.method_3(ItemType.Weapon))
		{
			WeaponDNA weaponDNA = this.method_6();
			if (weaponDNA != null)
			{
				hashtable_0[count++] = weaponDNA.m_extraEffectCount;
				for (int i = 0; i < weaponDNA.m_extraEffectCount; i++)
				{
					hashtable_0[count++] = weaponDNA.m_extraEffect[i];
					hashtable_0[count++] = weaponDNA.m_extraEffectIndex[i];
				}
			}
		}
		else if (this.method_3(ItemType.Shield))
		{
			ShieldDNA shieldDNA = this.method_7();
			if (shieldDNA != null)
			{
				hashtable_0[count++] = shieldDNA.m_extraEffectCount;
				for (int j = 0; j < shieldDNA.m_extraEffectCount; j++)
				{
					hashtable_0[count++] = shieldDNA.m_extraEffect[j];
					hashtable_0[count++] = shieldDNA.m_extraEffectIndex[j];
				}
			}
		}
		else
		{
			hashtable_0[count++] = 0;
		}
	}

	// Token: 0x06002689 RID: 9865 RVA: 0x000BA48C File Offset: 0x000B868C
	private static void smethod_13(ref ItemDNA itemDNA_0, Hashtable hashtable_0, int int_0)
	{
		if (itemDNA_0.method_3(ItemType.Weapon))
		{
			WeaponDNA weaponDNA = itemDNA_0.method_6();
			if (weaponDNA != null)
			{
				WeaponDNA weaponDNA2 = weaponDNA;
				int num = int_0 + 1;
				weaponDNA2.m_extraEffectCount = (int)hashtable_0[int_0];
				for (int i = 0; i < itemDNA_0.method_6().m_extraEffectCount; i++)
				{
					weaponDNA.m_extraEffect[i] = (int)hashtable_0[num++];
					weaponDNA.m_extraEffectIndex[i] = (int)hashtable_0[num++];
				}
			}
		}
		else if (itemDNA_0.method_3(ItemType.Shield))
		{
			ShieldDNA shieldDNA = itemDNA_0.method_7();
			if (shieldDNA != null)
			{
				ShieldDNA shieldDNA2 = shieldDNA;
				int num = int_0 + 1;
				shieldDNA2.m_extraEffectCount = (int)hashtable_0[int_0];
				for (int j = 0; j < itemDNA_0.method_7().m_extraEffectCount; j++)
				{
					shieldDNA.m_extraEffect[j] = (int)hashtable_0[num++];
					shieldDNA.m_extraEffectIndex[j] = (int)hashtable_0[num++];
				}
			}
		}
	}

	// Token: 0x04001C10 RID: 7184
	private WeaponDNA m_weapon;

	// Token: 0x04001C11 RID: 7185
	public static int m_extraEffectNums = 8;

	// Token: 0x04001C12 RID: 7186
	public int m_ownerID;
}
