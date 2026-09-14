using System;
using XsdSettings;

// Token: 0x02000572 RID: 1394
public struct DamageContext
{
	// Token: 0x0400187F RID: 6271
	public Entity m_killer;

	// Token: 0x04001880 RID: 6272
	public Entity m_victim;

	// Token: 0x04001881 RID: 6273
	public WeakPoint.StrengthType m_strengthType;

	// Token: 0x04001882 RID: 6274
	public AttackSubType m_subType;

	// Token: 0x04001883 RID: 6275
	public DamageInfo m_damageInfo;

	// Token: 0x04001884 RID: 6276
	public bool m_isRemote;
}
