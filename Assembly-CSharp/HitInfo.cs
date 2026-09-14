using System;
using UnityEngine;
using XsdSettings;

// Token: 0x0200056D RID: 1389
public class HitInfo : Arbitrator.ArbitrableData
{
	// Token: 0x0400185F RID: 6239
	public int m_from;

	// Token: 0x04001860 RID: 6240
	public int m_to;

	// Token: 0x04001861 RID: 6241
	public int m_owner;

	// Token: 0x04001862 RID: 6242
	public sbyte m_weakPointIndex;

	// Token: 0x04001863 RID: 6243
	public Vector3 m_rayOrigin;

	// Token: 0x04001864 RID: 6244
	public Vector3 m_rayDirection;

	// Token: 0x04001865 RID: 6245
	public float m_distance;

	// Token: 0x04001866 RID: 6246
	public double m_timeStamp;

	// Token: 0x04001867 RID: 6247
	public int m_damagePoint;

	// Token: 0x04001868 RID: 6248
	public AttackSubType m_attackSubType;

	// Token: 0x04001869 RID: 6249
	public AttackInfo.ElementalType m_elementalType;
}
