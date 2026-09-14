using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using XsdSettings;

// Token: 0x020008D9 RID: 2265
public class ClassModeDNA : ICloneable
{
	// Token: 0x06003E84 RID: 16004 RVA: 0x0002A2DF File Offset: 0x000284DF
	public ClassModeDNA()
	{
		this.m_id = 0;
		this.m_cmType = ClassModeType.SoldierDemoMan;
		this.m_adapterIdx = 0;
		this.m_bodyIdx = 0;
		this.m_chassisIdx = 0;
		this.m_drumIdx = 0;
		this.m_materialIdx = 0;
		this.m_level = 0;
	}

	// Token: 0x06003E85 RID: 16005 RVA: 0x00129E48 File Offset: 0x00128048
	public ClassModeDNA(ClassModeDNA classModeDNA_0)
	{
		this.m_id = classModeDNA_0.m_id;
		this.m_cmType = classModeDNA_0.m_cmType;
		this.m_adapterIdx = classModeDNA_0.m_adapterIdx;
		this.m_bodyIdx = classModeDNA_0.m_bodyIdx;
		this.m_chassisIdx = classModeDNA_0.m_chassisIdx;
		this.m_drumIdx = classModeDNA_0.m_drumIdx;
		this.m_materialIdx = classModeDNA_0.m_materialIdx;
		this.m_level = classModeDNA_0.m_level;
	}

	// Token: 0x06003E86 RID: 16006 RVA: 0x00129EBC File Offset: 0x001280BC
	public object Clone()
	{
		return (ClassModeDNA)base.MemberwiseClone();
	}

	// Token: 0x06003E87 RID: 16007 RVA: 0x00129ED8 File Offset: 0x001280D8
	public static ClassModeDNA smethod_0(Hashtable hashtable_0, int int_0)
	{
		ClassModeDNA classModeDNA2;
		try
		{
			if (hashtable_0 == null)
			{
				throw new Exception("data is NULL.");
			}
			ClassModeDNA classModeDNA = new ClassModeDNA();
			classModeDNA.m_level = (int)hashtable_0[1];
			classModeDNA.m_rarity = (ItemRarity)((int)hashtable_0[2]);
			classModeDNA.m_generationSource = (GenerationSource)((int)hashtable_0[3]);
			classModeDNA.m_id = (int)hashtable_0[4];
			classModeDNA.m_name = (string)hashtable_0[int_0 + 1];
			classModeDNA.m_cmType = (ClassModeType)((int)hashtable_0[int_0 + 2]);
			classModeDNA.m_adapterIdx = (int)hashtable_0[int_0 + 3];
			classModeDNA.m_bodyIdx = (int)hashtable_0[int_0 + 4];
			classModeDNA.m_chassisIdx = (int)hashtable_0[int_0 + 5];
			classModeDNA.m_drumIdx = (int)hashtable_0[int_0 + 6];
			classModeDNA.m_materialIdx = (int)hashtable_0[int_0 + 7];
			classModeDNA.method_4();
			classModeDNA2 = classModeDNA;
		}
		catch (Exception ex)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, string.Format("Invalid ClassMode Data: {0}", ex.Message));
			classModeDNA2 = null;
		}
		return classModeDNA2;
	}

	// Token: 0x06003E88 RID: 16008 RVA: 0x0012A048 File Offset: 0x00128248
	public override int GetHashCode()
	{
		return this.m_cmType.ToString().GetHashCode();
	}

	// Token: 0x06003E89 RID: 16009 RVA: 0x0002A31F File Offset: 0x0002851F
	public int method_0()
	{
		return this.m_material + 1;
	}

	// Token: 0x06003E8A RID: 16010 RVA: 0x0012A06C File Offset: 0x0012826C
	public int method_1(ClassModeSubPart classModeSubPart_0)
	{
		switch (classModeSubPart_0)
		{
		case ClassModeSubPart.Adapter:
			return this.m_adapterIdx;
		case ClassModeSubPart.Body:
			return this.m_bodyIdx;
		case ClassModeSubPart.Chassis:
			return this.m_chassisIdx;
		case ClassModeSubPart.Drum:
			return this.m_drumIdx;
		case ClassModeSubPart.Material:
			return this.m_materialIdx;
		default:
			return 0;
		}
	}

	// Token: 0x06003E8B RID: 16011 RVA: 0x0012A0BC File Offset: 0x001282BC
	public List<SkillAttributeConfig> method_2()
	{
		List<SkillAttributeConfig> list = new List<SkillAttributeConfig>();
		foreach (SkillAttributeConfig skillAttributeConfig in this.m_attribute.m_classModeAttributes)
		{
			if (skillAttributeConfig.m_bModified)
			{
				list.Add(skillAttributeConfig);
			}
		}
		return list;
	}

	// Token: 0x06003E8C RID: 16012 RVA: 0x0012A124 File Offset: 0x00128324
	public AvatarType method_3(ClassModeType classModeType_0)
	{
		switch (classModeType_0)
		{
		case ClassModeType.SoldierDemoMan:
		case ClassModeType.SoldierMachinist:
			return AvatarType.SOLDIER;
		case ClassModeType.SirenEnchanter:
		case ClassModeType.SirenSorcerer:
			return AvatarType.SIREN;
		case ClassModeType.BerserkerGuardian:
		case ClassModeType.BerserkerButcher:
			return AvatarType.BERSERKER;
		case ClassModeType.HunterAgent:
		case ClassModeType.HunterMarksman:
			return AvatarType.HUNTER;
		default:
			return AvatarType.TOTAL;
		}
	}

	// Token: 0x06003E8D RID: 16013 RVA: 0x0012A164 File Offset: 0x00128364
	public void method_4()
	{
		if (this.m_attribute == null)
		{
			this.m_attribute = new ClassModeAttribute();
		}
		for (int i = 0; i < 5; i++)
		{
			SubPartClassMode subPartClassMode = SubPartClassModeStore.SubPartClassModeStore_0.method_1(this.m_cmType, (ClassModeSubPart)i, this.method_1((ClassModeSubPart)i));
			if (subPartClassMode != null)
			{
				if (subPartClassMode.m_subpartType == ClassModeSubPart.Material)
				{
					this.m_material = (int)subPartClassMode.m_attributeValue;
				}
				else if (!subPartClassMode.m_attributeValue.AlmostEquals(0f, 0.001f))
				{
					this.method_5(subPartClassMode.m_affectType, subPartClassMode.m_classModeAttribute, subPartClassMode.m_attributeValue);
				}
			}
		}
	}

	// Token: 0x06003E8E RID: 16014 RVA: 0x0012A1F4 File Offset: 0x001283F4
	public void method_5(AffectType affectType_0, EffectType effectType_0, float float_0)
	{
		this.m_attribute.m_classModeAttributes[(int)effectType_0].m_bModified = true;
		switch (affectType_0)
		{
		case AffectType.PrevAdd:
		case AffectType.PostAdd:
			this.m_attribute.m_classModeAttributes[(int)effectType_0].m_attrValue += float_0;
			this.m_attribute.m_classModeAttributes[(int)effectType_0].m_affectType = affectType_0;
			break;
		case AffectType.Scale:
			this.m_attribute.m_classModeAttributes[(int)effectType_0].m_attrValue = float_0;
			this.m_attribute.m_classModeAttributes[(int)effectType_0].m_affectType = affectType_0;
			break;
		}
	}

	// Token: 0x06003E8F RID: 16015 RVA: 0x0002A329 File Offset: 0x00028529
	public string method_6()
	{
		return ItemDNA.smethod_11(this.m_name);
	}

	// Token: 0x06003E90 RID: 16016 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_7()
	{
	}

	// Token: 0x04002BEE RID: 11246
	public int m_id;

	// Token: 0x04002BEF RID: 11247
	public ClassModeType m_cmType;

	// Token: 0x04002BF0 RID: 11248
	public ItemRarity m_rarity;

	// Token: 0x04002BF1 RID: 11249
	public GenerationSource m_generationSource;

	// Token: 0x04002BF2 RID: 11250
	public string m_name;

	// Token: 0x04002BF3 RID: 11251
	public int m_level;

	// Token: 0x04002BF4 RID: 11252
	public int m_adapterIdx;

	// Token: 0x04002BF5 RID: 11253
	public int m_bodyIdx;

	// Token: 0x04002BF6 RID: 11254
	public int m_chassisIdx;

	// Token: 0x04002BF7 RID: 11255
	public int m_drumIdx;

	// Token: 0x04002BF8 RID: 11256
	public int m_materialIdx;

	// Token: 0x04002BF9 RID: 11257
	public ClassModeAttribute m_attribute;

	// Token: 0x04002BFA RID: 11258
	public int m_material;
}
