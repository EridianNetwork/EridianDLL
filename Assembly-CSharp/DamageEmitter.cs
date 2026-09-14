using System;
using XsdSettings;

// Token: 0x0200057D RID: 1405
public struct DamageEmitter
{
	// Token: 0x040018C0 RID: 6336
	public int m_owner;

	// Token: 0x040018C1 RID: 6337
	public int m_receiver;

	// Token: 0x040018C2 RID: 6338
	public sbyte m_weakpointIndex;

	// Token: 0x040018C3 RID: 6339
	public AttackInfo.ElementalType m_elementalType;

	// Token: 0x040018C4 RID: 6340
	public AttackSubType m_attackSubType;

	// Token: 0x040018C5 RID: 6341
	public float m_damagePerSecond;

	// Token: 0x040018C6 RID: 6342
	public float m_frequency;

	// Token: 0x040018C7 RID: 6343
	public float m_duration;

	// Token: 0x040018C8 RID: 6344
	public float m_startDate;

	// Token: 0x040018C9 RID: 6345
	public int m_damageApplicationCounter;
}
