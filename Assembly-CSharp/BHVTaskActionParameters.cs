using System;
using UnityEngine;
using XsdSettings;

// Token: 0x0200015E RID: 350
public sealed class BHVTaskActionParameters
{
	// Token: 0x04000713 RID: 1811
	public int m_targetEntity;

	// Token: 0x04000714 RID: 1812
	public int m_meleeDamageAmount;

	// Token: 0x04000715 RID: 1813
	public int m_areaDamageAmount;

	// Token: 0x04000716 RID: 1814
	public int m_spitDamageAmount;

	// Token: 0x04000717 RID: 1815
	public int m_chargeDamageAmount;

	// Token: 0x04000718 RID: 1816
	public float m_areaDamageRange;

	// Token: 0x04000719 RID: 1817
	public float m_spitDamageRange;

	// Token: 0x0400071A RID: 1818
	public float m_ChargeDamageRange;

	// Token: 0x0400071B RID: 1819
	public AttackSubType m_attackSubType;

	// Token: 0x0400071C RID: 1820
	public Vector3 m_fireDirection;

	// Token: 0x0400071D RID: 1821
	public Vector3 m_spitPosition;

	// Token: 0x0400071E RID: 1822
	public Vector3 m_chargePosition;

	// Token: 0x0400071F RID: 1823
	public Vector3 m_vAreaDamageCenter;

	// Token: 0x04000720 RID: 1824
	public bool m_bIgnoreAngle;
}
