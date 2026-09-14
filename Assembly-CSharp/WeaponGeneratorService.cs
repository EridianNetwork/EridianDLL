using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000332 RID: 818
public class WeaponGeneratorService : MonoBehaviour
{
	// Token: 0x0600146C RID: 5228 RVA: 0x0000F3B0 File Offset: 0x0000D5B0
	private void Start()
	{
		this.method_1("WeaponEditor/Bin/Preset_Weapons", ref this.m_weapons);
		this.method_1("WeaponEditor/Bin/Preset_WeaponsForNPC", ref this.m_NPCWeapons);
	}

	// Token: 0x0600146D RID: 5229 RVA: 0x00077508 File Offset: 0x00075708
	private void method_0(string string_0, ref WeaponDNA[] weaponDNA_0)
	{
		TextAsset textAsset = ResourcesLoader.smethod_0(string_0) as TextAsset;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset.text);
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("Weapon");
		weaponDNA_0 = new WeaponDNA[elementsByTagName.Count];
		int num = 0;
		foreach (object obj in elementsByTagName)
		{
			XmlNode xmlNode = (XmlNode)obj;
			WeaponType weaponType = (WeaponType)((int)Enum.Parse(typeof(WeaponType), xmlNode.Attributes["type"].Value));
			WeaponDNA weaponDNA = new WeaponDNA();
			weaponDNA.m_name = xmlNode.Attributes["name"].Value;
			weaponDNA.m_id = Convert.ToInt32(xmlNode.Attributes["id"].Value);
			weaponDNA.m_type = weaponType;
			weaponDNA.m_rarity = (WeaponRarity)((int)Enum.Parse(typeof(WeaponRarity), xmlNode.Attributes["raritytype"].Value));
			weaponDNA.m_level = Convert.ToInt32(xmlNode.Attributes["level"].Value);
			int[] array = new int[9];
			foreach (object obj2 in Enum.GetValues(typeof(WeaponSubPart)))
			{
				WeaponSubPart weaponSubPart = (WeaponSubPart)((int)obj2);
				if (weaponSubPart != WeaponSubPart.MAX)
				{
					array[(int)weaponSubPart] = new SubPartWpn(weaponType, weaponSubPart)
					{
						m_Index = Convert.ToInt32(xmlNode.Attributes[Enum.GetName(typeof(WeaponSubPart), weaponSubPart)].Value)
					}.GetHashCode();
				}
			}
			weaponDNA.m_subPartsCode = array;
			weaponDNA.m_generationSource = GenerationSource.Loot;
			weaponDNA.method_5();
			weaponDNA_0[num++] = weaponDNA;
		}
	}

	// Token: 0x0600146E RID: 5230 RVA: 0x00077758 File Offset: 0x00075958
	private void method_1(string string_0, ref WeaponDNA[] weaponDNA_0)
	{
		TextAsset textAsset = ResourcesLoader.smethod_0(string_0) as TextAsset;
		MemoryStream memoryStream = new MemoryStream(textAsset.bytes);
		using (BinaryReader binaryReader = new BinaryReader(memoryStream))
		{
			weaponDNA_0 = new WeaponDNA[binaryReader.ReadInt32()];
			for (int i = 0; i < weaponDNA_0.Length; i++)
			{
				WeaponDNA weaponDNA = new WeaponDNA();
				weaponDNA.m_name = binaryReader.ReadString();
				weaponDNA.m_id = binaryReader.ReadInt32();
				weaponDNA.m_type = (WeaponType)binaryReader.ReadByte();
				weaponDNA.m_rarity = (WeaponRarity)binaryReader.ReadByte();
				weaponDNA.m_level = binaryReader.ReadInt32();
				weaponDNA.m_extraEffectCount = binaryReader.ReadInt32();
				for (int j = 0; j < ItemDNA.m_extraEffectNums; j++)
				{
					weaponDNA.m_extraEffect[j] = binaryReader.ReadInt32();
				}
				for (int k = 0; k < ItemDNA.m_extraEffectNums; k++)
				{
					weaponDNA.m_extraEffectIndex[k] = binaryReader.ReadInt32();
				}
				int num = 9;
				int[] array = new int[9];
				for (int l = 0; l < num; l++)
				{
					array[l] = binaryReader.ReadInt32();
				}
				weaponDNA.m_subPartsCode = array;
				weaponDNA.m_generationSource = GenerationSource.Loot;
				weaponDNA.method_5();
				weaponDNA_0[i] = weaponDNA;
			}
			memoryStream.Dispose();
			binaryReader.Close();
		}
	}

	// Token: 0x0600146F RID: 5231 RVA: 0x0000F3D4 File Offset: 0x0000D5D4
	private void method_2(WeaponType weaponType_0, int int_0, int int_1, int int_2)
	{
		if (weaponType_0 != WeaponType.SniperRifle || (int_1 != 1 && int_1 != 3 && int_1 != 4) || int_2 == 2 || int_2 == 5)
		{
		}
	}

	// Token: 0x06001470 RID: 5232 RVA: 0x000778C0 File Offset: 0x00075AC0
	private IEnumerator method_3(WeaponType weaponType_0, int int_0, int int_1)
	{
		yield return new WaitForSeconds(ns0.MonoSingleton<AppManager>.Instance.m_serviceProcessingTime);
		List<WeaponDNA> weaponOfType = new List<WeaponDNA>();
		WeaponDNA[] weapons = m_weapons;
		foreach (WeaponDNA weapon in weapons)
		{
			if (weapon.method_1() == weaponType_0)
			{
				weaponOfType.Add(weapon);
			}
		}
		List<WeaponDNA> generatedWeapon = new List<WeaponDNA>();
		for (int i = 0; i < int_1 && i < weaponOfType.Count; i++)
		{
			generatedWeapon.Add(weaponOfType[i]);
		}
		SendMessage("OnRequestRandomWeaponGeneration", generatedWeapon, SendMessageOptions.DontRequireReceiver);
	}
	// Token: 0x06001471 RID: 5233 RVA: 0x000778F8 File Offset: 0x00075AF8
	public WeaponDNA method_4()
	{
		WeaponType weaponType = (WeaponType)global::UnityEngine.Random.Range(0, 3);
		WeaponRarity weaponRarity = (WeaponRarity)global::UnityEngine.Random.Range(0, 6);
		return this.method_7(weaponType, weaponRarity);
	}

	// Token: 0x06001472 RID: 5234 RVA: 0x00077920 File Offset: 0x00075B20
	public WeaponDNA method_5(WeaponRarity weaponRarity_0)
	{
		WeaponType weaponType = (WeaponType)global::UnityEngine.Random.Range(0, 5);
		return this.method_7(weaponType, weaponRarity_0);
	}

	// Token: 0x06001473 RID: 5235 RVA: 0x0000F3F0 File Offset: 0x0000D5F0
	public WeaponDNA method_6(WeaponType weaponType_0, ItemRarity itemRarity_0)
	{
		return this.method_7(weaponType_0, (WeaponRarity)itemRarity_0);
	}

	// Token: 0x06001474 RID: 5236 RVA: 0x00077940 File Offset: 0x00075B40
	public WeaponDNA method_7(WeaponType weaponType_0, WeaponRarity weaponRarity_0 = WeaponRarity.Common)
	{
		if (weaponType_0 == WeaponType.TOTAL)
		{
			weaponType_0 = (WeaponType)global::UnityEngine.Random.Range(0, 5);
		}
		if (weaponRarity_0 == WeaponRarity.TOTAL)
		{
			weaponRarity_0 = (WeaponRarity)global::UnityEngine.Random.Range(0, 6);
		}
		int[] array = new int[Enum.GetValues(typeof(WeaponSubPart)).Length - 1];
		for (int i = 0; i < 9; i++)
		{
			if (i != 9)
			{
				if (SubPartWeaponStore.SubPartWeaponStore_0.method_4(weaponType_0, (WeaponSubPart)i))
				{
					array[i] = new SubPartWpn(weaponType_0, (WeaponSubPart)i)
					{
						m_Index = -1
					}.GetHashCode();
				}
				else
				{
					int num = RarityStore.rarityStore.method_1(weaponType_0, weaponRarity_0, (WeaponSubPart)i);
					SubPartWpn subPartWpn = SubPartWeaponStore.SubPartWeaponStore_0.method_2(weaponType_0, (WeaponSubPart)i, num);
					if (subPartWpn != null)
					{
					}
					array[i] = subPartWpn.GetHashCode();
					DebugUtils.Log(LogCategory.Gamelogic, string.Concat(new object[]
					{
						"get:",
						Enum.GetName(typeof(WeaponSubPart), subPartWpn.m_partType),
						"-",
						subPartWpn.m_Index
					}));
				}
			}
		}
		WeaponDNA weaponDNA = new WeaponDNA();
		weaponDNA.m_type = weaponType_0;
		weaponDNA.m_subPartsCode = array;
		weaponDNA.m_generationSource = GenerationSource.Loot;
		weaponDNA.m_name = string.Format("{0}", weaponDNA.m_type);
		weaponDNA.m_rarity = weaponRarity_0;
		weaponDNA.method_5();
		weaponDNA.m_extraEffectCount = WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.m_slotSetups.method_0(weaponDNA.method_2());
		weaponDNA.m_extraEffect = WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.m_levelEffectSetups.method_0(weaponDNA.method_2(), weaponDNA.m_level, weaponDNA.m_extraEffectCount, null);
		weaponDNA.m_extraEffectIndex = WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.m_effectSetups.method_1(weaponDNA.method_2(), weaponDNA.m_extraEffect, weaponDNA.m_level);
		weaponDNA.method_13();
		return weaponDNA;
	}

	// Token: 0x06001475 RID: 5237 RVA: 0x0000F3FA File Offset: 0x0000D5FA
	public WeaponDNA method_8()
	{
		return this.m_weapons[global::UnityEngine.Random.Range(0, this.method_13())];
	}

	// Token: 0x06001476 RID: 5238 RVA: 0x0000F40F File Offset: 0x0000D60F
	public WeaponDNA method_9()
	{
		return this.m_weapons[global::UnityEngine.Random.Range(0, this.m_weapons.Length)];
	}

	// Token: 0x06001477 RID: 5239 RVA: 0x00077B10 File Offset: 0x00075D10
	public WeaponDNA method_10(int int_0)
	{
		for (int i = 0; i < this.m_weapons.Length; i++)
		{
			if (this.m_weapons[i].m_id == int_0)
			{
				return this.m_weapons[i];
			}
		}
		return null;
	}

	// Token: 0x06001478 RID: 5240 RVA: 0x00077B4C File Offset: 0x00075D4C
	public WeaponDNA method_11(string string_0)
	{
		for (int i = 0; i < this.m_weapons.Length; i++)
		{
			if (this.m_weapons[i].m_name.Equals(string_0))
			{
				return this.m_weapons[i];
			}
		}
		return null;
	}

	// Token: 0x06001479 RID: 5241 RVA: 0x00077B8C File Offset: 0x00075D8C
	public WeaponDNA method_12(int int_0)
	{
		for (int i = 0; i < this.m_NPCWeapons.Length; i++)
		{
			if (this.m_NPCWeapons[i].m_id == int_0)
			{
				return this.m_NPCWeapons[i];
			}
		}
		DebugUtils.LogError(LogCategory.AI, "Invalid Weapon ID");
		return null;
	}

	// Token: 0x0600147A RID: 5242 RVA: 0x0000F426 File Offset: 0x0000D626
	public int method_13()
	{
		return 15;
	}

	// Token: 0x0600147B RID: 5243 RVA: 0x00077BD4 File Offset: 0x00075DD4
	private int method_14(int int_0 = 0, int int_1 = 0, int int_2 = 0)
	{
		int num = int_0 + int_1 + int_2;
		int num2 = num - num % 10;
		int num3 = num2 + 11;
		int num4 = global::UnityEngine.Random.Range(num2, num3);
		DebugUtils.Log(LogCategory.Gamelogic, "*****WeaponLevelGenerator: " + num4);
		return num4;
	}

	// Token: 0x0600147C RID: 5244 RVA: 0x00077C14 File Offset: 0x00075E14
	private void method_15()
	{
		this.m_weaponQualityRule = new Dictionary<int, List<float>>();
		List<float> list = new List<float>();
		list.Add(0.25f);
		list.Add(0.18f);
		this.m_weaponQualityRule.Add(0, list);
		list = new List<float>();
		list.Add(0.25f);
		list.Add(0.25f);
		list.Add(0.18f);
		list.Add(0.08f);
		list.Add(0.002f);
		this.m_weaponQualityRule.Add(1, list);
		list = new List<float>();
		list.Add(0.25f);
		list.Add(0.25f);
		list.Add(0.18f);
		list.Add(0.1f);
		list.Add(0.002f);
		list.Add(0.002f);
		this.m_weaponQualityRule.Add(2, list);
		list = new List<float>();
		list.Add(0.25f);
		list.Add(0.38f);
		list.Add(0.22f);
		list.Add(0.08f);
		list.Add(0.02f);
		list.Add(0.008f);
		list.Add(0.002f);
		this.m_weaponQualityRule.Add(3, list);
		list = new List<float>();
		list.Add(0.25f);
		list.Add(0.38f);
		list.Add(0.22f);
		list.Add(0.08f);
		list.Add(0.02f);
		list.Add(0.008f);
		list.Add(0.005f);
		list.Add(0.002f);
		this.m_weaponQualityRule.Add(4, list);
		this.m_weaponQualityRule.Add(5, list);
		this.m_weaponQualityRule.Add(6, list);
	}

	// Token: 0x0600147D RID: 5245 RVA: 0x00077DDC File Offset: 0x00075FDC
	private WeaponQuality method_16(int int_0 = 0)
	{
		int num = (int_0 - 1) / 10;
		List<float> list = this.m_weaponQualityRule[num];
		if (this.m_weaponQualityRule == null)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "*****Invalid listIndex");
			return WeaponQuality.Max;
		}
		for (int i = 0; i < list.Count; i++)
		{
			DebugUtils.Log(LogCategory.Gamelogic, list[i].ToString());
		}
		int count = list.Count;
		float num2 = global::UnityEngine.Random.Range(0f, 1f);
		int j = 0;
		float num3 = 0f;
		while (j < count)
		{
			num3 += list[j];
			if (num3 > num2)
			{
				break;
			}
			j++;
		}
		WeaponQuality weaponQuality = (WeaponQuality)j;
		if (j == count)
		{
			weaponQuality = WeaponQuality.Max;
		}
		DebugUtils.Log(LogCategory.Gamelogic, string.Concat(new object[] { "*****WeaponQualityGenerator: ", weaponQuality, "  result: ", num2 }));
		return weaponQuality;
	}

	// Token: 0x0600147E RID: 5246 RVA: 0x00077EC0 File Offset: 0x000760C0
	private WeaponType method_17()
	{
		WeaponType weaponType = (WeaponType)global::UnityEngine.Random.Range(0, 5);
		DebugUtils.Log(LogCategory.Gamelogic, "*****WeaponTypeGenerator: " + weaponType);
		return weaponType;
	}

	// Token: 0x0600147F RID: 5247 RVA: 0x00077EEC File Offset: 0x000760EC
	private void method_18(string string_0, string string_1, ref int int_0, ref int int_1, ref int int_2, ref int int_3, ref int int_4, ref int int_5, ref string string_2)
	{
		int_0 = global::UnityEngine.Random.Range(0, 5);
		int_1 = global::UnityEngine.Random.Range(0, 5);
		int_2 = global::UnityEngine.Random.Range(0, 5);
		int_3 = global::UnityEngine.Random.Range(0, 5);
		int_4 = global::UnityEngine.Random.Range(0, 5);
		int_5 = global::UnityEngine.Random.Range(0, 5);
		DebugUtils.Log(LogCategory.Gamelogic, string.Concat(new object[]
		{
			"*****ModelPartGenerator--body:", int_0, " barrel:", int_1, " sight:", int_2, " mag:", int_3, " stock:", int_4,
			" acc:", int_5, " material:", string_2
		}));
	}

	// Token: 0x04000E57 RID: 3671
	public WeaponDNA[] m_weapons;

	// Token: 0x04000E58 RID: 3672
	public WeaponDNA[] m_NPCWeapons;

	// Token: 0x04000E59 RID: 3673
	private Dictionary<int, List<float>> m_weaponQualityRule;
}
