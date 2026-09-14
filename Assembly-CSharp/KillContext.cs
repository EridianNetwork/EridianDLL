using System;
using XsdSettings;

// Token: 0x02000571 RID: 1393
public struct KillContext
{
	// Token: 0x04001877 RID: 6263
	public Entity m_killer;

	// Token: 0x04001878 RID: 6264
	public Entity m_victim;

	// Token: 0x04001879 RID: 6265
	public WeakPoint.StrengthType m_strengthType;

	// Token: 0x0400187A RID: 6266
	public WeakPoint.PartInfo m_partInfo;

	// Token: 0x0400187B RID: 6267
	public AttackSubType m_subType;

	// Token: 0x0400187C RID: 6268
	public AttackInfo.ElementalType m_elementalType;

	// Token: 0x0400187D RID: 6269
	public float m_killDistance;

	// Token: 0x0400187E RID: 6270
	public bool m_isRemote;
}
