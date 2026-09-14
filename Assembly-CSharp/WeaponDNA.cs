using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000902 RID: 2306
[Serializable]
public class WeaponDNA : ICloneable, IDNA
{
	// Token: 0x06003F81 RID: 16257 RVA: 0x0012C36C File Offset: 0x0012A56C
	public WeaponDNA(WeaponDNA weaponDNA_0)
	{
		this.m_id = weaponDNA_0.m_id;
		this.m_name = weaponDNA_0.m_name;
		this.m_type = weaponDNA_0.m_type;
		this.m_level = weaponDNA_0.m_level;
		this.m_rarity = weaponDNA_0.m_rarity;
		this.m_subPartsCode = weaponDNA_0.m_subPartsCode;
		this.m_generationSource = weaponDNA_0.m_generationSource;
		this.m_attribute = new WeaponAttribute(weaponDNA_0.m_attribute);
	}

	// Token: 0x06003F82 RID: 16258 RVA: 0x0012C414 File Offset: 0x0012A614
	public WeaponDNA()
	{
		this.m_type = WeaponType.SMG;
		this.m_name = string.Empty;
		this.m_level = 1;
		this.m_rarity = WeaponRarity.Common;
		for (int i = 0; i < this.m_subPartsCode.Length; i++)
		{
			this.m_subPartsCode[i] = SubPartWpn.smethod_1(this.m_type, (WeaponSubPart)i, 0);
		}
		this.m_generationSource = GenerationSource.Loot;
		this.m_attribute = null;
		this.m_extraEffectCount = 0;
		for (int j = 0; j < ItemDNA.m_extraEffectNums; j++)
		{
			this.m_extraEffect[j] = 0;
		}
		for (int k = 0; k < ItemDNA.m_extraEffectNums; k++)
		{
			this.m_extraEffectIndex[k] = 0;
		}
	}

	// Token: 0x17000388 RID: 904
	// (get) Token: 0x06003F83 RID: 16259 RVA: 0x0002AB53 File Offset: 0x00028D53
	// (set) Token: 0x06003F84 RID: 16260 RVA: 0x0002AB5B File Offset: 0x00028D5B
	public int m_id { get; set; }

	// Token: 0x06003F85 RID: 16261 RVA: 0x0012C4E4 File Offset: 0x0012A6E4
	public object Clone()
	{
		WeaponDNA weaponDNA = (WeaponDNA)base.MemberwiseClone();
		this.m_subPartsCode.CopyTo(weaponDNA.m_subPartsCode, 0);
		return weaponDNA;
	}

	// Token: 0x06003F86 RID: 16262 RVA: 0x0012C510 File Offset: 0x0012A710
	public string method_0()
	{
		string[] array = new string[9];
		for (int i = 0; i < 9; i++)
		{
			array[i] = this.m_subPartsCode[i].ToString();
		}
		return string.Join(",", array);
	}

	// Token: 0x06003F87 RID: 16263 RVA: 0x0002AB64 File Offset: 0x00028D64
	public WeaponType method_1()
	{
		return this.m_type;
	}

	// Token: 0x06003F88 RID: 16264 RVA: 0x0002AB6C File Offset: 0x00028D6C
	public ItemRarity method_2()
	{
		return (ItemRarity)this.m_rarity;
	}

	// Token: 0x06003F89 RID: 16265 RVA: 0x0002AB74 File Offset: 0x00028D74
	public bool method_3()
	{
		return this.m_type == WeaponType.RepeaterPistol;
	}

	// Token: 0x06003F8A RID: 16266 RVA: 0x0002AB83 File Offset: 0x00028D83
	public string method_4()
	{
		return ItemDNA.smethod_11(this.m_name);
	}

	// Token: 0x06003F8B RID: 16267 RVA: 0x0012C554 File Offset: 0x0012A754
	public void method_5()
	{
		if (m_attribute == null)
		{
			m_attribute = new WeaponAttribute(WeaponStore.weaponStore.m_weaponDic[(int)method_1()]);
		}
		if (m_attribute.m_weaponAttribute[100].m_attributeValue is FloatAttributeValue floatAttributeValue)
		{
			floatAttributeValue.m_value = method_7(m_level, floatAttributeValue.m_value);
		}
		Dictionary<AttributeType, List<AttributeValue>> dictionary = new Dictionary<AttributeType, List<AttributeValue>>();
		for (int i = 0; i < m_subPartsCode.Length; i++)
		{
			SubPartWpn subPartWpn = SubPartWeaponStore.SubPartWeaponStore_0.method_1(m_subPartsCode[i]);
			if (subPartWpn != null)
			{
				if (subPartWpn.m_Attributes == null)
				{
					continue;
				}
				for (int j = 0; j < subPartWpn.m_Attributes.Length; j++)
				{
					BOLAttribute bOLAttribute = m_attribute.m_weaponAttribute[(int)subPartWpn.m_Attributes[j].m_attributeType];
					if (bOLAttribute.m_attributeType != subPartWpn.m_Attributes[j].m_attributeType)
					{
						DebugUtils.LogError(LogCategory.Gamelogic, bOLAttribute.m_attributeType.ToString() + "Attribute distortion!!!!" + subPartWpn.m_Attributes[j].m_attributeType);
					}
					List<AttributeValue> value = null;
					if (!dictionary.TryGetValue(subPartWpn.m_Attributes[j].m_attributeType, out value))
					{
						value = new List<AttributeValue>();
						value.Add(subPartWpn.m_Attributes[j].m_attributeValue);
						dictionary.Add(subPartWpn.m_Attributes[j].m_attributeType, value);
					}
					else
					{
						value.Add(subPartWpn.m_Attributes[j].m_attributeValue);
					}
				}
			}
			else if (!SubPartWeaponStore.SubPartWeaponStore_0.method_4(method_1(), (WeaponSubPart)i))
			{
				DebugUtils.LogError(LogCategory.Gamelogic, "can't find sub part for " + method_1().ToString() + "Rarity is " + m_rarity.ToString() + " subpart is " + (WeaponSubPart)i);
			}
		}
		foreach (KeyValuePair<AttributeType, List<AttributeValue>> item in dictionary)
		{
			List<AttributeValue> value2 = item.Value;
			AttributeValue attributeValue = m_attribute.m_weaponAttribute[(int)item.Key].m_attributeValue;
			for (int k = 0; k < value2.Count; k++)
			{
				if (attributeValue.m_type != value2[k].m_type)
				{
					DebugUtils.LogError(LogCategory.Gamelogic, "weapon type " + m_type.ToString() + " " + attributeValue.m_type.ToString() + "is not match " + value2[k].m_type.ToString() + " attribute is " + item.Key);
					break;
				}
			}
			attributeValue.vmethod_1(value2);
		}
		FloatAttributeValue floatAttributeValue2 = m_attribute.m_weaponAttribute[99].m_attributeValue as FloatAttributeValue;
		FloatAttributeValue floatAttributeValue3 = m_attribute.m_weaponAttribute[120].m_attributeValue as FloatAttributeValue;
		FloatAttributeValue floatAttributeValue4 = m_attribute.m_weaponAttribute[63].m_attributeValue as FloatAttributeValue;
		if (floatAttributeValue2 != null && floatAttributeValue3 != null && floatAttributeValue4 != null && floatAttributeValue4.m_value > 0f)
		{
			floatAttributeValue2.m_value = floatAttributeValue3.m_value / floatAttributeValue4.m_value;
			floatAttributeValue2.m_value = method_7(m_level, floatAttributeValue2.m_value);
		}
		IntAttributeValue intAttributeValue = m_attribute.m_weaponAttribute[101].m_attributeValue as IntAttributeValue;
		int num = IntAttributeValue.smethod_0(m_attribute.m_weaponAttribute[103].m_attributeValue as IntAttributeValue);
		if (intAttributeValue.m_value == 0 && num == 2)
		{
			intAttributeValue.m_value = 1;
		}
		method_6();
	}
	// Token: 0x06003F8C RID: 16268 RVA: 0x0012C9A4 File Offset: 0x0012ABA4
	public void method_6()
	{
		List<SingleWeaponAttribute> list = StarLevelAttributeStore.StarLevelAttributeStore_0.m_starLevelAttrSetup.method_0(this.m_type, this.m_starLevel);
		for (int i = 0; i < list.Count; i++)
		{
			AttributeValue attributeValue = this.m_attribute.m_weaponAttribute[(int)list[i].m_attributeType].m_attributeValue;
			List<AttributeValue> list2 = new List<AttributeValue>();
			if (attributeValue.m_type == AttributeValueType.FloatAttributeValue)
			{
				list2.Add(new FloatAttributeValue
				{
					m_value = list[i].m_value,
					m_affectType = list[i].m_affectType
				});
			}
			else if (attributeValue.m_type == AttributeValueType.IntAttributeValue)
			{
				list2.Add(new IntAttributeValue
				{
					m_value = Convert.ToInt32(list[i].m_value),
					m_affectType = list[i].m_affectType
				});
			}
			attributeValue.vmethod_1(list2);
		}
	}

	// Token: 0x06003F8D RID: 16269 RVA: 0x0012CA98 File Offset: 0x0012AC98
	public float method_7(int int_0, float float_0)
	{
		int num = MonoSingleton<LevelingManager>.Instance.m_progressionSetup.m_experienceTable.Length;
		int num2 = int_0 - 1;
		float num3 = ((num2 >= MonoSingleton<LevelingManager>.Instance.m_progressionSetup.m_experienceTable.Length) ? MonoSingleton<LevelingManager>.Instance.m_progressionSetup.m_experienceTable[num - 1].m_powerRating : MonoSingleton<LevelingManager>.Instance.m_progressionSetup.m_experienceTable[num2].m_powerRating);
		return float_0 * num3;
	}

	// Token: 0x06003F8E RID: 16270 RVA: 0x0012CB0C File Offset: 0x0012AD0C
	public bool method_8()
	{
		int num = IntAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.ScopeMaskType) as IntAttributeValue);
		return num != 0;
	}

	// Token: 0x06003F8F RID: 16271 RVA: 0x0012CB38 File Offset: 0x0012AD38
	public Dictionary<string, ItemCardDisplayType> imethod_0()
	{
		Dictionary<string, ItemCardDisplayType> dictionary = new Dictionary<string, ItemCardDisplayType>();
		int num = 0;
		for (int i = 0; i < this.m_subPartsCode.Length; i++)
		{
			SubPartWpn subPartWpn = SubPartWeaponStore.SubPartWeaponStore_0.method_1(this.m_subPartsCode[i]);
			if (subPartWpn != null && subPartWpn.m_redline != string.Empty && subPartWpn.m_redlinePriority > num)
			{
				num = subPartWpn.m_redlinePriority;
			}
		}
		List<WeaponSubPart> list = new List<WeaponSubPart>();
		for (int j = 0; j < this.m_subPartsCode.Length; j++)
		{
			SubPartWpn subPartWpn2 = SubPartWeaponStore.SubPartWeaponStore_0.method_1(this.m_subPartsCode[j]);
			if (subPartWpn2 != null && subPartWpn2.m_redline != string.Empty && subPartWpn2.m_redlinePriority > 0 && subPartWpn2.m_redlinePriority == num)
			{
				list.Add(subPartWpn2.m_partType);
			}
		}
		if (this.m_attribute != null)
		{
			string text = this.method_11();
			if (text != null)
			{
				dictionary.Add(text, ItemCardDisplayType.ManufacturerWord);
			}
			if (this.method_8())
			{
				double num2 = (double)(FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.FirstPersonMeshFOV) as FloatAttributeValue) / FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.ZoomEndFOV) as FloatAttributeValue));
				num2 = Math.Round(num2, 1);
				if (num2 > 1.0)
				{
					string text2 = num2.ToString("#0.0") + "x" + LocalizedString.smethod_0(new LocalizedString("ZoomEndFOV"));
					dictionary.Add(text2, ItemCardDisplayType.ZoomWord);
				}
			}
			ItemCardDisplayType itemCardDisplayType = ItemCardDisplayType.FireWord;
			string text3 = this.method_10(ref itemCardDisplayType);
			if (text3 != null)
			{
				dictionary.Add(text3, itemCardDisplayType);
			}
		}
		List<SkillAttributeConfig> list2 = WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.vmethod_0(this.m_extraEffect, this.m_extraEffectIndex, this.method_2(), this.m_level);
		for (int k = 0; k < list2.Count; k++)
		{
			StringBuilder stringBuilder = ExtraAttributeStore.smethod_1(list2[k]);
			dictionary.Add(stringBuilder.ToString(), ItemCardDisplayType.ExtraSlotWord);
		}
		return dictionary;
	}

	// Token: 0x06003F90 RID: 16272 RVA: 0x0012CD1C File Offset: 0x0012AF1C
	private float method_9(float float_0, EffectType effectType_0)
	{
		if (effectType_0 != EffectType.WeaponMaxHPPostAdd)
		{
			if (effectType_0 != EffectType.WeaponMaxShieldPostAdd)
			{
				return float_0;
			}
		}
		int num = (int)(float_0 * MonoSingleton<LevelingManager>.Instance.method_6(this.m_level));
		return (float)num;
	}

	// Token: 0x06003F91 RID: 16273 RVA: 0x0012CD50 File Offset: 0x0012AF50
	public string method_10(ref ItemCardDisplayType itemCardDisplayType_0)
	{
		AttackInfo.ElementalType elementalType = (AttackInfo.ElementalType)IntAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.ElementalType) as IntAttributeValue);
		string text = null;
		switch (elementalType)
		{
		case AttackInfo.ElementalType.Fire:
			text = LocalizedString.smethod_0(new LocalizedString("WC_Elem_Fire"));
			itemCardDisplayType_0 = ItemCardDisplayType.FireWord;
			break;
		case AttackInfo.ElementalType.Shock:
			text = LocalizedString.smethod_0(new LocalizedString("WC_Elem_Electric"));
			itemCardDisplayType_0 = ItemCardDisplayType.ShockWord;
			break;
		case AttackInfo.ElementalType.Corrosive:
			text = LocalizedString.smethod_0(new LocalizedString("WC_Elem_Corrosive"));
			itemCardDisplayType_0 = ItemCardDisplayType.CorrosiveWord;
			break;
		}
		return text;
	}

	// Token: 0x06003F92 RID: 16274 RVA: 0x0012CDD0 File Offset: 0x0012AFD0
	public string method_11()
	{
		switch (IntAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.ManufactureType) as IntAttributeValue))
		{
		case 0:
		{
			float num = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.FireRateIncrease) as FloatAttributeValue);
			if (num > 0f)
			{
				return LocalizedString.smethod_0(new LocalizedString("WC_Manu_Vladof"));
			}
			break;
		}
		case 1:
		{
			int num2 = IntAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.ZoomFiringBurst) as IntAttributeValue);
			if (num2 > 0)
			{
				return LocalizedString.smethod_0(new LocalizedString("WC_Manu_Dahl"));
			}
			break;
		}
		case 2:
		{
			float num3 = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.ElementalProcCoef) as FloatAttributeValue);
			if (num3 >= 0.33f)
			{
				return LocalizedString.smethod_0(new LocalizedString("WC_Manu_Maliwan"));
			}
			break;
		}
		}
		return null;
	}

	// Token: 0x06003F93 RID: 16275 RVA: 0x0012CEA0 File Offset: 0x0012B0A0
	public string method_12(string string_0)
	{
		List<string> list = new List<string>();
		int num = 0;
		string text = null;
		SubPartWpn subPartWpn = SubPartWeaponStore.SubPartWeaponStore_0.method_1(this.m_subPartsCode[0]);
		if (subPartWpn != null && subPartWpn.method_0(subPartWpn.m_partType) && subPartWpn.m_partName != null && subPartWpn.m_namePriority >= num && subPartWpn.m_partName != string_0)
		{
			text = subPartWpn.m_partName;
			num = subPartWpn.m_namePriority;
			list.Add(subPartWpn.m_partName);
		}
		for (int i = 0; i < this.m_extraEffectCount; i++)
		{
			for (int j = 0; j < WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.m_effectSetups.m_extraAttrEffectList.Length; j++)
			{
				if (WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.m_effectSetups.m_extraAttrEffectList[j].m_rarity == this.method_2() && WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.m_effectSetups.m_extraAttrEffectList[j].m_effect == (EffectType)this.m_extraEffect[i] && (int)WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.m_effectSetups.m_extraAttrEffectList[j].m_index == this.m_extraEffectIndex[i] && WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.m_effectSetups.m_extraAttrEffectList[j].m_partName != string_0)
				{
					if (WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.m_effectSetups.m_extraAttrEffectList[j].m_namePriority > num)
					{
						text = WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.m_effectSetups.m_extraAttrEffectList[j].m_partName;
						num = WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.m_effectSetups.m_extraAttrEffectList[j].m_namePriority;
						list.Clear();
					}
					if (WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.m_effectSetups.m_extraAttrEffectList[j].m_namePriority == num && WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.m_effectSetups.m_extraAttrEffectList[j].m_partName != null)
					{
						list.Add(WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.m_effectSetups.m_extraAttrEffectList[j].m_partName);
					}
				}
			}
		}
		if (list.Count > 1)
		{
			text = list[global::UnityEngine.Random.Range(0, list.Count)];
		}
		return text;
	}

	// Token: 0x06003F94 RID: 16276 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_13()
	{
	}

	// Token: 0x06003F95 RID: 16277 RVA: 0x0012D0A0 File Offset: 0x0012B2A0
	public BuildingUnit method_14()
	{
		BuildingPart[] array = new BuildingPart[this.m_subPartsCode.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new BuildingPart(SubPartWeaponStore.SubPartWeaponStore_0.method_1(this.m_subPartsCode[i]));
		}
		return new BuildingUnit(array);
	}

	// Token: 0x06003F96 RID: 16278 RVA: 0x0012D0EC File Offset: 0x0012B2EC
	public byte method_15(WeaponSubPart weaponSubPart_0)
	{
		byte b = SubPartWeaponStore.SubPartWeaponStore_0.method_5(this.m_type, weaponSubPart_0);
		return this.method_14().method_1((int)b).mFBX;
	}

	// Token: 0x06003F97 RID: 16279 RVA: 0x0012D11C File Offset: 0x0012B31C
	public static WeaponDNA smethod_0(Hashtable hashtable_0, int int_0)
	{
		WeaponDNA weaponDNA2;
		try
		{
			if (hashtable_0 == null)
			{
				throw new Exception("data is NULL.");
			}
			WeaponDNA weaponDNA = new WeaponDNA();
			weaponDNA.m_level = (int)hashtable_0[1];
			weaponDNA.m_rarity = (WeaponRarity)((int)hashtable_0[2]);
			weaponDNA.m_generationSource = (GenerationSource)((int)hashtable_0[3]);
			weaponDNA.m_id = (int)hashtable_0[4];
			weaponDNA.m_name = (string)hashtable_0[int_0 + 1];
			weaponDNA.m_type = (WeaponType)((int)hashtable_0[int_0 + 2]);
			weaponDNA.m_starLevel = (int)hashtable_0[int_0 + 12];
			weaponDNA.m_starExperience = (int)hashtable_0[int_0 + 13];
			for (int i = 0; i < weaponDNA.m_subPartsCode.Length; i++)
			{
				weaponDNA.m_subPartsCode[i] = SubPartWpn.smethod_1(weaponDNA.m_type, (WeaponSubPart)i, (int)hashtable_0[i + int_0 + 3]);
			}
			weaponDNA.method_5();
			weaponDNA2 = weaponDNA;
		}
		catch (Exception ex)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, string.Format("Invalid Weapon Data: {0}", ex.Message));
			weaponDNA2 = null;
		}
		return weaponDNA2;
	}

	// Token: 0x06003F98 RID: 16280 RVA: 0x0012D284 File Offset: 0x0012B484
	public override string ToString()
	{
		return string.Format("{0} - {1} - {2} - {3} - {4:X} - {5} - {6}", new object[]
		{
			this.m_name,
			this.method_1(),
			this.m_level,
			this.m_subPartsCode[0],
			this.m_subPartsCode[1],
			this.m_subPartsCode[2],
			this.m_subPartsCode[3]
		});
	}

	// Token: 0x06003F99 RID: 16281 RVA: 0x0012D308 File Offset: 0x0012B508
	public override bool Equals(object obj)
	{
		WeaponDNA weaponDNA = obj as WeaponDNA;
		if (weaponDNA != null && this.m_name == weaponDNA.m_name && this.m_type == weaponDNA.m_type && this.m_id == weaponDNA.m_id && this.m_level == weaponDNA.m_level && this.m_subPartsCode.Length == weaponDNA.m_subPartsCode.Length)
		{
			for (int i = 0; i < this.m_subPartsCode.Length; i++)
			{
				if (this.m_subPartsCode[i] != weaponDNA.m_subPartsCode[i])
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x06003F9A RID: 16282 RVA: 0x0012D39C File Offset: 0x0012B59C
	public override int GetHashCode()
	{
		int num = this.m_name.GetHashCode() ^ this.m_type.GetHashCode() ^ this.m_id.GetHashCode() ^ this.m_level.GetHashCode();
		for (int i = 0; i < this.m_subPartsCode.Length; i++)
		{
			num ^= this.m_subPartsCode[i].GetHashCode();
		}
		return num;
	}

	// Token: 0x04002CB1 RID: 11441
	public string m_name;

	// Token: 0x04002CB2 RID: 11442
	public WeaponType m_type;

	// Token: 0x04002CB3 RID: 11443
	public WeaponRarity m_rarity;

	// Token: 0x04002CB4 RID: 11444
	public int m_level;

	// Token: 0x04002CB5 RID: 11445
	public int[] m_subPartsCode = new int[9];

	// Token: 0x04002CB6 RID: 11446
	public GenerationSource m_generationSource;

	// Token: 0x04002CB7 RID: 11447
	public WeaponAttribute m_attribute;

	// Token: 0x04002CB8 RID: 11448
	public int m_extraEffectCount;

	// Token: 0x04002CB9 RID: 11449
	public int[] m_extraEffect = new int[ItemDNA.m_extraEffectNums];

	// Token: 0x04002CBA RID: 11450
	public int[] m_extraEffectIndex = new int[ItemDNA.m_extraEffectNums];

	// Token: 0x04002CBB RID: 11451
	public int m_starLevel;

	// Token: 0x04002CBC RID: 11452
	public int m_starExperience;
}
