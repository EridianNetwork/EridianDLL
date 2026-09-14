using System;
using System.Collections.Generic;
using System.Xml;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020005F2 RID: 1522
public class ItemGeneratorService : MonoBehaviour
{
	// Token: 0x0600268F RID: 9871 RVA: 0x000BA5E0 File Offset: 0x000B87E0
	private void Awake()
	{
		this.m_gUIDGen = new GUIDGenerator();
		this.m_localItemDic = new Dictionary<ItemInstance, ItemDNA>();
		this.method_4("Preset_ShieldsForPlayer");
		this.method_5("Preset_ClassMode");
		this.method_6("Preset_Outfit");
		this.method_7("Character_Creation");
	}

	// Token: 0x06002690 RID: 9872 RVA: 0x00019F5A File Offset: 0x0001815A
	public ShieldDNA method_0(int int_0)
	{
		if (int_0 >= 0 && int_0 < this.m_PlayerShields.Length)
		{
			return this.m_PlayerShields[int_0];
		}
		DebugUtils.LogError(LogCategory.Gamelogic, "Invalid shield ID");
		return null;
	}

	// Token: 0x06002691 RID: 9873 RVA: 0x000BA630 File Offset: 0x000B8830
	public ShieldDNA method_1(int int_0)
	{
		for (int i = 0; i < this.m_PlayerShields.Length; i++)
		{
			if (this.m_PlayerShields[i].m_id == int_0)
			{
				return this.m_PlayerShields[i];
			}
		}
		DebugUtils.LogError(LogCategory.Gamelogic, "Invalid shield ID");
		return null;
	}

	// Token: 0x06002692 RID: 9874 RVA: 0x000BA678 File Offset: 0x000B8878
	public ShieldDNA method_2(ItemManufacturer itemManufacturer_0)
	{
		for (int i = 0; i < this.m_PlayerShields.Length; i++)
		{
			if (this.m_PlayerShields[i].m_shieldManufacturer == itemManufacturer_0)
			{
				return this.m_PlayerShields[i];
			}
		}
		DebugUtils.LogError(LogCategory.Gamelogic, "Invalid shield manufacturer");
		return null;
	}

	// Token: 0x06002693 RID: 9875 RVA: 0x00019F80 File Offset: 0x00018180
	public ClassModeDNA method_3(int int_0)
	{
		if (int_0 >= 0 && int_0 < this.m_playerClassMode.Length)
		{
			return this.m_playerClassMode[int_0];
		}
		DebugUtils.LogError(LogCategory.Gamelogic, "Invalid class mode index");
		return null;
	}

	// Token: 0x06002694 RID: 9876 RVA: 0x000BA6C0 File Offset: 0x000B88C0
	private void method_4(string string_0)
	{
		TextAsset textAsset = ResourcesLoader.smethod_0(string_0) as TextAsset;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset.text);
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("Shield");
		this.m_PlayerShields = new ShieldDNA[elementsByTagName.Count];
		int num = 0;
		foreach (XmlNode xmlNode in elementsByTagName)
		{
			ShieldDNA shieldDNA = new ShieldDNA();
			shieldDNA.m_name = xmlNode.Attributes["name"].Value;
			try
			{
				shieldDNA.m_shieldManufacturer = (ItemManufacturer)((int)Enum.Parse(typeof(ItemManufacturer), xmlNode.Attributes["manufacturer"].Value));
			}
			catch (Exception ex)
			{
				shieldDNA.m_shieldManufacturer = ItemManufacturer.Vladof;
				DebugUtils.LogError(LogCategory.Gamelogic, "Manufacturer name is not correct in presetshield for player xml. " + ex.Message);
			}
			shieldDNA.m_id = Convert.ToInt32(xmlNode.Attributes["id"].Value);
			shieldDNA.m_rarity = (ItemRarity)((int)Enum.Parse(typeof(ItemRarity), xmlNode.Attributes["rarity"].Value));
			shieldDNA.m_level = Convert.ToInt32(xmlNode.Attributes["level"].Value);
			shieldDNA.m_bodyIdx = int.Parse(xmlNode.Attributes["Body"].Value);
			shieldDNA.m_batteryIdx = int.Parse(xmlNode.Attributes["Battery"].Value);
			shieldDNA.m_capacitorIdx = int.Parse(xmlNode.Attributes["Capacitor"].Value);
			shieldDNA.m_accessoryIdx = int.Parse(xmlNode.Attributes["Accessory"].Value);
			shieldDNA.m_materialIdx = int.Parse(xmlNode.Attributes["Material"].Value);
			shieldDNA.method_2();
			this.m_PlayerShields[num++] = shieldDNA;
		}
	}

	// Token: 0x06002695 RID: 9877 RVA: 0x000BA92C File Offset: 0x000B8B2C
	private void method_5(string string_0)
	{
		TextAsset textAsset = ResourcesLoader.smethod_0(string_0) as TextAsset;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset.text);
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("ClassMode");
		this.m_playerClassMode = new ClassModeDNA[elementsByTagName.Count];
		int num = 0;
		foreach (object obj in elementsByTagName)
		{
			XmlNode xmlNode = (XmlNode)obj;
			ClassModeDNA classModeDNA = new ClassModeDNA();
			classModeDNA.m_id = Convert.ToInt32(xmlNode.Attributes["id"].Value);
			classModeDNA.m_name = xmlNode.Attributes["name"].Value;
			classModeDNA.m_cmType = (ClassModeType)((int)Enum.Parse(typeof(ClassModeType), xmlNode.Attributes["CMType"].Value));
			classModeDNA.m_level = Convert.ToInt32(xmlNode.Attributes["level"].Value);
			classModeDNA.m_rarity = (ItemRarity)((int)Enum.Parse(typeof(ItemRarity), xmlNode.Attributes["rarity"].Value));
			classModeDNA.m_adapterIdx = Convert.ToInt32(xmlNode.Attributes["Adapter"].Value);
			classModeDNA.m_bodyIdx = Convert.ToInt32(xmlNode.Attributes["Body"].Value);
			classModeDNA.m_chassisIdx = Convert.ToInt32(xmlNode.Attributes["Chassis"].Value);
			classModeDNA.m_drumIdx = Convert.ToInt32(xmlNode.Attributes["Drum"].Value);
			classModeDNA.m_materialIdx = Convert.ToInt32(xmlNode.Attributes["Material"].Value);
			classModeDNA.method_4();
			this.m_playerClassMode[num] = classModeDNA;
			num++;
		}
	}

	// Token: 0x06002696 RID: 9878 RVA: 0x000BAB5C File Offset: 0x000B8D5C
	private void method_6(string string_0)
	{
		TextAsset textAsset = ResourcesLoader.smethod_0(string_0) as TextAsset;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset.text);
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("Outfit");
		this.m_playerOutfits = new OutfitDNA[elementsByTagName.Count];
		int num = 0;
		foreach (object obj in elementsByTagName)
		{
			XmlNode xmlNode = (XmlNode)obj;
			OutfitDNA outfitDNA = new OutfitDNA();
			outfitDNA.m_id = Convert.ToInt32(xmlNode.Attributes["id"].Value);
			outfitDNA.m_name = xmlNode.Attributes["name"].Value;
			outfitDNA.m_rarity = (ItemRarity)((int)Enum.Parse(typeof(ItemRarity), xmlNode.Attributes["rarity"].Value));
			outfitDNA.m_avatarType = (AvatarType)((int)Enum.Parse(typeof(AvatarType), xmlNode.Attributes["AvatarType"].Value));
			outfitDNA.m_avatarSubpart = (AvatarSubPart)((int)Enum.Parse(typeof(AvatarSubPart), xmlNode.Attributes["AvatarSubpart"].Value));
			outfitDNA.m_index = Convert.ToInt32(xmlNode.Attributes["Index"].Value);
			this.m_playerOutfits[num] = outfitDNA;
			num++;
		}
	}

	// Token: 0x06002697 RID: 9879 RVA: 0x000BAD0C File Offset: 0x000B8F0C
	private void method_7(string string_0)
	{
		TextAsset textAsset = ResourcesLoader.smethod_0(string_0) as TextAsset;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset.text);
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("CharacterCreationOutfit");
		this.m_creationOutfitIDs = new int[elementsByTagName.Count];
		int num = 0;
		foreach (object obj in elementsByTagName)
		{
			XmlNode xmlNode = (XmlNode)obj;
			this.m_creationOutfitIDs[num] = Convert.ToInt32(xmlNode.Attributes["id"].Value);
			num++;
		}
	}

	// Token: 0x06002698 RID: 9880 RVA: 0x000BADC8 File Offset: 0x000B8FC8
	public List<BuildingPart> method_8(AvatarType avatarType_0, AvatarSubPart avatarSubPart_0)
	{
		List<BuildingPart> list = new List<BuildingPart>();
		for (int i = 0; i < this.m_playerOutfits.Length; i++)
		{
			for (int j = 0; j < this.m_creationOutfitIDs.Length; j++)
			{
				if (this.m_playerOutfits[i].m_id == this.m_creationOutfitIDs[j] && this.m_playerOutfits[i].m_avatarType == avatarType_0 && this.m_playerOutfits[i].m_avatarSubpart == avatarSubPart_0)
				{
					list.Add(this.m_playerOutfits[i].method_3());
				}
			}
		}
		return list;
	}

	// Token: 0x06002699 RID: 9881 RVA: 0x000BAE4C File Offset: 0x000B904C
	public BuildingPart method_9(AvatarType avatarType_0, AvatarSubPart avatarSubPart_0)
	{
		List<BuildingPart> list = this.method_8(avatarType_0, avatarSubPart_0);
		if (list.Count > 0)
		{
			return list[0];
		}
		return null;
	}

	// Token: 0x0600269A RID: 9882 RVA: 0x00019FA6 File Offset: 0x000181A6
	public ItemDNA method_10(ItemRarity itemRarity_0)
	{
		return this.method_11((WeaponRarity)itemRarity_0);
	}

	// Token: 0x0600269B RID: 9883 RVA: 0x000BAE74 File Offset: 0x000B9074
	public ItemDNA method_11(WeaponRarity weaponRarity_0 = WeaponRarity.Common)
	{
		WeaponType weaponType = (WeaponType)global::UnityEngine.Random.Range(0, 5);
		return ItemDNA.smethod_2(base.GetComponent<WeaponGeneratorService>().method_7(weaponType, weaponRarity_0));
	}

	// Token: 0x0600269C RID: 9884 RVA: 0x00019FAF File Offset: 0x000181AF
	public ItemDNA method_12(int int_0)
	{
		return ItemDNA.smethod_2(base.GetComponent<WeaponGeneratorService>().method_10(int_0));
	}

	// Token: 0x0600269D RID: 9885 RVA: 0x00019FC2 File Offset: 0x000181C2
	public ItemDNA method_13(WeaponType weaponType_0, ItemRarity itemRarity_0)
	{
		return this.method_14(weaponType_0, (WeaponRarity)itemRarity_0);
	}

	// Token: 0x0600269E RID: 9886 RVA: 0x00019FCC File Offset: 0x000181CC
	public ItemDNA method_14(WeaponType weaponType_0 = WeaponType.TOTAL, WeaponRarity weaponRarity_0 = WeaponRarity.Common)
	{
		if (weaponType_0 == WeaponType.TOTAL)
		{
			weaponType_0 = (WeaponType)global::UnityEngine.Random.Range(0, 5);
		}
		return ItemDNA.smethod_2(base.GetComponent<WeaponGeneratorService>().method_7(weaponType_0, weaponRarity_0));
	}

	// Token: 0x0600269F RID: 9887 RVA: 0x000BAE9C File Offset: 0x000B909C
	public ItemDNA method_15(int int_0)
	{
		if (int_0 == 0)
		{
			int_0 = MonoSingleton<LootingManager>.Instance.method_2(ItemType.HealthPack, AmmoType.SMG);
		}
		return ItemDNA.smethod_0(int_0);
	}

	// Token: 0x060026A0 RID: 9888 RVA: 0x000BAEC4 File Offset: 0x000B90C4
	public ItemDNA method_16(int int_0)
	{
		return ItemDNA.smethod_1(int_0);
	}

	// Token: 0x060026A1 RID: 9889 RVA: 0x00019FEF File Offset: 0x000181EF
	public ItemDNA method_17(int int_0 = 0)
	{
		return this.method_19(this.method_18(), int_0);
	}

	// Token: 0x060026A2 RID: 9890 RVA: 0x000BAEDC File Offset: 0x000B90DC
	public AmmoType method_18()
	{
		AmmoType ammoType = (AmmoType)global::UnityEngine.Random.Range(0, 5);
		if (ammoType >= AmmoType.Grenade)
		{
			ammoType++;
		}
		return ammoType;
	}

	// Token: 0x060026A3 RID: 9891 RVA: 0x000BAEFC File Offset: 0x000B90FC
	public ItemDNA method_19(AmmoType ammoType_0, int int_0 = 0)
	{
		if (int_0 == 0)
		{
			int_0 = MonoSingleton<LootingManager>.Instance.method_2(ItemType.Ammo, ammoType_0);
		}
		return ItemDNA.smethod_4(int_0, ammoType_0);
	}

	// Token: 0x060026A4 RID: 9892 RVA: 0x000BAF28 File Offset: 0x000B9128
	public ItemDNA method_20(int int_0)
	{
		if (int_0 == 0)
		{
			int_0 = MonoSingleton<LootingManager>.Instance.method_2(ItemType.Money, AmmoType.SMG);
		}
		return ItemDNA.smethod_5(int_0);
	}

	// Token: 0x060026A5 RID: 9893 RVA: 0x000BAF50 File Offset: 0x000B9150
	public ItemDNA method_21(ItemType itemType_0, int int_0)
	{
		if (itemType_0 == ItemType.Weapon)
		{
			return this.method_11((WeaponRarity)global::UnityEngine.Random.Range(0, 6));
		}
		if (itemType_0 == ItemType.Ammo)
		{
			return this.method_17(int_0);
		}
		if (itemType_0 == ItemType.HealthPack)
		{
			return this.method_15(int_0);
		}
		if (itemType_0 == ItemType.AmmoPack)
		{
			return this.method_16(int_0);
		}
		if (itemType_0 == ItemType.Money)
		{
			return this.method_20(int_0);
		}
		if (itemType_0 == ItemType.Shield)
		{
			return this.method_33();
		}
		if (itemType_0 == ItemType.ClassMode)
		{
			return this.method_26();
		}
		return null;
	}

	// Token: 0x060026A6 RID: 9894 RVA: 0x000BAFB8 File Offset: 0x000B91B8
	public ItemDNA method_22(int int_0)
	{
		WeaponDNA weaponDNA = MonoSingleton<AppManager>.Instance.GetComponent<WeaponGeneratorService>().method_10(int_0);
		if (weaponDNA == null)
		{
			DebugUtils.LogWarning(LogCategory.Gamelogic, "weapon id " + int_0 + " not found in the preset weapons.");
		}
		return ItemDNA.smethod_2(weaponDNA);
	}

	// Token: 0x060026A7 RID: 9895 RVA: 0x00019FFE File Offset: 0x000181FE
	public ItemDNA method_23(int int_0)
	{
		return this.method_24((MaterialType)global::UnityEngine.Random.Range(0, 13), int_0);
	}

	// Token: 0x060026A8 RID: 9896 RVA: 0x0001A00F File Offset: 0x0001820F
	public ItemDNA method_24(MaterialType materialType_0, int int_0)
	{
		if (int_0 == 0)
		{
			int_0 = 1;
		}
		return ItemDNA.smethod_3(materialType_0, int_0);
	}

	// Token: 0x060026A9 RID: 9897 RVA: 0x000BAFFC File Offset: 0x000B91FC
	public ItemDNA method_25(ItemRarity itemRarity_0)
	{
		ClassModeDNA classModeDNA = new ClassModeDNA();
		ClassModeType classModeType = (ClassModeType)global::UnityEngine.Random.Range(0, 8);
		classModeDNA.m_adapterIdx = ClassModeRarityStore.ClassModeRarityStore_0.method_0(classModeType, itemRarity_0, ClassModeSubPart.Adapter);
		classModeDNA.m_bodyIdx = ClassModeRarityStore.ClassModeRarityStore_0.method_0(classModeType, itemRarity_0, ClassModeSubPart.Body);
		classModeDNA.m_chassisIdx = ClassModeRarityStore.ClassModeRarityStore_0.method_0(classModeType, itemRarity_0, ClassModeSubPart.Chassis);
		classModeDNA.m_drumIdx = ClassModeRarityStore.ClassModeRarityStore_0.method_0(classModeType, itemRarity_0, ClassModeSubPart.Drum);
		classModeDNA.m_materialIdx = ClassModeRarityStore.ClassModeRarityStore_0.method_0(classModeType, itemRarity_0, ClassModeSubPart.Material);
		classModeDNA.m_cmType = classModeType;
		classModeDNA.m_rarity = itemRarity_0;
		classModeDNA.method_4();
		classModeDNA.method_7();
		return this.method_31(classModeDNA);
	}

	// Token: 0x060026AA RID: 9898 RVA: 0x000BB098 File Offset: 0x000B9298
	public ItemDNA method_26()
	{
		ClassModeDNA classModeDNA = this.method_3(global::UnityEngine.Random.Range(0, this.m_playerClassMode.Length));
		return this.method_31(classModeDNA);
	}

	// Token: 0x060026AB RID: 9899 RVA: 0x000BB0C4 File Offset: 0x000B92C4
	public ItemDNA method_27(int int_0)
	{
		for (int i = 0; i < this.m_playerClassMode.Length; i++)
		{
			if (this.m_playerClassMode[i].m_id == int_0)
			{
				return this.method_31(this.m_playerClassMode[i]);
			}
		}
		return null;
	}

	// Token: 0x060026AC RID: 9900 RVA: 0x000BB108 File Offset: 0x000B9308
	public ItemDNA method_28(int int_0)
	{
		for (int i = 0; i < this.m_playerOutfits.Length; i++)
		{
			if (this.m_playerOutfits[i].m_id == int_0)
			{
				return this.method_30(this.m_playerOutfits[i]);
			}
		}
		return null;
	}

	// Token: 0x060026AD RID: 9901 RVA: 0x000BB14C File Offset: 0x000B934C
	public ItemDNA method_29(int int_0)
	{
		for (int i = 0; i < this.m_PlayerShields.Length; i++)
		{
			if (this.m_PlayerShields[i].m_id == int_0)
			{
				return this.method_34(this.m_PlayerShields[i]);
			}
		}
		return null;
	}

	// Token: 0x060026AE RID: 9902 RVA: 0x0001A020 File Offset: 0x00018220
	public ItemDNA method_30(OutfitDNA outfitDNA_0)
	{
		return ItemDNA.smethod_9(outfitDNA_0);
	}

	// Token: 0x060026AF RID: 9903 RVA: 0x0001A028 File Offset: 0x00018228
	public ItemDNA method_31(ClassModeDNA classModeDNA_0)
	{
		return ItemDNA.smethod_8(classModeDNA_0);
	}

	// Token: 0x060026B0 RID: 9904 RVA: 0x00003727 File Offset: 0x00001927
	public ItemDNA method_32(ItemRarity itemRarity_0)
	{
		return null;
	}

	// Token: 0x060026B1 RID: 9905 RVA: 0x00003727 File Offset: 0x00001927
	public ItemDNA method_33()
	{
		return null;
	}

	// Token: 0x060026B2 RID: 9906 RVA: 0x0001A030 File Offset: 0x00018230
	public ItemDNA method_34(ShieldDNA shieldDNA_0)
	{
		return ItemDNA.smethod_7(shieldDNA_0);
	}

	// Token: 0x060026B3 RID: 9907 RVA: 0x000BB190 File Offset: 0x000B9390
	public ItemInstance method_35(ItemDNA itemDNA_0)
	{
		if (MonoSingleton<AppManager>.Instance.m_offlineMode)
		{
			ItemInstance itemInstance = new ItemInstance(this.m_gUIDGen.method_1(false), 0);
			this.m_localItemDic.Add(itemInstance, itemDNA_0);
			return itemInstance;
		}
		return null;
	}

	// Token: 0x060026B4 RID: 9908 RVA: 0x0001A038 File Offset: 0x00018238
	public static string smethod_0(ItemDNA itemDNA_0)
	{
		if (itemDNA_0 != null)
		{
			return ItemGeneratorService.smethod_4(itemDNA_0.m_type, itemDNA_0.m_ammoType, itemDNA_0.m_materialType, itemDNA_0);
		}
		return string.Empty;
	}

	// Token: 0x060026B5 RID: 9909 RVA: 0x0001A05B File Offset: 0x0001825B
	public static string smethod_1(ItemType itemType_0)
	{
		return ItemGeneratorService.smethod_4(itemType_0, AmmoType.TOTAL, MaterialType.TOTAL, null);
	}

	// Token: 0x060026B6 RID: 9910 RVA: 0x0001A067 File Offset: 0x00018267
	public static string smethod_2(ItemType itemType_0, AmmoType ammoType_0)
	{
		return ItemGeneratorService.smethod_4(itemType_0, ammoType_0, MaterialType.TOTAL, null);
	}

	// Token: 0x060026B7 RID: 9911 RVA: 0x0001A073 File Offset: 0x00018273
	public static string smethod_3(ItemType itemType_0, MaterialType materialType_0)
	{
		return ItemGeneratorService.smethod_4(itemType_0, AmmoType.TOTAL, materialType_0, null);
	}

	// Token: 0x060026B8 RID: 9912 RVA: 0x000BB1CC File Offset: 0x000B93CC
	private static string smethod_4(ItemType itemType_0, AmmoType ammoType_0, MaterialType materialType_0, ItemDNA itemDNA_0 = null)
	{
		string text = string.Empty;
		switch (itemType_0)
		{
		case ItemType.HealthPack:
			text = "Entities/Object/Item/PRO_Pack_HP_P";
			break;
		case ItemType.Weapon:
			text = "Entities/Object/Weapon/Weapon";
			break;
		case ItemType.Money:
			text = "Entities/Object/Item/PRO_Cash_P";
			break;
		case ItemType.Ammo:
			switch (ammoType_0)
			{
			case AmmoType.SMG:
				text = "Entities/Object/Item/PRO_Ammo_SMG_P";
				break;
			case AmmoType.SniperRifle:
				text = "Entities/Object/Item/PRO_Ammo_Sniper_P";
				break;
			case AmmoType.Grenade:
				text = "Entities/Object/Item/PRO_Ammo_Grenade_P";
				break;
			case AmmoType.ShotGun:
				text = "Entities/Object/Item/PRO_Ammo_Shotgun_P";
				break;
			case AmmoType.Pistol:
				text = "Entities/Object/Item/PRO_Ammo_RepeaterPistol_P";
				break;
			case AmmoType.AssaultRifle:
				text = "Entities/Object/Item/PRO_Ammo_SMG_P";
				break;
			}
			break;
		case ItemType.Shield:
			if (itemDNA_0 != null && itemDNA_0.m_shiled != null && itemDNA_0.m_shiled.m_shieldManufacturer != ItemManufacturer.MAX)
			{
				text = "Entities/Object/Item/PRO_Shield_" + itemDNA_0.m_shiled.m_shieldManufacturer.ToString() + "_P";
			}
			else
			{
				text = "Entities/Object/Shield";
			}
			break;
		case ItemType.Material:
			text = "Entities/Object/Item/PRO_" + materialType_0.ToString() + "_P";
			break;
		case ItemType.AmmoPack:
			text = "Entities/Object/Item/PRO_Ammo_Pack_P";
			break;
		case ItemType.ClassMode:
			if (itemDNA_0 != null && itemDNA_0.m_classMode != null)
			{
				text = "Entities/Object/Item/ClassMode/PRO_CM_" + itemDNA_0.m_classMode.m_cmType.ToString() + "_P";
			}
			break;
		case ItemType.Claptrap:
			text = "Entities/Object/Item/Claptrap";
			break;
		}
		return text;
	}

	// Token: 0x04001C24 RID: 7204
	private const string m_itemPath = "Entities/Object/Item/";

	// Token: 0x04001C25 RID: 7205
	private GUIDGenerator m_gUIDGen;

	// Token: 0x04001C26 RID: 7206
	private Dictionary<ItemInstance, ItemDNA> m_localItemDic;

	// Token: 0x04001C27 RID: 7207
	private NPCShieldSetup[] m_NPCShields;

	// Token: 0x04001C28 RID: 7208
	private ShieldDNA[] m_PlayerShields;

	// Token: 0x04001C29 RID: 7209
	private ClassModeDNA[] m_playerClassMode;

	// Token: 0x04001C2A RID: 7210
	private OutfitDNA[] m_playerOutfits;

	// Token: 0x04001C2B RID: 7211
	private int[] m_creationOutfitIDs;
}
