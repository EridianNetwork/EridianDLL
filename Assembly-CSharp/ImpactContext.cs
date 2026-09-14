using System;
using UnityEngine;

// Token: 0x02000579 RID: 1401
public struct ImpactContext
{
	// Token: 0x040018A0 RID: 6304
	public ImpactContext.ImpactType m_impactType;

	// Token: 0x040018A1 RID: 6305
	public float m_resolutionTime;

	// Token: 0x040018A2 RID: 6306
	public GameObject m_affectedObject;

	// Token: 0x040018A3 RID: 6307
	public AttackInfo.ElementalType m_elementalType;

	// Token: 0x040018A4 RID: 6308
	public Vector3 m_position;

	// Token: 0x040018A5 RID: 6309
	public Vector3 m_forward;

	// Token: 0x040018A6 RID: 6310
	public Vector3 m_normal;

	// Token: 0x040018A7 RID: 6311
	public Entity m_victim;

	// Token: 0x040018A8 RID: 6312
	public DamageInfo m_damageInfo;

	// Token: 0x0200057A RID: 1402
	public enum ImpactType
	{
		// Token: 0x040018AA RID: 6314
		Terrain,
		// Token: 0x040018AB RID: 6315
		Entity
	}
}
