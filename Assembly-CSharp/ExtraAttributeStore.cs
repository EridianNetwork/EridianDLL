using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020008D2 RID: 2258
public class ExtraAttributeStore
{
	// Token: 0x06003E5D RID: 15965 RVA: 0x001290FC File Offset: 0x001272FC
	public static float smethod_0(float float_0, EffectType effectType_0, int int_0)
	{
		if (int_0 > 0)
		{
			if (effectType_0 != EffectType.WeaponMaxHPPostAdd && effectType_0 != EffectType.WeaponMaxShieldPostAdd && effectType_0 != EffectType.AllResistance && effectType_0 != EffectType.MeleeDamageResistance && effectType_0 != EffectType.CorrosiveResistance && effectType_0 != EffectType.FireResistance)
			{
				if (effectType_0 != EffectType.ShockResistance)
				{
					return float_0;
				}
			}
			int num = (int)(float_0 * MonoSingleton<LevelingManager>.Instance.method_6(int_0));
			return (float)num;
		}
		DebugUtils.LogError(LogCategory.Gamelogic, "item level should not below 0");
		return float_0;
	}

	// Token: 0x06003E5E RID: 15966 RVA: 0x0012915C File Offset: 0x0012735C
	public static StringBuilder smethod_1(SkillAttributeConfig skillAttributeConfig_0)
	{
		EntityPlayer entityPlayer = null;
		if (MonoSingleton<Session>.Instance != null)
		{
			entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (skillAttributeConfig_0.m_attrValue >= 0f)
		{
			stringBuilder.Append("+");
		}
		float num = skillAttributeConfig_0.m_attrValue;
		if (skillAttributeConfig_0.m_attrType == EffectType.WeaponMaxHPPostAdd || skillAttributeConfig_0.m_attrType == EffectType.WeaponMaxShieldPostAdd)
		{
			num *= ((!(entityPlayer != null)) ? 1f : entityPlayer.method_72());
		}
		if (SkillDisplayStore.SkillDisplayStore_0.m_skillDisplaySetup.method_1(skillAttributeConfig_0.m_attrType) == DisplayType.Percentage)
		{
			stringBuilder.Append(num.ToString("#0%"));
		}
		else
		{
			stringBuilder.Append(num.ToString("F0"));
		}
		stringBuilder.Append(" ");
		stringBuilder.Append(LocalizedString.smethod_0(new LocalizedString(skillAttributeConfig_0.m_attrType.ToString())));
		if (num > skillAttributeConfig_0.m_attrValue)
		{
			stringBuilder.Append('G');
		}
		return stringBuilder;
	}

	// Token: 0x06003E5F RID: 15967 RVA: 0x00129260 File Offset: 0x00127460
	public static List<string> smethod_2()
	{
		if (ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
		{
			List<SkillAttributeConfig> list = new List<SkillAttributeConfig>();
			ItemDNA itemDNA = ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_7(ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_8());
			if (itemDNA != null && itemDNA.method_6() != null)
			{
				list.AddRange(WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.vmethod_0(itemDNA.method_6().m_extraEffect, itemDNA.method_6().m_extraEffectIndex, itemDNA.ItemRarity_0, itemDNA.method_0()));
			}
			ItemDNA itemDNA2 = ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_26();
			if (itemDNA2 != null && itemDNA2.method_7() != null)
			{
				list.AddRange(ShieldExtraAttributeStore.ShieldExtraAttributeStore_0.vmethod_0(itemDNA2.method_7().m_extraEffect, itemDNA2.method_7().m_extraEffectIndex, itemDNA2.ItemRarity_0, itemDNA2.method_0()));
			}
			ItemDNA itemDNA3 = ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_27();
			if (itemDNA3 != null && itemDNA3.method_8() != null && itemDNA3.method_8().m_attribute != null)
			{
				list.AddRange(itemDNA3.method_8().m_attribute.method_0());
			}
			List<EffectType> m_effectList = new List<EffectType>();
			for (int i = 0; i < list.Count; i++)
			{
				if (!m_effectList.Contains(list[i].m_attrType))
				{
					m_effectList.Add(list[i].m_attrType);
				}
			}
			List<SkillAttributeConfig> list2 = new List<SkillAttributeConfig>();
			for (int index = 0; index < m_effectList.Count; index++)
			{
				List<SkillAttributeConfig> list3 = list.FindAll((SkillAttributeConfig skillAttributeConfig_0) => skillAttributeConfig_0.m_attrType == m_effectList[index]);
				SkillAttributeConfig skillAttributeConfig = new SkillAttributeConfig(m_effectList[index]);
				for (int j = 0; j < list3.Count; j++)
				{
					skillAttributeConfig.m_attrValue += list3[j].m_attrValue;
					skillAttributeConfig.m_affectType = list3[j].m_affectType;
					skillAttributeConfig.m_bModified = true;
				}
				list2.Add(skillAttributeConfig);
			}
			List<string> list4 = new List<string>();
			for (int k = 0; k < list2.Count; k++)
			{
				StringBuilder stringBuilder = smethod_1(list2[k]);
				list4.Add(stringBuilder.ToString());
			}
			return list4;
		}
		return null;
	}
	// Token: 0x06003E60 RID: 15968 RVA: 0x001294C4 File Offset: 0x001276C4
	public virtual List<SkillAttributeConfig> vmethod_0(int[] int_0, int[] int_1, ItemRarity itemRarity_0, int int_2)
	{
		List<SkillAttributeConfig> list = new List<SkillAttributeConfig>();
		for (int i = 0; i < ItemDNA.m_extraEffectNums; i++)
		{
			EffectType effectType = (EffectType)int_0[i];
			int num = int_1[i];
			SkillAttributeConfig skillAttributeConfig = new SkillAttributeConfig(effectType);
			for (int j = 0; j < m_effectSetups.m_extraAttrEffectList.Length; j++)
			{
				if (m_effectSetups.m_extraAttrEffectList[j].m_rarity == itemRarity_0 && m_effectSetups.m_extraAttrEffectList[j].m_effect == effectType && m_effectSetups.m_extraAttrEffectList[j].m_index == num)
				{
					skillAttributeConfig.m_bModified = true;
					skillAttributeConfig.m_affectType = m_effectSetups.m_extraAttrEffectList[j].m_affectType;
					skillAttributeConfig.m_attrValue = smethod_0(m_effectSetups.m_extraAttrEffectList[j].m_attributeValue, effectType, int_2);
					list.Add(skillAttributeConfig);
					break;
				}
			}
		}
		return list;
	}
	// Token: 0x06003E61 RID: 15969 RVA: 0x001295AC File Offset: 0x001277AC
	public SkillAttributeConfig method_0(int[] int_0, int[] int_1, ItemRarity itemRarity_0, EffectType effectType_0, int int_2)
	{
		for (int i = 0; i < int_0.Length; i++)
		{
			if (int_0[i] == (int)effectType_0)
			{
				for (int j = 0; j < this.m_effectSetups.m_extraAttrEffectList.Length; j++)
				{
					ExtraAttrEffect extraAttrEffect = this.m_effectSetups.m_extraAttrEffectList[j];
					if (extraAttrEffect.m_rarity == itemRarity_0 && extraAttrEffect.m_effect == effectType_0 && (int)extraAttrEffect.m_index == int_1[i])
					{
						return new SkillAttributeConfig(effectType_0)
						{
							m_affectType = extraAttrEffect.m_affectType,
							m_attrValue = ExtraAttributeStore.smethod_0(extraAttrEffect.m_attributeValue, effectType_0, int_2)
						};
					}
				}
			}
		}
		return null;
	}

	// Token: 0x06003E62 RID: 15970 RVA: 0x00129640 File Offset: 0x00127840
	public void method_1(int int_0, XmlNode xmlNode_0, ItemRarity itemRarity_0, int int_1, ref int[] int_2, ref int[] int_3)
	{
		List<EffectType> list = new List<EffectType>();
		if (int_0 > 0)
		{
			int num = 0;
			for (int i = 0; i < int_0; i++)
			{
				string text = "EffectType" + (i + 1);
				if (xmlNode_0.Attributes[text] != null && xmlNode_0.Attributes[text].Value != null)
				{
					EffectType effectType = (EffectType)((int)Enum.Parse(typeof(EffectType), xmlNode_0.Attributes[text].Value));
					int_2[i] = (int)effectType;
					list.Add(effectType);
					num++;
				}
			}
			if (int_0 - num > 0)
			{
				int[] array = this.m_levelEffectSetups.method_0(itemRarity_0, int_1, int_0 - num, list);
				for (int j = 0; j < int_0 - num; j++)
				{
					int_2[j + num] = array[j];
				}
			}
			int_3 = this.m_effectSetups.method_1(itemRarity_0, int_2, int_1);
		}
	}

	// Token: 0x06003E63 RID: 15971 RVA: 0x00129724 File Offset: 0x00127924
	public static void smethod_3(string string_0, ExtraAttributeStore extraAttributeStore_0)
	{
		TextAsset textAsset = ResourcesLoader.smethod_0("Settings/ExtraAttrSlot" + string_0) as TextAsset;
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExtraAttrSlotSetup));
		using (Stream stream = new MemoryStream(textAsset.bytes))
		{
			extraAttributeStore_0.m_slotSetups = (ExtraAttrSlotSetup)xmlSerializer.Deserialize(stream);
			stream.Close();
		}
		Resources.UnloadAsset(textAsset);
		TextAsset textAsset2 = ResourcesLoader.smethod_0("Settings/ExtraAttrLevelEffect" + string_0) as TextAsset;
		XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(ExtraAttrLevelEffectSetup));
		using (Stream stream2 = new MemoryStream(textAsset2.bytes))
		{
			extraAttributeStore_0.m_levelEffectSetups = (ExtraAttrLevelEffectSetup)xmlSerializer2.Deserialize(stream2);
			stream2.Close();
		}
		Resources.UnloadAsset(textAsset2);
		TextAsset textAsset3 = ResourcesLoader.smethod_0("Settings/ExtraAttrEffect" + string_0) as TextAsset;
		XmlSerializer xmlSerializer3 = new XmlSerializer(typeof(ExtraAttrEffectSetup));
		using (Stream stream3 = new MemoryStream(textAsset3.bytes))
		{
			extraAttributeStore_0.m_effectSetups = (ExtraAttrEffectSetup)xmlSerializer3.Deserialize(stream3);
			stream3.Close();
		}
		Resources.UnloadAsset(textAsset3);
		DebugUtils.Log(LogCategory.Framework, "System.GC.Collect");
		GC.Collect();
	}

	// Token: 0x04002BD7 RID: 11223
	public const string AttrSlotAssetPath = "Settings/ExtraAttrSlot";

	// Token: 0x04002BD8 RID: 11224
	public const string AttrLevelEffectAssetPath = "Settings/ExtraAttrLevelEffect";

	// Token: 0x04002BD9 RID: 11225
	public const string AttrEffectAssetPath = "Settings/ExtraAttrEffect";

	// Token: 0x04002BDA RID: 11226
	public ExtraAttrSlotSetup m_slotSetups = new ExtraAttrSlotSetup();

	// Token: 0x04002BDB RID: 11227
	public ExtraAttrLevelEffectSetup m_levelEffectSetups = new ExtraAttrLevelEffectSetup();

	// Token: 0x04002BDC RID: 11228
	public ExtraAttrEffectSetup m_effectSetups = new ExtraAttrEffectSetup();

	// Token: 0x04002BDD RID: 11229
	public int[] m_extraEffect = new int[ItemDNA.m_extraEffectNums];

	// Token: 0x04002BDE RID: 11230
	public int[] m_extraEffectIndex = new int[ItemDNA.m_extraEffectNums];
}
