using System;

// Token: 0x020008E5 RID: 2277
public class SubpartChoice : ICloneable
{
	// Token: 0x06003EC5 RID: 16069 RVA: 0x0002A481 File Offset: 0x00028681
	public object Clone()
	{
		return base.MemberwiseClone();
	}

	// Token: 0x04002C27 RID: 11303
	public int m_subpartIndex;

	// Token: 0x04002C28 RID: 11304
	public float m_probability = 100f;

	// Token: 0x04002C29 RID: 11305
	public ProbabilityModifier m_modifier;
}
