using System;
using System.IO;
using System.Text;
using Core;
using ExitGames.Client.Photon;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000AAD RID: 2733
public static class BolCustomType
{
	// Token: 0x06004A28 RID: 18984 RVA: 0x0013355C File Offset: 0x0013175C
	public static int smethod_0(object object_0)
	{
		int num = 0;
		if (object_0 != null)
		{
			if (object_0 is Enum)
			{
				num = 5;
			}
			else if (object_0 is int)
			{
				num = 5;
			}
			else if (object_0 is short)
			{
				num = 3;
			}
			else if (object_0 is ushort)
			{
				num = 3;
			}
			else if (object_0 is byte)
			{
				num = 2;
			}
			else if (object_0 is char)
			{
				num = 3;
			}
			else if (object_0 is bool)
			{
				num = 2;
			}
			else if (object_0 is double)
			{
				num = 9;
			}
			else if (object_0 is float)
			{
				num = 5;
			}
			else if (object_0 is Vector2)
			{
				num = 10;
			}
			else if (object_0 is Vector3)
			{
				num = 15;
			}
			else if (object_0 is Transform)
			{
				num = 30;
			}
			else if (object_0 is Quaternion)
			{
				num = 16;
			}
			else if (object_0 is PhotonPlayer)
			{
				num = 4;
			}
			else if (object_0 is WeaponDNA)
			{
				num = 106;
			}
			else if (object_0 is ItemDNA)
			{
				num = 98;
			}
			else if (object_0 is ItemInstance)
			{
				num = 39;
			}
			else if (object_0 is AvatarDNA)
			{
				num = 14;
			}
			else
			{
				DebugUtils.LogWarning(LogCategory.Network, "unknown BOL custom type:" + object_0.GetType().Name);
			}
		}
		return num;
	}

	// Token: 0x06004A29 RID: 18985 RVA: 0x00133690 File Offset: 0x00131890
	public static void smethod_1()
	{
		PhotonPeer.RegisterType(typeof(WeaponDNA), 65, new SerializeMethod(BolCustomType.smethod_2), new DeserializeMethod(BolCustomType.smethod_3));
		PhotonPeer.RegisterType(typeof(ItemDNA), 66, new SerializeMethod(BolCustomType.smethod_4), new DeserializeMethod(BolCustomType.smethod_5));
		PhotonPeer.RegisterType(typeof(ItemInstance), 67, new SerializeMethod(BolCustomType.smethod_6), new DeserializeMethod(BolCustomType.smethod_7));
		PhotonPeer.RegisterType(typeof(AvatarDNA), 68, new SerializeMethod(BolCustomType.smethod_8), new DeserializeMethod(BolCustomType.smethod_9));
	}

	// Token: 0x06004A2A RID: 18986 RVA: 0x00133748 File Offset: 0x00131948
	private static byte[] smethod_2(object object_0)
	{
		WeaponDNA weaponDNA = (WeaponDNA)object_0;
		byte[] bytes = Encoding.Unicode.GetBytes(weaponDNA.m_name);
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(BitConverter.GetBytes(weaponDNA.m_id), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(weaponDNA.m_level), 0, 4);
		memoryStream.Write(BitConverter.GetBytes((int)weaponDNA.m_type), 0, 4);
		memoryStream.Write(BitConverter.GetBytes((int)weaponDNA.m_rarity), 0, 4);
		memoryStream.Write(BitConverter.GetBytes((int)weaponDNA.m_generationSource), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(weaponDNA.m_starLevel), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(weaponDNA.m_starExperience), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(weaponDNA.m_subPartsCode.Length), 0, 4);
		for (int i = 0; i < weaponDNA.m_subPartsCode.Length; i++)
		{
			memoryStream.Write(BitConverter.GetBytes(weaponDNA.m_subPartsCode[i]), 0, 4);
		}
		memoryStream.Write(BitConverter.GetBytes(weaponDNA.m_extraEffectCount), 0, 4);
		for (int j = 0; j < weaponDNA.m_extraEffectCount; j++)
		{
			memoryStream.Write(BitConverter.GetBytes(weaponDNA.m_extraEffect[j]), 0, 4);
		}
		for (int k = 0; k < weaponDNA.m_extraEffectCount; k++)
		{
			memoryStream.Write(BitConverter.GetBytes(weaponDNA.m_extraEffectIndex[k]), 0, 4);
		}
		memoryStream.Write(BitConverter.GetBytes(bytes.Length), 0, 4);
		memoryStream.Write(bytes, 0, bytes.Length);
		return memoryStream.ToArray();
	}

	// Token: 0x06004A2B RID: 18987 RVA: 0x001338C0 File Offset: 0x00131AC0
	private static object smethod_3(byte[] byte_0)
	{
		WeaponDNA weaponDNA = new WeaponDNA();
		weaponDNA.m_id = BitConverter.ToInt32(byte_0, 0);
		weaponDNA.m_level = BitConverter.ToInt32(byte_0, 4);
		weaponDNA.m_type = (WeaponType)((byte)BitConverter.ToChar(byte_0, 8));
		weaponDNA.m_rarity = (WeaponRarity)((byte)BitConverter.ToChar(byte_0, 12));
		weaponDNA.m_generationSource = (GenerationSource)((byte)BitConverter.ToChar(byte_0, 16));
		weaponDNA.m_starLevel = BitConverter.ToInt32(byte_0, 20);
		weaponDNA.m_starExperience = BitConverter.ToInt32(byte_0, 24);
		int num = BitConverter.ToInt32(byte_0, 28);
		int num2 = 32;
		if (num != weaponDNA.m_subPartsCode.Length)
		{
			DebugUtils.LogError(LogCategory.Network, "DeserializeWeaponDNA subparts num is different");
		}
		for (int i = 0; i < num; i++)
		{
			weaponDNA.m_subPartsCode[i] = BitConverter.ToInt32(byte_0, num2);
			num2 += 4;
		}
		weaponDNA.m_extraEffectCount = BitConverter.ToInt32(byte_0, num2);
		num2 += 4;
		if (weaponDNA.m_extraEffectCount > ItemDNA.m_extraEffectNums)
		{
			DebugUtils.LogError(LogCategory.Network, "m_extraEffectCount number + " + weaponDNA.m_extraEffectCount + " is over max");
		}
		for (int j = 0; j < weaponDNA.m_extraEffectCount; j++)
		{
			weaponDNA.m_extraEffect[j] = BitConverter.ToInt32(byte_0, num2);
			num2 += 4;
		}
		for (int k = 0; k < weaponDNA.m_extraEffectCount; k++)
		{
			weaponDNA.m_extraEffectIndex[k] = BitConverter.ToInt32(byte_0, num2);
			num2 += 4;
		}
		int num3 = BitConverter.ToInt32(byte_0, num2);
		num2 += 4;
		weaponDNA.m_name = Encoding.Unicode.GetString(byte_0, num2, num3);
		num2 += num3;
		weaponDNA.method_5();
		return weaponDNA;
	}

	// Token: 0x06004A2C RID: 18988 RVA: 0x00133A4C File Offset: 0x00131C4C
	private static byte[] smethod_4(object object_0)
	{
		ItemDNA itemDNA = (ItemDNA)object_0;
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_type), 0, 4);
		if (itemDNA.method_3(ItemType.Weapon))
		{
			byte[] array = BolCustomType.smethod_2(itemDNA.method_6());
			memoryStream.Write(array, 0, array.Length);
		}
		else if (itemDNA.method_3(ItemType.Ammo))
		{
			memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_ammoType), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_value), 0, 4);
		}
		else if (itemDNA.method_3(ItemType.Material))
		{
			memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_materialType), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_value), 0, 4);
		}
		else if (itemDNA.method_3(ItemType.Shield))
		{
			if (itemDNA.m_shiled != null)
			{
				memoryStream.Write(BitConverter.GetBytes(itemDNA.m_shiled.m_id), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(itemDNA.m_shiled.m_level), 0, 4);
				memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_shiled.m_shieldManufacturer), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(itemDNA.m_shiled.m_bodyIdx), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(itemDNA.m_shiled.m_batteryIdx), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(itemDNA.m_shiled.m_capacitorIdx), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(itemDNA.m_shiled.m_accessoryIdx), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(itemDNA.m_shiled.m_materialIdx), 0, 4);
				memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_shiled.m_generationSource), 0, 4);
				memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_shiled.m_rarity), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(itemDNA.m_shiled.m_extraEffectCount), 0, 4);
				for (int i = 0; i < itemDNA.m_shiled.m_extraEffectCount; i++)
				{
					memoryStream.Write(BitConverter.GetBytes(itemDNA.m_shiled.m_extraEffect[i]), 0, 4);
				}
				for (int j = 0; j < itemDNA.m_shiled.m_extraEffectCount; j++)
				{
					memoryStream.Write(BitConverter.GetBytes(itemDNA.m_shiled.m_extraEffectIndex[j]), 0, 4);
				}
				byte[] bytes = Encoding.Unicode.GetBytes(itemDNA.m_shiled.m_name);
				memoryStream.Write(BitConverter.GetBytes(bytes.Length), 0, 4);
				memoryStream.Write(bytes, 0, bytes.Length);
			}
			else
			{
				memoryStream.Write(BitConverter.GetBytes(0), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(0), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(0), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(0), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(0), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(0), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(0), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(0), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(0), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(0), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(0), 0, 4);
			}
		}
		else if (itemDNA.method_3(ItemType.ClassMode))
		{
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_classMode.m_id), 0, 4);
			memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_classMode.m_cmType), 0, 4);
			memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_classMode.m_rarity), 0, 4);
			memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_classMode.m_generationSource), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_classMode.m_adapterIdx), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_classMode.m_bodyIdx), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_classMode.m_chassisIdx), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_classMode.m_drumIdx), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_classMode.m_materialIdx), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_classMode.m_level), 0, 4);
			byte[] bytes2 = Encoding.Unicode.GetBytes(itemDNA.m_classMode.m_name);
			memoryStream.Write(BitConverter.GetBytes(bytes2.Length), 0, 4);
			memoryStream.Write(bytes2, 0, bytes2.Length);
		}
		else if (itemDNA.method_3(ItemType.Outfit))
		{
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_outfit.m_id), 0, 4);
			memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_outfit.m_avatarType), 0, 4);
			memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_outfit.m_avatarSubpart), 0, 4);
			memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_outfit.m_expirationType), 0, 4);
			memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_outfit.m_rarity), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_outfit.m_level), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_outfit.m_index), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_outfit.m_expirationTime), 0, 4);
			byte[] bytes3 = Encoding.Unicode.GetBytes(itemDNA.m_outfit.m_name);
			memoryStream.Write(BitConverter.GetBytes(bytes3.Length), 0, 4);
			memoryStream.Write(bytes3, 0, bytes3.Length);
		}
		else
		{
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_value), 0, 4);
		}
		return memoryStream.ToArray();
	}

	// Token: 0x06004A2D RID: 18989 RVA: 0x00133FB8 File Offset: 0x001321B8
	private static object smethod_5(byte[] byte_0)
	{
		ItemDNA itemDNA = null;
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(byte_0, 0, byte_0.Length);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		byte[] array = new byte[4];
		memoryStream.Read(array, 0, 4);
		int num = BitConverter.ToInt32(byte_0, 0);
		if (num == 2)
		{
			byte[] array2 = new byte[memoryStream.Length - memoryStream.Position];
			memoryStream.Read(array2, 0, array2.Length);
			WeaponDNA weaponDNA = new WeaponDNA();
			weaponDNA = (WeaponDNA)BolCustomType.smethod_3(array2);
			itemDNA = ItemDNA.smethod_2(weaponDNA);
		}
		if (num == 1)
		{
			memoryStream.Read(array, 0, array.Length);
			int num2 = BitConverter.ToInt32(array, 0);
			itemDNA = ItemDNA.smethod_0(num2);
		}
		if (num == 7)
		{
			memoryStream.Read(array, 0, array.Length);
			int num3 = BitConverter.ToInt32(array, 0);
			itemDNA = ItemDNA.smethod_1(num3);
		}
		if (num == 4)
		{
			memoryStream.Read(array, 0, array.Length);
			int num4 = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			int num5 = BitConverter.ToInt32(array, 0);
			itemDNA = ItemDNA.smethod_4(num5, (AmmoType)num4);
		}
		if (num == 6)
		{
			memoryStream.Read(array, 0, array.Length);
			int num6 = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			int num7 = BitConverter.ToInt32(array, 0);
			itemDNA = ItemDNA.smethod_3((MaterialType)num6, num7);
		}
		if (num == 3)
		{
			memoryStream.Read(array, 0, array.Length);
			int num8 = BitConverter.ToInt32(array, 0);
			itemDNA = ItemDNA.smethod_5(num8);
		}
		if (num == 5)
		{
			ShieldDNA shieldDNA = new ShieldDNA();
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_id = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_level = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_shieldManufacturer = (ItemManufacturer)BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_bodyIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_batteryIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_capacitorIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_accessoryIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_materialIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_generationSource = (GenerationSource)BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_rarity = (ItemRarity)BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_extraEffectCount = BitConverter.ToInt32(array, 0);
			if (shieldDNA.m_extraEffectCount > ItemDNA.m_extraEffectNums)
			{
				DebugUtils.LogError(LogCategory.Network, "m_extraEffectCount number + " + shieldDNA.m_extraEffectCount + " is over max");
			}
			for (int i = 0; i < shieldDNA.m_extraEffectCount; i++)
			{
				memoryStream.Read(array, 0, array.Length);
				shieldDNA.m_extraEffect[i] = BitConverter.ToInt32(array, 0);
			}
			for (int j = 0; j < shieldDNA.m_extraEffectCount; j++)
			{
				memoryStream.Read(array, 0, array.Length);
				shieldDNA.m_extraEffectIndex[j] = BitConverter.ToInt32(array, 0);
			}
			memoryStream.Read(array, 0, array.Length);
			int num9 = BitConverter.ToInt32(array, 0);
			if (num9 > 0)
			{
				byte[] array3 = new byte[num9];
				memoryStream.Read(array3, 0, num9);
				shieldDNA.m_name = Encoding.Unicode.GetString(array3, 0, num9);
			}
			shieldDNA.method_2();
			itemDNA = ItemDNA.smethod_7(shieldDNA);
		}
		if (num == 8)
		{
			ClassModeDNA classModeDNA = new ClassModeDNA();
			memoryStream.Read(array, 0, array.Length);
			classModeDNA.m_id = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			int num10 = BitConverter.ToInt32(array, 0);
			classModeDNA.m_cmType = (ClassModeType)num10;
			memoryStream.Read(array, 0, array.Length);
			int num11 = BitConverter.ToInt32(array, 0);
			classModeDNA.m_rarity = (ItemRarity)num11;
			memoryStream.Read(array, 0, array.Length);
			int num12 = BitConverter.ToInt32(array, 0);
			classModeDNA.m_generationSource = (GenerationSource)num12;
			memoryStream.Read(array, 0, array.Length);
			classModeDNA.m_adapterIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			classModeDNA.m_bodyIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			classModeDNA.m_chassisIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			classModeDNA.m_drumIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			classModeDNA.m_materialIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			classModeDNA.m_level = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			int num13 = BitConverter.ToInt32(array, 0);
			if (num13 > 0)
			{
				byte[] array4 = new byte[num13];
				memoryStream.Read(array4, 0, num13);
				classModeDNA.m_name = Encoding.Unicode.GetString(array4, 0, num13);
			}
			classModeDNA.method_4();
			itemDNA = ItemDNA.smethod_8(classModeDNA);
		}
		if (num == 11)
		{
			OutfitDNA outfitDNA = new OutfitDNA();
			memoryStream.Read(array, 0, array.Length);
			outfitDNA.m_id = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			outfitDNA.m_avatarType = (AvatarType)BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			outfitDNA.m_avatarSubpart = (AvatarSubPart)BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			outfitDNA.m_expirationType = (OutfitExpirationType)BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			outfitDNA.m_rarity = (ItemRarity)BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			outfitDNA.m_level = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			outfitDNA.m_index = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			outfitDNA.m_expirationTime = BitConverter.ToSingle(array, 0);
			memoryStream.Read(array, 0, array.Length);
			int num14 = BitConverter.ToInt32(array, 0);
			if (num14 > 0)
			{
				byte[] array5 = new byte[num14];
				memoryStream.Read(array5, 0, num14);
				outfitDNA.m_name = Encoding.Unicode.GetString(array5, 0, num14);
			}
			itemDNA = ItemDNA.smethod_9(outfitDNA);
		}
		if (itemDNA != null)
		{
			itemDNA.method_2(ServiceWrapperBase<ShopServiceWrapper>.Instance.method_4(itemDNA));
		}
		return itemDNA;
	}

	// Token: 0x06004A2E RID: 18990 RVA: 0x001345E4 File Offset: 0x001327E4
	private static byte[] smethod_6(object object_0)
	{
		ItemInstance itemInstance = (ItemInstance)object_0;
		MemoryStream memoryStream = new MemoryStream();
		byte[] array = new byte[39];
		Array.Clear(array, 0, array.Length);
		for (int i = 0; i < itemInstance.m_id.Length; i++)
		{
			array[i] = Convert.ToByte(itemInstance.m_id[i]);
		}
		memoryStream.Write(array, 0, 39);
		memoryStream.Write(BitConverter.GetBytes(itemInstance.m_exp), 0, 4);
		return memoryStream.ToArray();
	}

	// Token: 0x06004A2F RID: 18991 RVA: 0x00134660 File Offset: 0x00132860
	private static object smethod_7(byte[] byte_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(byte_0, 0, 39);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		byte[] array = new byte[39];
		memoryStream.Read(array, 0, 39);
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		while (num < array.Length && array[num] != 0)
		{
			stringBuilder.Append(Convert.ToChar(array[num]));
			num++;
		}
		Array.Clear(array, 0, array.Length);
		memoryStream.Read(array, 0, 4);
		int num2 = BitConverter.ToInt32(array, 0);
		return new ItemInstance(stringBuilder.ToString(), num2);
	}

	// Token: 0x06004A30 RID: 18992 RVA: 0x001346F4 File Offset: 0x001328F4
	private static byte[] smethod_8(object object_0)
	{
		AvatarDNA avatarDNA = (AvatarDNA)object_0;
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(BitConverter.GetBytes((char)avatarDNA.m_type), 0, 2);
		memoryStream.Write(BitConverter.GetBytes(avatarDNA.m_buildingUnit.mFBXs.Count), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(avatarDNA.m_buildingUnit.bkID), 0, 4);
		memoryStream.Write(avatarDNA.m_buildingUnit.mFBXs.ToArray(), 0, avatarDNA.m_buildingUnit.mFBXs.Count * 1);
		memoryStream.Write(avatarDNA.m_buildingUnit.mMats.ToArray(), 0, avatarDNA.m_buildingUnit.mMats.Count * 1);
		return memoryStream.ToArray();
	}

	// Token: 0x06004A31 RID: 18993 RVA: 0x001347B0 File Offset: 0x001329B0
	private static object smethod_9(byte[] byte_0)
	{
		AvatarDNA avatarDNA = new AvatarDNA();
		avatarDNA.m_type = (AvatarType)((byte)BitConverter.ToChar(byte_0, 0));
		int num = BitConverter.ToInt32(byte_0, 2);
		avatarDNA.method_0(num);
		avatarDNA.m_buildingUnit.bkID = BitConverter.ToUInt32(byte_0, 6);
		int num2 = 10;
		for (int i = 0; i < num; i++)
		{
			avatarDNA.m_buildingUnit.mFBXs[i] = byte_0[num2];
			num2++;
		}
		for (int j = 0; j < num; j++)
		{
			avatarDNA.m_buildingUnit.mMats[j] = byte_0[num2];
			num2++;
		}
		return avatarDNA;
	}
}
