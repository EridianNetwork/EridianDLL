using System;
using XsdSettings;

// Token: 0x0200056E RID: 1390
public struct DamageInfo
{
	// Token: 0x0400186A RID: 6250
	public AttackSubType m_attackSubType;

	// Token: 0x0400186B RID: 6251
	public AttackInfo.ElementalType m_elementalType;

	// Token: 0x0400186C RID: 6252
	public int m_from;

	// Token: 0x0400186D RID: 6253
	public int m_healthDamagePoints;

	// Token: 0x0400186E RID: 6254
	public int m_shieldDamagePoints;

	// Token: 0x0400186F RID: 6255
	public float m_force;

	// Token: 0x04001870 RID: 6256
	public int m_weakPointIndex;

	// Token: 0x04001871 RID: 6257
	public bool m_isTriggeringDamageOverTime;

	// Token: 0x04001872 RID: 6258
	public bool m_isLethal;
}
