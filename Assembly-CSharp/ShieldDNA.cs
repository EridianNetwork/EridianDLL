using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020008DA RID: 2266
[Serializable]
public class ShieldDNA : ICloneable, IDNA
{
	// Token: 0x06003E91 RID: 16017 RVA: 0x0012A294 File Offset: 0x00128494
	public ShieldDNA(ShieldDNA shieldDNA_0)
	{
		this.m_id = shieldDNA_0.m_id;
		this.m_generationSource = shieldDNA_0.m_generationSource;
		this.m_level = shieldDNA_0.m_level;
		this.m_shieldManufacturer = shieldDNA_0.m_shieldManufacturer;
		this.m_bodyIdx = shieldDNA_0.m_bodyIdx;
		this.m_batteryIdx = shieldDNA_0.m_batteryIdx;
		this.m_capacitorIdx = shieldDNA_0.m_capacitorIdx;
		this.m_accessoryIdx = shieldDNA_0.m_accessoryIdx;
		this.m_materialIdx = shieldDNA_0.m_materialIdx;
		this.m_name = shieldDNA_0.m_name;
		this.m_rarity = shieldDNA_0.m_rarity;
	}

	// Token: 0x06003E92 RID: 16018 RVA: 0x0012A34C File Offset: 0x0012854C
	public ShieldDNA()
	{
		this.m_id = 0;
		this.m_shieldManufacturer = ItemManufacturer.Vladof;
		this.m_generationSource = GenerationSource.Loot;
		this.m_level = 0;
		this.m_bodyIdx = 0;
		this.m_batteryIdx = 0;
		this.m_capacitorIdx = 0;
		this.m_accessoryIdx = 0;
		this.m_materialIdx = 0;
		this.m_name = string.Empty;
		this.m_rarity = ItemRarity.Common;
		this.m_extraEffectCount = 0;
		for (int i = 0; i < ItemDNA.m_extraEffectNums; i++)
		{
			this.m_extraEffect[i] = 0;
		}
		for (int j = 0; j < ItemDNA.m_extraEffectNums; j++)
		{
			this.m_extraEffectIndex[j] = 0;
		}
	}

	// Token: 0x06003E93 RID: 16019 RVA: 0x0012A40C File Offset: 0x0012860C
	public object Clone()
	{
		return (ShieldDNA)base.MemberwiseClone();
	}

	// Token: 0x06003E94 RID: 16020 RVA: 0x0012A428 File Offset: 0x00128628
	public static ShieldDNA smethod_0(Hashtable hashtable_0, int int_0)
	{
		ShieldDNA shieldDNA2;
		try
		{
			if (hashtable_0 == null)
			{
				throw new Exception("data is NULL.");
			}
			ShieldDNA shieldDNA = new ShieldDNA();
			shieldDNA.m_level = (int)hashtable_0[1];
			shieldDNA.m_rarity = (ItemRarity)((int)hashtable_0[2]);
			shieldDNA.m_generationSource = (GenerationSource)((int)hashtable_0[3]);
			shieldDNA.m_id = (int)hashtable_0[4];
			shieldDNA.m_name = (string)hashtable_0[int_0 + 1];
			shieldDNA.m_shieldManufacturer = (ItemManufacturer)((int)hashtable_0[int_0 + 3]);
			shieldDNA.m_bodyIdx = (int)hashtable_0[int_0 + 4];
			shieldDNA.m_batteryIdx = (int)hashtable_0[int_0 + 5];
			shieldDNA.m_capacitorIdx = (int)hashtable_0[int_0 + 6];
			shieldDNA.m_accessoryIdx = (int)hashtable_0[int_0 + 7];
			shieldDNA.m_materialIdx = (int)hashtable_0[int_0 + 8];
			shieldDNA.method_2();
			shieldDNA2 = shieldDNA;
		}
		catch (Exception ex)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, string.Format("Invalid shield Data: {0}", ex.Message));
			shieldDNA2 = null;
		}
		return shieldDNA2;
	}

	// Token: 0x06003E95 RID: 16021 RVA: 0x0002A336 File Offset: 0x00028536
	public int method_0()
	{
		return this.m_material + 1;
	}

	// Token: 0x06003E96 RID: 16022 RVA: 0x0002A340 File Offset: 0x00028540
	public ItemRarity method_1()
	{
		return this.m_rarity;
	}

	// Token: 0x06003E97 RID: 16023 RVA: 0x0012A598 File Offset: 0x00128798
	public override int GetHashCode()
	{
		return this.m_shieldManufacturer.ToString().GetHashCode();
	}

	// Token: 0x06003E98 RID: 16024 RVA: 0x0012A5BC File Offset: 0x001287BC
	public void method_2()
	{
		if (this.m_attribute == null)
		{
			this.m_attribute = new ShieldAttribute();
		}
		for (int i = 0; i < 5; i++)
		{
			SubPartShield subPartShield = SubPartShieldStore.SubPartShieldStore_0.method_1((ShieldSubPart)i, this.method_5((ShieldSubPart)i));
			if (subPartShield != null)
			{
				this.method_6(subPartShield.m_affectType, subPartShield.m_shieldAttribute, subPartShield.m_attributeValue);
			}
		}
		this.m_material = (int)this.m_attribute.method_0(ShieldAttributeType.Material);
		this.m_shieldManufacturer = (ItemManufacturer)this.m_attribute.m_shieldAttributes[3].m_attrValue;
	}

	// Token: 0x06003E99 RID: 16025 RVA: 0x0002A348 File Offset: 0x00028548
	public string method_3()
	{
		return ItemDNA.smethod_11(this.m_name);
	}

	// Token: 0x06003E9A RID: 16026 RVA: 0x0012A648 File Offset: 0x00128848
	public Dictionary<string, ItemCardDisplayType> imethod_0()
	{
		Dictionary<string, ItemCardDisplayType> dictionary = new Dictionary<string, ItemCardDisplayType>();
		List<SkillAttributeConfig> list = ShieldExtraAttributeStore.ShieldExtraAttributeStore_0.vmethod_0(this.m_extraEffect, this.m_extraEffectIndex, this.method_1(), this.m_level);
		for (int i = 0; i < list.Count; i++)
		{
			StringBuilder stringBuilder = ExtraAttributeStore.smethod_1(list[i]);
			dictionary.Add(stringBuilder.ToString(), ItemCardDisplayType.ExtraSlotWord);
		}
		return dictionary;
	}

	// Token: 0x06003E9B RID: 16027 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_4()
	{
	}

	// Token: 0x06003E9C RID: 16028 RVA: 0x0012A6AC File Offset: 0x001288AC
	public int method_5(ShieldSubPart shieldSubPart_0)
	{
		switch (shieldSubPart_0)
		{
		case ShieldSubPart.Body:
			return this.m_bodyIdx;
		case ShieldSubPart.Battery:
			return this.m_batteryIdx;
		case ShieldSubPart.Capacitor:
			return this.m_capacitorIdx;
		case ShieldSubPart.Accessory:
			return this.m_accessoryIdx;
		case ShieldSubPart.Material:
			return this.m_materialIdx;
		default:
			return 0;
		}
	}

	// Token: 0x06003E9D RID: 16029 RVA: 0x0012A6FC File Offset: 0x001288FC
	public void method_6(AffectType affectType_0, ShieldAttributeType shieldAttributeType_0, float float_0)
	{
		switch (affectType_0)
		{
		case AffectType.PrevAdd:
		case AffectType.PostAdd:
			this.m_attribute.m_shieldAttributes[(int)shieldAttributeType_0].m_attrValue += float_0;
			break;
		case AffectType.Scale:
			this.m_attribute.m_shieldAttributes[(int)shieldAttributeType_0].m_attrValue *= float_0;
			break;
		}
	}

	// Token: 0x06003E9E RID: 16030 RVA: 0x0012A760 File Offset: 0x00128960
	public float method_7(ShieldAttributeType shieldAttributeType_0)
	{
		if (shieldAttributeType_0 == ShieldAttributeType.Capacity)
		{
			float num = this.m_attribute.method_0(shieldAttributeType_0) / ShieldAttributeConfig.s_maxShieldPoint;
			int num2 = MonoSingleton<LevelingManager>.Instance.method_5(AvatarType.SIREN, (this.m_level <= 0) ? 1 : this.m_level);
			return (float)Mathf.FloorToInt(num * (float)num2);
		}
		if (shieldAttributeType_0 == ShieldAttributeType.RechargeDelay)
		{
			return this.m_attribute.method_0(shieldAttributeType_0);
		}
		if (shieldAttributeType_0 == ShieldAttributeType.RechargeRate)
		{
			float num3 = this.m_attribute.method_0(ShieldAttributeType.Capacity) / ShieldAttributeConfig.s_maxShieldPoint;
			int num4 = MonoSingleton<LevelingManager>.Instance.method_5(AvatarType.SIREN, (this.m_level <= 0) ? 1 : this.m_level);
			return (float)num4 * num3 * this.m_attribute.method_0(shieldAttributeType_0);
		}
		return 0f;
	}

	// Token: 0x04002BFB RID: 11259
	public int m_id;

	// Token: 0x04002BFC RID: 11260
	public string m_name;

	// Token: 0x04002BFD RID: 11261
	public ItemRarity m_rarity;

	// Token: 0x04002BFE RID: 11262
	public ItemManufacturer m_shieldManufacturer;

	// Token: 0x04002BFF RID: 11263
	public int m_level;

	// Token: 0x04002C00 RID: 11264
	public int m_bodyIdx;

	// Token: 0x04002C01 RID: 11265
	public int m_batteryIdx;

	// Token: 0x04002C02 RID: 11266
	public int m_capacitorIdx;

	// Token: 0x04002C03 RID: 11267
	public int m_accessoryIdx;

	// Token: 0x04002C04 RID: 11268
	public int m_materialIdx;

	// Token: 0x04002C05 RID: 11269
	public GenerationSource m_generationSource;

	// Token: 0x04002C06 RID: 11270
	public ShieldAttribute m_attribute;

	// Token: 0x04002C07 RID: 11271
	public int m_material;

	// Token: 0x04002C08 RID: 11272
	public int m_extraEffectCount;

	// Token: 0x04002C09 RID: 11273
	public int[] m_extraEffect = new int[ItemDNA.m_extraEffectNums];

	// Token: 0x04002C0A RID: 11274
	public int[] m_extraEffectIndex = new int[ItemDNA.m_extraEffectNums];
}
