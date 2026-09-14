using System;
using XsdSettings;

// Token: 0x020008CF RID: 2255
public class SkillAttributeConfig
{
	// Token: 0x06003E53 RID: 15955 RVA: 0x0002A12A File Offset: 0x0002832A
	public SkillAttributeConfig(EffectType effectType_0)
	{
		this.m_attrType = effectType_0;
		this.m_attrValue = 0f;
		this.m_affectType = AffectType.PostAdd;
		this.m_bModified = false;
	}

	// Token: 0x04002BD1 RID: 11217
	public AffectType m_affectType;

	// Token: 0x04002BD2 RID: 11218
	public float m_attrValue;

	// Token: 0x04002BD3 RID: 11219
	public EffectType m_attrType;

	// Token: 0x04002BD4 RID: 11220
	public bool m_bModified;
}
