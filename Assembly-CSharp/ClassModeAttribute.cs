using System;
using System.Collections.Generic;
using XsdSettings;

// Token: 0x020008CB RID: 2251
public class ClassModeAttribute
{
	// Token: 0x06003E42 RID: 15938 RVA: 0x00128B20 File Offset: 0x00126D20
	public ClassModeAttribute()
	{
		this.m_classModeAttributes.Clear();
		foreach (object obj in Enum.GetValues(typeof(EffectType)))
		{
			EffectType effectType = (EffectType)((int)obj);
			this.m_classModeAttributes.Add(new SkillAttributeConfig(effectType));
		}
	}

	// Token: 0x06003E43 RID: 15939 RVA: 0x00128BAC File Offset: 0x00126DAC
	public List<SkillAttributeConfig> method_0()
	{
		List<SkillAttributeConfig> list = new List<SkillAttributeConfig>();
		foreach (object obj in Enum.GetValues(typeof(EffectType)))
		{
			EffectType effectType = (EffectType)((int)obj);
			if (this.m_classModeAttributes[(int)effectType].m_bModified)
			{
				list.Add(this.m_classModeAttributes[(int)effectType]);
			}
		}
		return list;
	}

	// Token: 0x06003E44 RID: 15940 RVA: 0x00128C38 File Offset: 0x00126E38
	public float method_1(EffectType effectType_0, AffectType affectType_0, int int_0)
	{
		if (!this.m_classModeAttributes[(int)effectType_0].m_bModified)
		{
			if (affectType_0 == AffectType.Scale)
			{
				return 1f;
			}
			return 0f;
		}
		else
		{
			if (affectType_0 == AffectType.Scale)
			{
				return this.m_classModeAttributes[(int)effectType_0].m_attrValue + 1f;
			}
			return ExtraAttributeStore.smethod_0(this.m_classModeAttributes[(int)effectType_0].m_attrValue, effectType_0, int_0);
		}
	}

	// Token: 0x04002BCA RID: 11210
	public List<SkillAttributeConfig> m_classModeAttributes = new List<SkillAttributeConfig>();
}
