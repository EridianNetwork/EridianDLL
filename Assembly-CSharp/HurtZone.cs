using System;
using UnityEngine;

// Token: 0x02000513 RID: 1299
public class HurtZone : MonoBehaviour
{
	// Token: 0x0400165C RID: 5724
	public AttackInfo.ElementalType m_elementalDamage;

	// Token: 0x0400165D RID: 5725
	public float m_damageRatioPerSecond;

	// Token: 0x0400165E RID: 5726
	public int m_fixedDamagePerSecond;

	// Token: 0x0400165F RID: 5727
	public bool m_hurtPlayer = true;

	// Token: 0x04001660 RID: 5728
	public bool m_hurtNpc;

	// Token: 0x04001661 RID: 5729
	public bool m_hurtBoss;
}
